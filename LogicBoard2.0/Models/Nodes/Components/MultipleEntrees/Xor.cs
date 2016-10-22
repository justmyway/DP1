using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicBoard2._0.Visitors;

namespace LogicBoard2._0.Models.Nodes.Components.MultipleEntrees
{
    class Xor : MultipleEntreeNode
    {
        public override bool Accept(Visitor visitor)
        {
            return visitor.Visit(this);
        }

        public override Node getNewInstance()
        {
            return new Xor();
        }
    }
}
