using System.ComponentModel.DataAnnotations;

namespace Pramerica_Assignment.Models.AccountModels
{
    public class LoginModel
    {

        [Required, EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
