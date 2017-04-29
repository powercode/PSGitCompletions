using System;
using System.Collections.Generic;

namespace PowerCode {
    public class GitRemoteRef : IEqualityComparer<GitRemoteRef>, IComparable<GitRemoteRef> {
        public GitRemoteRef(string commit, string remote) {
            Commit = commit;
            var slash = remote.IndexOf("/", 13, StringComparison.OrdinalIgnoreCase);
            Remote = remote.Substring(13, slash - 13);
            Ref = remote.Substring(slash + 1);
        }

        public string Commit { get; }
        public string Remote { get; }
        public string Ref { get; }

        public string RemoteRef => $"{Remote}/{Ref}";

        public int CompareTo(GitRemoteRef other) {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var remoteComparison = string.Compare(Remote, other.Remote, StringComparison.Ordinal);
            if (remoteComparison != 0) return remoteComparison;
            return string.Compare(Ref, other.Ref, StringComparison.Ordinal);
        }

        public bool Equals(GitRemoteRef x, GitRemoteRef y) {
            return x.Commit == y.Commit;
        }

        public int GetHashCode(GitRemoteRef obj) {
            return Commit.GetHashCode();
        }
    }
}