using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicBoard2._0.Models.Nodes.Components
{
    class Probe : SingleEntreeNode
    {
        public override Node getNewInstance()
        {
            return new Probe(Value);
        }

        public Probe(Current startCurrent)
        {
            Value = startCurrent;
        }
    }
}
