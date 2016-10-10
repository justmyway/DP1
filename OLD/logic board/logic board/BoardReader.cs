﻿using logic_board.Model;
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
        private List<Node> _inputProbes;
        private List<Node> _outputProbes;

        public List<Node> InputProbes { get { return _inputProbes; } }
        public List<Node> OutputProbes { get { return _outputProbes; } }

        public BoardReader()
        {
            components.Add("INPUT_HIGH", new Probe(Current.High));
            components.Add("INPUT_LOW", new Probe(Current.Low));
            components.Add("PROBE", new Probe(Current.notSet));

            components.Add("NOT", new Not());
            components.Add("AND", new And());
            components.Add("OR", new Or());
            //components.Add("NOr", new NOr());
            //components.Add("NAnd", new NAnd());
            //components.Add("XOr", new XOr());
        }

        public void read(String circuitDescription)
        {
            Console.WriteLine("-- fase 1 --");

            circuit = new List<Node>();
            _inputProbes = new List<Node>();
            _outputProbes = new List<Node>();
            int fase = 1;

            using (StringReader sr = new StringReader(circuitDescription))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == Environment.NewLine || line == "")
                    {
                        fase++;
                        Console.WriteLine("-- fase 2 --");
                    }
                    else if (line[0] == '#')
                    {
                        //Console.WriteLine("-> comment");
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
                }
            }
        }

        private void readFase1(string line)
        {
            string[] componentsAndValues = sanitizeAndSplitLine(line);

            if (components.ContainsKey(componentsAndValues[1]))
            {
                Node newNode = components[componentsAndValues[1]].getNewInstance();
                newNode.Name = componentsAndValues[0];
                ConnectToBoard(newNode);
            }
            else
            {
                Console.WriteLine("Unknown component: {0}", componentsAndValues[1]);
            }
        }

        private void readFase2(string line)
        {
            string[] componentsAndValues = sanitizeAndSplitLine(line);
            foreach (Node component in circuit)
            {
                if (component.Name.Equals(componentsAndValues[0]))
                {
                    string[] forwardNodes = splitConnectLine(componentsAndValues[1]);
                    foreach (string connectNodeName in forwardNodes)
                    {
                        foreach (Node forwardNode in circuit)
                        {
                            if (forwardNode.Name.Equals(connectNodeName))
                            {
                                forwardNode.ConnectToPreviousNode(component);
                                Console.WriteLine("Connected {0} to {1}", component.Name, forwardNode.Name);
                            }
                        }
                    }
                }
            }
        }

        private void ConnectToBoard(Node createdNode)
        {
            if (createdNode.GetType().Equals(typeof(Probe)))
            {
                if (createdNode.Value == Current.notSet)
                {
                    _outputProbes.Add(createdNode);
                }
                else
                {
                    _inputProbes.Add(createdNode);
                }
            }

            circuit.Add(createdNode);
        }

        private string[] sanitizeAndSplitLine(string line)
        {
            char tab = '\u0009';
            line = line.Replace(tab.ToString(), "");

            return line.Trim(new char[] { ' ', '\t' }).Split(new char[] { ':', ';' }, 3, StringSplitOptions.RemoveEmptyEntries);
        }

        private string[] splitConnectLine(string connectLine)
        {
            return connectLine.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
