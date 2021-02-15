using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appWizard.Models
{
    public class StepViewThree
    {
        [Required]
        public string Country { get; set; }
        [Required]
        [Display(Name = "Office Name")]
        public string OfficeName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Postal Code")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }



        public string ModelId { get; set; }
    }
}
