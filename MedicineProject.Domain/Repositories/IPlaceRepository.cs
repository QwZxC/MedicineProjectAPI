using MedicineProject.Domain.Models.Base;

namespace MedicineProject.Domain.Repositories
{
    public interface IPlaceRepository : IBaseRepository
    {
        IEnumerable<TModel> GetItems<TModel>() where TModel : BaseModel;
    }
}
