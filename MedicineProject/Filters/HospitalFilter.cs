using MedicineProject.DTOs;

namespace MedicineProject.Filters
{
    public class HospitalFilter
    {
        public string Name { get; set; } = string.Empty;

        public int MinRating { get; set; } = 0;

        public int MaxRating { get; set; } = 5;

        public long CityId { get; set; }

        public HospitalFilter()
        {

        }
    }
}
