using System.IO;

namespace BusinessLogic
{
    public interface IFileIndexer
    {
        void IndexingFolder(string path);

        void IndexingFolder(DirectoryInfo directoryInfo);
    }
}
