using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;

namespace PowerCode
{
    public struct GitExecuterScope : IDisposable {
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

public class GitRemote
    {
        public string Name { get; }
        public string FetchUrl { get; set; }
        public string PushUrl { get; set; }

        public GitRemote(string name)
        {
            Name = name;
        }
    }
    public class Git
    {

        public static Func<string, IEnumerable<string>> GitExecuter = GitExecute;

        private static IEnumerable<string> Execute(string command)
        {
            return GitExecuter(command);
        }

        private static IEnumerable<string> GitExecute(string command)
        {
            using (var ps = PowerShell.Create(RunspaceMode.CurrentRunspace))
            {
                ps.AddScript(command);
                return ps.Invoke<string>();
            }
        }

        public static IEnumerable<GitRemote> Remotes()
        {
            var res = Execute("git remove -v");
            GitRemote current = null;
            foreach (string line in res)
            {
                var parts = line.Split('\t');
                var name = parts[0];
                var uri = parts[1];
                if (current == null)
                {
                    current = new GitRemote(name);
                }


                if (current.Name != name)
                {
                    yield return current;
                    current = new GitRemote(name);
                }
                if (uri.EndsWith("(fetch)"))
                {
                    current.FetchUrl = uri;
                }
                else
                {
                    current.PushUrl = uri;
                }
            }
            if (current != null)
            {
                yield return current;
            }
        }

        public static IEnumerable<GitRef> Refs(string match)
        {
            var res = Execute($"git for-each-ref '--format=%(refname)' '--sort=\"refname:strip=3\"' 'refs/heads/{match}*' 'refs/heads/{match}*/**'");
            foreach (string line in res)
            {
                yield return new GitRef(line.Substring(0, 40), line.Substring(41));
            }
        }

        public static IEnumerable<string> Heads(string match)
        {
            var heads = Execute($"git for-each-ref '--format=%(refname:strip=2)' 'refs/heads/{match}*' 'refs/heads/{match}*/**'").Distinct().ToArray();
            Array.Sort(heads);
            return heads;
        }

        public static IEnumerable<string> Tags(string match)
        {
            var heads = Execute($"git for-each-ref '--format=%(refname:strip=2)' 'refs/tags/{match}*' 'refs/tags/{match}*/**'").ToArray();
            Array.Sort(heads);
            return heads;
        }

        public static IEnumerable<string> Files(string match)
        {
            return Execute($"git ls-files --exclude-standard {match}*");
        }
        public static IEnumerable<string> CommitableFiles(string match)
        {
            return Execute("git diff-index --name-only --relative HEAD");
        }

        public static IEnumerable<GitLog> Log(int count = 50)
        {
            return Execute($"git log --oneline -{count}").Select(l =>new GitLog(l.Substring(0,8), l.Substring(9)));

        }
    }
}