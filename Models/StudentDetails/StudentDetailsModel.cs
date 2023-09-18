using System.ComponentModel.DataAnnotations;

namespace Pramerica_Assignment.Models.StudentDetails
{
    public class StudentDetailsModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int RollNo{ get; set; }
        [Required]
        public int Class { get; set; }

    }
}
