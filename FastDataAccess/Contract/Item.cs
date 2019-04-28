using System;
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
        public int Id { get; set; }

        public string Name { get; set; }

        public int ItemPathId { get; set; }

        public DateTimeOffset ModyfiedDate { get; set; }

        public ItemPath ItemPath;
    }
}
