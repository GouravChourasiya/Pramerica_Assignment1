using Microsoft.EntityFrameworkCore;
using Pramerica_Assignment.Models.StudentDetails;

namespace Pramerica_Assignment.Context
{
    public class StudentDetailsContext : DbContext
    {
        public StudentDetailsContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<StudentDetailsModel> StudentDetails { get; set; }
    }
}
