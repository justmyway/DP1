using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_board.Model.Components
{
    class Or : LogicComponent
    {
        public override Node getNewInstance()
        {
            return new Or();
        }
    }
}
