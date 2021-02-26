using System;
using System.Collections.Generic;

namespace PowerCode {
    public class GitRemoteRef : IComparable<GitRemoteRef>, IEquatable<GitRemoteRef>, IComparable
    {
        public string Commit { get; }
        public string Remote { get; }
        public string Ref { get; }

        public string RemoteRef => $"{Remote}/{Ref}";

        public GitRemoteRef(string commit, string remote)
        {
            Commit = commit;
            var slash = remote.IndexOf("/", 13, comparisonType: StringComparison.OrdinalIgnoreCase);
            Remote = remote[13..slash];
            Ref = remote[(slash + 1)..];
        }

        public int CompareTo(object? obj)
        {
            if (obj is null) return 1;
            if (ReferenceEquals(this, objB: obj)) return 0;
            return obj is GitRemoteRef other ? CompareTo(other: other) : throw new ArgumentException($"Object must be of type {nameof(GitRemoteRef)}");
        }

        public int CompareTo(GitRemoteRef? other)
        {
            if (ReferenceEquals(this, objB: other)) return 0;
            if (other is null) return 1;
            return string.Compare(strA: Commit, strB: other.Commit, comparisonType: StringComparison.Ordinal);
        }

        public bool Equals(GitRemoteRef? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, objB: other)) return true;
            return Commit == other.Commit;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, objB: obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((GitRemoteRef) obj);
        }

        public override int GetHashCode() => Commit.GetHashCode();

        public static bool operator ==(GitRemoteRef? left, GitRemoteRef? right) => Equals(objA: left, objB: right);

        public static bool operator !=(GitRemoteRef? left, GitRemoteRef? right) => !Equals(objA: left, objB: right);

        public static bool operator <(GitRemoteRef? left, GitRemoteRef? right) => Comparer<GitRemoteRef>.Default.Compare(x: left, y: right) < 0;

        public static bool operator >(GitRemoteRef? left, GitRemoteRef? right) => Comparer<GitRemoteRef>.Default.Compare(x: left, y: right) > 0;

        public static bool operator <=(GitRemoteRef? left, GitRemoteRef? right) => Comparer<GitRemoteRef>.Default.Compare(x: left, y: right) <= 0;

        public static bool operator >=(GitRemoteRef? left, GitRemoteRef? right) => Comparer<GitRemoteRef>.Default.Compare(x: left, y: right) >= 0;
    }
}