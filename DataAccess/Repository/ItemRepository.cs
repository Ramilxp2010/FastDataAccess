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
        /// GetById first or default item by item id
        /// </summary>
        /// <param name="id"> Item id</param>
        /// <returns>Item or null</returns>
        public Item GetById(int id)
        {
            return dbContext.Items.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// GetById first or default item by item name
        /// </summary>
        /// <param name="name">Item name</param>
        /// <returns>Item or null</returns>
        public IEnumerable<Item> GetByName(string name)
        {
            return dbContext.Items.Where(x => x.Name == name);
        }

        /// <summary>
        /// GetById all items
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
            var oldItem = GetById(item.Id);
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
        
        public IEnumerable<Item> GetByItemPath(ItemPath itemPath)
        {
            return dbContext.Items.Where(x => x.ItemPathId == itemPath.Id);
        }
    }
}
