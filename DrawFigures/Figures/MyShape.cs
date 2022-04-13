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

        internal struct shapeInfStruct
        {
            internal string Name;
            internal int fieldsNum;
            internal delegate List<MyPoint> createShape(int[] vals, Brush br);
            internal createShape crShape;
            //internal static crRect Rect = new crRect(MyRectangle.Cr);
            public shapeInfStruct(string name, int fields, createShape crSh)
            {
                Name = name;
                fieldsNum = fields;
                crShape = crSh;
                MyShape.shapeInf.Add(this);
            }
        }
        internal static List<shapeInfStruct> shapeInf = new List<shapeInfStruct>();

        public static void InitializeStruct()
        {
            MyRectangle.initStruct();
            MyEllipse.initStruct();
            MyPoint.initStruct();
            MySegment.initStruct();
            MyTriangle.initStruct();
        }
        //internal  static List<MyPoint> Cr(int[] vals, Brush br);
        internal abstract void makePoints(List<MyPoint> shapePoints);
    }
}
