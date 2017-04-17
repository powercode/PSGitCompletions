using System;
using System.Management.Automation;

namespace PowerCode {
    public static class GitCompletionExtensions {
        public static bool IgnoreCaseEquals(this string str, string value) {
            return string.Equals(str, value, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IgnoreCaseStartsWith(this string str, string value) {
            return str.StartsWith(value, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsEmpty(this string str) {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsGitCommand(this string str) {
            return !string.IsNullOrEmpty(str) && str.IndexOf("git", StringComparison.OrdinalIgnoreCase) != -1;
        }

        public static CompletionResult ToCompletionResult(this GitCommand command) {
            return new CompletionResult(command.Name, command.Name, CompletionResultType.Method,
                command.Description + Environment.NewLine + command.Synopsis);
        }

        public static CompletionResult ToCompletionResult(this GitCommandOption command) {
            return new CompletionResult(command.Completion, command.ListText, CompletionResultType.ParameterName,
                command.ToolTip);
        }

        public static Status ToStatus(this char c) {
            switch (c) {
                case ' ': return Status.Unmodified;
                case 'M': return Status.Modified;
                case 'A': return Status.Added;
                case 'D': return Status.Deleted;
                case 'R': return Status.Renamed;
                case 'C': return Status.Copied;
                case 'U': return Status.UpdatedButUnmerged;
                case '?': return Status.Untracked;
                case '!': return Status.Ignored;
                default: throw new ArgumentOutOfRangeException(nameof(c));
            }
        }
    }
}