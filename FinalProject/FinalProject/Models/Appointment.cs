namespace FinalProject.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public User? Name { get; set; }
        public int? NameId { get; set; }
        public DateTime? DateTime { get; set; }
        public AdoptionCenter? Center { get; set; }
        public int? CenterId { get; set; }
        public string? Reason { get; set; }

    }
}
