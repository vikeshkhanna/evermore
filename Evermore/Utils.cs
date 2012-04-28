using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Evermore
{
    public static class Utils
    {
        private static void ApplyAllFiles(string folder, string searchFile, List<string> IgnoreDirs, List<string> files, int MAX_DEPTH = 5, int depth = 0)
        {
            //To avoid default pruning, send MAX_DEPTH negative
            if (depth == MAX_DEPTH)
            {
                return;
            }

            foreach (string file in Directory.GetFiles(folder))
            {
                if (file.EndsWith(searchFile))
                {
                    files.Add(file);
                }
            }

            foreach (string subDir in Directory.GetDirectories(folder))
            {
                bool searchDir = true;

                foreach (var ignorable in IgnoreDirs)
                {
                    if (subDir.ToLower().Contains(ignorable))
                    {
                        Console.WriteLine("Ignoring dir : " + subDir);
                        searchDir = false;
                        break;
                    }
                }

                if (searchDir)
                {
                    try
                    {
                        ApplyAllFiles(subDir, searchFile, IgnoreDirs, files, MAX_DEPTH, depth + 1);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
            }
        }

        public static List<string> SearchFileLocal(string _searchFile, List<string> _ignoreDirs, int MAX_DEPTH = -1)
        {
            var files = new List<string>();

            //@Stan R. suggested an improvement to handle floppy drives...
            //foreach (DriveInfo d in DriveInfo.GetDrives())
            foreach (DriveInfo d in DriveInfo.GetDrives().Where(x => x.IsReady == true))
            {
                try
                {
                    Debug.WriteLine("Searching for the file in : " + d.Name);
                    ApplyAllFiles(d.Name, _searchFile, _ignoreDirs, files, MAX_DEPTH);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            return files;
        }
    }
}
