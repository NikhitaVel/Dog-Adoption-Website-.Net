using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Donation
    {
        public int DonationId { get; set; }
        public User? User { get; set; }
        [DisplayName("Donar Name")]
        public int? UserId { get; set; }
        public AdoptionCenter? Center { get; set; }
        [DisplayName("Adoption Center")]
        public int? CenterId { get; set; }

        [DisplayName("Amount(in $)")]
        public decimal? Amount { get; set; }

        [DisplayName("Donation Date")]
        [DataType(DataType.Date)]
        public DateTime? DonationDate { get; set; }
        public string? ContactEmail { get; set; }
        public int? ContactPhone { get; set; }

    }
}
