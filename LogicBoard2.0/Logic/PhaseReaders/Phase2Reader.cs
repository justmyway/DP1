using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicBoard2._0.Models;

namespace LogicBoard2._0.Logic.PhaseReaders
{
    class Phase2Reader : IBoardPhaseReader
    {
        public Phase2Reader()
        {
            Log.Instance.AddLogLine(new string[] { "--- Reading phase 2 ---", "- Connecting all the nodes" });
        }

        public IBoardPhaseReader NextPhase()
        {
            Log.Instance.AddLogLine(new string[] { "--- WARNING ---", "- Found a second empty line", "- Comping continues" });
            return this;
        }

        public Circuit ReadLine(Circuit circuit, string[] circuitLine)
        {
            //todo: write code to connect
            Log.Instance.AddLogLine(circuitLine);



            return circuit;
        }

        private string[] splitConnectLine(string connectLine)
        {
            return connectLine.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
