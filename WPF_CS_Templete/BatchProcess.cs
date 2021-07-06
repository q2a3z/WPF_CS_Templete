using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WPF_CS_Templete
{
    class BatchProcess
    {
        public static String sTrMSBuildPath = @"C:\";
        private enum FilePathType
        { 
            NotFound,
            File,
            Directory,
        }
        private static FilePathType GetFilePathType(string path) 
        {
            if (File.Exists(path)) return FilePathType.File;
            if (Directory.Exists(path)) return FilePathType.Directory;
            return FilePathType.NotFound;
        }
        public String GetMSbuildPath { get { return sTrMSBuildPath; }set { sTrMSBuildPath = value; } }
    }
}
