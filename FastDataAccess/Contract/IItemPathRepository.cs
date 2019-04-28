using System.Collections.Generic;

namespace FastDataAccess.Contract
{
    public interface IItemPathRepository
    {
        void Add(ItemPath itemPath);

        ItemPath GetById(int id);

        ItemPath GetByPath(string path);

        IEnumerable<ItemPath> GetByItem(Item item);

        void Update(ItemPath itemPath);

        void Delete(ItemPath itemPath);
    }
}
