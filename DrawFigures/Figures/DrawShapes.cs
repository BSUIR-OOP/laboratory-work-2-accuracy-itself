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
    public class DrawShapes
    {
        public List<MyShape> list;
        internal static void DrawPoints(List<MyPoint> points, Canvas g)
        {
            const int pSize = 7;
            foreach (var point in points)
            {
                Ellipse pEllipse = new Ellipse();
                pEllipse.Width = pSize;
                pEllipse.Height = pSize;
                pEllipse.Margin = new System.Windows.Thickness(point.x, point.y, 0, 0);
                pEllipse.Stroke = point.Color;
                pEllipse.StrokeThickness = pSize;
                g.Children.Add(pEllipse);
            }
        }

        public void DrawList(Canvas g)
        {
            foreach (MyShape shape in list)
            {
                DrawPoints(shape.shapePoints, g);
            }
        }

        //internal delegate List<MyPoint> crRect(int[] vals, Brush br);
        //internal static crRect Rect = new crRect(MyRectangle.Cr);
        

        public DrawShapes()
        { list = new List<MyShape>(); }

        public void Add(MyShape shape)
        {
            list.Add(shape);
        }

    }
}
