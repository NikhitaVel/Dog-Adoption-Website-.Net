namespace FinalProject.Models
{
    public class AdoptionCenter
    {
        public int AdoptionCenterId { get; set; }
        public string? CenterName { get; set; }
        public string? Location { get; set; }
        public int? ZipCode { get; set; }
        public string? ContactEmail { get; set; }
        public int? ContactPhone { get; set; }
        public List<Dog>? Dogs { get; set; }
        public List<Adoption>? Adoptions { get; set; }
        public List<Donation>? Donations { get; set; }
        public List<Appointment>? Appointments { get; set; }

    }
}
