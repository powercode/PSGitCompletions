using System.Diagnostics;

namespace PowerCode {
    [DebuggerDisplay("{Completion}")]
    public class GitCommandOption {
        public GitCommandOption(string completion, string listText, string toolTip) {
            Completion = completion;
            ListText = listText;
            ToolTip = toolTip;
        }

        public string Completion { get; }
        public string ListText { get; }
        public string ToolTip { get; }
    }
}