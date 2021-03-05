namespace PowerCode
{
    public struct GitRemote
    {
        public string Commit { get; }
        public string Name { get; }

        public GitRemote(string commit, string name)
        {
            Commit = commit;
            Name = name;
        }
    }
}