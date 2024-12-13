using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageGame
{
    internal class EmptySpace : IMazeObject
    {
        public char icon { get => ' '; }
        public bool is_block { get => false; }
    }
}
