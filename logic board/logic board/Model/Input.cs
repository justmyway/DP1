using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_board.Model
{
    class Input : Node
    {
        public override Node getNewInitial()
        {
            return new Input();
        }
    }
}
