using logic_board.Model;
using logic_board.Model.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_board
{
    class BoardReader
    {
        private Dictionary<string, Node> components = new Dictionary<string, Node>();
        private List<Node> circuit;

        public BoardReader() {
            components.Add("INPUT_HIGH", new Input());
            components.Add("INPUT_LOW", new Input());
            components.Add("PROBE", new Probe());

            components.Add("NOT", new Not());
            components.Add("AND", new And());
            components.Add("OR", new Or());
            //components.Add("NOr", new NOr());
            //components.Add("NAnd", new NAnd());
            //components.Add("XOr", new XOr());
        }

        public void read(String circuitDescription) {
            Console.Write("fase 1");
            Console.Write(circuitDescription);

            circuit = new List<Node>();
            int fase = 1;

            using (StringReader sr = new StringReader(circuitDescription))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == Environment.NewLine || line == "")
                    {
                        fase++;
                    }
                    else if (line[0] == '#')
                    {
                        Console.WriteLine("-> comment");
                    }
                    else if (fase == 1)
                    {
                        readFase1(line);
                    }
                    else if (fase == 2)
                    {
                        Console.Write(circuit);
                        readFase2(line);
                    }
                    else
                    {
                        //error fases
                        Console.WriteLine("At reading board");
                        Console.WriteLine("To much blank lines found");
                    }

                    Console.WriteLine(line);
                }
            }
        }

        private void readFase1(string line)
        {
            string[] componentsAndValues = sanitizeAndSplitLine(line);

            if (components.ContainsKey(componentsAndValues[1]))
            {
                Node newNode = components[componentsAndValues[1]].getNewInitial();
                newNode.Name = componentsAndValues[0];
                circuit.Add(newNode);
            }
            else
            {
                Console.WriteLine("Unknown component: {0}", componentsAndValues[1]);
            }            
        }

        private void readFase2(string line)
        { 
        }

        private string[] sanitizeAndSplitLine(string line) {
            char tab = '\u0009';
            line = line.Replace(tab.ToString(), "");

            return line.Trim(new char[] {' ', '\t'}).Split(new char[] { ':', ';' }, 3, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
