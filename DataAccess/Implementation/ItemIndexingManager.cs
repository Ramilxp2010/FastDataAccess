using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FastDataAccess.Contract;

namespace DataAccess.Implementation
{
    public class ItemIndexingManager
    {
        private IItemRepository ItemRepository;
        private IItemPathRepository ItemPathRepository;

        public ItemIndexingManager(IItemRepository itemRepository, IItemPathRepository itemPathRepository)
        {
            ItemRepository = itemRepository;
            ItemPathRepository = itemPathRepository;
        }

        public void SaveItemInfo(FileInfo fileInfo)
        {
            
        }
    }
}
