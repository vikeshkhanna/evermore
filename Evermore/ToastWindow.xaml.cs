using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Timers;
using System.Windows.Media.Animation;

namespace Evermore
{
    /// <summary>
    /// Interaction logic for ToastWindow.xaml
    /// </summary>
    public partial class ToastWindow : Window
    {
        private static int GAP = 10;
        private static int timerInterval;
        private Timer endToastTimer; 
        private Storyboard closeStoryboard;
        private Boolean closeStoryboardComplete = false;
        private Boolean closeStoryboardInProgress = false;
        private Window parentWindow;
        private string notificationMessage;

        public int AnimationTime
        {
            get 
            {
                return 1;
            }
            set
            {
            }
        }
        
        public ToastWindow(Window _parentWindow, string notificationMessage, int endToastInterval = 10000)
        {
            InitializeComponent();

            this.ToastMessage.Text = notificationMessage;
            timerInterval = endToastInterval;
            setupAnimation(endToastInterval);
            this.parentWindow = _parentWindow;
        }

        private void setupAnimation(int timerInvertal)
        {
            this.endToastTimer = new Timer(timerInterval);
            this.endToastTimer.Elapsed += new ElapsedEventHandler(endToastTimer_Elapsed);

            
            this.closeStoryboard = new Storyboard();
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 1;
            myDoubleAnimation.To = 0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(this.AnimationTime));
            Storyboard.SetTarget(myDoubleAnimation, this);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Window.OpacityProperty));
            closeStoryboard.Children.Add(myDoubleAnimation);
            this.closeStoryboard.Completed += new EventHandler(closeStoryboard_Completed);
        }

        private void closeStoryboard_Completed(object sender, EventArgs args)
        {
            this.closeStoryboardComplete = true;
            this.Close();
        }

        public void RaiseToast()
        {
            this.Show();
            var desktopWorkingArea = SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width - GAP;
            this.Top = desktopWorkingArea.Bottom - this.Height - GAP;
            this.endToastTimer.Start();
        }

        public void EndToast()
        {
            if (!this.closeStoryboardInProgress)
            {
                this.closeStoryboardInProgress = true;
                this.endToastTimer.Stop();
                this.closeStoryboard.Begin();
            }
        }

        private void endToastTimer_Elapsed(object sender, EventArgs args)
        {
            if (!this.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(
                    new Action(EndToast));
                return;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!this.closeStoryboardComplete)
            {
                this.EndToast();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.EndToast();
            }
            else if (e.ChangedButton == MouseButton.Right)
            {
                this.parentWindow.Activate(); 
                this.EndToast();
            }
        }
    }
}
