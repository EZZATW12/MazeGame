using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageGame
{
    public interface IMazeObject
    {
        public char icon { get;  }
        public bool is_block { get;  }
    }
}
