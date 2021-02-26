using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading;

namespace PowerCode
{
    public class Git
    {
        public static Func<string, IEnumerable<string>> GitExecuter { get; set; } = GitExecute;

        private static IEnumerable<string> Execute(string command) => GitExecuter(arg: command);

        private static IEnumerable<string> GitExecute(string command)
        {
            using var ps = PowerShell.Create(runspace: RunspaceMode.CurrentRunspace);
            ps.AddScript(script: command);
            return ps.Invoke<string>();
        }

        public static IEnumerable<GitRemoteUrl> Remotes()
        {
            var res = Execute("git remote -v");
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
                .Select(l => new GitRemoteRef(l.Substring(0, 40), l[41..]));
        }

        public static IEnumerable<GitStatus> Status() => Execute("git status --porcelain").Select(GitStatusParser.FromStatusString);

        public static IEnumerable<GitRef> Refs(string match)
        {
            var res = Execute($"git for-each-ref '--format=%(refname)' '--sort=\"refname:strip=3\"' 'refs/heads/{match}*' 'refs/heads/{match}*/**'");
            foreach (var line in res) yield return new GitRef(line[.. 40], line[41..]);
        }

        public static IEnumerable<GitRef> Remotes(string match)
        {
            var res = Execute($"git for-each-ref '--format=%(refname)' '--sort=\"refname:strip=3\"' 'refs/heads/{match}*' 'refs/heads/{match}*/**'");
            foreach (var line in res) yield return new GitRef(line.Substring(0, 40), line[41..]);
        }

        public static IEnumerable<string> Heads(string match)
        {
            var heads = Execute($"git for-each-ref '--format=%(refname:strip=2)' 'refs/heads/{match}*' 'refs/heads/{match}*/**'").Distinct().ToArray();
            Array.Sort(array: heads);
            return heads;
        }

        public static IEnumerable<string> GetDiffableFiles(string? match, string? fromCommit, string? toCommit, bool cached = false) => Execute($"git diff --name-only {(cached ? "--cached" : "" )} {fromCommit} {toCommit} -- {match}*");

        public static IEnumerable<string> LsFiles(string match) => Execute($"git ls-files -- {match}");

        public static IEnumerable<string> Tags(string match)
        {
            var heads = Execute($"git for-each-ref '--format=%(refname:strip=2)' 'refs/tags/{match}*' 'refs/tags/{match}*/**'").ToArray();
            Array.Sort(array: heads);
            return heads;
        }

        public static IEnumerable<string> Files(string match) => Execute($"git ls-files --exclude-standard {match}*");

        public static IEnumerable<string> CommitableFiles(string match) => Execute("git diff-index --name-only --relative HEAD");

        public static IEnumerable<GitLog> Log(int count = 50) => Execute($"git log --oneline -{count}").Select(l => new GitLog(l.Substring(0, 7), l[9..]));

        public static IList<(string alias, string command, string parameters)> GetAliases(string name) {
            return Execute($"git config --get-regex ^alias\\.{name}")
                .Select(t => {
                    var aliasEnd = t.IndexOf(" ", StringComparison.Ordinal);
                    var commandEnd =  t.IndexOf(" ", aliasEnd + 1, StringComparison.Ordinal);
                    if (commandEnd == -1) {
                        commandEnd = t.Length;
                    }

                    var paramStart = commandEnd + 1;
                    var parameters = paramStart >= t.Length ? "" : t[paramStart..];

                    var alias = t[6..aliasEnd];
                    var command = t[(aliasEnd + 1)..commandEnd];
                    return (alias, command, parameters);
                }).ToList();
        }
    }
}