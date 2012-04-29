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
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Drawing;

namespace Evermore
{
    public enum EvermoreState
    { 
        Welcome = 0,
        Searching,
        SearchingComplete,
        SearchingStopped,
        SearchingCancelled,
        Watching
    }

    public enum SearchMode
    { 
        Local = 0,
        Remote
    }

    public enum PathMode
    { 
        Search = 0,
        Absolute
    }

    class LocalFileArgs
    { 
        public string searchFile;
        public List<string> ignoreDirs;
        public int MAX_DEPTH;

        public LocalFileArgs(string _searchFile, List<string> _ignoreDirs, int _max)
        {
            searchFile = _searchFile;
            ignoreDirs = _ignoreDirs;
            MAX_DEPTH = _max;
        }
    }

    class RemoteFileArgs
    {
        public string machine;
        public string username;
        public string password;
        public string searchFile;
        public List<string> ignoreDirs;
        public int MAX_DEPTH;

        public  RemoteFileArgs(string _machine, string _username, string _password, string _searchFile, List<string> _ignoreDirs, int _max)
        {
            machine = _machine;
            username = _username;
            password = _password;
            searchFile = _searchFile;
            ignoreDirs = _ignoreDirs;
            MAX_DEPTH = _max;
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EvermoreModel evermoreModel = new EvermoreModel();
        private BackgroundWorker searchBackgroundWorker = new BackgroundWorker();
        private List<string> IgnoreDirs = new List<string> { "system", "windows", "program", "users", "bin","cygwin","python" };
        private string fileToSearch;
 
        public void reportSearchProgress(string file, bool isSearchFile)
        {
            if(!this.evermoreModel.SearchPage.Dispatcher.CheckAccess()) 
            {
                this.evermoreModel.SearchPage.Dispatcher.BeginInvoke(
                    new Action<string, bool> (reportSearchProgress), new object[] { file, isSearchFile });
                return;
            }
            
            if (isSearchFile)
            {
                this.evermoreModel.IsFileFound = true;
                this.evermoreModel.SearchPage.FoundFilesComboBox.Items.Add(file);
                Debug.WriteLine("[Success] Received file : " + file);
            }
            else
            {
                this.evermoreModel.SearchProgressLabelContent = "Looking in " + file;
                Debug.WriteLine("[Reporting] Processing dir : " + file);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.PageCanvas.Children.Add(this.evermoreModel.WelcomePage);
            this.evermoreModel.CurrentPage = this.evermoreModel.WelcomePage;
            this.DataContext = this.evermoreModel;
            this.searchBackgroundWorker.DoWork +=new DoWorkEventHandler(searchBackgroundWorker_DoWork);
            this.searchBackgroundWorker.RunWorkerCompleted +=new RunWorkerCompletedEventHandler(searchBackgroundWorker_RunWorkerCompleted);
        }

        #region Properties
        public EvermoreModel EvermoreModel
        {
            get
            {
                return this.evermoreModel;            
            }
        }
        #endregion

        #region Background Worker

        private void searchBackgroundWorker_DoWork(object sender, DoWorkEventArgs args)
        {   
            if(this.evermoreModel.IsMachineLocal)
            {
                LocalFileArgs localFileArgs = (LocalFileArgs)args.Argument;
                List<string> files = Utils.SearchFileLocal(localFileArgs.searchFile, localFileArgs.ignoreDirs, localFileArgs.MAX_DEPTH, this.reportSearchProgress);
            }
        }

        private void searchBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs args)
        { 
            this.evermoreModel.AppState = EvermoreState.SearchingComplete;
        }

        #endregion


        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            switch (this.evermoreModel.AppState)
            { 
                case EvermoreState.Welcome:
                    this.PageCanvas.Children.Remove(this.evermoreModel.CurrentPage);
                    
                    if (!this.evermoreModel.IsAbsolutePath)
                    {
                        this.evermoreModel.AppState = EvermoreState.Searching;
                        this.PageCanvas.Children.Add(this.evermoreModel.SearchPage);
                        this.evermoreModel.CurrentPage = this.evermoreModel.SearchPage;
                        this.searchBackgroundWorker.RunWorkerAsync(new LocalFileArgs(this.evermoreModel.WelcomePage.fileNameTextBox.Text, 
                            this.IgnoreDirs, 5));
                    }
                    else
                    {
                        this.evermoreModel.AppState = EvermoreState.Watching;
                        this.PageCanvas.Children.Add(this.evermoreModel.WatchPage);
                        this.evermoreModel.CurrentPage = this.evermoreModel.WatchPage;
                    }
                    break;

                case EvermoreState.SearchingComplete:
                    this.evermoreModel.AppState = EvermoreState.Watching;
                    this.PageCanvas.Children.Remove(this.evermoreModel.CurrentPage);
                    this.PageCanvas.Children.Add(this.evermoreModel.WatchPage);
                    this.evermoreModel.CurrentPage = this.evermoreModel.WatchPage;
                    break;
            }
          }

        private void buttonPrevious_Click(object sender, RoutedEventArgs e)
        {
            switch (this.evermoreModel.AppState)
            { 
                case EvermoreState.Searching:
                    this.PageCanvas.Children.Remove(this.evermoreModel.CurrentPage);
                    this.PageCanvas.Children.Add(this.evermoreModel.WelcomePage);
                    this.evermoreModel.CurrentPage = this.evermoreModel.WelcomePage;
                    this.evermoreModel.AppState = EvermoreState.Welcome;
                    //this.buttonPrevious.IsEnabled = false;
                    break;
                case EvermoreState.Watching:
                    this.PageCanvas.Children.Remove(this.evermoreModel.CurrentPage);
                    this.PageCanvas.Children.Add(this.evermoreModel.WelcomePage);
                    this.evermoreModel.CurrentPage = this.evermoreModel.WelcomePage;
                    this.evermoreModel.AppState = EvermoreState.Welcome;
                    break;
                case EvermoreState.SearchingComplete:
                    this.PageCanvas.Children.Remove(this.evermoreModel.CurrentPage);
                    this.PageCanvas.Children.Add(this.evermoreModel.WelcomePage);
                    this.evermoreModel.CurrentPage = this.evermoreModel.WelcomePage;
                    this.evermoreModel.AppState = EvermoreState.Welcome;
                    break;
            }
        }
    }

    public class EvermoreModel : INotifyPropertyChanged
    {
        private EvermoreState appState;
        private WelcomePage welcomePage = new WelcomePage();
        private SearchPage searchPage = new SearchPage();
        private WatchPage watchPage = new WatchPage();
        private UserControl currentPage;
        private SearchMode searchMode;
        private PathMode pathMode;
        private Boolean isAbsolutePath = false;
        private Boolean isMachineLocal = false;
        private Boolean isFileFound = false;
        private string searchProgressLabelContent;

        #region Properties

        public WelcomePage WelcomePage
        {
            get
            {
                return this.welcomePage;
            }
        }

        public SearchPage SearchPage
        {
            get
            {
                return this.searchPage;
            }
        }

        public WatchPage WatchPage
        {
            get
            {
                return this.watchPage;
            }
        }

        public UserControl CurrentPage
        {
            get
            {
                return this.currentPage;
            }
            set
            {
                this.currentPage = value;
                this.RaisePropertyChanged("CurrentPage");
                this.RaisePropertyChanged("ControlPanelFooter");
                this.RaisePropertyChanged("ControlPanelColor");
            }
        }

        public System.Windows.Media.Color ControlPanelColor
        {
            get
            {
                if (this.currentPage == this.welcomePage)
                {
                    return System.Windows.Media.Brushes.BlueViolet.Color;
                }
                else if (this.currentPage == this.searchPage)
                {
                    return System.Windows.Media.Brushes.DarkOrange.Color;
                }
                else if(this.currentPage == this.WatchPage)
                {
                    return System.Windows.Media.Brushes.DeepPink.Color;
                }

                return System.Windows.Media.Brushes.BlueViolet.Color;
            }
        }

        public EvermoreState AppState
        {
            get
            {
                return this.appState;
            }
            set
            {
                if (this.appState == value)
                {
                    return;
                }

                // Post-state switching actions
                switch (this.AppState)
                { 
                    case EvermoreState.Watching:
                        this.WatchPage.EndWatch();
                        break;
                }

                // switch state
                this.appState = value;

                switch(this.AppState)
                {
                    case EvermoreState.Searching:
                        this.IsFileFound = false;
                        this.SearchPage.FoundFilesComboBox.Items.Clear();
                        break;
                    
                    case EvermoreState.SearchingComplete:
                        
                        if (this.IsFileFound)
                        {
                            this.SearchProgressLabelContent = "Done! Choose a file like a sir.";
                        }
                        else
                        {
                            this.SearchProgressLabelContent = "Nothing to do here. File not found.";
                        }
                        break;
                    case EvermoreState.Watching:
                        if (this.IsAbsolutePath == true)
                        {
                            this.WatchPage.InitWatch(this.WelcomePage.fileNameTextBox.Text);
                        }
                        else
                        {
                            this.WatchPage.InitWatch((string)this.SearchPage.FoundFilesComboBox.SelectedItem);
                        }
                        break;
                }

                this.RaisePropertyChanged("IsSearchComplete");
                this.RaisePropertyChanged("CanMoveBack");
                this.RaisePropertyChanged("CanMoveNext");
            }
        }

        public Boolean CanMoveBack
        {
            get
            {
                if (this.AppState == EvermoreState.Welcome || this.AppState == EvermoreState.Searching)
                {
                    return false;
                }

                return true;
            }
        }

        public Boolean CanMoveNext
        {
            get
            {
                if (this.AppState == EvermoreState.Watching || this.AppState == EvermoreState.Searching)
                {
                    return false;
                }

                return true;
            }
        }

        public String ControlPanelFooter
        { 
            get
            {
                if (this.CurrentPage == this.WelcomePage)
                {
                    return "Some information, first";
                }
                else if(this.CurrentPage == this.SearchPage)
                {
                    return "Patience!";
                }
                else if (this.CurrentPage == this.WatchPage)
                {
                    return "Princes kept the view!";
                }

                return "Coming Soon!";
            }
        }

        public Boolean IsAbsolutePath
        {
            get
            {
                return this.isAbsolutePath; 
            }
            set
            {
                this.isAbsolutePath = value;

                if (this.isAbsolutePath)
                {
                    this.pathMode = PathMode.Absolute;
                }
                else
                {
                    this.pathMode = PathMode.Search;
                }
            }
        }

        public Boolean IsMachineLocal
        {
            get
            {
                return this.isMachineLocal;
            }
            set
            {
                this.isMachineLocal = value;

                if (this.isMachineLocal)
                {
                    this.searchMode = SearchMode.Local;
                }
                else
                {
                    this.searchMode = SearchMode.Remote;
                }
            }
        }

        public ImageSource FileIcon
        {
            get
            {
                return Utils.GetIcon(this.WatchPage.FilePath);
            }
            set
            {
                this.RaisePropertyChanged("FileIcon");
            }
        }

        public Boolean IsFileFound
        {
            get
            {
                return this.isFileFound;
            }
            set
            {
                if (this.isFileFound != value)
                {
                    this.isFileFound = value;
                    this.RaisePropertyChanged("IsFileFound");
                }
            }
        }

        public Boolean IsSearchComplete
        {
            get
            {
                return (this.AppState == EvermoreState.SearchingComplete);
            }
            set
            { }
        }

        public string SearchProgressLabelContent
        {
            get
            {
                return this.searchProgressLabelContent;
            }
            set
            {
                this.searchProgressLabelContent = value;
                this.RaisePropertyChanged("SearchProgressLabelContent");
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }

    [ValueConversion(typeof(bool), typeof(bool))]
    public class InverseBooleanConverter: IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(bool))
                throw new InvalidOperationException("The target must be a boolean");

            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
    
    [ValueConversion(typeof(string), typeof(bool))]
    public class EmptyStringConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            string val = (string)value;
            return (bool)(val.Trim().Length > 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
