using FastDataAccess.Contract;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repository
{
    public class ItemRepository : IItemRepository
    {
        private DataAccessDbContext dbContext;

        public ItemRepository(DataAccessDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Add Item
        /// </summary>
        /// <param name="item"></param>
        public void Add(Item item)
        {
            dbContext.Items.Add(item);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Get first or default item by item id
        /// </summary>
        /// <param name="id"> Item id</param>
        /// <returns>Item or null</returns>
        public Item Get(int id)
        {
            return dbContext.Items.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Get first or default item by item name
        /// </summary>
        /// <param name="name">Item name</param>
        /// <returns>Item or null</returns>
        public Item GetByName(string name)
        {
            return dbContext.Items.FirstOrDefault(x => x.Name == name);
        }

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns>Item list</returns>
        public IEnumerable<Item> GetAll()
        {
            return dbContext.Items;
        }

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="item"></param>
        public void Update(Item item)
        {
            var oldItem = Get(item.Id);
            if (oldItem == null)
            {
                return;
            }
            else
            {
                oldItem.Name = item.Name;
                dbContext.Items.Update(oldItem);
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="item"></param>
        public void Delete(Item item)
        {
            dbContext.Items.Remove(item);
            dbContext.SaveChanges();
        }
    }
}
