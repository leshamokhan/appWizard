using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appWizard.Models
{
    public class RegisterModelUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Salutation { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }



        [Required]
        public bool Finance { get; set; }
        [Required]
        public bool Operations { get; set; }
        [Required]
        public bool IT { get; set; }
        [Required]
        public bool Sales { get; set; }
        [Required]
        public bool Administrative { get; set; }
        [Required]
        public bool Legal { get; set; }
        [Required]
        public bool Marketing { get; set; }

        [Required]
        public string Comments { get; set; }



        [Required]
        public string Country { get; set; }
        [Required]
        public string OfficeName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }



        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
