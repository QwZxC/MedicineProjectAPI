using MedicineProject.Context;
using MedicineProject.interfaces;
using MedicineProject.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MedicineProject.Repositories.Base
{
    public class BaseRepository : IBaseRepository 
    {
        protected readonly WebMobileContext context;
        
        public BaseRepository(WebMobileContext context)
        {
            this.context = context;
        }

        public async Task<EntityEntry<MODEL>> CreateItemAsync<MODEL>(MODEL item)
            where MODEL : BaseModel
        {
           return await context.Set<MODEL>().AddAsync(item);
        }

        public async Task DeleteItemAsync<MODEL>(long id)
            where MODEL : BaseModel
        {
            MODEL oldItem = await context.Set<MODEL>().FindAsync(id);
            if( oldItem != null)
            {
                context.Set<MODEL>().Remove(oldItem);
            }
        }

        public async Task<List<MODEL>> GetItemList<MODEL>()
            where MODEL : BaseModel
        {
            return await context.Set<MODEL>().ToListAsync();
        }

        public async Task SaveAsync()
        {
           await context.SaveChangesAsync();
        }

        public async Task<MODEL> TryGetItemByIdAsync<MODEL>(long id)
            where MODEL : BaseModel
        {
            return await context.Set<MODEL>().FindAsync(id);
        }

        public async Task<MODEL> TryGetItemByNameAsync<MODEL>(string name)
            where MODEL : BaseModel
        {
            return await context.Set<MODEL>().FirstOrDefaultAsync(item => item.Name.Contains(name));
        }

        public EntityEntry<MODEL> UpdateItemAsync<MODEL>(MODEL item, MODEL oldItem)
            where MODEL : BaseModel
        {
            return context.Set<MODEL>().Update(oldItem);
        }
    }
}
