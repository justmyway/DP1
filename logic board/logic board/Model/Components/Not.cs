﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_board.Model.Components
{
    class Not : Component
    {
        public override Node getNewInitial()
        {
            return new Not();
        }
    }
}
