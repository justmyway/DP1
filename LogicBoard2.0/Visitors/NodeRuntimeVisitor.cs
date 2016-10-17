using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicBoard2._0.Models.Nodes.Components.MultipleEntrees;
using LogicBoard2._0.Models.Nodes.Components.SingleEntrees;
using LogicBoard2._0.Models.Nodes;
using LogicBoard2._0.Logic;

namespace LogicBoard2._0.Visitors
{
    class NodeRuntimeVisitor : Visitor
    {
        public override void Visit(Or or)
        {
            throw new NotImplementedException();
        }

        public override void Visit(Not not)
        {
            throw new NotImplementedException();
        }

        public override void Visit(Probe probe)
        {
            throw new NotImplementedException();
        }

        public override void Visit(And or)
        {
            throw new NotImplementedException();
        }

        public override void VisitMultiple(MultipleEntreeNode multipleEntreeNode)
        {
            throw new NotImplementedException();
        }

        public override void VisitSingle(SingleEntreeNode singleEntreeNode)
        {
            throw new NotImplementedException();
        }
    }
}
