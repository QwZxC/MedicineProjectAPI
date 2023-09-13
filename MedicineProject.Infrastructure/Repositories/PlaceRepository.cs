using MedicineProject.Domain.Context;
using MedicineProject.Domain.Models.Base;
using MedicineProject.Domain.Repositories;

namespace MedicineProject.Infrastructure.Repositories
{
    public class PlaceRepository : BaseRepository, IPlaceRepository
    {
        public PlaceRepository(WebMobileContext context) : base(context)
        {

        }
        
        public IEnumerable<TModel> GetItems<TModel>()
            where TModel : BaseModel
        {
            return _context.Set<TModel>();
        }
    }
}
