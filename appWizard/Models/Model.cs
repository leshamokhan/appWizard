using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appWizard.Models
{
    public class Model
    {
        public string Id { get; set; }

        public StepViewOne StepViewOne { get; set; }
        public StepViewTwo StepViewTwo { get; set; }
        public StepViewThree StepViewThree { get; set; }
        public StepViewFour StepViewFour { get; set; }
    }
}
