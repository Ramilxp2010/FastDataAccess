using System;
using System.Collections.Generic;
using System.Text;

namespace SynchronizeData
{
    public class SyncData : ISyncData
    {
        private SyncManager _manager;
        public string TargetFolder { get; set; }

        public SyncData(SyncManager manager, string targetFolder)
        {
            _manager = manager;
            TargetFolder = targetFolder;
        }

        public void UpdateAddedFiles()
        {
            var pathItem = _manager.ItemPathRepository.GetByPath(TargetFolder);
            var items = _manager.ItemRepository.GetByItemPath(pathItem);


        }

        public void UpdateDeletedFiles()
        {
            throw new NotImplementedException();
        }

        public void UpdateUpdatedFiles()
        {
            throw new NotImplementedException();
        }
    }
}
