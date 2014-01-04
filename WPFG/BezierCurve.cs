using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFG
{
    class BezierCurve
    {

        private Point[] controlPoints;
        private Grid G;

        PolyLineSegment GetBezierApproximation(Point[] controlPoints, int outputSegmentCount)
        {
            Point[] points = new Point[outputSegmentCount + 1];
            for (int i = 0; i <= outputSegmentCount; i++)
            {
                double t = (double)i / outputSegmentCount;
                points[i] = GetBezierPoint(t, controlPoints, 0, controlPoints.Length);
            }
            return new PolyLineSegment(points, true);
        }

        Point GetBezierPoint(double t, Point[] controlPoints, int index, int count)
        {
            if (count == 1)
                return controlPoints[index];
            var P0 = GetBezierPoint(t, controlPoints, index, count - 1);
            var P1 = GetBezierPoint(t, controlPoints, index + 1, count - 1);
            return new Point((1 - t) * P0.X + t * P1.X, (1 - t) * P0.Y + t * P1.Y);
        }

        public BezierCurve(Point[] points, Grid Grid)
        {
            
            this.controlPoints = points;
            this.G = Grid;
        }


        internal void draw()
        {

            var b = GetBezierApproximation(controlPoints, 256);
            PathFigure pf = new PathFigure(b.Points[0], new[] { b }, false);
            PathFigureCollection pfc = new PathFigureCollection();
            pfc.Add(pf);
            var pge = new PathGeometry();
            pge.Figures = pfc;
            Path p = new Path();
            p.Data = pge;
            p.Stroke = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            //((G)sender).Children.Add(p);
            G.Children.Add(p);
        }

        internal bool compareTo(BezierCurve bc)
        {
            Point p, q;
            int i, j;
            i = j = 0;
            while (i != controlPoints.Length && j != bc.controlPoints.Length)
            {
                p = controlPoints[i];
                q = bc.controlPoints[j];
                if (p != q)
                    return false;
                i++;
                j++;
            }
            if (i != controlPoints.Length || j != bc.controlPoints.Length)
                return false;
           
            return true;
            
        }

        internal void raiseGrade(BezierCurve bc){
           
                while (controlPoints.Length < bc.controlPoints.Length)
                {
                    int n = controlPoints.Length - 1;
                    Point[] aux = new Point[n + 2];
                    aux[0] = controlPoints[0];
                    aux[n + 1] = controlPoints[n];
                    for (int i = 1; i <= n; i++)
                    {
                        aux[i].X = ((double)i / (n + 1)) * controlPoints[i - 1].X + (1 - ((double)i / (n + 1))) * controlPoints[i].X;
                        aux[i].Y = ((double)i / (n + 1)) * controlPoints[i - 1].Y + (1 - ((double)i / (n + 1))) * controlPoints[i].Y;
                    }
                    controlPoints = aux;
                }
            }



    }
}
