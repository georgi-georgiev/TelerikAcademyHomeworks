using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.FileTree
{
    public class Folder
    {
        public Folder(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            this.Name = dirInfo.Name;

            CreateFilesAndFolders(dirInfo);
        }

        public string Name { get; set; }

        public List<File> Files { get; set; }

        public List<Folder> Folders { get; set; }

        public long GetFilesSize()
        {
            long size = 0;

            foreach (var file in Files)
            {
                size += file.Size;
            }

            foreach (var folder in Folders)
            {
                size += folder.GetFilesSize();
            }

            return size;
        }

        public Folder FindFolder(string name)
        {

            foreach (var folder in Folders)
            {
                if (folder.Name == name)
                {
                    return folder;
                }
            }

            foreach (var folder in Folders)
            {
                Folder foundFolder = FindFolder(name);
                if (foundFolder != null)
                {
                    return foundFolder;
                }
            }

            throw new ArgumentException("No such folder");
        }

        private void CreateFilesAndFolders(DirectoryInfo dirInfo)
        {
            FileInfo[] files;
            try
            {
                files = dirInfo.GetFiles();
            }
            catch (UnauthorizedAccessException)
            {
                this.Files = new List<File>();
                this.Folders = new List<Folder>();
                return;
            }

            this.Files = new List<File>();
            foreach (var file in files)
            {
                this.Files.Add(new File(file.Name, file.Length));
            }

            DirectoryInfo[] directories = dirInfo.GetDirectories();
            Folders = new List<Folder>();
            foreach (var directory in directories)
            {
                this.Folders.Add(new Folder(directory.FullName));
            }
        }
    }
}
