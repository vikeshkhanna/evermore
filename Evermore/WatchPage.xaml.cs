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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.IO;
using System.Diagnostics;

namespace Evermore
{
    /// <summary>
    /// Interaction logic for WatchPage.xaml
    /// </summary>
    public partial class WatchPage : UserControl
    {
        private Timer timer;
        private int TIMER_INTERVAL = 1000;
        private string filePath;
        private long fileSize;
        private FileInfo fileInfo;
        private DateTime lastUpdateTime;
        private Window parentWindow;
        private Boolean errorDetected = false;
        private Boolean firstTime = false;

        #region Properties
        public string FilePath
        {
            get 
            {
                return this.filePath;
            }
        }
        #endregion

        public WatchPage(Window _parentWindow)
        {
            InitializeComponent();
            this.timer = new Timer();
            this.timer.Enabled = false;
            this.timer.Elapsed += new ElapsedEventHandler(timerElapsed);
            this.parentWindow = _parentWindow;
        }

        public void InitWatch(string _filePath)
        {
            this.MinutesAgoLabel.Content = "Initializing";
            this.filePath = _filePath;
            this.fileSize = -1;
            this.timer.Enabled = false;
            this.errorDetected = false;
            this.firstTime = false;
        }

        public void StartWatch()
        {
            this.timer.Start();
        }

        public void EndWatch()
        {
            this.timer.Stop();
        }

        private void startTimer()
        {
            this.timer = new Timer(TIMER_INTERVAL);
            this.timer.Enabled = true;
        }

        private void timerElapsed(object sender, EventArgs eventArgs)
        {
            if (!this.LastUpdatedLabel.CheckAccess())
            {
                this.LastUpdatedLabel.Dispatcher.BeginInvoke(
                    new Action(updateUI));
                return;
            }
        }

        private void updateUI()
        {
            try
            {
                this.fileInfo = new FileInfo(this.filePath);

                if (this.lastUpdateTime != this.fileInfo.LastWriteTime)
                {
                    this.fileSize = fileInfo.Length;
                    this.lastUpdateTime = this.fileInfo.LastWriteTime;
                    this.LastUpdatedLabel.Content = "Last updated at " + String.Format("{0}", DateTime.Now);
                    Debug.WriteLine("File Changed : " + fileInfo.Length);
                    
                    //Display Toast

                    ToastWindow toast;

                    if (this.firstTime)
                    {
                        toast = new ToastWindow(this.parentWindow, "Relax gentlemen, we are watching your file.");
                    }
                    else
                    {
                        toast = new ToastWindow(this.parentWindow, "File haz been updated!\nNew Size - " + fileInfo.Length + " bytes.");
                    }

                    toast.RaiseToast();
                    this.firstTime = false;
                }
                else
                {
                    //Debug.WriteLine("File size same : " + fileInfo.Length);
                }

                TimeSpan diff = DateTime.Now - this.lastUpdateTime;

                if (diff.Minutes < 1 && diff.Seconds < 60)
                {
                    this.MinutesAgoLabel.Content = diff.Seconds + " seconds ago";
                }
                else
                {
                    this.MinutesAgoLabel.Content = diff.Minutes + " minutes ago";
                }
            }
            catch (Exception ex)
            {
                if (!this.errorDetected)
                {
                    this.EndWatch();
                    this.errorDetected = true;
                    ((MainWindow)this.parentWindow).HandleError(ex);
                    
                }
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(filePath);
        }
    }
}
