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
    internal class MyRectangle : MyShape
    {
        public MyPoint leftAngle;
        public int width, height;

        internal override void makePoints(List<MyPoint> Points)
        {
            MySegment l1 = new MySegment(leftAngle.x, leftAngle.y, leftAngle.x + width, leftAngle.y, Color);
            MySegment l2 = new MySegment(leftAngle.x, leftAngle.y, leftAngle.x, leftAngle.y + height, Color);
            MySegment l3 = new MySegment(leftAngle.x + width, leftAngle.y, leftAngle.x + width, leftAngle.y + height, Color);
            MySegment l4 = new MySegment(leftAngle.x, leftAngle.y + height, leftAngle.x + width, leftAngle.y + height, Color);
            l1.makePoints(Points);
            l2.makePoints(Points);
            l3.makePoints(Points);
            l4.makePoints(Points);
        }

        public MyRectangle(int x, int y, int width, int height, Brush br)
        {
            shapePoints = new List<MyPoint>();
            leftAngle = new MyPoint(x, y);
            this.width = width;
            this.height = height;
            Color = br;
            makePoints(shapePoints);
        }

    }
}
