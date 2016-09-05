using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_board.Model
{
    abstract class MultipleEntreeNode : Node
    {
        public override void ConnectToPreviousNode(Node previousNode)
        {
            if (input.Count < 2)
            {
                input.Add(previousNode);
                previousNode.ConnectToNextNode(this);
            }
            else
            {
                throw new Exception(String.Format("Circuit incorrect!!! \n \"{0}\" already got 2 connection form \"{1}\" and \"{2}\" \n \"{3}\" trying to connect aswell!", Name, input[0].Name, input[1].Name, previousNode.Name));
            }
        }
    }
}
