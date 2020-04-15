namespace PowerCode
{
    public struct GitLog
    {
        public string Commit { get; }
        public string Message { get; }

        public GitLog(string commit, string message)
        {
            Commit = commit;
            Message = message;
        }
    }
}