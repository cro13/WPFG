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

namespace WPFG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point[] points = new Point[0];
        Point[] points2 = new Point[0];
        BezierCurve b1;
        BezierCurve b2;
        int i = 0; int j = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //points = new[] { 
                //new Point(-600,600),
                //new Point(-200,600),
                //new Point(100,400),
                //new Point(300,0)
       // };
            /* points2 = new[]{
                 new Point(-600, 600),
                 new Point(0, 600),
                 new Point(200, 0),
                
            };*/

             /* BezierCurve b1 = new BezierCurve(points, Grid);
             b1.draw();
              BezierCurve b2 = new BezierCurve(points2, Grid);
              b2.draw();

            
              b2.raiseGrade(b1);*/
            // BezierCurve b2 = new BezierCurve(points2, Grid);
           //  b2.draw();

          
            /*if(b1.compareTo(b2)==true)
            MessageBox.Show("Curbele sunt egale");
            else
            MessageBox.Show("Curbele nu sunt egale");*/
            

        }

        private void Ins1_Click_1(object sender, RoutedEventArgs e)
        {
            Grid.Children.Clear();
            Point p = new Point(Convert.ToInt32(X1.Text), Convert.ToInt32(Y1.Text));
            int n = points.Length;
            Point [] temp = new Point [n];
            
            for (int k = 0; k < n; k++)
                temp[k] = points[k];

            points = new Point[temp.Length + 1];

            for (int k = 0; k < n; k++)
                points[k] = temp[k];

            points[points.Length -1] = p;

            b1 = new BezierCurve(points, Grid);
            b1.draw();
            

        }

        private void Ins2_Click_1(object sender, RoutedEventArgs e)
        {
                Grid.Children.Clear();
                b1.draw();
            Point p = new Point(Convert.ToInt32(X2.Text), Convert.ToInt32(Y2.Text));
            int n = points2.Length;
            Point[] temp = new Point[n];

            for (int k = 0; k < n; k++)
                temp[k] = points2[k];

            points2 = new Point[temp.Length + 1];

            for (int k = 0; k < n; k++)
                points2[k] = temp[k];

            
            points2[points2.Length - 1] = p;

            b2 = new BezierCurve(points2, Grid);
            b2.draw();


        }

        private void Compare_Click_1(object sender, RoutedEventArgs e)
        {
            b2.raiseGrade(b1);

            if (b1.compareTo(b2) == true)
                MessageBox.Show("Curbele sunt egale");
            else
                MessageBox.Show("Curbele nu sunt egale");
        }
    }
}
