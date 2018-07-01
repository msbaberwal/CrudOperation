using System.ComponentModel.DataAnnotations;

namespace ContactInformation.ViewModel
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required] [Display(Name = "Email")] public string Email { get; set; }
    }
}