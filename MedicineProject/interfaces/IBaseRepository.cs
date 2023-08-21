using MedicineProject.Models.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MedicineProject.interfaces
{
    public interface IBaseRepository
    {
        Task<List<MODEL>> GetItemList<MODEL>() where MODEL : BaseModel;

        Task<MODEL> TryGetItemByIdAsync<MODEL>(long id) where MODEL : BaseModel;

        Task<MODEL> TryGetItemByNameAsync<MODEL>(string name) where MODEL : BaseModel;

        Task<EntityEntry<MODEL>> CreateItemAsync<MODEL>(MODEL item) where MODEL : BaseModel;

        EntityEntry<MODEL> UpdateItemAsync<MODEL>(MODEL item, MODEL oldItem) where MODEL : BaseModel; 

        Task DeleteItemAsync<MODEL>(long id) where MODEL : BaseModel;

        Task SaveAsync();
    }
}
