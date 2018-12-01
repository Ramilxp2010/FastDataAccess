using System.Collections.Generic;

namespace FastDataAccess.Contract
{
    public interface IItemRepository
    {
        void Add(Item item);

        Item Get(int id);

        Item GetByName(string name);

        IEnumerable<Item> GetAll();

        void Update(Item item);

        void Delete(Item item);
    }
}
