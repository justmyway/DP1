using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicBoard2._0.Models.Nodes.Components.MultipleEntrees;
using LogicBoard2._0.Models.Nodes.Components.SingleEntrees;
using LogicBoard2._0.Logic;

namespace LogicBoard2._0.Visitors
{
    abstract class NodeValidationVisitorHandler : Visitor
    {
        public override void Visit(And and)
        {
            this.VisitMultiple(and);
        }

        public override void Visit(Not not)
        {
            this.VisitSingle(not);
        }

        public override void Visit(Or or)
        {
            this.VisitMultiple(or);
        }
    }
}
