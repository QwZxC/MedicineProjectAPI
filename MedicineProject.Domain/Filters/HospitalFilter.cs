using MedicineProject.Domain.DTOs;

namespace MedicineProject.Domain.Filters
{
    public class HospitalFilter
    {
        public string Name { get; set; } = string.Empty;

        public int MinRating { get; set; } = 0;

        public int MaxRating { get; set; } = 5;

        public string CityName { get; set; }

        public HospitalFilter()
        {

        }
    }
}
