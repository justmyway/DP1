using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_board.Model
{
    class Probe : SingleEntreeNode
    {
        public override Node getNewInstance()
        {
            return new Probe(Value);
        }

        public Probe(Current startCurrent) {
            Value = startCurrent;
        }
    }
}
