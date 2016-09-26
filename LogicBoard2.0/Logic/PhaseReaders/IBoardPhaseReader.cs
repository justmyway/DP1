using LogicBoard2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicBoard2._0.Logic.PhaseReaders
{
    internal interface IBoardPhaseReader
    {
        Circuit ReadLine(Circuit circuit, string[] circuitLine);
        IBoardPhaseReader NextPhase();
    }
}
