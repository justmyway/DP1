using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicBoard2._0.Models.Nodes.Components.MultipleEntrees;
using LogicBoard2._0.Models.Nodes.Components.SingleEntrees;
using LogicBoard2._0.Models.Nodes;

namespace LogicBoard2._0.Visitors
{
    abstract class Visitor
    {
        public abstract void VisitSingle(SingleEntreeNode singleEntreeNode);
        public abstract void VisitMultiple(MultipleEntreeNode multipleEntreeNode);
        public abstract void Visit(And or);
        public abstract void Visit(Or or);
        public abstract void Visit(Not not);
        public abstract void Visit(Probe probe);
    }
}
