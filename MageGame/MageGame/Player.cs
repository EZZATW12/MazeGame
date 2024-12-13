using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageGame
{
    public class Player : IMazeObject
    {
        public int x, y;
        public char icon { get => '@'; }
        public bool is_block { get => true; }
    }
}
