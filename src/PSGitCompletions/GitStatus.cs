using System.IO;

namespace PowerCode {
    public record GitStatus(string Path, GitStatusKind WorkTreeStatus, GitStatusKind IndexStatus);

    class GitStatusParser {
        public static GitStatus FromStatusString(string statusString) {
            var index = statusString[0];
            var working = statusString[1];
            var path = statusString[3..];
            return new GitStatus(path, ToStatusKind(working), ToStatusKind(index));
        }

        private static GitStatusKind ToStatusKind(char c) => c switch {
            ' ' => GitStatusKind.None,
            'A' => GitStatusKind.Added,
            'D' => GitStatusKind.Deleted,
            'R' => GitStatusKind.Renamed,
            'C' => GitStatusKind.Copied,
            'M' => GitStatusKind.Modified,
            'U' => GitStatusKind.UpdatedButUnmerged,
            _ => GitStatusKind.Untracked,
        };
    }

    public enum GitStatusKind {
        None,
        Modified,
        Untracked,
        Added,
        Deleted,
        Renamed,
        Copied,
        UpdatedButUnmerged
    }
}
