using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicBoard2._0.Models;

namespace LogicBoard2._0.Logic.PhaseReaders
{
    class BoardPhaseReader
    {
        private IBoardPhaseReader phaseReader;

        public void ReadNewCircuit()
        {
            phaseReader = new Phase1Reader();
        }

        public Circuit ReadLine(Circuit circuit, string circuitLine)
        {
            // at empty line ask the next phase
            if (circuitLine.Length == 0 || circuitLine == Environment.NewLine)
            {
                phaseReader = phaseReader.NextPhase();
                return circuit;
            }

            // no need for commends
            if (circuitLine[0] == '#') 
                return circuit;
            
            string[] sanitizedParts = SanitizeAndSplitLine(circuitLine);
            circuit = phaseReader.ReadLine(circuit, sanitizedParts);

            return circuit;
        }

        private string[] SanitizeAndSplitLine(string line)
        {
            char tab = '\u0009';
            line = line.Replace(tab.ToString(), "");

            return line.Trim(new char[] { ' ', '\t' }).Split(new char[] { ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
        }


    }
}
