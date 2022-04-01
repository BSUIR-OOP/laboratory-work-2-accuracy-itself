using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Figures
{
    /// <summary>
    /// 
    /// Логика взаимодействия для MainWindow.xaml
    ///
    /// </summary>
    /// 

    /*
    public class ListShapes 
    {
        public List<MyShape> list;
        public void DrawList(Canvas g)
        {
            foreach(MyShape shape in list)
            {
                shape.Draw(g);
            }
        }

        public ListShapes()
        { list = new List<MyShape>(); }

        public void Add(MyShape shape)
        {
            list.Add(shape);
        }
       
    }
    */

    public class ListShapes
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

        public ListShapes()
        { list = new List<MyShape>(); }

        public void Add(MyShape shape)
        {
            list.Add(shape);
        }

    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int Number(string s)
        {
            return int.Parse(s);
        }

        private void bPaint_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            ListShapes listShapes = new ListShapes();

            try
            {
                MySegment segm = new MySegment(Number(seg_x1.Text), Number(seg_y1.Text), Number(seg_x2.Text), Number(seg_y2.Text), Brushes.Yellow);
                listShapes.Add(segm);
                MyRectangle rect = new MyRectangle(Number(rect_x1.Text), Number(rect_y1.Text), Number(rect_width.Text), Number(rect_height.Text), Brushes.Black);
                listShapes.Add(rect);
                MyEllipse ell = new MyEllipse(Number(ell_x1.Text), Number(ell_y1.Text), Number(ell_width.Text), Number(ell_height.Text), Brushes.Fuchsia);
                listShapes.Add(ell);
                MyTriangle tri = new MyTriangle(Number(tri_x1.Text), Number(tri_y1.Text), Number(tri_x2.Text), Number(tri_y2.Text), Number(tri_x3.Text), Number(tri_y3.Text), Brushes.Violet);
                listShapes.Add(tri);
            }
            catch (Exception ex)
            {
                MessageBox.Show("!ENTER NORMAL DATA!");
            }
            
            listShapes.DrawList(g);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
