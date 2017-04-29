using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace PowerCode {
    public static class GitCompletionExtensions {
        private static string[] s_refCommands;

        private static string[] RefCommands => s_refCommands ?? (s_refCommands = new[] {
            "cherry", "cherry-pick", "diff", "difftool", "log", "merge", "rebase", "reset", "revert", "show"
        });

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

        public static CompletionResult ToCompletionResult(this GitStatusPath statusPath, string tooltip = null) {
            return new CompletionResult(statusPath.Path, statusPath.Path, CompletionResultType.ProviderItem,
                statusPath.Path);
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

        public static char ToChar(this Status status) {
            switch (status) {
                case Status.Unmodified: return ' ';
                case Status.Modified: return 'M';
                case Status.Added: return 'A';
                case Status.Deleted: return 'D';
                case Status.Renamed: return 'R';
                case Status.Copied: return 'C';
                case Status.UpdatedButUnmerged: return 'U';
                case Status.Untracked: return '?';
                case Status.Ignored: return '!';
            }
            throw new ArgumentException("Not a valid ", nameof(status));
        }

        public static bool IsAddable(this GitStatusPath status) {
            return status.Working == Status.UpdatedButUnmerged || status.Working == Status.Modified || status.Working == Status.Added;
        }

        public static bool IsWorkingDiffable(this GitStatusPath status) => status.Working == Status.UpdatedButUnmerged || status.Working == Status.Modified || status.Index == Status.Modified;

        public static bool IsIndexDiffable(this GitStatusPath status) => status.Index == Status.Modified;

        public static bool IsAnyOf(this string text, IEnumerable<string> alternatives, out string match) {
            foreach (var option in alternatives) {
                if (string.Compare(option, text, StringComparison.OrdinalIgnoreCase) != 0) continue;
                match = option;
                return true;
            }
            match = null;
            return false;
        }

        public static bool IsRefCompleteCommand(this string command) {
            for (var i = 0; i < RefCommands.Length; i++) if (RefCommands[i] == command) return true;
            return false;
        }
    }
}