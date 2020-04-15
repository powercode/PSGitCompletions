using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;

namespace PowerCode
{
    public class GitCompleter : IModuleAssemblyInitializer
    {
        public void OnImport()
        {
            using var ps = PowerShell.Create(runspace: RunspaceMode.CurrentRunspace);
            ps.AddCommand("Register-ArgumentCompleter")
                .AddParameter("-Native", true)
                .AddParameter("CommandName", "git")
                .AddParameter("ScriptBlock",
                    ScriptBlock.Create("param($wordToComplete, $ast, $cursorPosition) [PowerCode.GitCompleter]::CompleteInput($wordToComplete, $ast, $cursorPosition)"));
            ps.Invoke();
        }

        public static IList<CompletionResult> CompleteInput(string wordToComplete, CommandAst ast, int cursorPosition)
        {
            var elementCount = ast.CommandElements.Count;
            var prevIndex = elementCount - (string.IsNullOrEmpty(value: wordToComplete) ? 1 : 2);
            string? previousParameterName = null;
            string? previousParameterValue = null;
            var doubleDash = ast.CommandElements.FirstOrDefault(c => c.Extent.Text == "--");
            var afterDoubleDash = doubleDash != null && doubleDash.Extent.EndColumnNumber < cursorPosition;
            if (prevIndex < elementCount)
                switch (ast.CommandElements[index: prevIndex])
                {
                    case CommandParameterAst p:
                        previousParameterName = p.Extent.Text;
                        break;
                    case StringConstantExpressionAst s:
                        previousParameterValue = s.Value;
                        break;
                }

            if (previousParameterValue.IsGitCommand()) return CompleteGitCommands(wordToComplete: wordToComplete);
            var commandName = ast.CommandElements[1].Extent.Text;
            var gitCommand = GitCommand.GetOptions(name: commandName);
            return CompleteGitCommand(commandName: commandName, gitCommandOptions: gitCommand, previousParameterName: previousParameterName, previousParameterValue: previousParameterValue,
                wordToComplete: wordToComplete, afterDoubleDash: afterDoubleDash);
        }

        private static IList<CompletionResult> CompleteGitCommand(string commandName, GitCommandOption[] gitCommandOptions, string? previousParameterName, string? previousParameterValue,
            string wordToComplete, bool afterDoubleDash)
        {
            switch (commandName)
            {
                case "branch":
                    if (!wordToComplete.StartsWith("-")) return CompleteBranches(wordToComplete: wordToComplete);
                    goto default;
                case "checkout":
                    if (string.IsNullOrEmpty(value: previousParameterName) && !wordToComplete.StartsWith("-")) return CompleteBranches(wordToComplete: wordToComplete);
                    goto default;
                case "fetch":
                    if (!wordToComplete.StartsWith("-"))
                    {
                        if (!string.IsNullOrEmpty(value: previousParameterValue) && previousParameterValue != commandName)
                            return Git.RemoteRefs()
                                .Where(r => r.Remote.IgnoreCaseEquals(value: previousParameterValue) && r.Ref.IgnoreCaseStartsWith(value: wordToComplete))
                                .Select(c => new CompletionResult(completionText: c.Ref, listItemText: c.Ref, resultType: CompletionResultType.ParameterValue,
                                    toolTip: c.RemoteRef))
                                .ToList();
                        return Git.RemoteRefs()
                            .Where(r => r.Remote.IgnoreCaseStartsWith(value: wordToComplete))
                            .GroupBy(c => c.Remote)
                            .Select(g => g.First())
                            .Select(c => new CompletionResult(completionText: c.Remote, listItemText: c.Remote, resultType: CompletionResultType.ParameterValue, toolTip: c.Remote))
                            .ToList();
                    }

                    goto default;
                case "diff":
                case "rebase":
                    if (wordToComplete.IsEmpty())
                        return Git.Log()
                            .Select(log => new CompletionResult(completionText: log.Commit, listItemText: log.Commit, resultType: CompletionResultType.ParameterValue, toolTip: log.Message))
                            .ToList();
                    else if (!wordToComplete.StartsWith("-"))
                        return Git.Log()
                            .Where(l => l.Commit.IgnoreCaseStartsWith(value: wordToComplete) || l.Message.IgnoreCaseStartsWith(value: wordToComplete))
                            .Select(log => new CompletionResult(completionText: log.Commit, listItemText: log.Commit, resultType: CompletionResultType.ParameterValue, toolTip: log.Message))
                            .ToList();
                    goto default;
                default:
                    return GitOptionsToCompletionResults(gitCommandOptions: gitCommandOptions, wordToComplete: wordToComplete);
            }
        }

        private static IList<CompletionResult> CompleteBranches(string wordToComplete)
        {
            return Git.Heads(match: wordToComplete)
                .Select(c => new CompletionResult(completionText: c, listItemText: c, resultType: CompletionResultType.ParameterValue, toolTip: c))
                .ToList();
        }

        private static List<CompletionResult> GitOptionsToCompletionResults(GitCommandOption[] gitCommandOptions, string wordToComplete)
        {
            return gitCommandOptions.Where(option => option.Completion.StartsWith(value: wordToComplete))
                .Select(o => o.ToCompletionResult())
                .ToList();
        }

        private static IList<CompletionResult> CompleteGitCommands(string wordToComplete)
        {
            return GitCommand.Commands.Where(c => c.Name.IgnoreCaseStartsWith(value: wordToComplete))
                .Select(c => c.ToCompletionResult())
                .ToList();
        }
    }

    public struct GitRef
    {
        public string Commit { get; }
        public string Name { get; }

        public GitRef(string commit, string name)
        {
            Commit = commit;
            Name = name;
        }
    }
}