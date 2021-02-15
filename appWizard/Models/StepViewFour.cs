using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appWizard.Models
{
    public class StepViewFour
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression(@"^((?=.*\d)(?=.*[A-Z])(?=.*[a-z]).{8,100})$", ErrorMessage = @"Password must include:<br>- at least 8 characters<br>- a UPPER case letter<br>- a lower case letter<br>- a number")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "I have read and accept the terms of use")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Required condition")]
        public bool Accept { get; set; }        
        
        public string ModelId { get; set; }
    }
}
