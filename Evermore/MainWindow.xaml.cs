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
            }
        }

        public Color ControlPanelColor
        {
            get
            {
                if (this.currentPage == this.welcomePage)
                {
                    return Brushes.BurlyWood.Color;
                }
                else if (this.currentPage == this.searchPage)
                {
                    return Brushes.BurlyWood.Color;
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
}
