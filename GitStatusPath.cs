using System.Diagnostics;

namespace PowerCode {
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class GitStatusPath {
        public GitStatusPath(Status index, Status working, string path) {
            Working = working;
            Index = index;
            Path = path;
        }

        public Status Working { get; }
        public Status Index { get; }
        public string Path { get; }

        private string DebuggerDisplay => $"{Index.ToChar()}{Working.ToChar()} {Path}";
    }
}