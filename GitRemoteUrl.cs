namespace PowerCode {
    public class GitRemoteUrl {
        public GitRemoteUrl(string name) {
            Name = name;
        }

        public string Name { get; }
        public string FetchUrl { get; set; }
        public string PushUrl { get; set; }
    }
}