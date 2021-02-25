using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Language;
using PowerCode;

namespace GitCompletionTests
{
    static class CompletionTestExtensions
    {
        public static IList<CompletionResult> CompleteInput(this string str) => str.CompleteInput(str.Length);
        public static IList<CompletionResult> CompleteInput(this string str, int cursorPosition)
        {
            var (wordToComplete, ast) = GetData(str, cursorPosition);
            return GitCompleter.CompleteInput(wordToComplete, ast, cursorPosition);
        }

        public static CompleteCommandParameters CreateCompleteCommandParameters(this string str) => CreateCompleteCommandParameters(str, str.Length);

        public static CompleteCommandParameters CreateCompleteCommandParameters(this string str, int cursorPosition) {
            var (wordToComplete, ast) = GetData(str, cursorPosition);
            return CompleteCommandParameters.Create(wordToComplete, ast, cursorPosition);
        }

        static (string wordToComplete, CommandAst ast) GetData(string str, int cursorPosition) {
            var ast = Parser.ParseInput(str, out Token[] _, out ParseError[] _);
            var endBlockStatement = (CommandAst)((PipelineAst)ast.EndBlock.Statements[0]).PipelineElements[0];
            var commandElement = endBlockStatement.CommandElements.Last(c => c.Extent.EndOffset <= cursorPosition);
            var wordToComplete = cursorPosition == commandElement.Extent.EndOffset ? commandElement.Extent.Text : string.Empty;
            return (wordToComplete, endBlockStatement);
        }
    }
}