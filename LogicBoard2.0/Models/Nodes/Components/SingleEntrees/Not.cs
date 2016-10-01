﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicBoard2._0.Visitors;

namespace LogicBoard2._0.Models.Nodes.Components.SingleEntrees
{
    class Not : SingleEntreeNode
    {
        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public override Node getNewInstance()
        {
            return new Not();
        }
    }
}
