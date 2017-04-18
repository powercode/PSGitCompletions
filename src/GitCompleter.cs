using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;

namespace PowerCode {
    public class GitCompleter : IModuleAssemblyInitializer {
        public void OnImport() {
            using (var ps = PowerShell.Create(RunspaceMode.CurrentRunspace)) {
                ps.AddCommand("Register-ArgumentCompleter")
                    .AddParameter("-Native", true)
                    .AddParameter("CommandName", "git")
                    .AddParameter("ScriptBlock",
                        ScriptBlock.Create(
                            "param($wordToComplete, $ast, $cursorPosition) [PowerCode.GitCompleter]::CompleteInput($wordToComplete, $ast, $cursorPosition)"));
                ps.Invoke();
            }
        }

        public static IList<CompletionResult> CompleteInput(string wordToComplete, CommandAst ast, int cursorPosition) {
            var elementCount = ast.CommandElements.Count;
            var prevIndex = elementCount - (string.IsNullOrEmpty(wordToComplete) ? 1 : 2);
            string previosParameterName = null;
            string previousParameterValue = null;
            var doubleDash = ast.CommandElements.FirstOrDefault(c => c.Extent.Text == "--");
            var afterDoubleDash = doubleDash != null && doubleDash.Extent.EndColumnNumber < cursorPosition;
            if (prevIndex < elementCount)
                switch (ast.CommandElements[prevIndex]) {
                    case CommandParameterAst p:
                        previosParameterName = p.Extent.Text;
                        break;
                    case StringConstantExpressionAst s:
                        previousParameterValue = s.Value;
                        break;
                }

            if (previousParameterValue.IsGitCommand())
                return CompleteGitCommands(wordToComplete);
            var commandName = ast.CommandElements[1].Extent.Text;
            var gitCommand = GitCommand.GetOptions(commandName);
            if (gitCommand != null)
                return CompleteGitCommand(commandName, gitCommand, previosParameterName, previousParameterValue,
                    wordToComplete, afterDoubleDash);

            return null;
        }

        private static IList<CompletionResult> CompleteGitCommand(string commandName,
            GitCommandOption[] gitCommandOptions, string previosParameterName, string previousParameterValue,
            string wordToComplete, bool afterDoubleDash) {
            switch (commandName) {
                case "add":
                    if (!wordToComplete.StartsWith("-")) {
                        return CompleteFiles(wordToComplete);
                    }
                    goto default;
                case "branch":
                    if (!wordToComplete.StartsWith("-"))
                        return CompleteBranches(wordToComplete);
                    goto default;
                case "checkout":
                    if (string.IsNullOrEmpty(previosParameterName) && !wordToComplete.StartsWith("-"))
                        return CompleteBranches(wordToComplete);
                    goto default;
                case "fetch":
                    if (!wordToComplete.StartsWith("-")) {
                        if (!string.IsNullOrEmpty(previousParameterValue) && previousParameterValue != commandName)
                            return Git.RemoteRefs()
                                .Where(r => r.Remote.IgnoreCaseEquals(previousParameterValue) &&
                                            r.Ref.IgnoreCaseStartsWith(wordToComplete))
                                .Select(c => new CompletionResult(c.Ref, c.Ref, CompletionResultType.ParameterValue,
                                    c.RemoteRef))
                                .ToList();
                        return Git.RemoteRefs()
                            .Where(r => r.Remote.IgnoreCaseStartsWith(wordToComplete))
                            .GroupBy(c => c.Remote)
                            .Select(g => g.First())
                            .Select(c => new CompletionResult(c.Remote, c.Remote, CompletionResultType.ParameterValue,
                                c.Remote))
                            .ToList();
                    }
                    goto default;
                case "diff":
                case "rebase":
                    if (wordToComplete.IsEmpty())
                        return Git.Log()
                            .Select(log => new CompletionResult(log.Commit, log.Commit,
                                CompletionResultType.ParameterValue, log.Message))
                            .ToList();
                    else if (!wordToComplete.StartsWith("-"))
                        return Git.Log()
                            .Where(l => l.Commit.IgnoreCaseStartsWith(wordToComplete) ||
                                        l.Message.IgnoreCaseStartsWith(wordToComplete))
                            .Select(log => new CompletionResult(log.Commit, log.Commit,
                                CompletionResultType.ParameterValue, log.Message))
                            .ToList();
                    goto default;
                default:
                    return GitOptionsToCompletionResults(gitCommandOptions, wordToComplete);
            }
        }

        private static IList<CompletionResult> CompleteFiles(string wordToComplete) {
            throw new System.NotImplementedException();
        }

        private static IList<CompletionResult> CompleteBranches(string wordToComplete) {
            return Git.Heads(wordToComplete)
                .Select(c => new CompletionResult(c, c, CompletionResultType.ParameterValue, c))
                .ToList();
        }

        private static List<CompletionResult> GitOptionsToCompletionResults(GitCommandOption[] gitCommandOptions,
            string wordToComplete) {
            return gitCommandOptions.Where(option => option.Completion.StartsWith(wordToComplete))
                .Select(o => o.ToCompletionResult())
                .ToList();
        }

        private static IList<CompletionResult> CompleteGitCommands(string wordToComplete) {
            return GitCommand.Commands.Where(c => c.Name.IgnoreCaseStartsWith(wordToComplete))
                .Select(c => c.ToCompletionResult())
                .ToList();
        }
    }

    public struct GitRef {
        public string Commit;
        public string Name;

        public GitRef(string commit, string name) {
            Commit = commit;
            Name = name;
        }
    }
}