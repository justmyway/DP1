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
        public override bool Visit(Or or)
        {
            if (VisitMultiple(or))
            {
                if (or.Inputs[0].Value == Current.Low && or.Inputs[1].Value == Current.Low)
                {
                    or.Value = Current.Low;
                }
                else
                {
                    or.Value = Current.High;
                }

                return true;
            }
            return false;
        }

        public override bool Visit(Not not)
        {
            if (VisitSingle(not))
            {
                if (not.Inputs[0].Value == Current.High)
                {
                    not.Value = Current.Low;
                }
                else
                {
                    not.Value = Current.High;
                }

                return true;
            }
            return false;
        }

        public override bool Visit(Nand nand)
        {
            if (VisitMultiple(nand))
            {
                if (nand.Inputs[0].Value == Current.High && nand.Inputs[1].Value == Current.High)
                {
                    nand.Value = Current.Low;
                }
                else
                {
                    nand.Value = Current.High;
                }

                return true;
            }
            return false;
        }

        public override bool Visit(Xor xor)
        {
            if (VisitMultiple(xor))
            {
                if (xor.Inputs[0].Value == xor.Inputs[1].Value)
                {
                    xor.Value = Current.Low;
                }
                else
                {
                    xor.Value = Current.High;
                }

                return true;
            }
            return false;
        }

        public override bool Visit(Nor nor)
        {
            if (VisitMultiple(nor))
            {
                if (nor.Inputs[0].Value == Current.Low && nor.Inputs[1].Value == Current.Low)
                {
                    nor.Value = Current.High;
                }
                else
                {
                    nor.Value = Current.Low;
                }

                return true;
            }
            return false;
        }

        public override bool Visit(Probe probe)
        {
            if (probe.Inputs.Count == 0)
            {
                return true;
            }
            else
            {
                if (probe.Inputs[0].Value != Current.NotSet) {
                    probe.Value = probe.Inputs[0].Value;
                    return true;
                }
                return false;
            }
        }

        public override bool Visit(And and)
        {
            if (VisitMultiple(and))
            {
                if (and.Inputs[0].Value == Current.High && and.Inputs[1].Value == Current.High)
                {
                    and.Value = Current.High;
                }
                else
                {
                    and.Value = Current.Low;
                }

                return true;
            }
            return false;
        }

        public override bool VisitMultiple(MultipleEntreeNode multipleEntreeNode)
        {
            foreach (Node input in multipleEntreeNode.Inputs) {
                if (input.Value == Current.NotSet) return false;
            }
            return true;
        }

        public override bool VisitSingle(SingleEntreeNode singleEntreeNode)
        {
            foreach (Node input in singleEntreeNode.Inputs)
            {
                if (input.Value == Current.NotSet) return false;
            }
            return true;
        }
    }
}
