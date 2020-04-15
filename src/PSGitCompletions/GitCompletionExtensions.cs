using System;
using System.Management.Automation;

namespace PowerCode
{
    public static class GitCompletionExtensions
    {
        public static bool IgnoreCaseEquals(this string str, string value) => string.Equals(a: str, b: value, comparisonType: StringComparison.OrdinalIgnoreCase);

        public static bool IgnoreCaseStartsWith(this string str, string value) => str.StartsWith(value: value, comparisonType: StringComparison.OrdinalIgnoreCase);

        public static bool IsEmpty(this string? str) => string.IsNullOrEmpty(value: str);

        public static bool IsGitCommand(this string? str) => !string.IsNullOrEmpty(value: str) && str.IndexOf("git", comparisonType: StringComparison.OrdinalIgnoreCase) != -1;

        public static CompletionResult ToCompletionResult(this GitCommand command) => new CompletionResult(completionText: command.Name, listItemText: command.Name,
            resultType: CompletionResultType.Method, command.Description + Environment.NewLine + command.Synopsis);

        public static CompletionResult ToCompletionResult(this GitCommandOption command) => new CompletionResult(completionText: command.Completion, listItemText: command.ListText,
            resultType: CompletionResultType.ParameterName, toolTip: command.ToolTip);
    }
}