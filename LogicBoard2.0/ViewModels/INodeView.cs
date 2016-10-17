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

        abstract public void Draw(Canvas e);

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
            else
            {
                rect.Fill = Brushes.CadetBlue;
            }
            rect.StrokeThickness = 2;
            rect.Stroke = Brushes.LightCyan;
            rect.Width = 80;
            rect.Height = 80;
            rect.Margin = new Thickness(basePoint.X, basePoint.Y + 30, 0, 0);
            e.Children.Add(rect);

            //Name
            TextBox textBlock = new TextBox();
            textBlock.Text = baseNode.Name;
            textBlock.Foreground = Brushes.Black;
            Canvas.SetLeft(textBlock, basePoint.X + 5);
            Canvas.SetTop(textBlock, basePoint.Y + 50);
            e.Children.Add(textBlock);

            //Sort
            textBlock = new TextBox();
            textBlock.Text = baseNode.GetType().Name;
            textBlock.Foreground = Brushes.Black;
            Canvas.SetLeft(textBlock, basePoint.X + 5);
            Canvas.SetTop(textBlock, basePoint.Y + 70);
            e.Children.Add(textBlock);

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
            else
            {
                elip.Fill = Brushes.CadetBlue;
            }
            elip.StrokeThickness = 2;
            elip.Stroke = Brushes.LightCyan;
            elip.Width = 30;
            elip.Height = 30;
            elip.Margin = new Thickness(basePoint.X+25, basePoint.Y+110, 0, 0);
            e.Children.Add(elip);
        }
    }
}
