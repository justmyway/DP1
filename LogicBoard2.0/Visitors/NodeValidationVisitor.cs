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
    class NodeValidationVisitor : NodeValidationVisitorHandler
    {
        private bool _isValid = true;
        public bool IsValid { get { return _isValid; } }

        public override void VisitSingle(SingleEntreeNode singlenode)
        {
            CheckAmountInputNodes(singlenode, 1);
            CheckAmountOutputNodesNotNull(singlenode);
        }

        public override void VisitMultiple(MultipleEntreeNode multipeNode)
        {
            CheckAmountInputNodes(multipeNode, 2);
            CheckAmountOutputNodesNotNull(multipeNode);
        }

        public override void Visit(Probe probe)
        {
            if (probe.Value == Current.notSet)
            {
                CheckAmountInputNodes(probe, 1);
                CheckAmountOutputNodes(probe, 0);
            }
            else
            {
                CheckAmountInputNodes(probe, 0);
                CheckAmountOutputNodesNotNull(probe);
            }
        }

        private void CheckAmountInputNodes(Node node, int amount) {
            if (node.Inputs.Count != amount) {
                _isValid = false;
                Log.Instance.AddErrorLogLine(string.Format("{0} has {1} input nodes, there supposed to be {2}", node.Name, node.Inputs.Count.ToString(), amount.ToString()));
            }
        }

        private void CheckAmountOutputNodes(Node node, int amount)
        {
            if (node.Outputs.Count != amount)
            {
                _isValid = false;
                Log.Instance.AddErrorLogLine(string.Format("{0} has {1} output nodes, there supposed to be {2}", node.Name, node.Outputs.Count.ToString(), amount.ToString()));
            }
        }

        private void CheckAmountOutputNodesNotNull(Node node)
        {
            if (node.Outputs.Count == 0)
            {
                _isValid = false;
                Log.Instance.AddErrorLogLine(string.Format("{0} has 0 output nodes, there supposed to be at leased one", node.Name));
            }
        }
    }
}
