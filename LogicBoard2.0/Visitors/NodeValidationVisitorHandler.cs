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
        public override bool Visit(And and)
        {
            return this.VisitMultiple(and);
        }

        public override bool Visit(Nand nand)
        {
            return this.VisitMultiple(nand);
        }

        public override bool Visit(Not not)
        {
            return this.VisitSingle(not);
        }

        public override bool Visit(Or or)
        {
            return this.VisitMultiple(or);
        }

        public override bool Visit(Nor nor)
        {
            return this.VisitMultiple(nor);
        }

        public override bool Visit(Xor xor)
        {
            return this.VisitMultiple(xor);
        }
    }
}
