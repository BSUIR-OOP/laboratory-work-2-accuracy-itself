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
    internal class MyTriangle : MyShape
    {
        public MyPoint a, b, c;
        
        public MyTriangle(int x1, int y1, int x2, int y2, int x3, int y3, Brush br)
        {
            shapePoints = new List<MyPoint>();
            a = new MyPoint(x1, y1);
            b = new MyPoint(x2, y2);
            c = new MyPoint(x3, y3);
            Color = br;
            makePoints(shapePoints);
        }

        internal override void makePoints(List<MyPoint> Points)
        {
            MySegment l1 = new MySegment(a.x, a.y, b.x, b.y, Color);
            MySegment l2 = new MySegment(c.x, c.y, b.x, b.y, Color);
            MySegment l3 = new MySegment(a.x, a.y, c.x, c.y, Color);
            l1.makePoints(Points);
            l2.makePoints(Points);
            l3.makePoints(Points);
        }

    }
}
