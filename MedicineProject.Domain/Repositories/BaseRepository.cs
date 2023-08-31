using MedicineProject.Domain.Context;
using MedicineProject.Domain.Models.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MedicineProject.Domain.Repositories
{
    public class BaseRepository : IBaseRepository 
    {
        protected readonly WebMobileContext context;
        
        public BaseRepository(WebMobileContext context)
        {
            this.context = context;
        }

        public async Task<EntityEntry<TModel>> CreateItemAsync<TModel>(TModel item)
            where TModel : BaseModel
        {
            var itemFromDb = await context.Set<TModel>().AddAsync(item);
            await context.SaveChangesAsync();
            return itemFromDb;
        }

        public async Task DeleteItemAsync<TModel>(long id)
            where TModel : BaseModel
        {
            TModel oldItem = await context.Set<TModel>().FindAsync(id);
            if( oldItem != null)
            {
                context.Set<TModel>().Remove(oldItem);
            }
            await context.SaveChangesAsync();
        }

        public async Task<List<TModel>> GetItemListAsync<TModel>()
            where TModel : BaseModel
        {
            return await context.Set<TModel>().ToListAsync();
        }

        public async Task<TModel> TryGetItemByIdAsync<TModel>(long id)
            where TModel : BaseModel
        {
            return await context.Set<TModel>().FindAsync(id);
        }

        public async Task<TModel> TryGetItemByNameAsync<TModel>(string name)
            where TModel : BaseModel
        {
            return await context.Set<TModel>().FirstOrDefaultAsync(item => item.Name.Contains(name));
        }

        public async Task<EntityEntry<TModel>> UpdateItemAsync<TModel>(TModel item, TModel oldItem)
            where TModel : BaseModel
        {
            EntityEntry<TModel> updatedItem = context.Set<TModel>().Update(oldItem);
            await context.SaveChangesAsync();
            return updatedItem;
        }
    }
}
