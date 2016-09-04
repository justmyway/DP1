using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_board.Model.Components
{
    class Not : LogicComponent
    {
        public override Node getNewInstance()
        {
            return new Not();
        }

        public Not() {
            Value = Current.notSet;
        }
    }
}
