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



        public BoardReader() {
        }

        public void read(String circuit) {
            Console.Write("fase 1");
            Console.Write(circuit);

            using (StringReader sr = new StringReader(circuit))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line[0] == '#') {
                        Console.WriteLine("-> comment");
                    }
                    Console.WriteLine(line);
                }
            }
        }
    }
}
