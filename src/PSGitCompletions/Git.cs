using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace PowerCode
{
    public struct GitExecuterScope : IDisposable
    {
        private readonly Func<string, IEnumerable<string>> _executer;

        public GitExecuterScope(Func<string, IEnumerable<string>> executer)
        {
            _executer = executer;
        }

        public void Dispose()
        {
            Git.GitExecuter = _executer;
        }
    }

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
            Ref = remote.Substring(slash + 1);
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

    public class GitRemoteUrl
    {
        public string Name { get; }
        public string? FetchUrl { get; set; }
        public string? PushUrl { get; set; }

        public GitRemoteUrl(string name)
        {
            Name = name;
        }
    }

    public class Git
    {
        public static Func<string, IEnumerable<string>> GitExecuter = GitExecute;

        private static IEnumerable<string> Execute(string command) => GitExecuter(arg: command);

        private static IEnumerable<string> GitExecute(string command)
        {
            using var ps = PowerShell.Create(runspace: RunspaceMode.CurrentRunspace);
            ps.AddScript(script: command);
            return ps.Invoke<string>();
        }

        public static IEnumerable<GitRemoteUrl> Remotes()
        {
            var res = Execute("git remove -v");
            GitRemoteUrl? current = null;
            foreach (var line in res)
            {
                var parts = line.Split('\t');
                var name = parts[0];
                var uri = parts[1];
                if (current == null) current = new GitRemoteUrl(name: name);


                if (current.Name != name)
                {
                    yield return current;
                    current = new GitRemoteUrl(name: name);
                }

                if (uri.EndsWith("(fetch)"))
                    current.FetchUrl = uri;
                else
                    current.PushUrl = uri;
            }

            if (current != null) yield return current;
        }

        public static IEnumerable<GitRemoteRef> RemoteRefs()
        {
            return Execute("git for-each-ref '--format=%(objectname) %(refname)' refs/remotes/*/*")
                .Select(l => new GitRemoteRef(l.Substring(0, 40), l.Substring(41)));
        }

        public static IEnumerable<GitRef> Refs(string match)
        {
            var res = Execute($"git for-each-ref '--format=%(refname)' '--sort=\"refname:strip=3\"' 'refs/heads/{match}*' 'refs/heads/{match}*/**'");
            foreach (var line in res) yield return new GitRef(line.Substring(0, 40), line.Substring(41));
        }

        public static IEnumerable<GitRef> Remotes(string match)
        {
            var res = Execute($"git for-each-ref '--format=%(refname)' '--sort=\"refname:strip=3\"' 'refs/heads/{match}*' 'refs/heads/{match}*/**'");
            foreach (var line in res) yield return new GitRef(line.Substring(0, 40), line.Substring(41));
        }

        public static IEnumerable<string> Heads(string match)
        {
            var heads = Execute($"git for-each-ref '--format=%(refname:strip=2)' 'refs/heads/{match}*' 'refs/heads/{match}*/**'").Distinct().ToArray();
            Array.Sort(array: heads);
            return heads;
        }

        public static IEnumerable<string> Tags(string match)
        {
            var heads = Execute($"git for-each-ref '--format=%(refname:strip=2)' 'refs/tags/{match}*' 'refs/tags/{match}*/**'").ToArray();
            Array.Sort(array: heads);
            return heads;
        }

        public static IEnumerable<string> Files(string match) => Execute($"git ls-files --exclude-standard {match}*");

        public static IEnumerable<string> CommitableFiles(string match) => Execute("git diff-index --name-only --relative HEAD");

        public static IEnumerable<GitLog> Log(int count = 50) => Execute($"git log --oneline -{count}").Select(l => new GitLog(l.Substring(0, 8), l.Substring(9)));
    }
}