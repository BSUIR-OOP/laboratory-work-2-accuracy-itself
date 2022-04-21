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

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //oh
        TextBox[] textBoxs;
        Button[] buttons;
        private int[] getShapeValues()
        {
            int[] ints = new int[textBoxs.Length];
            bool parsed;
            for(int i = 0; i < textBoxs.Length; i++)
            {
                parsed = int.TryParse(textBoxs[i].Text.ToString(), out ints[i]);
                if ((!parsed) || (ints[i] < 0))
                {
                    MessageBox.Show("ENTER NORMAL DATA");
                    return null;
                }

            }
            return ints;
        }

        private void Click_Draw(object sender, EventArgs e)
        {
            ShapeInfoStruct.createShape create;
            create = (ShapeInfoStruct.createShape)((Button)sender).Tag;
            int[] shapevalues = new int[textBoxs.Length];
            shapevalues = getShapeValues();
            if(shapevalues != null)
                DrawShapes.DrawPoints(create(shapevalues, Brushes.Aqua), g);
        }

        internal struct ShapeInfoStruct
        {
            internal string Name;
            internal int fieldsNum;
            internal delegate List<MyPoint> createShape(int[] vals, Brush br);
            internal createShape crShape;
            //internal static crRect Rect = new crRect(MyRectangle.Cr);
            public ShapeInfoStruct(string name, int fields, createShape crSh)
            {
                Name = name;
                fieldsNum = fields;
                crShape = crSh;
            }
        }
        internal static ShapeInfoStruct[] ShapeInfo =
                                            new ShapeInfoStruct[]
                                            {
                                                new ShapeInfoStruct("Rectangle", 4, MyRectangle.Create),
                                                new ShapeInfoStruct("Ellipse", 4, MyEllipse.Create),
                                                new ShapeInfoStruct("Triangle", 6, MyTriangle.Create),
                                                new ShapeInfoStruct("Segment", 4, MySegment.Create)
                                            };
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int i = 0, numTB = 0;

            foreach (var shape in ShapeInfo)
            {
                if (shape.fieldsNum > numTB) numTB = shape.fieldsNum;
            }

            buttons = new Button[ShapeInfo.Length];
            textBoxs = new TextBox[numTB];
            const int defaultHeight = 80;
            int height = Math.Min((int)stackPanel.Height / (ShapeInfo.Length + numTB), defaultHeight);
            const int width = 240;
            for (int j = 0; j < textBoxs.Length; j++)
            {
                textBoxs[j] = new TextBox();
                textBoxs[j].HorizontalAlignment = HorizontalAlignment.Left;
                textBoxs[j].Height = height;
                textBoxs[j].Width = width;
                textBoxs[j].FontSize = height * 50 / 100;
                textBoxs[j].Text = "0";
                stackPanel.Children.Add(textBoxs[j]);
            }

            foreach (var shape in ShapeInfo)
            {
                buttons[i] = new Button();
                buttons[i].Height = height;
                buttons[i].Width = width;
                buttons[i].HorizontalAlignment = HorizontalAlignment.Left;
                buttons[i].Tag = shape.crShape;
                buttons[i].FontSize = height * 50 / 100;
                buttons[i].Content = shape.Name + ", " + (shape.fieldsNum).ToString() + " fs";
                buttons[i].Click += Click_Draw;
                buttons[i].Background = new SolidColorBrush(Color.FromArgb(100, 147, 112, 219));
                stackPanel.Children.Add(buttons[i]);
                i++;
            }

            MessageBox.Show("REMEMBER!:\nYou should enter only numbers greater than or equal to 0!");
        }
    }
}
