using Microsoft.AspNetCore.Identity;

namespace Pramerica_Assignment.Models
{
  
        public class ApplicationUser : IdentityUser
        {
            public string? Name { get; set; }
        }
}
