using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Management;
using System.Windows.Controls;
using System.Threading;
using System.Windows.Media;
using System.Drawing;
using System.Windows.Interop;

namespace Evermore
{
    public static class Utils
    {
        public static int REPORT_FREQUENCY = 50;
        private static int reportCount = 0;

        private static void ApplyAllFiles(string folder, string searchFile, List<string> IgnoreDirs, List<string> files, int MAX_DEPTH = 5, int depth = 0, Action<string, bool> callback = null)
        {
            //To avoid default pruning, send MAX_DEPTH negative
            if (depth == MAX_DEPTH)
            {
                Debug.WriteLine("[Depth Limit] Ignoring folder : " + folder);
                return;
            }

            foreach (string file in Directory.GetFiles(folder))
            {
                if (file.EndsWith(searchFile))
                {
                    Debug.WriteLine("[Success] Found file : " + file);
                    
                    if (callback != null)
                    {
                        callback(file, true);
                    } 
                    
                    files.Add(file);
                }

                Debug.WriteLine("[Processing] Processing file: " + file);
            }

            foreach (string subDir in Directory.GetDirectories(folder))
            {
                bool searchDir = true;
                Debug.WriteLine("[Processing] Processing dir: " + subDir);
                
                foreach (var ignorable in IgnoreDirs)
                {
                    if (subDir.ToLower().Contains(ignorable))
                    {
                        Debug.WriteLine("[Ignored] Ignoring dir : " + subDir);
                        searchDir = false;
                        break;
                    }
                }

                if (searchDir)
                {
                    try
                    {
                        if (reportCount == 0)
                        {
                            callback(subDir, false);
                        }

                        reportCount = (reportCount + 1) % REPORT_FREQUENCY;
                        
                        ApplyAllFiles(subDir, searchFile, IgnoreDirs, files, MAX_DEPTH, depth + 1, callback);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("[Exception][ApplyAllFiles] " + ex.Message);
                    }
                }
            }
        }

        public static List<string> SearchFileLocal(string _searchFile, List<string> _ignoreDirs, int MAX_DEPTH = -1, Action<string, bool> callback = null)
        {
            List<string> files = new List<string>();

            //@Stan R. suggested an improvement to handle floppy drives...
            //foreach (DriveInfo d in DriveInfo.GetDrives())
            foreach (DriveInfo d in DriveInfo.GetDrives().Where(x => (x.DriveType == DriveType.Fixed || x.DriveType == DriveType.Network 
                || x.DriveType == DriveType.Removable) && x.IsReady == true))
            {
                try
                {
                    Debug.WriteLine("Searching for the file in : " + d.Name);
                    ApplyAllFiles(d.Name, _searchFile, _ignoreDirs, files, MAX_DEPTH, 0, callback);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            foreach (var file in files)
            {
                Debug.WriteLine(file);
            }

            return files;
        }

        public static List<string> SearchFileRemote(string _machine, string _username, string _password, string _searchFile, List<string> _ignoreDirs, int MAX_DEPTH = -1)
        { 
            List<string> files = new List<string>();

            var options = new ConnectionOptions { Username = _username, Password = _password };
            var scope = new ManagementScope(@"\\" + _machine + @"\root\cimv2", options);
            var queryString = "Select Name, Size, FreeSpace from Win32_LogicalDisk where DriveType=3"; var query = new ObjectQuery(queryString);

            var worker = new ManagementObjectSearcher(scope, query);

            var results = worker.Get();
          
            foreach (ManagementObject item in results)
            {
                Debug.WriteLine("{0} {2} {1}", item["Name"], item["FreeSpace"], item["Size"]);
                string drive = item["Name"].ToString().Replace(":","");
                ApplyAllFiles(@"\\" + _machine + @"\" + drive + @"$", _searchFile,_ignoreDirs,files,MAX_DEPTH);
            }
            
            foreach (var file in files)
            {
                Debug.WriteLine(file);
            }

            return files;
        }

        public static ImageSource GetIcon(string file)
        {
            ImageSource icon = null;

            if (System.IO.File.Exists(file))
            {
                using (Icon sysicon = Icon.ExtractAssociatedIcon(file))
                {
                    // This new call in WPF finally allows us to read/display 32bit Windows file icons!
                    icon = Imaging.CreateBitmapSourceFromHIcon(
                    sysicon.Handle,
                    System.Windows.Int32Rect.Empty,
                    System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                }
            }

            return icon;
        }
    }
}
    
