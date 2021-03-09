using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
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
            var res = Execute($"git for-each-ref '--format=%(objectname:short=7)%00%(objecttype)%00%(refname:lstrip=2)%00%(subject)' 'refs/*/{match}*'");
            foreach (var line in res)
            {
                var parts = line.Split('\0');
                if (parts.Length != 4) yield break;

                var objectType = parts[1] switch
                {
                    "blob" => GitObjectType.Blob,
                    "tree" => GitObjectType.Tree,
                    "commit" => GitObjectType.Commit,
                    "tag" => GitObjectType.Tag,
                    var invalidType => throw new BadOutputException($"Git ref has an invalid object type '{invalidType}'")
                };

                yield return new GitRef(parts[0], objectType, parts[2], parts[3]);
            }
        }

        public static IEnumerable<GitRemote> Remotes(string match)
        {
            var res = Execute($"git for-each-ref '--format=%(refname)' '--sort=\"refname:strip=3\"' 'refs/heads/{match}*' 'refs/heads/{match}*/**'");
            foreach (var line in res) yield return new GitRemote(line.Substring(0, 40), line[41..]);
        }

        public static IEnumerable<GitHead> Heads(string match)
        {
            var heads = Execute($"git for-each-ref '--format=%(refname:strip=2)%00%(subject)' 'refs/heads/{match}*' 'refs/heads/{match}*/**'").Distinct().ToArray();
            Array.Sort(array: heads);
            return heads.Select(s => {
                var parts = s.Split('\0');
                return new GitHead(parts[0], parts[1]);
            });
        }

        public static IEnumerable<GitBranchDescription> BranchDescriptions() {
            var heads = Execute(@"git config --local --null --get-regex branch\..+?\.description");

            string? branchName = null;
            var builder = new StringBuilder(256);
            foreach (var head in heads) {
                if (branchName  == null) {
                    branchName  = head[7..^12]; // strip initial "branch." and trailing ".description'
                }
                else
                {
                    if (head.EndsWith('\0')) {
                        builder.Append(head[..^1]);
                        yield return new GitBranchDescription(branchName, builder.ToString());
                        builder.Clear();
                        branchName  = null;
                    }
                    else
                    {
                        builder.AppendLine(head);
                    }
                }
            }
        }

        public static IEnumerable<string> GetDiffableFiles(string? match, string? fromCommit, string? toCommit, bool cached = false) => Execute($"git diff --name-only {(cached ? "--cached " : "" )}{fromCommit} {toCommit} -- {match}*");

        public static IEnumerable<string> LsFiles(string match) => Execute($"git ls-files -- {match}");

        public static IEnumerable<string> Tags(string match)
        {
            var heads = Execute($"git for-each-ref '--format=%(refname:strip=2)' 'refs/tags/{match}*' 'refs/tags/{match}*/**'").ToArray();
            Array.Sort(array: heads);
            return heads;
        }

        public static IEnumerable<string> Files(string match) => Execute($"git ls-files --exclude-standard {match}*");

        public static IEnumerable<string> CommitableFiles(string match) => Execute("git diff-index --name-only --relative HEAD");

        public static IEnumerable<GitLog> Log(string? commit = null, int count = 50) => Execute($"git log --oneline -{count} {commit}").Select(l => new GitLog(l[..7], l[8..]));

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

        public static IEnumerable<string> GetCommitFiles(string? commit) {
            return commit is null ? Enumerable.Empty<string>() : Execute($"git diff {commit}~1 {commit} --name-only").ToArray();
        }

        public class BadOutputException : Exception
        {
            public BadOutputException(string message) : base(message) { }
        }
    }

    public record GitHead (string Name, string Subject);

    public record GitBranchDescription(string Name, string Description);

}