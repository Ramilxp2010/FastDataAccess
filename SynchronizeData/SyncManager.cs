using System;
using System.Collections.Generic;
using System.Text;
using FastDataAccess.Contract;

namespace SynchronizeData
{
    public class SyncManager
    {
        public IItemRepository ItemRepository { get; }
        public IItemPathRepository ItemPathRepository { get; }

        public SyncManager(IItemRepository itemRepository, IItemPathRepository itemPathRepository)
        {
            ItemRepository = itemRepository;
            ItemPathRepository = itemPathRepository;
        }
    }
}
