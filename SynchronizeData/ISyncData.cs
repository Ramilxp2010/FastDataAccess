using System;
using System.Collections.Generic;
using System.Text;

namespace SynchronizeData
{
    public interface ISyncData
    {
        string TargetFolder { get; set; }
        void UpdateAddedFiles();
        void UpdateDeletedFiles();
        void UpdateUpdatedFiles();
    }
}
