using System.Collections.Generic;
using System.Management.Automation;
using System.Management.Automation.Language;
using PowerCode;

namespace GitCompletionTests
{
    static class CompletionTestExtensions
    {
        public static IList<CompletionResult> CompleteInput(this string str, string wordToComplete, int cursorPosition)
        {
            var ast = Parser.ParseInput(str, out Token[] _, out ParseError[] _);
            var endBlockStatement = (CommandAst) ((PipelineAst) ast.EndBlock.Statements[0]).PipelineElements[0];
            return GitCompleter.CompleteInput(wordToComplete, endBlockStatement, cursorPosition);
        }

        public static IList<CompletionResult> CompleteInput(this string str, string wordToComplete) => str.CompleteInput(wordToComplete, str.Length);

        public static IList<CompletionResult> CompleteInput(this string str) => str.CompleteInput("", str.Length);
    }
}