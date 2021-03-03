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
            using var scope = FakeGit.GetScope();
            var res = "git ".CompleteInput();
            Assert.AreEqual("add", res[0].CompletionText);
            var diff = res.FirstOrDefault(c => c.CompletionText == "diff");
            Assert.IsNotNull(diff);
        }

        [TestMethod]
        public void CanCompleteGitCommandPart()
        {
            using var scope = FakeGit.GetScope();
            var res = "git ad".CompleteInput();
            Assert.AreEqual("add", res[0].CompletionText);
        }


        [TestMethod]
        public void CanCompleteGitCommandOptions()
        {
            using var scope = FakeGit.GetScope();
            var res = "git add -".CompleteInput();
            Assert.AreEqual("--", res[0].CompletionText);
            Assert.AreEqual("-A", res[1].CompletionText);
            Assert.AreEqual("--all", res[2].CompletionText);
        }


        [DataTestMethod]
        [DataRow("git add ", "src/PSGitCompletions/Git.cs")]
        [DataRow("git add -", "--")]
        public void CanCompleteAddFiles(string command, string firstResult) {
            using var scope = FakeGit.GetScope();

            var res = command.CompleteInput();
            Assert.AreEqual(firstResult, res[0].CompletionText);

        }

        [DataTestMethod]
        [DataRow("git bisect ", "start")]
        [DataRow("git bisect g", "good")]
        public void CanCompleteBisect(string command, string firstResult)
        {
            using var scope = FakeGit.GetScope();
            var res = command.CompleteInput();
            Assert.AreEqual(firstResult, res[0].CompletionText);

        }

        [TestMethod]
        public void CanCompleteGitDiffCommits()
        {
            using var scope = FakeGit.GetScope();
            var res = "git diff ".CompleteInput();
            Assert.AreEqual("afcff36f", res[0].CompletionText);
            Assert.AreEqual("adding resharper settings to gitignore", res[0].ToolTip);
        }

        [TestMethod]
        public void CanCompleteGitDiffFiles()
        {
            using var scope = FakeGit.GetScope();
            var res = "git diff -- ".CompleteInput();
            Assert.AreEqual("src/PSGitCompletions/Git.cs", res[0].CompletionText);
        }

        [TestMethod]
        public void CanCompleteFetchOriginRef() {
            using var scope = FakeGit.GetScope();

            var completions = "git fetch origin ".CompleteInput();
            Assert.AreEqual(2, completions.Count);
            Assert.AreEqual("origin", completions[0].CompletionText);
        }

        [DataTestMethod]
        [DataRow("git checkout -- ", "src/PSGitCompletions/Git.cs", 7)]
        [DataRow("git checkout ", "ext-method", 30)]
        public void CanCompleteCheckoutFiles(string command, string firstResult, int resultCount)
        {
            using var scope = FakeGit.GetScope();

            var completions = command.CompleteInput();
            Assert.AreEqual(resultCount, completions.Count);
            Assert.AreEqual(firstResult, completions[0].CompletionText);

        }

        [TestMethod]
        public void CanCompleteGetGitFetchRemote()
        {
            using var scope = FakeGit.GetScope();

            var completions = "git fetch ".CompleteInput();
            Assert.AreEqual(2, completions.Count);
            Assert.AreEqual("upstream", completions[1].CompletionText);

        }

        [TestMethod]
        public void CanGetGitRemoteUrls()
        {
            using var scope = FakeGit.GetScope();

            var remoteRefs = Git.Remotes().ToArray();
            Assert.AreEqual("origin", remoteRefs[0].Name);
            Assert.AreEqual("https://github.com/powershell/PowerShell (fetch)", remoteRefs[1].FetchUrl);
            Assert.AreEqual("https://github.com/powershell/PowerShell (fetch)", remoteRefs[1].FetchUrl);

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
            using var scope = FakeGit.GetScope();

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