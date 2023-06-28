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

        public static IEnumerable<CompletionResult> CompleteInput(string wordToComplete, CommandAst ast, int cursorPosition)
        {
            var completeCommandParameters = CompleteCommandParameters.Create(wordToComplete, ast, cursorPosition);
            if (completeCommandParameters.IsCompletingCommand)
            {
                return CompleteGitCommands(wordToComplete: wordToComplete);
            }
            return CompleteGitCommand(completeCommandParameters);
        }


        private static IEnumerable<CompletionResult> CompleteGitCommand(CompleteCommandParameters completeCommandParameters)
        {
            var wordToComplete = completeCommandParameters.WordToComplete;
            bool isCompletingParameterName = completeCommandParameters.IsCompletingParameterName;
            switch (completeCommandParameters.CommandName)
            {
                case "add":
                    if (!isCompletingParameterName) return CompleteModifiedFiles(wordToComplete);
                    goto default;
                case "bisect":
                    if (!isCompletingParameterName) return CompleteBisect(completeCommandParameters);
                    goto default;
                case "branch":
                    if (!isCompletingParameterName) return CompleteHeads(wordToComplete: wordToComplete);
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
                case "reset":
                    return CompleteReset(completeCommandParameters);
                case "restore":
                    return CompleteRestore(completeCommandParameters);
                case "show":
                    return CompleteShow(completeCommandParameters);
                case "switch":
                    if (!isCompletingParameterName) return CompleteBranch(wordToComplete, false);
                    goto default;
                case "tag":
                    return CompleteTag(completeCommandParameters);
                default:
                    return isCompletingParameterName
                        ? (IList<CompletionResult>)GitOptionsToCompletionResults(gitCommandOptions: completeCommandParameters.GitCommandOptions,
                            wordToComplete: wordToComplete)
                        : Array.Empty<CompletionResult>();
            }
        }

        private static IList<CompletionResult> CompleteBisect(CompleteCommandParameters completeCommandParameters)
        {
            var relativeIndex = completeCommandParameters.CurrentElementIndex - completeCommandParameters.CommandElementIndex;
            return relativeIndex switch
            {
                1 => CompleteCommands(completeCommandParameters.WordToComplete),
                int i when i > 1 => CompleteSubParameter(i, completeCommandParameters.Ast.CommandElements[completeCommandParameters.CommandElementIndex + 1].Extent.Text, completeCommandParameters.WordToComplete),
                _ => Array.Empty<CompletionResult>(),
            };


            static IList<CompletionResult> CompleteCommands(string wordToComplete)
            {
                var commands = new[] { "start", "bad", "new", "good", "old", "terms", "skip", "reset", "visualize", "view", "replay", "log", "run", "help" };
                var res = new List<CompletionResult>(10);
                foreach (var cmd in commands.Where(c => c.StartsWith(wordToComplete, StringComparison.OrdinalIgnoreCase)))
                {
                    res.Add(new CompletionResult(cmd));
                }

                return res;
            }

            static IList<CompletionResult> CompleteSubParameter(int elementIndex, string subCommand, string wordToComplete)
            {
                var res = new List<CompletionResult>();
                // todo
                return res;
            }

        }

        private static IEnumerable<CompletionResult> CompleteReset(CompleteCommandParameters completeCommandParameters)
        {
            var wordToComplete = completeCommandParameters.WordToComplete;
            var isCompletingParameterName = completeCommandParameters.IsCompletingParameterName;
            if (isCompletingParameterName)
                return GitOptionsToCompletionResults(completeCommandParameters.GitCommandOptions, wordToComplete);

            if (completeCommandParameters.AfterDoubleDash)
            {
                return CompleteModifiedFiles(wordToComplete);
            }

            var positional = completeCommandParameters.GetPositionalParameters();
            if (positional.Count == 0 || wordToComplete == positional[0].token)
            {

                return CompleteHead(wordToComplete)
                    .Concat(CompleteHeads(wordToComplete))
                    .Concat(CompleteRemoteRefs(wordToComplete));
            }

            return CompleteModifiedFiles(wordToComplete);
        }

        private static IEnumerable<CompletionResult> CompleteRestore(CompleteCommandParameters completeCommandParameters)
        {
            var wordToComplete = completeCommandParameters.WordToComplete;
            var isCompletingParameterName = completeCommandParameters.IsCompletingParameterName;
            if (isCompletingParameterName)
                return GitOptionsToCompletionResults(completeCommandParameters.GitCommandOptions, wordToComplete);

            if (completeCommandParameters.PreviousParameterName == "-s" || completeCommandParameters.PreviousParameterName == "--source") {
                return CompleteBranchesAndLogCommits(wordToComplete);
            }

            return CompleteModifiedFiles(wordToComplete);
        }


        private static IEnumerable<CompletionResult> CompleteHead(string wordToComplete) => "HEAD".IgnoreCaseStartsWith(wordToComplete) ? new[] {new CompletionResult("HEAD")} : Array.Empty<CompletionResult>();

        private static IEnumerable<CompletionResult> CompleteTag(CompleteCommandParameters completeCommandParameters)
        {
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


            if (positional != null && positional != wordToComplete)
            {
                return CompleteBranchesAndLogCommits(wordToComplete);
            }

            return Array.Empty<CompletionResult>();
        }

        private static IEnumerable<CompletionResult> CompleteRemoteRefs(string wordToComplete)
        {
            return Git.RemoteRefs().Where(r => r.Ref.IgnoreCaseStartsWith(wordToComplete) || r.Remote.IgnoreCaseStartsWith(wordToComplete))
                .Select(c => new CompletionResult(c.RemoteRef));
        }

        private static IList<CompletionResult> CompleteShow(CompleteCommandParameters completeCommandParameters)
        {

            var wordToComplete = completeCommandParameters.WordToComplete;
            var isCompletingParameterName = completeCommandParameters.IsCompletingParameterName;

            var parameters = completeCommandParameters.GetPositionalParameters();
            var positional = parameters switch
            {
                { Count: 1 } => parameters[0].token,
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

        private static IList<CompletionResult> CompleteRebase(CompleteCommandParameters completeCommandParameters)
        {
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
                    .Concat(CompleteRefs(wordToComplete))
                    .ToList();
        }

        private static IList<CompletionResult> CompleteDiff(CompleteCommandParameters completeCommandParameters)
        {
            var wordToComplete = completeCommandParameters.WordToComplete;
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

            var cached = completeCommandParameters.Ast.Extent.Text.Contains("--cached");

            if (completeCommandParameters.AfterDoubleDash)
            {

                return Git.GetDiffableFiles(match: wordToComplete, from, to, cached).Select(f => new CompletionResult(f)).ToList();
            }

            return completeCommandParameters.IsCompletingParameterName
                ? GitOptionsToCompletionResults(completeCommandParameters.GitCommandOptions, wordToComplete)
                : CompleteLog(wordToComplete);
        }


        private static IList<CompletionResult> CompleteCheckout(CompleteCommandParameters completeCommandParameters)
        {
            var wordToComplete = completeCommandParameters.WordToComplete;
            return completeCommandParameters.AfterDoubleDash ? CompleteModifiedFiles(wordToComplete) : CompleteRefsAndLog(wordToComplete);
        }

        private static IList<CompletionResult> CompleteModifiedFiles(string wordToComplete)
        {
            return Git.Status()
                .Where(s => s.WorkTreeStatus != GitStatusKind.None && s.Path.StartsWith(wordToComplete, StringComparison.OrdinalIgnoreCase))
                .Select(status => new CompletionResult(status.Path, status.Path, CompletionResultType.ProviderItem, $"status: {status.WorkTreeStatus}"))
                .ToArray();
        }

        private static IList<CompletionResult> CompleteBranch(string wordToComplete, bool includeCurrent)
        {
            var log = Git.Branches();
            
            bool MatchesWordToComplete(GitBranch branch) => branch.Name.IgnoreCaseContains(value: wordToComplete) && (includeCurrent || !branch.IsHead);            

            return log.Where(MatchesWordToComplete)
                .Select(branch => new CompletionResult(completionText: branch.Name, listItemText: branch.Name, resultType: CompletionResultType.ParameterValue, toolTip: branch.Commit))
                .ToList();
        }


        private static IList<CompletionResult> CompleteLog(string wordToComplete, int count = 50, string? startCommit = null)
        {
            var log = Git.Log(startCommit, count);

            bool AlwaysTrue(GitLog logItem) => true;

            bool MatchesWordToComplete(GitLog logItem) => logItem.Commit.IgnoreCaseStartsWith(value: wordToComplete) || logItem.Message.IgnoreCaseContains(value: wordToComplete);

            Predicate<GitLog> predicate = string.IsNullOrEmpty(wordToComplete) ? AlwaysTrue : MatchesWordToComplete;

            return log.Where(l => predicate(l))
                .Select(logItem => new CompletionResult(completionText: logItem.Commit, listItemText: logItem.Commit, resultType: CompletionResultType.ParameterValue, toolTip: logItem.Message))
                .ToList();
        }

        private static IEnumerable<CompletionResult> CompleteBranchesAndLogCommits(string wordToComplete)
        {
            return CompleteHeads(wordToComplete)
                .Concat(CompleteLog(wordToComplete));
        }

        private static IEnumerable<CompletionResult> CompleteHeads(string wordToComplete) {
            var descs = Git.BranchDescriptions().ToDictionary(c=>c.Name);

            string ToolTip(GitHead head)
            {
                if (descs.TryGetValue(head.Name, out var branchDescription)) {
                    return @$"{branchDescription.Description}
----
HEAD at {head.Subject}
";
                }

                return head.Subject;
            }

            return Git.Heads(match: wordToComplete)
                .Select(c => new CompletionResult(completionText: c.Name, listItemText: c.Name, resultType: CompletionResultType.ParameterValue, toolTip: ToolTip(c)));
        }

        private static IList<CompletionResult> CompleteRefsAndLog(string wordToComplete)
        {
            return CompleteRefs(wordToComplete)
                .Concat(CompleteLog(wordToComplete)).ToList();
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

        private static IList<CompletionResult> CompleteRefs(string wordToComplete) {
            var desc = Git.BranchDescriptions().ToDictionary(c => c.Name);
            string ToolTip(GitRef gitRef) {


                if (gitRef.ObjectType == GitObjectType.Commit && desc.TryGetValue(gitRef.Name, out var description)) {
                    return @$"{description.Description}
----
HEAD at {gitRef.Subject}
";
                }
                return gitRef.Subject;
            }

            return Git.Refs(wordToComplete)
                .Select(r => new CompletionResult(r.Name, r.Name,
                    CompletionResultType.ParameterValue, ToolTip(r)))
                .ToList();
        }
    }
}