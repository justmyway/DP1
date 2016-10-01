using LogicBoard2._0.Logic.PhaseReaders;
using LogicBoard2._0.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicBoard2._0.Logic
{
    class BoardReader
    {
        private Circuit circuit;
        private BoardPhaseReader phaseReader;

        public BoardReader() {
            phaseReader = new BoardPhaseReader();
        }

        public Circuit Compile(string logicCircuit)
        {
            if (logicCircuit.Length == 0) {
                Log.Instance.AddErrorLogLine("No circuit found to render!");
                return new Circuit();
            }

            circuit = new Circuit();
            phaseReader.ReadNewCircuit();

            using (StringReader sr = new StringReader(logicCircuit))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                    circuit = phaseReader.ReadLine(circuit, line);
                
            }

            Log.Instance.AddLogLine("--- Circuit renderd success full ---");

            if (circuit.Validate())
            {
                Log.Instance.AddLogLine("--- Circuit is valid and ready to run ---");
            }

            return circuit;
        }
    }
}
