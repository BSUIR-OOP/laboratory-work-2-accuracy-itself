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
            double step = 0.1;
            if (width == 0 || height == 0)
            {
                shapePoints.Add(new MyPoint(a.x, a.y, Color));
            }
            else
            {
                double aa = width / 2, b = height / 2, y0 = a.y, y = y0 - b, x0 = a.x, k = 0;
                for (double x = x0 - aa; x < x0 + aa + 2 * step; x += step)
                {
                    k = b * Math.Sqrt(Math.Abs(1 - (x - x0) * (x - x0) / (aa * aa)));
                    Color = Brushes.Gray;
                    shapePoints.Add(new MyPoint(x, y0 + k, Color));
                    shapePoints.Add(new MyPoint(x, y0 - k, Color));
                }
            }
            
            /*
            for(double i = a.x - width / 2; i < a.x + width / 2 + 5; i += step)
                for (double j = a.y - height / 2; j < a.y + height / 2 + 5; j += step)
                {
                    if ( Math.Abs((double)((i - a.x) * (i - a.x)) / (width / 2) / (width / 2) + (double)((j - a.y) * (j - a.y)) / (height / 2) / (height / 2) - 1) < 0.1)
                    {
                        shapePoints.Add(new MyPoint(i, j, Color));
                    }
                }
            */
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
        
        public MyEllipse(int[] vals, Brush br)
        {
            shapePoints = new List<MyPoint>();
            a = new MyPoint(vals[0], vals[1]);
            this.width = vals[2];
            this.height = vals[3];
            //Color = br;
            Color = Brushes.Gray; 
            makePoints(shapePoints);
        }

        public static List<MyPoint> Cr(int[] vals, Brush br)
        {
            MyEllipse ell = new MyEllipse(vals, br);
            return ell.shapePoints;
        }

        public static void initStruct()
        {
            shapeInfStruct EllInf = new shapeInfStruct("Ellipse", 4, Cr);
        }

    }
}
