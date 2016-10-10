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
    abstract class INodeView
    {
        protected Point basePoint { get; set; }
        protected Node baseNode { get; set; }

        public INodeView(int x, int y) {
            basePoint = new Point(x, y);
        }

        public void SetNode(Node node) {
            baseNode = node;
        }

        public void DrawBase(Canvas e) {
            //box
            Rectangle rect = new Rectangle();
            if (baseNode.Value == Current.High)
            {
                rect.Fill = Brushes.LightGreen;
            }
            else if (baseNode.Value == Current.Low)
            {
                rect.Fill = Brushes.OrangeRed;
            }
            rect.StrokeThickness = 2;
            rect.Stroke = Brushes.LightCyan;
            rect.Width = 80;
            rect.Height = 80;
            rect.Margin = new Thickness(basePoint.X, basePoint.Y + 25, 0, 0);
            e.Children.Add(rect);

            //output
            Ellipse elip = new Ellipse();
            if (baseNode.Value == Current.High)
            {
                elip.Fill = Brushes.LightGreen;
            }
            else if (baseNode.Value == Current.Low)
            {
                elip.Fill = Brushes.OrangeRed;
            }
            elip.StrokeThickness = 2;
            elip.Stroke = Brushes.LightCyan;
            elip.Width = 30;
            elip.Height = 30;
            elip.Margin = new Thickness(basePoint.X+40, basePoint.Y+125, 0, 0);
            e.Children.Add(elip);
        }
    }
}
