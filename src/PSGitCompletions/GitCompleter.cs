using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PSGitCompletionsTests")]

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
            var completeCommandParameters = CompleteCommandParameters.Create(wordToComplete, ast, cursorPosition);
            if (completeCommandParameters.IsCompletingCommand) {
                return CompleteGitCommands(wordToComplete: wordToComplete);
            }
            return CompleteGitCommand(completeCommandParameters);
        }


        private static IList<CompletionResult> CompleteGitCommand(CompleteCommandParameters completeCommandParameters) {
            var wordToComplete = completeCommandParameters.WordToComplete;
            bool isCompletingParameterName = completeCommandParameters.IsCompletingParameterName;
            switch (completeCommandParameters.CommandName)
            {
                case "add":
                    if (!isCompletingParameterName) return CompleteModifiedFiles(wordToComplete: wordToComplete);
                    goto default;
                case "branch":
                    if (!isCompletingParameterName) return CompleteBranches(wordToComplete: wordToComplete);
                    goto default;
                case "checkout":
                    if (string.IsNullOrEmpty(value: completeCommandParameters.PreviousParameterName) && !isCompletingParameterName) return CompleteCheckout(completeCommandParameters);
                    goto default;
                case "fetch":
                    if (!isCompletingParameterName)
                    {
                        if (!string.IsNullOrEmpty(value: completeCommandParameters.PreviousParameterValue) && completeCommandParameters.PreviousParameterValue != completeCommandParameters.CommandName)
                            return Git.RemoteRefs()
                                .Where(r => r.Remote.IgnoreCaseEquals(value: completeCommandParameters.PreviousParameterValue) && r.Ref.IgnoreCaseStartsWith(value: wordToComplete))
                                .Select(c => new CompletionResult(completionText: c.Ref, listItemText: c.Ref, resultType: CompletionResultType.ParameterValue,
                                    toolTip: c.RemoteRef))
                                .ToList();
                        return Git.RemoteRefs()
                            .Where(r => r.Remote.IgnoreCaseContains(value: wordToComplete))
                            .GroupBy(c => c.Remote)
                            .Select(g => g.First())
                            .Select(c => new CompletionResult(completionText: c.Remote, listItemText: c.Remote, resultType: CompletionResultType.ParameterValue, toolTip: c.Remote))
                            .ToList();
                    }

                    goto default;
                case "diff":
                case "difftool":
                    return CompleteDiff(completeCommandParameters);
                case "rebase":
                    return CompleteRebase(completeCommandParameters);
                case "show":
                    return CompleteShow(completeCommandParameters);
                case "tag":
                    return CompleteTag(completeCommandParameters);
                default:
                    return isCompletingParameterName
                        ? (IList<CompletionResult>) GitOptionsToCompletionResults(gitCommandOptions: completeCommandParameters.GitCommandOptions,
                            wordToComplete: wordToComplete)
                        : Array.Empty<CompletionResult>();
            }
        }

        private static IList<CompletionResult> CompleteTag(CompleteCommandParameters completeCommandParameters) {
            var wordToComplete = completeCommandParameters.WordToComplete;
            var isCompletingParameterName = completeCommandParameters.IsCompletingParameterName;

            var parameters = completeCommandParameters.GetPositionalParameters();
            var positional = parameters switch
            {
                { Count: 1 } => parameters[0].token,
                _ => null,
            };

            if (isCompletingParameterName)
                return GitOptionsToCompletionResults(completeCommandParameters.GitCommandOptions, wordToComplete);


            if (positional != null && positional != wordToComplete) {
                return CompleteBranchesAndLogCommits(wordToComplete);
            }

            return Array.Empty<CompletionResult>();
        }

        private static IList<CompletionResult> CompleteShow(CompleteCommandParameters completeCommandParameters) {

            var wordToComplete = completeCommandParameters.WordToComplete;
            var isCompletingParameterName = completeCommandParameters.IsCompletingParameterName;

            var parameters = completeCommandParameters.GetPositionalParameters();
            var positional = parameters switch {
                {Count: 1} => parameters[0].token,
                _ => null,
            };

            if (completeCommandParameters.AfterDoubleDash)
            {
                return Git.GetCommitFiles(positional).Select(f => new CompletionResult(f)).ToList();
            }

            return isCompletingParameterName
                ? GitOptionsToCompletionResults(completeCommandParameters.GitCommandOptions, wordToComplete)
                : CompleteLog(wordToComplete);


        }

        private static IList<CompletionResult> CompleteRebase(CompleteCommandParameters completeCommandParameters) {
            var wordToComplete = completeCommandParameters.WordToComplete;
            var isCompletingParameterName = completeCommandParameters.IsCompletingParameterName;

            var commits = completeCommandParameters.Ast.CommandElements.Skip(1)
                .Where(ce => !ce.Extent.Text.StartsWith("-"))
                .Take(3)
                .Select(ce => ce.Extent.Text)
                .Skip(1).ToArray();

            var (from, to) = commits switch
            {
                { Length: 1 } => (commits[0], null),
                { Length: 2 } => (commits[0], commits[1]),
                _ => (null, null),
            };

            if (wordToComplete.IsEmpty())
                return Git.Log().TakeWhile(l => l.Commit != from)
                    .Select(log => new CompletionResult(completionText: log.Commit, listItemText: log.Commit, resultType: CompletionResultType.ParameterValue, toolTip: log.Message))
                    .ToList();
            return isCompletingParameterName
                ? GitOptionsToCompletionResults(completeCommandParameters.GitCommandOptions, wordToComplete)
                : Git.Log().TakeWhile(l => l.Commit != from)
                    .Where(l => l.Commit.IgnoreCaseStartsWith(value: wordToComplete) || l.Message.IgnoreCaseContains(value: wordToComplete))
                    .Select(log => new CompletionResult(completionText: log.Commit, listItemText: log.Commit,
                        resultType: CompletionResultType.ParameterValue, toolTip: log.Message))
                    .ToList();
        }

        private static IList<CompletionResult> CompleteDiff(CompleteCommandParameters completeCommandParameters) {
            var wordToComplete = completeCommandParameters.WordToComplete;
            var commits = completeCommandParameters.Ast.CommandElements.Skip(1)
                .Where(ce => !ce.Extent.Text.StartsWith("-"))
                .Take(3)
                .Select(ce => ce.Extent.Text)
                .Skip(1).ToArray();
            var (from, to) = commits switch {
                {Length: 1} => (commits[0], null),
                {Length: 2} => (commits[0], commits[1]),
                _ => (null, null),
            };

            var cached = completeCommandParameters.Ast.Extent.Text.Contains("--cached");

            if (completeCommandParameters.AfterDoubleDash) {

                return Git.GetDiffableFiles(match:wordToComplete, from, to, cached).Select(f=>new CompletionResult(f)).ToList();
            }

            return completeCommandParameters.IsCompletingParameterName
                ? GitOptionsToCompletionResults(completeCommandParameters.GitCommandOptions, wordToComplete)
                : CompleteLog(wordToComplete);
        }


        private static IList<CompletionResult> CompleteCheckout(CompleteCommandParameters completeCommandParameters) {
            var wordToComplete = completeCommandParameters.WordToComplete;
            return completeCommandParameters.AfterDoubleDash ? CompleteModifiedFiles(wordToComplete) : CompleteBranches(wordToComplete);
        }

        private static IList<CompletionResult> CompleteModifiedFiles(string wordToComplete) {
            return Git.Status()
                .Where(s=>s.WorkTreeStatus != GitStatusKind.None && s.Path.StartsWith(wordToComplete, StringComparison.OrdinalIgnoreCase))
                .Select(status => new CompletionResult(status.Path, status.Path, CompletionResultType.ProviderItem, $"status: {status.WorkTreeStatus}"))
                .ToArray();
        }

        private static IList<CompletionResult> CompleteLog(string wordToComplete, int count = 50, string? startCommit = null) {
            var log = Git.Log(startCommit, count);

            bool AlwaysTrue(GitLog logItem) => true;

            bool MatchesWordToComplete(GitLog logItem) => logItem.Commit.IgnoreCaseStartsWith(value: wordToComplete) || logItem.Message.IgnoreCaseContains(value: wordToComplete);

            Predicate<GitLog> predicate = string.IsNullOrEmpty(wordToComplete) ? AlwaysTrue : MatchesWordToComplete;

            return log.Where(l => predicate(l))
                .Select(logItem => new CompletionResult(completionText: logItem.Commit, listItemText: logItem.Commit, resultType: CompletionResultType.ParameterValue, toolTip: logItem.Message))
                .ToList();
        }

        private static IList<CompletionResult> CompleteBranchesAndLogCommits(string wordToComplete)
        {
            var heads = Git.Heads(match: wordToComplete)
                .Select(c => new CompletionResult(completionText: c, listItemText: c, resultType: CompletionResultType.ParameterValue, toolTip: c))
                .ToList();
            heads.AddRange(CompleteLog(wordToComplete));
            return heads;
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
            var commands = GitCommand.Commands.Where(c => c.Name.IgnoreCaseStartsWith(value: wordToComplete))
                .Select(c => c.ToCompletionResult())
                .ToList();
            var aliases = Git.GetAliases(wordToComplete).Select(a => new CompletionResult(a.alias, a.alias, CompletionResultType.Command, $"alias: {a.command} {a.parameters}"));
            commands.AddRange(aliases);
            commands.Sort((result, completionResult) => string.CompareOrdinal(result.CompletionText, completionResult.CompletionText));
            return commands;
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