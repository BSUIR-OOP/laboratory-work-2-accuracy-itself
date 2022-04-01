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
    internal class MySegment : MyShape
    {
        public MyPoint v1, v2;
       
        internal override void makePoints(List<MyPoint> Points)
        {
            int maxI;
            double x = v1.x, y = v1.y, ix, iy; ;

            if ((v2.y - v1.y) > (v2.x - v1.x))
            {
                maxI = Math.Abs((int)(v2.y - v1.y));
                if (v2.y > v1.y) iy = step;
                else iy = -step;
                ix = (v2.x - v1.x) / (v2.y - v1.y);
            }
            else 
            {
                maxI = Math.Abs((int)(v2.x - v1.x));
                if (v2.x > v1.x) ix = step;
                else ix = -step;
                iy = (v2.y - v1.y) / (v2.x - v1.x);
            }

            Points.Add(new MyPoint(x, y, Color));
            for(int i = 1; i < maxI; i++)
            {
                x += ix;
                y += iy;
                Points.Add(new MyPoint(x, y, Color));
            }
        }

        public MySegment(double x1, double y1, double x2, double y2, Brush br)
        {
            shapePoints = new List<MyPoint>();
            v1 = new MyPoint(x1, y1);
            v2 = new MyPoint(x2, y2);
            Color = br;
            makePoints(shapePoints);
        }
    }
}
