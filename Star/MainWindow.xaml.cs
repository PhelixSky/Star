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
using System.Timers;
using System.Windows.Interop;
namespace Star
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   Point old;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y,
        int cx, int cy, uint uFlags);

            public const int HWND_BOTTOM = 0x1;
            public const uint SWP_NOSIZE = 0x1;
            public const uint SWP_NOMOVE = 0x2;
            public const uint SWP_SHOWWINDOW = 0x40;
            private IntPtr Handle
            {
                get
                {
                    return new WindowInteropHelper(this).Handle;
                }
            }
        private void ShoveToBackground()
         {
            SetWindowPos((int)this.Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE |
                  SWP_NOSIZE | SWP_SHOWWINDOW);
         }
        private static Timer aTimer;
        private static void SetTimer()
            {
                // Create a timer with a two second interval.
                aTimer = new System.Timers.Timer(2000);
                // Hook up the Elapsed event for the timer. 
                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = true;
                aTimer.Enabled = true;
            }
       
       public MainWindow()
        {


        }
       private void aTimer_Tick(object sender, EventArgs e)
        {
            Timesec.Text = DateTime.Now.ToString("ss.fff");
            time.Text = DateTime.Now.ToString("hh:mm");
        }
       

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
        }

        private void time_Initialized(object sender, EventArgs e)
        {

        }
        
        private void Image1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            old = e.GetPosition(null);
        }

        private void Image1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point cur = e.GetPosition(null);

                this.Left += cur.X - old.X;
                this.Top += cur.Y - old.Y;
            }
        }
    }
}
