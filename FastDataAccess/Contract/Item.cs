using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FastDataAccess.Contract
{
    /// <summary>
    /// This entity describes file, folder or another files in the file system
    /// </summary>
    [DataContract]
    public class Item
    {
        public Item()
        {
            ItemPaths = new List<ItemPath>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ItemPath> ItemPaths;
    }
}
