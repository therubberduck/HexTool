using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexTool.VVM.UndoRedo
{
    public class CommandHandler
    {
        private readonly Stack<Command> _undoCommands = new Stack<Command>();
        private readonly Stack<Command> _redoCommands = new Stack<Command>();

        public void Execute(Command command)
        {
            _undoCommands.Push(command);
            _redoCommands.Clear();
            command.Execute();
        }

        public void Undo()
        {
            if (_undoCommands.Count == 0)
            {
                return;
            }
            var lastCommand = _undoCommands.Pop();
            lastCommand.Undo();
            _redoCommands.Push(lastCommand);
        }

        public void Redo()
        {
            if (_redoCommands.Count == 0)
            {
                return;
            }
            var nextCommand = _redoCommands.Pop();
            nextCommand.Redo();
            _undoCommands.Push(nextCommand);
        }
    }
}
