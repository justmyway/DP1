using LogicBoard2._0.Models;
using LogicBoard2._0.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

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

        private List<PositionCounter> _thickes;
        private Point _beginProbe;

        public CircuitDrawer() {
            _drawnNodes = new List<Node>();
            _iViewDrawables = new List<INodeView>();
            _thickes = new List<PositionCounter>();
            _beginProbe = new Point();
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
            _thickes.Clear();
            if (_drawnNodes.Count == 0)
            {
                foreach (Node drawNode in _circuit.Inputs)
                {
                    PrepareNode(drawNode, 0);
                }
            }
            DrawNodes();
        }

        private void PrepareNode(Node drawNode, int height)
        {
            PositionCounter pc = GetPositionCounter(height);

            INodeView view;

            if (!_drawnNodes.Contains(drawNode))
            {
                if (drawNode is MultipleEntreeNode)
                {
                    view = new MultipleNodeView(_x * pc.Width, _y * height);
                }
                else
                {
                    view = new SingleNodeView(_x * pc.Width, _y * height);
                }

                pc.Width++;

                view.SetNode(drawNode);
                _iViewDrawables.Add(view);

                _drawnNodes.Add(drawNode);
            }
            else {
                view = GetNodeView(drawNode);
            }

            if(drawNode.Inputs.Count != 0 && view.CallAmount()) DrawPowerLine(view.GetInputNode());

            SetMediumHeight(height);
            SetMediumWidth(pc.Width);

            height = height + 1;
            foreach (Node nextNode in drawNode.Outputs) {
                _beginProbe = GetNodeView(drawNode).GetOutputProbe();
                PrepareNode(nextNode, height);
            }
            height = height - 1;
        }

        private void DrawNodes() {
            foreach (INodeView drawable in _iViewDrawables) {
                drawable.Draw(_canvas);
            }
        }

        private PositionCounter GetPositionCounter(int height) {
            foreach (PositionCounter pc in _thickes)
            {
                if (pc.Height == height) return pc;
            }

            _thickes.Add(new PositionCounter { Height = height, Width = 0});

            return GetPositionCounter(height);
        }

        private INodeView GetNodeView(Node node) {
            foreach (INodeView nv in _iViewDrawables) {
                if (nv.GetNode().Name == node.Name) return nv;
            }
            return null;
        }

        private void SetMediumHeight(int rows) {
            if (_canvas.Height < rows * _y) _canvas.Height = (rows * (_y + 5));
        }

        private void SetMediumWidth(int columns)
        {
            if (_canvas.Width < columns * _x) _canvas.Width = (columns * _x);
        }

        private void DrawPowerLine(Point p){
            //connect line
            Line line = new Line();
            line.Stroke = Brushes.Black;
            line.StrokeThickness = 4;
            line.X1 = _beginProbe.X;
            line.Y1 = _beginProbe.Y;
            line.X2 = p.X;
            line.Y2 = p.Y;
            _canvas.Children.Add(line);
        }

    }
}
