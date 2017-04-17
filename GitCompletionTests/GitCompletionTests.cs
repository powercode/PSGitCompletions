using System;
using System.Collections;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GitCompletionTests
{
    [TestClass]
    public class GitCompletionTests
    {
        [TestMethod]
        public void CanCompleteGitCommands()
        {
            var res = "git ".CompleteInput();
            Assert.AreEqual("add", res[0].CompletionText);
            var diff = res.First(c => c.CompletionText == "diff");
            Assert.AreEqual(diff.ToolTip, @"Show changes between the working tree and the index or a tree, changes between the index and a tree, changes between two trees, changes between two blob objects, or changes between two files on disk.");
        }

        [TestMethod]
        public void CanCompleteGitCommandPart()
        {
            var res = "git ad".CompleteInput("ad");
            Assert.AreEqual("add", res[0].CompletionText);
        }


        [TestMethod]
        public void CanCompleteGitCommandOptions()
        {
            var res = "git add ".CompleteInput();
            Assert.AreEqual("--", res[0].CompletionText);
            Assert.AreEqual("-A", res[1].CompletionText);
            Assert.AreEqual("--all", res[2].CompletionText);
        }

    }
}
