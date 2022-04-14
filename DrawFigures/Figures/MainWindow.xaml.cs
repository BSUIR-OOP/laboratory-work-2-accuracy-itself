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
        private int[] getInts()
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
            MyShape.shapeInfStruct.createShape create;
            create = (MyShape.shapeInfStruct.createShape)((Button)sender).Tag;
            int[] ints = new int[textBoxs.Length];
            ints = getInts();
            if(ints != null)
                DrawShapes.DrawPoints(create(ints, Brushes.Aqua), g);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MyShape.InitializeStruct();
            MyRectangle.initStruct();
            MyEllipse.initStruct();
            MyPoint.initStruct();
            MySegment.initStruct();
            MyTriangle.initStruct();
            int i = 0, numTB = 0;

            foreach (var shape in MyShape.shapeInf)
            {
                if (shape.fieldsNum > numTB) numTB = shape.fieldsNum;
            }

            buttons = new Button[MyShape.shapeInf.Count];
            textBoxs = new TextBox[numTB];
            const int defaultHeight = 80;
            int height = Math.Min((int)stackPanel.Height / (MyShape.shapeInf.Count + numTB), defaultHeight);
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

            foreach (var shape in MyShape.shapeInf)
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
