using System;

namespace PowerCode
{
    public class GitRemote : IComparable<GitRemote>, IEquatable<GitRemote>, IComparable
    {
        public string Commit { get; }
        public string Name { get; }

        public GitRemote(string commit, string name)
        {
            Commit = commit;
            Name = name;
        }

        public int CompareTo(GitRemote? other)
        {
            if (ReferenceEquals(this, other))
                return 0;
            return other is null ? 1 : string.Compare(Commit, other.Commit, StringComparison.Ordinal);
        }

        public bool Equals(GitRemote? other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Commit == other.Commit;
        }

        public int CompareTo(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return 0;
            if (obj is null)
                return 1;
            return obj is GitRemote other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(GitRemote)}");
        }
    }
}