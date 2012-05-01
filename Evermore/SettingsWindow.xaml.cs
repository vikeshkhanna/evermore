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
using System.Diagnostics;

namespace Evermore
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            this.Width = SystemParameters.PrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;
            Init();
        }

        private void Init()
        {
            this.MaxRecusionDepth.Text = Properties.Settings.Default.MAX_DEPTH.ToString();
            List<string> ignoreDirs = Properties.Settings.Default.IgnoreDirs.Split('\\').ToList<string>();

            foreach (string dir in ignoreDirs)
            {
                if (Utils.IsValidIgnoreDir(dir))
                {
                    this.IgnoreDirsList.Items.Add(dir);
                }
            }
        }

        private void AddDir_Click(object sender, RoutedEventArgs e)
        {
            string toAdd = this.IgnoreDirectory.Text;

            if (Utils.IsValidIgnoreDir(toAdd))
            {
                this.IgnoreDirsList.Items.Add(toAdd.Trim());
            }
        }


        private void RemoveDir_Click(object sender, RoutedEventArgs e)
        {
            if (this.IgnoreDirsList.SelectedItems.Count > 0)
            {
                this.IgnoreDirsList.Items.Remove(this.IgnoreDirsList.SelectedItem);
            }
        }

        private void SaveSettings_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int max_depth = Convert.ToInt32(this.MaxRecusionDepth.Text);
                Properties.Settings.Default.MAX_DEPTH = max_depth;

                string storeString = String.Empty;

                foreach (string dir in this.IgnoreDirsList.Items)
                {
                    if (Utils.IsValidIgnoreDir(dir))
                    {
                        storeString += dir.Trim() + @"\";
                    }
                }

                if (storeString.EndsWith(@"\"))
                {
                    storeString.TrimEnd('\\');
                }

                Properties.Settings.Default.IgnoreDirs = storeString;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            this.Close();
        }

        private void CancelSettings_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
