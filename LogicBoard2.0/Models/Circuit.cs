using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicBoard2._0.Models.Nodes;
using LogicBoard2._0.Logic;
using LogicBoard2._0.Models.Nodes.Components.SingleEntrees;
using LogicBoard2._0.Visitors;

namespace LogicBoard2._0.Models
{
    class Circuit
    {
        private List<Node> components;
        private List<Node> _inputs;
        private List<Node> _outputs;

        public bool Valid { get {
                if (_valideded)
                    return _valide;

                return Validate();
            }
        }
        private bool _valide;
        private bool _valideded;

        public List<Node> Inputs { get { return _inputs; } }

        public Circuit() {
            components = new List<Node>();
            _inputs = new List<Node>();
            _outputs = new List<Node>();
            _valideded = false;
        }

        public void AddNode(Node newNode)
        {
            components.Add(newNode);
            if (newNode.GetType() == typeof(Probe))
            {
                if (newNode.Value == Current.notSet)
                {
                    _outputs.Add(newNode);
                }
                else
                {
                    _inputs.Add(newNode);
                }
            }
        }

        public void Connect(string baseNode, string nextNode)
        {
            FindNodeByName(baseNode).BindNextNode(FindNodeByName(nextNode));

            Log.Instance.AddLogLine(string.Format("{0} is connected to {1}", nextNode, baseNode));
        }

        private Node FindNodeByName(string nodeName)
        {
            foreach (Node searchNode in components) {
                if (searchNode.Name == nodeName) return searchNode;
            }

            Log.Instance.AddErrorLogLine(string.Format("Node \"{0}\" could not be found while connecting.", nodeName));
            throw new Exception(string.Format("Node \"{0}\" could not be found.", nodeName));
        }

        public bool Validate()
        {
            NodeValidationVisitor visitor = new NodeValidationVisitor();
            _valide = true;

            foreach (Node startNode in _inputs)
            {
                VisitAllNextNodes(startNode, visitor, new List<Node>());
            }
            
            if (_valide) _valide = visitor.IsValid;
            _valideded = true;
            return _valide;  
        }

        private void VisitAllNextNodes(Node node, NodeValidationVisitor visitor, List<Node> visitedNodes) {
            if (visitedNodes.Contains(node)) {
                Log.Instance.AddErrorLogLine(string.Format("Infinite loop found, twice containing: {0}", node.Name));
                _valide = false;
                return;
            }
            node.Accept(visitor);

            visitedNodes.Add(node);

            if (!visitor.IsValid || !_valide) return;

            foreach (Node visitableNode in node.Outputs) {
                VisitAllNextNodes(visitableNode, visitor, visitedNodes);
                visitedNodes.Remove(visitableNode);
            }
        }
    }
}
