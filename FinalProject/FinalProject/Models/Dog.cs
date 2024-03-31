namespace FinalProject.Models
{
    public class Dog
    {
        public int DogId { get; set; }
        public string? Breed { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public bool? IsVaccinated { get; set; }
        public AdoptionCenter? CenterName { get; set; }
        public int? CenterNameId { get; set; }
        public List<Adoption>? Adoptions { get; set; }
    }
}
