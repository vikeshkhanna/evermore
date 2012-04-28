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


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EvermoreModel evermoreModel = new EvermoreModel();

        public MainWindow()
        {
            InitializeComponent();
            this.PageCanvas.Children.Add(this.evermoreModel.WelcomePage);
            this.evermoreModel.CurrentPage = this.evermoreModel.WelcomePage;
            this.DataContext = this.evermoreModel;
        }

        public EvermoreModel EvermoreModel
        {
            get
            {
                return this.evermoreModel;            
            }
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            switch (this.evermoreModel.AppState)
            { 
                case EvermoreState.Welcome:
                    this.PageCanvas.Children.Remove(this.evermoreModel.CurrentPage);
                    this.PageCanvas.Children.Add(this.evermoreModel.SearchPage);
                    this.evermoreModel.CurrentPage = this.evermoreModel.SearchPage;
                    this.evermoreModel.AppState = EvermoreState.Searching;
                    //this.buttonPrevious.IsEnabled = true;

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
            }
        }

      
    }

    public class EvermoreModel : INotifyPropertyChanged
    {
        private EvermoreState appState;
        private WelcomePage welcomePage = new WelcomePage();
        private SearchPage searchPage = new SearchPage();
        private UserControl currentPage;
        private SearchMode searchMode;
        private PathMode pathMode;
        private Boolean isAbsolutePath = false;
        private Boolean isMachineLocal = false;

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
                this.RaisePropertyChanged("ControlPanelColor");
            }
        }

        public Color ControlPanelColor
        {
            get
            {
                if (this.currentPage == this.welcomePage)
                {
                    return Brushes.BlueViolet.Color;
                }
                else if (this.currentPage == this.searchPage)
                {
                    return Brushes.DarkOrange.Color;
                }

                return Brushes.BlueViolet.Color;
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
                this.appState = value;
                this.RaisePropertyChanged("CanMoveBack");
                this.RaisePropertyChanged("CanMoveNext");
                this.RaisePropertyChanged("");
            }
        }

        public Boolean CanMoveBack
        {
            get
            {
                if (this.AppState != EvermoreState.Welcome)
                {
                    return true;
                }

                return false;
            }
        }

        public Boolean CanMoveNext
        {
            get
            {
                return true;
            }
        }

        public String ControlPanelFooter
        { 
            get
            {
                if (this.currentPage == this.welcomePage)
                {
                    return "Some information, first";
                }
                else if(this.currentPage == this.searchPage)
                {
                    return "Patience!";
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


        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propName)
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
