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


        #region Properties
        public string FilePath
        {
            get 
            {
                return this.filePath;
            }
        }
        #endregion

        public WatchPage()
        {
            InitializeComponent();
            this.timer = new Timer();
            this.timer.Enabled = false;
            this.timer.Elapsed += new ElapsedEventHandler(timerElapsed);
        }

        public void InitWatch(string _filePath)
        {
            this.MinutesAgoLabel.Content = "Initializing";
            this.filePath = _filePath;
            this.fileSize = 0;
            this.timer.Enabled = true;
            updateUI(String.Empty);
        }

        public void EndWatch()
        {
            this.timer.Enabled = false;
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
                    new Action<string>(updateUI), new object[] { "Changed!" });
                return;
            }
        }

        private void updateUI(string toastUpdate)
        {
            this.fileInfo = new FileInfo(this.filePath);

            if (this.fileInfo.Length != this.fileSize)
            {
                this.fileSize = fileInfo.Length;
                this.lastUpdateTime = this.fileInfo.LastWriteTime;
                this.LastUpdatedLabel.Content = "Last updated at " + String.Format("{0}", DateTime.Now);
                Debug.WriteLine("File Changed : " + fileInfo.Length);
            }
            else
            {
                Debug.WriteLine("File size same : " + fileInfo.Length);
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
    }
}
