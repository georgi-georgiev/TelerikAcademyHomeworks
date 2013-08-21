using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.FileTree
{
    class DirectoryTree
    {
        public DirectoryTree(string rootPath)
        {
            this.RootPath = rootPath;
            this.RootFolder = new Folder(rootPath);
        }

        public string RootPath { get; set; }
        public Folder RootFolder { get; set; }

        public double CalculateSizeOfTree()
        {
            long sizeBytes = RootFolder.GetFilesSize();
            double sizeMegaBytes = sizeBytes / 1048576;
            return sizeMegaBytes;
        }

        public double CalculateSizeOfFolder(string folderName)
        {
            Folder foundFolder = RootFolder.FindFolder(folderName);

            long sizeBytes = GetFilesSize(foundFolder);
            double sizeMegaBytes = sizeBytes / 1048576;

            return sizeMegaBytes;
        }

        public Folder FindFolder(string folderName)
        {
            return RootFolder.FindFolder(folderName);
        }

        public long GetFilesSize(Folder folder)
        {
            long size = 0;

            foreach (var file in folder.Files)
            {
                size += file.Size;
            }

            foreach (var subFolder in folder.Folders)
            {
                size += subFolder.GetFilesSize();
            }

            return size;
        }
    }
}
