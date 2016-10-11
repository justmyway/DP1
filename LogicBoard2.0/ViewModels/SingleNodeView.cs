using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using LogicBoard2._0.Models.Nodes;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace LogicBoard2._0.ViewModels
{
    class SingleNodeView : INodeView
    {
        public SingleNodeView(int x, int y) : base(x, y)
        {
        }

        public override void Draw(Canvas e)
        {
            base.DrawBase(e);

            //input
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
                elip.Fill = Brushes.LightGray;
            }
            elip.StrokeThickness = 2;
            elip.Stroke = Brushes.LightCyan;
            elip.Width = 30;
            elip.Height = 30;
            elip.Margin = new Thickness(basePoint.X + 25, basePoint.Y, 0, 0);
            e.Children.Add(elip);
        }
    }
}
