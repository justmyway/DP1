using LogicBoard2._0.Models;
using LogicBoard2._0.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LogicBoard2._0.ViewModels
{
    class CircuitDrawer
    {
        private Circuit _circuit;
        private Canvas _canvas;
        private List<Node> _drawnNodes;
        private List<INodeView> _iViewDrawables;

        private int _x = 150;
        private int _y = 150;

        public CircuitDrawer() {
            _drawnNodes = new List<Node>();
            _iViewDrawables = new List<INodeView>();
        }

        public void SetCircuit(Circuit circuit) {
            _circuit = circuit;
            _drawnNodes.Clear();
        }

        public void SetMedium(Canvas scheme)
        {
            _canvas = scheme;
            _drawnNodes.Clear();
        }

        public void Draw()
        {
            if (_drawnNodes.Count == 0)
            {
                int width = 0;
                foreach (Node drawNode in _circuit.Inputs)
                {
                    PrepareNode(drawNode, width, 0);
                    width++;
                }
            }
            DrawNodes();
        }

        private void PrepareNode(Node drawNode, int width, int height)
        {
            if (!_drawnNodes.Contains(drawNode))
            {
                INodeView view;

                if (drawNode is MultipleEntreeNode)
                {
                    view = new MultipleNodeView(_x * width, _y * height);
                }
                else
                {
                    view = new SingleNodeView(_x * width, _y * height);
                }

                view.SetNode(drawNode);
                _iViewDrawables.Add(view);

                _drawnNodes.Add(drawNode);
            }

            int addedWidth = 0;
            foreach (Node nextNode in drawNode.Outputs) {
                height = height + 1;
                PrepareNode(nextNode, width + addedWidth, height);
                addedWidth++;
            }
        }

        private void DrawNodes() {
            foreach (INodeView drawable in _iViewDrawables) {
                drawable.Draw(_canvas);
            }
        }
    }
}
