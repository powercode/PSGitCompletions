using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;

namespace PowerCode {
    public struct GitExecuterScope : IDisposable {
        private readonly Func<string, IEnumerable<string>> _executer;

        public GitExecuterScope(Func<string, IEnumerable<string>> executer) {
            _executer = executer;
        }

        public void Dispose() {
            Git.GitExecuter = _executer;
        }
    }

    public enum Status {
        Unmodified,
        Modified,
        Added,
        Deleted,
        Renamed,
        Copied,
        UpdatedButUnmerged,
        Untracked,
        Ignored
    }

    public class Git {
        /// <summary>
        ///     Give a way to fake git for testing
        /// </summary>
        public static Func<string, IEnumerable<string>> GitExecuter = GitExecute;

        /// <summary>
        ///     Default implementation for GitExecuter
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private static IEnumerable<string> GitExecute(string command) {
            using (var ps = PowerShell.Create(RunspaceMode.CurrentRunspace)) {
                ps.AddScript(command);
                return ps.Invoke<string>();
            }
        }


        private static IEnumerable<string> Execute(string command) {
            Debug.WriteLine(command);
            return GitExecuter(command);
        }

        public static IEnumerable<GitStatusPath> Status() {
            return Execute("git status --porcelain")
                .Select(l => new GitStatusPath(l[0].ToStatus(), l[1].ToStatus(), l.Substring(3)));
        }

        public static IEnumerable<GitRemoteUrl> Remotes() {
            var res = Execute("git remote -v");
            GitRemoteUrl current = null;
            foreach (var line in res) {
                var parts = line.Split('\t');
                var name = parts[0];
                var uri = parts[1];
                if (current == null)
                    current = new GitRemoteUrl(name);


                if (current.Name != name) {
                    yield return current;
                    current = new GitRemoteUrl(name);
                }
                if (uri.EndsWith("(fetch)"))
                    current.FetchUrl = uri;
                else
                    current.PushUrl = uri;
            }
            if (current != null)
                yield return current;
        }


        public static IEnumerable<GitRemoteRef> RemoteRefs() {
            return Execute("git for-each-ref '--format=%(objectname) %(refname)' refs/remotes/*/*")
                .Skip(1)
                .Select(l => new GitRemoteRef(l.Substring(0, 40), l.Substring(41)));
        }

        public static IEnumerable<GitRef> Refs(string match) {
            var res =
                Execute(
                    $"git for-each-ref '--format=%(refname)' '--sort=\"refname:strip=3\"' 'refs/heads/{match}*' 'refs/heads/{match}*/**'");
            foreach (var line in res)
                yield return new GitRef(line.Substring(0, 40), line.Substring(41));
        }

        public static IEnumerable<GitRef> Remotes(string match) {
            var res =
                Execute(
                    $"git for-each-ref '--format=%(refname)' '--sort=\"refname:strip=3\"' 'refs/heads/{match}*' 'refs/heads/{match}*/**'");
            foreach (var line in res)
                yield return new GitRef(line.Substring(0, 40), line.Substring(41));
        }

        public static IEnumerable<string> Heads(string match) {
            var heads =
                Execute(
                        $"git for-each-ref '--format=%(refname:strip=2)' 'refs/heads/{match}*' 'refs/heads/{match}*/**'")
                    .Distinct()
                    .ToArray();
            Array.Sort(heads);
            return heads;
        }

        public static IEnumerable<string> Tags(string match) {
            var heads =
                Execute($"git for-each-ref '--format=%(refname:strip=2)' 'refs/tags/{match}*' 'refs/tags/{match}*/**'")
                    .ToArray();
            Array.Sort(heads);
            return heads;
        }

        public static IEnumerable<string> Files(string match) {
            return Execute($"git ls-files --exclude-standard {match}*");
        }

        public static IEnumerable<string> CommitableFiles(string match) {
            return Execute("git diff-index --name-only --relative HEAD");
        }

        public static IEnumerable<GitLog> Log(int count = 50) {
            return Execute($"git log --oneline -{count}").Select(l => new GitLog(l.Substring(0, 8), l.Substring(9)));
        }

        //public static IEnumerable<GitRef> Branches
    }
}