using System.ComponentModel.DataAnnotations;

namespace ContactInformation.ViewModel
{
    public class ForgotViewModel
    {
        [Required] [Display(Name = "Email")] public string Email { get; set; }
    }
}