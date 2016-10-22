using LogicBoard2._0.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicBoard2._0.Models.Nodes
{
    abstract class Node
    {
        private string _name;
        protected List<Node> _inputs = new List<Node>();
        protected List<Node> _outputs = new List<Node>();

        public List<Node> Inputs { get { return _inputs; } }
        public List<Node> Outputs { get { return _outputs; } }

        public Current Value { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length > 0)
                {
                    _name = value.ToString();
                }
                else
                {
                    throw new Exception("Name to short");
                }
            }
        }

        public abstract Node getNewInstance();

        public abstract bool Accept(Visitor visitor);

        public void BindNextNode(Node nextNode)
        {
            _outputs.Add(nextNode);
            nextNode.PreviousNode(this);
        }

        public void PreviousNode(Node previousNode)
        {
            _inputs.Add(previousNode);
        }
    }
}
