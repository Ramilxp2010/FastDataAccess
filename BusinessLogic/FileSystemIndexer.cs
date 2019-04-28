using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DataAccess.Repository;

namespace BusinessLogic
{
    public class FileSystemIndexer : IFileIndexer
    {
        public void IndexingFolder(string path)
        {

        }

        public void IndexingFolder(DirectoryInfo directoryInfo)
        {
            foreach (var directory in directoryInfo.GetDirectories())
            {
                SaveAllFiles(directory);
            }
        }

        private void SaveAllFiles(DirectoryInfo directory)
        {
            foreach (var file in directory.GetFiles())
            {
            }
        }
    }
}
