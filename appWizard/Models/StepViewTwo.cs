using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appWizard.Models
{
    public class StepViewTwo
    {
        public bool Finance { get; set; }
        public bool Operations { get; set; }
        public bool IT { get; set; }
        public bool Sales { get; set; }
        public bool Administrative { get; set; }
        public bool Legal { get; set; }
        public bool Marketing { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }



        public string ModelId { get; set; }
    }


}
