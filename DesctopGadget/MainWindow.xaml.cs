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

namespace DesctopGadget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point old;
        
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            old = e.GetPosition(null);
            

        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point cur = e.GetPosition(null);
                this.Left += cur.X - old.X;
                this.Top += cur.Y - old.Y;
            }
        }

        private void ExitBut_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           this.Close(); 
            
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            Timelabel.Content = DateTime.Now.ToString("hh:mm:ss");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
