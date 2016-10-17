﻿using System;
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
    class MultipleNodeView : INodeView
    {
        int called = -1;

        public MultipleNodeView(int x, int y) : base(x, y)
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
                elip.Fill = Brushes.CadetBlue;
            }
            elip.StrokeThickness = 2;
            elip.Stroke = Brushes.LightCyan;
            elip.Width = 30;
            elip.Height = 30;
            elip.Margin = new Thickness(basePoint.X + 5, basePoint.Y, 0, 0);
            e.Children.Add(elip);

            //input
            elip = new Ellipse();
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
            elip.Margin = new Thickness(basePoint.X + 45, basePoint.Y, 0, 0);
            e.Children.Add(elip);
        }

        public override bool CallAmount() { return called < 1; }

        public override Point GetInputNode() {
            if (called == 1) return new Point();
            called = called + 1;
            Point p = new Point();
            p.X = basePoint.X + 20 + (40 * called);
            p.Y = basePoint.Y + 15;
            return p;
        }
    }
}
