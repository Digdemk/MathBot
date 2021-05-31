using MathBot.Models.ORM.Entities;
using MathBothCommon.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MathBot.Models.VM
{
    public class OperationVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Number is required!")]
        [Display(Name = "First Number")]

        public double FirstNumber { get; set; }

        [Required(ErrorMessage = "Number is required!")]
        [Display(Name = "Second Number")]

        public double SecondNumber { get; set; }

        public List<OperationType> OperationTypes { get; set; }

        public double Result { get; set; }
    }
}
