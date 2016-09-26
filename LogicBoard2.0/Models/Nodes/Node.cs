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
    }
}
