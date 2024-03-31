namespace FinalProject.Models
{
    public class Adoption
    {
        public int AdoptionId { get; set; }
        public User? User { get; set; }
        public int? UserId { get; set; }
        public AdoptionCenter? Center { get; set; }
        public int? CenterId { get; set; }
        public Dog? Dog { get; set; }
        public int? DogId { get; set; }

    }
}
