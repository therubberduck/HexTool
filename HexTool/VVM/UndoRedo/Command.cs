using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexTool.VVM.UndoRedo
{
    public class Command
    {
        public delegate void Action();

        public Action Redo { get; protected set; }
        public Action Undo { get; protected set; }

        public void Execute()
        {
            Redo();
        }
    }
}
