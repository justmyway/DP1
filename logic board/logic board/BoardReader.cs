using logic_board.Model;
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

        private List<Node> circuit;

        public BoardReader() {
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
                    if (line[0] == '#')
                    {
                        Console.WriteLine("-> comment");
                    }
                    if (line == Environment.NewLine)
                    {
                        fase++;
                    }
                    else if (fase == 1)
                    {
                        readFase1(line);
                    }
                    else if (fase == 2)
                    {
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

        }

        private void readFase2(string line)
        {
        }
    }
}
