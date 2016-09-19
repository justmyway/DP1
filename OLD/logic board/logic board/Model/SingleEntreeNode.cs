using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_board.Model
{
    abstract class SingleEntreeNode : Node
    {
        public override void ConnectToPreviousNode(Node previousNode)
        {
            if (input.Count < 1)
            {
                input.Add(previousNode);
                previousNode.ConnectToNextNode(this);
            }
            else
            {
                throw new Exception(String.Format("Circuit incorrect!!! \n \"{0}\" already got 1 connection form \"{1}\" \n \"{2}\" trying to connect aswell!", Name, input[0].Name, previousNode.Name));
            }
        }
    }
}
