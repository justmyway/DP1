using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_board.Model
{
    abstract class Node
    {
        string _name;
        List<Node> input = new List<Node>();
        List<Node> output = new List<Node>();

        public Node() {
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public abstract Node getNewInitial();
    }
}
