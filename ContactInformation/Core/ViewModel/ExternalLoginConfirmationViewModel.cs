﻿using System.ComponentModel.DataAnnotations;

namespace ContactInformation.Core.ViewModel
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required] [Display(Name = "Email")] public string Email { get; set; }
    }
}