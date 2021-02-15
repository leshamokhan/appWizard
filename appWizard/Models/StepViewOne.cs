using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appWizard.Models
{
    public class StepViewOne
    {
        [Required]
        public string Salutation { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$", ErrorMessage = "Please enter correct Email")]
        public string Email { get; set; }        
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Confirm Email")]
        [Compare("Email", ErrorMessage = "The Email and confirmation Email do not match.")]
        public string ConfirmEmail { get; set; }
        [Required]
        [Phone]
        [RegularExpression(@"^(\+{0,1}[\s]{0,1}\d{1,3}[\s.-]{0,1})?\(?\d{1,3}\)?[\s.-]{0,1}?\d{3}[\s.-]{0,1}?\d{2}[\s.-]{0,1}?\d{2}$", ErrorMessage = "Please enter correct Phone<br>+ ***(**)***-**-**<br>+ **(***) * **-**-**<br>+**(**) * **-**-**<br>+*(*) * **-**-**<br>+***********<br>")]
        public string Phone { get; set; }
        [Phone]
        [RegularExpression(@"^(\+{0,1}[\s]{0,1}\d{1,3}[\s.-]{0,1})?\(?\d{1,3}\)?[\s.-]{0,1}?\d{3}[\s.-]{0,1}?\d{2}[\s.-]{0,1}?\d{2}$", ErrorMessage = "Please enter correct Fax<br>+ ***(**)***-**-**<br>+ **(***) * **-**-**<br>+**(**) * **-**-**<br>+*(*) * **-**-**<br>+***********<br>")]
        public string Fax { get; set; }
        [Phone]
        [RegularExpression(@"^(\+{0,1}[\s]{0,1}\d{1,3}[\s.-]{0,1})?\(?\d{1,3}\)?[\s.-]{0,1}?\d{3}[\s.-]{0,1}?\d{2}[\s.-]{0,1}?\d{2}$", ErrorMessage = "Please enter correct Mobile<br>+ ***(**)***-**-**<br>+ **(***) * **-**-**<br>+**(**) * **-**-**<br>+*(*) * **-**-**<br>+***********<br>")]
        public string Mobile { get; set; }



        public string ModelId { get; set; }
    }
}
