using System.ComponentModel.DataAnnotations;

namespace ContactInformation.Core.ViewModel
{
    public class ForgotViewModel
    {
        [Required] [Display(Name = "Email")] public string Email { get; set; }
    }
}