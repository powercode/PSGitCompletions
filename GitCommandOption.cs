namespace PowerCode
{
    public class GitCommandOption
    {
        public string Completion { get; }
        public string ListText { get; }

        public string ToolTip { get; }

        public GitCommandOption(string completion, string listText, string toolTip)
        {
            Completion = completion;
            ListText = listText;
            ToolTip = toolTip;
        }
    }
}