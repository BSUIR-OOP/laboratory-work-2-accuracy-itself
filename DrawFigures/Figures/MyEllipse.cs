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
    internal class MyEllipse : MyShape
    {
        public MyPoint a;
        public int width;
        public int height;

        internal override void makePoints(List<MyPoint> shapePoints)
        {
            for(double i = a.x - width / 2; i < a.x + width / 2 + 5; i += 0.1)
                for (double j = a.y - height / 2; j < a.y + height / 2 + 5; j += 0.1)
                {
                    if ( Math.Abs((double)((i - a.x) * (i - a.x)) / (double)(width / 2) / (double)(width / 2) + (double)((j - a.y) * (j - a.y)) / (double)(height / 2) / (double)(height / 2) - 1) < 0.001)
                    {
                        shapePoints.Add(new MyPoint(i, j));
                    }
                }
        }

        public MyEllipse(int x, int y, int width, int height, Brush br)
        {
            shapePoints = new List<MyPoint>();
            a = new MyPoint(x, y);
            this.width = width;
            this.height = height;
            Color = br;
            makePoints(shapePoints);
        }
    }
}
