using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MathBot.Models.VM
{
    public class LoginVM
    {
        [Required(ErrorMessage="Please enter your Username")]
        [Display(Name = "Username")]

        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your Password")]
        [Display(Name = "Password")]


        public string Password { get; set; }
    }
}
