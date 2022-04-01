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
    internal class MyCircle : MyEllipse
    {
        public int r;

        public MyCircle(int x, int y, int width, int height, Brush br) : base(x, y, width, height, br)
        {
            r = width / 2;
        }

        public MyCircle(int x, int y, int r, Brush br) : base(x - r, y - r, r*2, r*2, br)
        {
            this.a = new MyPoint(x - r, y - r); 
            this.r = r;
            Color = br;
        }

    }
}
