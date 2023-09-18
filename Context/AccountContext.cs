using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pramerica_Assignment.Models;

namespace Pramerica_Assignment.Context
{
  
    public class AccountContext : IdentityDbContext<ApplicationUser>
    {
        public AccountContext(DbContextOptions<AccountContext> options)
          : base(options)
        {
        }
    }
}
