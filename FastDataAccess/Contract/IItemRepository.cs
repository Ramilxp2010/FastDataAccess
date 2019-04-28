using System.Collections.Generic;

namespace FastDataAccess.Contract
{
    public interface IItemRepository
    {
        void Add(Item item);

        Item GetById(int id);

        IEnumerable<Item> GetByName(string name);

        IEnumerable<Item> GetByItemPath(ItemPath itemPath);

        IEnumerable<Item> GetAll();

        void Update(Item item);

        void Delete(Item item);
    }
}
