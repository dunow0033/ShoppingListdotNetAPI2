using Microsoft.EntityFrameworkCore;
using ShoppingListdotNetAPI2.Models;

namespace ShoppingListdotNetAPI2.Repositories
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private readonly ShoppingListContext _dbContext;

        public ShoppingListRepository(ShoppingListContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ShoppingListItem> AddItem(ShoppingListItem item)
        {
            var entry = await _dbContext.ShoppingListItems.AddAsync(item);

            return entry.Entity;
        }

        public void DeleteItem(ShoppingListItem item)
        {
            _dbContext.ShoppingListItems.Remove(item);
        }

        public async Task<ShoppingListItem?> GetItem(Guid id)
        {
            var item = await _dbContext.ShoppingListItems.FindAsync(id);

            return item;
        }

        public async Task<List<ShoppingListItem>> GetItems()
        {
            var items = await _dbContext.ShoppingListItems.AsNoTracking().ToListAsync();

            return items;
        }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void UpdateItem(ShoppingListItem item)
        {
            _dbContext.ShoppingListItems.Update(item);
        }
    }
}
