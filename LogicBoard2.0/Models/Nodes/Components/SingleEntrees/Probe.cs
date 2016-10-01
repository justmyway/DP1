using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicBoard2._0.Visitors;

namespace LogicBoard2._0.Models.Nodes.Components.SingleEntrees
{
    class Probe : SingleEntreeNode
    {
        public override Node getNewInstance()
        {
            return new Probe(Value);
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public Probe(Current startCurrent = Current.notSet)
        {
            Value = startCurrent;
        }
    }
}
