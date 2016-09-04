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
    }
}
