using System;
using System.Collections;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerCode;

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
            var diff = res.FirstOrDefault(c => c.CompletionText == "diff");
            Assert.IsNotNull(diff);
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

        [TestMethod]
        public void CanCompleteGitDiffOptions()
        {
            using (new GitExecuterScope(Git.GitExecuter))
            {
                Git.GitExecuter = GetGitLog;
                var res = "git diff ".CompleteInput();
                Assert.AreEqual("afcff36f", res[0].CompletionText);
                Assert.AreEqual("Moving CurrentTypeDefinitionAst to TypeInferenceContext", res[4].ToolTip);
            }
        }

        string[] GetGitLog(string command)
        {
            return new[]
            {
                "afcff36f adding resharper settings to gitignore",
                "2a9ace83 Adding tests and fixing issues",
                "8e2a3ad3 Changing completion tests to distinguish between tests where the expected results are just a subset and those where all results are expected.",
                "21175387 Enabling TypeInference use of runtime SafeExprEval for completion",
                "2f74cd0a Moving CurrentTypeDefinitionAst to TypeInferenceContext",
                "48e07bf6 Replace CompletionExecutionHelper with PowerShellExecutionHelper",
                "6f02a0aa Removing the Ast.GetInferredType virtual methods from all ASTs",
                "51253d25 Adding TypeInferenceVisitor with methods transformed from Ast.GetInferredType",
                "06020f34 Fix New-Item to create correct symlink type (#2915) (#3509)",
                "2851f7e8 Accept `-i` for an interactive shell (#3558)",
                "47ec6b2a Use IntPtr(-1) for INVALID_HANDLE_VALUE instead of IntPtr.Zero (#3544)",
                "4ad4b194 Convert tab indentations to spaces in *.cs files (#3551)",
                "acec58c0 Make the output of $PSVersionTable in alphabetical order (#3530)",
                "f0c0176a Typo in Format-Hex (#3539)",
                "35168721 Use /bin/bash, fixes #3525",
                "8d4db01a Add sudo for adding cert for OpenSUSE (#3524)",
                "68bcd4b5 Removed trailing whitespace (#3485)",
                "18c28f8f Fix markdown lint issues for SSH Remoting demo and enable related tests (#3484)",
                "4697dd2b Adding public ValidRootDrives property to ValidateDrive (#3510)",
                "753b1965 Fix crash at startup when env:HOME not set (#3437)"
            };
        }

    }
}
