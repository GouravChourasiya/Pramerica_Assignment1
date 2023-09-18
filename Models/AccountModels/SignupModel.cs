using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Pramerica_Assignment.Models.AccountModels
{
    public class SignupModel
    {
        [Required(ErrorMessage = "Please enter name")]
        public string? Name { get; set; }


        [Required(ErrorMessage = "Please Enter Your Email")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Please Enter Your Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
