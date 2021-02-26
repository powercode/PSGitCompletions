using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Language;

namespace PowerCode {
    public class CompleteCommandParameters {
        public CompleteCommandParameters(CommandAst ast, int currentElementIndex, bool isCompletingCommand, string? commandName, GitCommandOption[] gitCommandOptions, string? previousParameterName,
            string? previousParameterValue, string wordToComplete, bool afterDoubleDash, int cursorPosition, bool isCompletingParameterName) {
            Ast = ast;
            CurrentElementIndex = currentElementIndex;
            IsCompletingCommand = isCompletingCommand;
            CommandName = commandName;
            GitCommandOptions = gitCommandOptions;
            PreviousParameterName = previousParameterName;
            PreviousParameterValue = previousParameterValue;
            WordToComplete = wordToComplete;
            AfterDoubleDash = afterDoubleDash;
            CursorPosition = cursorPosition;
            IsCompletingParameterName = isCompletingParameterName;
        }

        public CommandAst Ast { get; }
        public int CurrentElementIndex { get; }
        public bool IsCompletingCommand { get; }
        public string? CommandName { get; }
        public GitCommandOption[] GitCommandOptions { get; }
        public string? PreviousParameterName { get; }
        public string? PreviousParameterValue { get; }
        public string WordToComplete { get; }
        public bool AfterDoubleDash { get; }
        public int CursorPosition { get; }

        public bool IsCompletingParameterName { get; }

        public IList<(string token, int index)> GetPositionalParameters() {
            return Ast.CommandElements.Select((ce, i) => (ce.Extent.Text, i))
                .Where(t => !t.Text.StartsWith('-'))
                .SkipWhile(t => t.Text != CommandName)
                .Skip(1).ToList();
        }

        internal static CompleteCommandParameters Create(string wordToComplete, CommandAst ast, int cursorPosition)
        {
            string? previousParameterName = null;
            string? previousParameterValue = null;

            // find the git command
            var (commandElementAst, index) = ast.CommandElements.Select((command, i) => (command, i)).FirstOrDefault(ce => !ce.command.Extent.Text.StartsWith("-") && !ce.command.Extent.Text.StartsWith("git", StringComparison.OrdinalIgnoreCase));


            bool isCompletingCommand = index == 0 || cursorPosition == commandElementAst.Extent.EndOffset;


            var commandName = commandElementAst?.Extent?.Text;
            var (currentElement, currentElementIndex) = ast.CommandElements.Select((ce, i) => (ce, i))
                .FirstOrDefault(p => p.ce.Extent.StartOffset <= cursorPosition && p.ce.Extent.EndOffset >= cursorPosition);

            if (currentElementIndex == 0 && cursorPosition > ast.Extent.EndOffset)
            {
                currentElementIndex = ast.CommandElements.Count;
            }


            var dashDashIndex = ast.CommandElements.Select((ce, i) => (ce, i)).FirstOrDefault(p => p.ce.Extent.Text == "--").i;
            var afterDoubleDash = dashDashIndex > 0 && dashDashIndex < currentElementIndex;


            var prevIndex = currentElementIndex - 1;
            bool isCompletingParameterName = false;
            if (prevIndex >= 0)
                switch (ast.CommandElements[prevIndex])
                {
                    case CommandParameterAst p:
                        previousParameterName = p.ParameterName == "-" ? null : "-" + p.ParameterName;

                        break;
                    case StringConstantExpressionAst {Value: "-"} s:
                        previousParameterValue = null;
                        break;
                    case StringConstantExpressionAst sce when sce.Value.StartsWith("--"):
                        var value = sce.Extent.Text;
                        var eq = value.IndexOf("=", StringComparison.Ordinal);
                        if (eq == -1) {
                            previousParameterName = value;
                        }
                        else {
                            previousParameterName = value[..eq];
                            previousParameterValue = value[(eq + 1)..];
                        }
                        break;

                }

            isCompletingParameterName = wordToComplete.StartsWith("-");

            if (commandName is not null)
                commandName = ResolveCommandName(commandName);

            var gitCommandOptions = commandName is null ? Array.Empty<GitCommandOption>() : GitCommand.GetOptions(name: commandName);

            if (previousParameterName == "--")
            {
                afterDoubleDash = true;
                previousParameterName = null;
            }

            var completeCommandParameters = new CompleteCommandParameters(ast, currentElementIndex, isCompletingCommand, commandName, gitCommandOptions, previousParameterName, previousParameterValue, wordToComplete, afterDoubleDash, cursorPosition, isCompletingParameterName);
            return completeCommandParameters;
        }

        private static string? ResolveCommandName(string commandName) {
            var cmd = GitCommand.Commands.FirstOrDefault(c => c.Name == commandName);
            return cmd is null ? Git.GetAliases(commandName).FirstOrDefault().command : cmd.Name;
        }
    }
}