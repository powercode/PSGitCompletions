using System;
using System.Linq;
using NuGet.Frameworks;
using PowerCode;

namespace GitCompletionTests {
    public class FakeGit {
        private static readonly string[] GetGitAliases = {
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
            " M src/PSGitCompletions/Git.cs",
            " M src/PSGitCompletions/GitCompleter.cs",
            " M src/PSGitCompletions/GitCompletionExtensions.cs",
            " M src/PSGitCompletions/GitCompletionTests/GitCompletionTests.cs",
            "A  src/PSGitCompletions/GitRemoteRef.cs",
            "A  src/PSGitCompletions/GitRemoteUrl.cs",
            "AM src/PSGitCompletions/GitStatusPath.cs",
            " M src/PSGitCompletions/PSGitCompletions.csproj",
            "?? GitTabExpansion.ps1"
        };

        private static readonly string[] GitDiffIndexName = {
            "src/PSGitCompletions/Git.cs",
            "src/PSGitCompletions/GitCompleter.cs",
            "test/PSGitCompletionsTests/GitCompletionTests.cs"
        };

        private static readonly string[] GitDiffName = {
            "src/PSGitCompletions/Git.cs",
            "src/PSGitCompletions/GitCompleter.cs",
            "test/PSGitCompletionsTests/GitCompletionTests.cs"
        };

        private static readonly string[] GetGitLsFiles = {
            ".gitattributes",
            ".gitignore",
            "LICENSE",
            "PSGitCompletions.sln",
            "PSGitCompletions.sln.DotSettings",
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
            "afcff36 adding resharper settings to gitignore",
            "2a9ace8 Adding tests and fixing issues",
            "8e2a3ad Changing completion tests to distinguish between tests where the expected results are just a subset and those where all results are expected.",
            "2117538 Enabling TypeInference use of runtime SafeExprEval for completion",
            "2f74cd0 Moving CurrentTypeDefinitionAst to TypeInferenceContext",
            "48e07bf Replace CompletionExecutionHelper with PowerShellExecutionHelper",
            "6f02a0a Removing the Ast.GetInferredType virtual methods from all ASTs",
            "51253d2 Adding TypeInferenceVisitor with methods transformed from Ast.GetInferredType",
            "06020f3 Fix New-Item to create correct symlink type (#2915) (#3509)",
            "2851f7e Accept `-i` for an interactive shell (#3558)",
            "47ec6b2 Use IntPtr(-1) for INVALID_HANDLE_VALUE instead of IntPtr.Zero (#3544)",
            "4ad4b19 Convert tab indentations to spaces in *.cs files (#3551)",
            "acec58c Make the output of $PSVersionTable in alphabetical order (#3530)",
            "f0c0176 Typo in Format-Hex (#3539)",
            "3516872 Use /bin/bash, fixes #3525",
            "8d4db01 Add sudo for adding cert for OpenSUSE (#3524)",
            "68bcd4b Removed trailing whitespace (#3485)",
            "18c28f8 Fix markdown lint issues for SSH Remoting demo and enable related tests (#3484)",
            "4697dd2 Adding public ValidRootDrives property to ValidateDrive (#3510)",
            "753b196 Fix crash at startup when env:HOME not set (#3437)"
        };


        private static readonly string[] GitRemoteurl =
        {
            "origin	https://github.com/powercode/PowerShell (fetch)",
            "origin	https://github.com/powercode/PowerShell (push)",
            "upstream	https://github.com/powershell/PowerShell (fetch)",
            "upstream	https://github.com/powershell/PowerShell (push)"
        };

        private static readonly string[] GetGitRefs = {
             "afcff36\0commit\0ext-method\0adding resharper settings to gitignore",
             "2a9ace8\0commit\0foreach-member-typeinference\0Adding tests and fixing issues",
             "8e2a3ad\0commit\0master\0Moving CurrentTypeDefinitionAst to TypeInferenceContext",
             "2117538\0commit\0native-arg-hyphen\0Typo in Format-Hex (#3539)",
             "2f74cd0\0commit\0overload-err\0Removing the Ast.GetInferredType virtual methods from all ASTs",
             "48e07bf\0commit\0process-completion\0Use /bin/bash, fixes #3525",
             "6f02a0a\0commit\0psmethod-func\0Fix crash at startup when env:HOME not set (#3437)",
             "51253d2\0commit\0typeinference-visitor\0Adding public ValidRootDrives property to ValidateDrive (#3510)",
             "06020f3\0commit\0updatehelp-progress\0Add sudo for adding cert for OpenSUSE (#3524)",
             "2851f7e\0commit\0vs2017-build\0Enabling TypeInference use of runtime SafeExprEval for completion",
             "47ec6b2\0commit\0SD/688741\0Accept `-i` for an interactive shell (#3558)",
             "4ad4b19\0commit\0SD/692351\0Use IntPtr(-1) for INVALID_HANDLE_VALUE instead of IntPtr.Zero (#3544)",
             "acec58c\0commit\0SD/693793\0Convert tab indentations to spaces in *.cs files (#3551)",
             "f0c0176\0tag\0v0.1.0\0adding resharper settings to gitignore",
             "3516872\0tag\0v0.2.0\0Moving CurrentTypeDefinitionAst to TypeInferenceContext",
             "8d4db01\0tag\0v6.0.0-alpha.18\0Typo in Format-Hex (#3539)",
             "68bcd4b\0tag\0v6.0.0-alpha.7\0Enabling TypeInference use of runtime SafeExprEval for completion",
        };

        private static readonly string[] GetBranchDescriptions = {
            "branch.master.description",
            "Main branch",
            "This is the branch that releases are made from\0",
            "branch.other.description",
            "Some other branch",
            "\0branch.newline.description",
            "Some desc ending in newline branch\0",
        };

        public static  string[] Execute(string command) {
            return command switch {
                "git for-each-ref '--format=%(refname:strip=2)' 'refs/heads/*' 'refs/heads/*/**'" => GitHeads,
                "git for-each-ref '--format=%(refname:strip=2)' 'refs/tags/*' 'refs/tags/*/**'" => GitTags,
                "git status --porcelain" => GitStatus,
                "git for-each-ref '--format=%(objectname) %(refname)' refs/remotes/*/*" => GitRemoteRefs,
                "git remote -v" => GitRemoteurl,
                "git diff-index --name-only --relative HEAD" => GitDiffIndexName,
                "git diff --name-only   -- *" => GitDiffName,
                "git log --oneline -50 " => GetGitLog,
                "git ls-files -- " => GetGitLsFiles,
                "git config --get-regex ^alias\\." => GetGitAliases,
                "git config --get-regex ^alias\\.ad" => Array.Empty<string>(),
                "git for-each-ref '--format=%(objectname:short=7)%00%(objecttype)%00%(refname:lstrip=2)%00%(subject)' 'refs/*/*'" => GetGitRefs,
                @"git config --local --null --get-regex branch\..+?\.description" => GetBranchDescriptions,
                _ => throw new ArgumentException(command)
            };
        }

        public static FakeGitScope GetScope() => new FakeGitScope();

        public class FakeGitScope : IDisposable {
            private GitExecuterScope _scope;

            public FakeGitScope() {
                _scope = new GitExecuterScope(Git.GitExecuter);
                Git.GitExecuter = Execute;
            }

            public void Dispose() {
                _scope.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }


}