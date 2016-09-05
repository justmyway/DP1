using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_board.Model
{
    abstract class Node
    {
        private string _name;
        protected List<Node> input = new List<Node>();
        protected List<Node> output = new List<Node>();

        public Node()
        {
        }

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

        public Current Value { get; set; }

        public abstract Node getNewInstance();

        public abstract void ConnectToPreviousNode(Node previousNode);
        public void ConnectToNextNode(Node nextNode) {
            output.Add(nextNode);
        }
    }
}
