using System.Runtime.Serialization;

namespace FastDataAccess.Contract
{
    /// <summary>
    /// Describes file, folder or another file type paths
    /// </summary>
    [DataContract]
    public class ItemPath
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }
    }
}
