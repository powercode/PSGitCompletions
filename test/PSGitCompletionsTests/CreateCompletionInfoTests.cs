using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GitCompletionTests {
    [TestClass]
    public class CreateCompletionInfoTests {
        [DataTestMethod]
        [DataRow("git diff ", "diff", false, false, null, null, "", false, 9)]
        [DataRow("git -P ", null, false, false, "-P", null, "", true)]
        [DataRow("git ", null, false, false, null, null, "", true)]
        [DataRow("git add ", "add", false, false, null, null)]
        [DataRow("git add -", "add", false, true, null, null, "-")]
        [DataRow("git add -A ", "add", false, false, "-A", null)]
        [DataRow("git add -- ", "add", true, false, null, null)]
        [DataRow("git -P add ", "add", false, false, null, null)]
        [DataRow("git -P ad", "ad", false, false, "-P", null, "ad", true)]
        [DataRow("git -P add --format=\"%a\" ", "add", false, false, "--format", "\"%a\"")]
        public void CanParseCompletionInfo(string command, string commandName, bool afterDoubleDash, bool isCompletingParameterName, string? previousParameterName, string? previousParameterValue, string wordToComplete="", bool isCompletingCommand = false, int cursorPosition = -1)
        {
            var res = command.CreateCompleteCommandParameters();
            Assert.AreEqual(commandName, res.CommandName, "Expected same command name");
            Assert.AreEqual(afterDoubleDash, res.AfterDoubleDash, "Expected correct AfterDoubleDash");
            Assert.AreEqual(isCompletingParameterName, res.IsCompletingParameterName, "Expected correct IsCopmpletingParameterName");
            Assert.AreEqual(previousParameterName, res.PreviousParameterName, "Expected correct PreviousParameterName");
            Assert.AreEqual(previousParameterValue, res.PreviousParameterValue, "Expected correct PreviousParameterValue");
            Assert.AreEqual(wordToComplete, res.WordToComplete, "Expected correct WordToComplete");
            Assert.AreEqual(isCompletingCommand, res.IsCompletingCommand, "Expected correct IsCompletingCommand");
            if (cursorPosition > 0) {
                Assert.AreEqual(cursorPosition, res.CursorPosition,"Expected correct IsCompletingCommand");
            }
        }
    }
}