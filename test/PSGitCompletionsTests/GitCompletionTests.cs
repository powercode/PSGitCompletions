using System;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Runtime.ExceptionServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerCode;

namespace GitCompletionTests
{
    [TestClass]
    public class GitCompletionTests
    {
        [TestMethod]
        public void CanCompleteGitCommands()
        {
            var res = "git ".CompleteInput();
            Assert.AreEqual("add", res[0].CompletionText);
            var diff = res.FirstOrDefault(c => c.CompletionText == "diff");
            Assert.IsNotNull(diff);
        }

        [TestMethod]
        public void CanCompleteGitCommandPart()
        {
            var res = "git ad".CompleteInput();
            Assert.AreEqual("add", res[0].CompletionText);
        }


        [TestMethod]
        public void CanCompleteGitCommandOptions()
        {
            using (new GitExecuterScope(Git.GitExecuter)) {
                Git.GitExecuter = FakeGit;
                var res = "git add -".CompleteInput();
                Assert.AreEqual("--", res[0].CompletionText);
                Assert.AreEqual("-A", res[1].CompletionText);
                Assert.AreEqual("--all", res[2].CompletionText);
            }
        }


        [DataTestMethod]
        [DataRow("git add ", "src/PSGitCompletions/Git.cs")]
        [DataRow("git add -", "--")]
        public void CanCompleteAddFiles(string command, string firstResult)
        {
            using (new GitExecuterScope(Git.GitExecuter))
            {
                Git.GitExecuter = FakeGit;
                var res = command.CompleteInput();
                Assert.AreEqual(firstResult, res[0].CompletionText);
            }
        }

        [TestMethod]
        public void CanCompleteGitDiffCommits()
        {
            using (new GitExecuterScope(Git.GitExecuter))
            {
                Git.GitExecuter = FakeGit;
                var res = "git diff ".CompleteInput();
                Assert.AreEqual("afcff36f", res[0].CompletionText);
                Assert.AreEqual("adding resharper settings to gitignore", res[0].ToolTip);
            }
        }

        [TestMethod]
        public void CanCompleteGitDiffFiles()
        {
            using (new GitExecuterScope(Git.GitExecuter))
            {
                Git.GitExecuter = FakeGit;
                var res = "git diff -- ".CompleteInput();
                Assert.AreEqual(".gitattributes", res[0].CompletionText);
            }
        }

        [TestMethod]
        public void CanCompleteFetchOriginRef()
        {
            using (new GitExecuterScope(Git.GitExecuter))
            {
                Git.GitExecuter = FakeGit;
                var completions = "git fetch origin ".CompleteInput();
                Assert.AreEqual(2, completions.Count);
                Assert.AreEqual("origin", completions[0].CompletionText);
            }
        }

        [DataTestMethod]
        [DataRow("git checkout -- ", "src/PSGitCompletions/Git.cs", 3)]
        [DataRow("git checkout ", "ext-method", 10)]
        public void CanCompleteCheckoutFiles(string command, string firstResult, int resultCount)
        {
            using (new GitExecuterScope(Git.GitExecuter))
            {
                Git.GitExecuter = FakeGit;
                var completions = command.CompleteInput();
                Assert.AreEqual(resultCount, completions.Count);
                Assert.AreEqual(firstResult, completions[0].CompletionText);
            }
        }

        [TestMethod]
        public void CanCompleteGetGitFetchRemote()
        {
            using (new GitExecuterScope(Git.GitExecuter))
            {
                Git.GitExecuter = FakeGit;
                var completions = "git fetch ".CompleteInput();
                Assert.AreEqual(2, completions.Count);
                Assert.AreEqual("upstream", completions[1].CompletionText);

            }
        }

        [TestMethod]
        public void CanGetGitRemoteUrls()
        {
            using (new GitExecuterScope(Git.GitExecuter))
            {
                Git.GitExecuter = FakeGit;
                var remoteRefs = Git.Remotes().ToArray();
                Assert.AreEqual("origin", remoteRefs[0].Name);
                Assert.AreEqual("https://github.com/powershell/PowerShell (fetch)", remoteRefs[1].FetchUrl);
                Assert.AreEqual("https://github.com/powershell/PowerShell (fetch)", remoteRefs[1].FetchUrl);
            }
        }

        [DataTestMethod]
        [DataRow("git diff ", "afcff36f")]
        [DataRow("git -P ", "add")]
        [DataRow("git ", "add")]
        [DataRow("git add ", "src/PSGitCompletions/Git.cs")]
        [DataRow("git add -", "--")]
        [DataRow("git add -A ", "src/PSGitCompletions/Git.cs")]
        [DataRow("git add -- ", "src/PSGitCompletions/Git.cs")]
        [DataRow("git -P add ", "src/PSGitCompletions/Git.cs")]
        [DataRow("git -P ad", "add")]
        public void TestPSTabExpansion(string command, string firstMatch) {
            using var gitExecuterScope = new GitExecuterScope(Git.GitExecuter);
            Git.GitExecuter = FakeGit;
            InitialSessionState iss = InitialSessionState.CreateDefault();
            var codeBaseUrl = new Uri(typeof(Git).Assembly.Location);
            var codeBasePath = Uri.UnescapeDataString(codeBaseUrl.AbsolutePath);
            iss.ImportPSModule(new []{codeBasePath});
            //iss.Commands.Add(new SessionStateFunctionEntry("TabExpansion2", TabExpansionFunction));
            using var ps = PowerShell.Create(iss);
            Assert.IsFalse(ps.HadErrors, string.Join(Environment.NewLine, ps.Streams.Error.ReadAll().Select(e=>e.Exception.Message)));

            ps.AddScript($"Import-Module {codeBasePath}", true).Invoke();
            Assert.IsFalse(ps.HadErrors, string.Join(Environment.NewLine, ps.Streams.Error.ReadAll().Select(e => e.Exception.Message)));

            ps.AddScript($"TabExpansion2 -inputScript '{command}' -cursorColumn {command.Length}");

            var res = (CommandCompletion)(ps.Invoke()[0].BaseObject);
            Assert.IsFalse(ps.HadErrors, string.Join(Environment.NewLine, ps.Streams.Error.ReadAll().Select(e => e.Exception.Message)));
            Assert.IsTrue(res.CompletionMatches.Count > 0);
            Assert.AreEqual(firstMatch, res.CompletionMatches[0].CompletionText);
        }

        string[] FakeGit(string command) {
            return command switch {
                "git for-each-ref '--format=%(refname:strip=2)' 'refs/heads/*' 'refs/heads/*/**'" => GitHeads,
                "git for-each-ref '--format=%(refname:strip=2)' 'refs/tags/*' 'refs/tags/*/**'" => GitTags,
                "git status --porcelain" => GitStatus,
                "git for-each-ref '--format=%(objectname) %(refname)' refs/remotes/*/*" => GitRemoteRefs,
                "git remote -v" => GitRemoteurl,
                "git diff-index --name-only --relative HEAD" => GitDiffIndexName,
                "git log --oneline -50" => GetGitLog,
                "git ls-files -- " => GetGitLsFiles,
                _ => throw new ArgumentException(command)
            };
        }

        private static readonly string[] GitHeads= {
                "ext-method",
                "foreach-member-typeinference",
                "master",
                "native-arg-hyphen",
                "overload-err",
                "process-completion",
                "psmethod-func",
                "typeinference-visitor",
                "updatehelp-progress",
                "vs2017-build"
            };

        private static readonly string[] GitTags = {
            "SD/688741",
            "SD/692351",
            "SD/693793",
            "v0.1.0",
            "v0.2.0",
            "v6.0.0-alpha.18",
            "v6.0.0-alpha.7"
        };

        private static readonly string[] GitStatus = {
                " M Git.cs",
                " M GitCompleter.cs",
                " M GitCompletionExtensions.cs",
                " M GitCompletionTests/GitCompletionTests.cs",
                "A  GitRemoteRef.cs",
                "A  GitRemoteUrl.cs",
                "AM GitStatusPath.cs",
                " M PSGitCompletions.csproj",
                "?? GitTabExpansion.ps1"
        };


        private static readonly string[] GitDiffIndexName = {
            "src/PSGitCompletions/Git.cs",
            "src/PSGitCompletions/GitCompleter.cs",
            "test/PSGitCompletionsTests/GitCompletionTests.cs"
        };

        private static readonly string[] GetGitLsFiles = {
            ".gitattributes",
            ".gitignore",
            "Git.cs",
            "GitCommand.cs",
            "GitCompleter.cs",
            "GitCompletionExtensions.cs",
            "GitRemoteRef.cs",
            "GitRemoteUrl.cs",
            "GitStatusPath.cs",
            "LICENSE",
            "PSGitCompletions.csproj",
            "PSGitCompletions.sln",
            "PSGitCompletions.sln.DotSettings",
            "Properties/AssemblyInfo.cs",
            "README.md",
            "packages.config",
            "src/PSGitCompletions/CompleteCommandParameters.cs",
            "src/PSGitCompletions/Git.cs",
            "src/PSGitCompletions/GitCommand.cs",
            "src/PSGitCompletions/GitCommandOption.cs",
            "src/PSGitCompletions/GitCompleter.cs",
            "src/PSGitCompletions/GitCompletionExtensions.cs",
            "src/PSGitCompletions/GitLog.cs",
            "src/PSGitCompletions/PSGitCompletions.csproj",
            "test/PSGitCompletionsTests/CompletionTestExtensions.cs",
            "test/PSGitCompletionsTests/CreateCompletionInfoTests.cs",
            "test/PSGitCompletionsTests/GitCompletionTests.cs",
            "test/PSGitCompletionsTests/PSGitCompletionsTests.csproj"
        };

        private static readonly string[] GitRemoteRefs = {
            "f807df7d865824da7db794f311263c0bc917845f refs/remotes/origin/HEAD",
            "fea270412167ad3e4e5a5297642dcb7d5f9c51ee refs/remotes/origin/ext-method",
            "80e5b9a832c1ef076b5d2c4ee0bb39bb6d19698a refs/remotes/origin/foreach-member-typeinference",
            "f807df7d865824da7db794f311263c0bc917845f refs/remotes/origin/master",
            "2727ca94c20de706d33168cd092a22caddc6940c refs/remotes/origin/native-arg-hyphen",
            "118b0abaf9fc4fffe984e6e2c78a3cceab0d3012 refs/remotes/origin/process-completion",
            "f72ccceb0ceb631632090e86f3ed8075f092df53 refs/remotes/origin/typeinference-visitor",
            "98e95cfb24ee6fccf299cdfc4fdeb0debe92abde refs/remotes/origin/vs2017-build",
            "1f561e626ece3b370e12cdca7456ac3a25bd6d6e refs/remotes/upstream/doc-update",
            "08e855556cff42274a5903799b826e78d0cebd3f refs/remotes/upstream/master",
            "c748652c34c3e208fad4d9b8abcf061b7f371c83 refs/remotes/upstream/source-depot"
        };

        private static readonly string[] GetGitLog = {
            "afcff36f adding resharper settings to gitignore",
            "2a9ace83 Adding tests and fixing issues",
            "8e2a3ad3 Changing completion tests to distinguish between tests where the expected results are just a subset and those where all results are expected.",
            "21175387 Enabling TypeInference use of runtime SafeExprEval for completion",
            "2f74cd0a Moving CurrentTypeDefinitionAst to TypeInferenceContext",
            "48e07bf6 Replace CompletionExecutionHelper with PowerShellExecutionHelper",
            "6f02a0aa Removing the Ast.GetInferredType virtual methods from all ASTs",
            "51253d25 Adding TypeInferenceVisitor with methods transformed from Ast.GetInferredType",
            "06020f34 Fix New-Item to create correct symlink type (#2915) (#3509)",
            "2851f7e8 Accept `-i` for an interactive shell (#3558)",
            "47ec6b2a Use IntPtr(-1) for INVALID_HANDLE_VALUE instead of IntPtr.Zero (#3544)",
            "4ad4b194 Convert tab indentations to spaces in *.cs files (#3551)",
            "acec58c0 Make the output of $PSVersionTable in alphabetical order (#3530)",
            "f0c0176a Typo in Format-Hex (#3539)",
            "35168721 Use /bin/bash, fixes #3525",
            "8d4db01a Add sudo for adding cert for OpenSUSE (#3524)",
            "68bcd4b5 Removed trailing whitespace (#3485)",
            "18c28f8f Fix markdown lint issues for SSH Remoting demo and enable related tests (#3484)",
            "4697dd2b Adding public ValidRootDrives property to ValidateDrive (#3510)",
            "753b1965 Fix crash at startup when env:HOME not set (#3437)"
        };

        private static readonly string[] GetGitAlias = {
            "alias.dt difftool",
            "alias.mt mergetool",
            "alias.f fetch",
            "alias.cdiff diff --compact-summary",
            "alias.fo fetch origin",
            "alias.fu fetch upstream",
            "alias.l log --oneline",
            "alias.lg log --oneline --graph --decorate",
            "alias.s status",
            "alias.sb status -s -b",
            "alias.fdiff difftool --dir-diff --tool=bc --no-prompt"
        };

        private static readonly string[] GitRemoteurl =
        {
            "origin	https://github.com/powercode/PowerShell (fetch)",
            "origin	https://github.com/powercode/PowerShell (push)",
            "upstream	https://github.com/powershell/PowerShell (fetch)",
            "upstream	https://github.com/powershell/PowerShell (push)"
        };

        const string TabExpansionFunction= @"
function TabExpansion2 {
[CmdletBinding(DefaultParameterSetName = 'ScriptInputSet')]
Param(
    [Parameter(ParameterSetName = 'ScriptInputSet', Mandatory = $true, Position = 0)]
    [string] $inputScript,

    [Parameter(ParameterSetName = 'ScriptInputSet', Mandatory = $true, Position = 1)]
    [int] $cursorColumn,

    $options
)

End
{
    return [System.Management.Automation.CommandCompletion]::CompleteInput(<#inputScript#>  $inputScript, <#cursorColumn#> $cursorColumn, <#options#>      $options)
}
}";
    }
}