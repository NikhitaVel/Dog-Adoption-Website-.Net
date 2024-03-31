namespace FinalProject.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? ContactEmail { get; set; }
        public int? ContactPhone { get; set; }
        public List<Adoption>? Adoptions { get; set; }
        public List<Donation>? Donations { get; set; }
        public List<Appointment>? Appointments { get; set; }

    }
}
