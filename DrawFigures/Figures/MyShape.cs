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
        
        internal abstract void makePoints(List<MyPoint> shapePoints);
    }
}
