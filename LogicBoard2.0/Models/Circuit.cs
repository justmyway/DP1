using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicBoard2._0.Models.Nodes;

namespace LogicBoard2._0.Models
{
    class Circuit
    {
        private List<Node> components;

        public Circuit() {
            components = new List<Node>();
        }

        public void AddNode(Node newNode)
        {
            components.Add(newNode);
        }
    }
}
