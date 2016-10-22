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
        public abstract bool VisitSingle(SingleEntreeNode singleEntreeNode);
        public abstract bool VisitMultiple(MultipleEntreeNode multipleEntreeNode);
        public abstract bool Visit(And and);
        public abstract bool Visit(Nand nand);
        public abstract bool Visit(Or or);
        public abstract bool Visit(Nor nor);
        public abstract bool Visit(Xor xor);
        public abstract bool Visit(Not not);
        public abstract bool Visit(Probe probe);
    }
}
