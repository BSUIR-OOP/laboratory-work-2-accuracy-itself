using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Figures
{
    internal class MyPoint : MyShape
    {
        public double x, y;
        public MyPoint(MyPoint point)
        {
            shapePoints = new List<MyPoint>();
            this.x = point.x;
            this.y = point.y;
        }
        public MyPoint(double x, double y, Brush br)
        {
            this.x = x;
            this.y = y;
            Color = br;
        }

        public MyPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
            Color = Brushes.Red;
        }

        internal override void makePoints(List<MyPoint> shapePoints)
        {
            shapePoints.Add(new MyPoint(x, y, Color));
        }

        public MyPoint(int[] vals, Brush br)
        {
            shapePoints = new List<MyPoint>();
            this.x = vals[0];
            this.y = vals[1];
            //Color = br;
            Color = Brushes.GreenYellow;
            makePoints(shapePoints);
        }

        public static List<MyPoint> Create(int[] vals, Brush br)
        {
            MyPoint p = new MyPoint(vals, br);
            return p.shapePoints;
        }

    }
}
