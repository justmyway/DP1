using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicBoard2._0.Models;
using LogicBoard2._0.Models.Nodes;
using LogicBoard2._0.Models.Nodes.Components.SingleEntrees;
using LogicBoard2._0.Models.Nodes.Components.MultipleEntrees;

namespace LogicBoard2._0.Logic.PhaseReaders
{
    class Phase1Reader : IBoardPhaseReader
    {
        private Dictionary<string, Node> nodes = new Dictionary<string, Node>();

        public Phase1Reader() {
            Log.Instance.AddLogLine(new string [] { "--- Reading phase 1 ---", "- Initialising all the nodes" });

            nodes.Add("INPUT_HIGH", new Probe(Current.High));
            nodes.Add("INPUT_LOW", new Probe(Current.Low));
            nodes.Add("PROBE", new Probe());

            nodes.Add("NOT", new Not());
            nodes.Add("AND", new And());
            nodes.Add("OR", new Or());
            nodes.Add("NOr", new Nor());
            nodes.Add("NAnd", new Nand());
            nodes.Add("XOr", new Xor());
        }

        public IBoardPhaseReader NextPhase()
        {
            return new Phase2Reader();
        }

        public Circuit ReadLine(Circuit circuit, string[] circuitLine)
        {
            if (nodes.ContainsKey(circuitLine[1]))
            {
                Node newNode = nodes[circuitLine[1]].getNewInstance();
                newNode.Name = circuitLine[0];
                circuit.AddNode(newNode);

                Log.Instance.AddLogLine(string.Format("Node \"{0}\" added to the circuit", newNode.Name));
            }
            else
            {
                Log.Instance.AddErrorLogLine(string.Format("Unknown component: {0} with Name: {1}", circuitLine[1], circuitLine[0]));
            }

            return circuit;
        }
    }
}
