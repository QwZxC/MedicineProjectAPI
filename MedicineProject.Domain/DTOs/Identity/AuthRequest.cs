namespace MedicineProject.DTOs.Identity
{
    public record AuthRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
