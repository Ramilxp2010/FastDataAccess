using FastDataAccess.Contract;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repository
{
    public class ItemPathRepository : IItemPathRepository
    {
        private DataAccessDbContext dbContext;

        public ItemPathRepository(DataAccessDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Add item path
        /// </summary>
        /// <param name="itemPath"></param>
        public void Add(ItemPath itemPath)
        {
            dbContext.ItemPaths.Add(itemPath);
            dbContext.SaveChanges();
        }

        /// <summary>
        /// GetById item path by item path id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ItemPath or null</returns>
        public ItemPath GetById(int id)
        {
            return dbContext.ItemPaths.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// GetById item path by path
        /// </summary>
        /// <param name="path"></param>
        /// <returns>ItemPath or null</returns>
        public ItemPath GetByPath(string path)
        {
            return dbContext.ItemPaths.FirstOrDefault(x => x.Path == path);
        }

        /// <summary>
        /// GetById item path by item
        /// </summary>
        /// <param name="item"></param>
        /// <returns>ItemPath list</returns>
        public IEnumerable<ItemPath> GetByItem(Item item)
        {
            return dbContext.ItemPaths.Where(x => x.ItemId == item.Id);
        }

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="itemPath"></param>
        public void Update(ItemPath itemPath)
        {
            var oldItem = GetById(itemPath.Id);
            if (oldItem == null)
            {
                return;
            }
            else
            {
                oldItem.Path = itemPath.Path;
                dbContext.ItemPaths.Update(oldItem);
                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Delete itemPath
        /// </summary>
        /// <param name="itemPath"></param>
        public void Delete(ItemPath itemPath)
        {
            dbContext.ItemPaths.Remove(itemPath);
            dbContext.SaveChanges();
        }
    }
}
