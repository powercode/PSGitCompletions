using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;

namespace PowerCode
{
    public class GitCompleter : IModuleAssemblyInitializer
    {
        public static IList<CompletionResult> CompleteInput(string wordToComplete, CommandAst ast, int cursorPosition)
        {
            var elementCount = ast.CommandElements.Count;
            var prevIndex = elementCount - (string.IsNullOrEmpty(wordToComplete) ? 1 : 2);
            string previosParameterName = null;
            string previousParameterValue = null;
            var doubleDash = ast.CommandElements.FirstOrDefault(c => c.Extent.Text == "--");
            var afterDoubleDash = doubleDash != null && doubleDash.Extent.EndColumnNumber < cursorPosition;
            if (prevIndex < elementCount)
            {
                switch (ast.CommandElements[prevIndex])
                {
                    case CommandParameterAst p:
                        previosParameterName = p.ParameterName;
                        break;
                    case StringConstantExpressionAst s:
                        previousParameterValue = s.Value;
                        break;
                }
            }

            if (previousParameterValue.IsGitCommand())
            {
                return CompleteGitCommands(wordToComplete);
            }
            string commandName = ast.CommandElements[1].Extent.Text;
            var gitCommand = GitCommand.GetOptions(commandName);
            if (gitCommand != null)
            {
                return CompleteGitCommand(commandName, gitCommand, previosParameterName, previousParameterValue, wordToComplete, afterDoubleDash);
            }

            return null;

        }

        private static IList<CompletionResult> CompleteGitCommand(string commandName, GitCommandOption[] gitCommandOptions, string previosParameterName, string previousParameterValue, string wordToComplete, bool afterDoubleDash)
        {
            switch (commandName)
            {
                case "diff":
                case "rebase":
                    if (wordToComplete.IsEmpty())
                    {
                        return Git.Log()
                            .Select(log => new CompletionResult(log.Commit, log.Commit, CompletionResultType.ParameterValue, log.Message)).ToList();
                    }
                    else if (!wordToComplete.StartsWith("-"))
                    {
                        return Git.Log()
                            .Where(l=>l.Commit.IgnoreCaseStartsWith(wordToComplete) || l.Message.IgnoreCaseStartsWith(wordToComplete))
                            .Select(log => new CompletionResult(log.Commit, log.Commit, CompletionResultType.ParameterValue, log.Message)).ToList();
                    }
                    goto default;
                default:
                    return GitOptionsToCompletionResults(gitCommandOptions, wordToComplete);
            }
        }

        private static List<CompletionResult> GitOptionsToCompletionResults(GitCommandOption[] gitCommandOptions, string wordToComplete)
        {
            return gitCommandOptions.Where(option => option.Completion.StartsWith(wordToComplete))
                .Select(o => o.ToCompletionResult())
                .ToList();
        }

        private static IList<CompletionResult> CompleteGitCommands(string wordToComplete)
        {
            return GitCommand.Commands.Where(c => c.Name.IgnoreCaseStartsWith(wordToComplete))
                .Select(c => c.ToCompletionResult())
                .ToList();
        }

        public void OnImport()
        {
            using (var ps = PowerShell.Create(RunspaceMode.CurrentRunspace))
            {
                ps.AddCommand("Register-ArgumentCompleter")
                    .AddParameter("-Native", true)
                    .AddParameter("CommandName", "git")
                    .AddParameter("ScriptBlock", ScriptBlock.Create("param($wordToComplete, $ast, $cursorPosition) [PowerCode.GitCompleter]::CompleteInput($wordToComplete, $ast, $cursorPosition)"));
                ps.Invoke();
            }
        }
    }

    public struct GitRef
    {
        public string Commit;
        public string Name;

        public GitRef(string commit, string name)
        {
            Commit = commit;
            Name = name;
        }
    }
}
