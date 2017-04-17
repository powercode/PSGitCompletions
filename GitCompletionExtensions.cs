using System;
using System.Management.Automation;

namespace PowerCode
{
    public static class GitCompletionExtensions
    {
        public static bool IgnoreCaseEquals(this string str, string value)
        {
            return string.Equals(str, value, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IgnoreCaseStartsWith(this string str, string value)
        {
            return str.StartsWith(value, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsGitCommand(this string str)
        {
            return str.IndexOf("git", StringComparison.OrdinalIgnoreCase) != -1;
        }

        public static CompletionResult ToCompletionResult(this GitCommand command)
        {
            return new CompletionResult(command.Name, command.Name, CompletionResultType.Method, command.Description + Environment.NewLine + command.Synopsis);
        }

        public static CompletionResult ToCompletionResult(this GitCommandOption command)
        {
            return new CompletionResult(command.Completion, command.ListText, CompletionResultType.ParameterName, @command.ToolTip);
        }
    }

    
}