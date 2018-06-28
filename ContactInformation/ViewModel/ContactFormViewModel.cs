using System.ComponentModel.DataAnnotations;

namespace ContactInformation.ViewModel
{
    public class ContactFormViewModel
    {
        [Required]

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailId { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public bool Status { get; set; }

    }
}