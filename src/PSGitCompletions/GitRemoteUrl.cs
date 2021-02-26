namespace PowerCode {
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
}