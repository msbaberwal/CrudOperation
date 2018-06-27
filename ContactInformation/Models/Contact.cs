using System.ComponentModel.DataAnnotations;

namespace ContactInformation.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string EmailId { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public bool Status { get; set; }
    }
}