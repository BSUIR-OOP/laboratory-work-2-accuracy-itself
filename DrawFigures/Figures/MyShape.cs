using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Figures
{
    
    public abstract class MyShape
    {

        public Brush Color;
        public const double step = 1;
        //public abstract void Draw(Canvas g);

        internal List<MyPoint> shapePoints;

        
        /*
        public static void InitializeStruct()
        {
            MyRectangle.initStruct();
            MyEllipse.initStruct();
            MyPoint.initStruct();
            MySegment.initStruct();
            MyTriangle.initStruct();
        */
        //internal  static List<MyPoint> Cr(int[] vals, Brush br);
        internal abstract void makePoints(List<MyPoint> shapePoints);
    }
}
