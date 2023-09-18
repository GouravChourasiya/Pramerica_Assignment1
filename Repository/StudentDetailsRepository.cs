using Microsoft.EntityFrameworkCore;
using Pramerica_Assignment.Context;
using Pramerica_Assignment.Controllers;
using Pramerica_Assignment.Models.StudentDetails;

namespace Pramerica_Assignment.Repository
{
    public class StudentDetailsRepository : IStudentDetailsRepository
    {
        private readonly StudentDetailsContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public StudentDetailsRepository(StudentDetailsContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public List<StudentDetailsModel> Index()
        {
            var result = _context.StudentDetails?.ToList();
            return result;
        }
        public async Task<StudentDetailsModel> Create(StudentDetailsModel student)
        {
            var newDetails = new StudentDetailsModel()
            {
               Id=student.Id,
                Name = student.Name,
                RollNo = student.RollNo,
                Class = student.Class
               


            };

            _context.Add(newDetails);
            await _context.SaveChangesAsync();
            return newDetails;
        }
        public async Task<StudentDetailsModel> Edit(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var StudentDetailsModel = await _context.StudentDetails.FindAsync(id);
            if (StudentDetailsModel == null)
            {
                return null;
            }
            return StudentDetailsModel;
        }
        public async Task<StudentDetailsModel> EditPost(StudentDetailsModel StudentDetails)
        {
            var updateEvent = new StudentDetailsModel()
            {
                Id = StudentDetails.Id,
                Name = StudentDetails.Name,
                RollNo = StudentDetails.RollNo,
                Class = StudentDetails.Class,
                /*CreatedBy = _httpContext.HttpContext?.User.Identity?.Name*/


            };
            _context.Update(updateEvent);
            await _context.SaveChangesAsync();


            return updateEvent;
        }
        public StudentDetailsModel Details(int? id)
        {
            var result = _context.StudentDetails.FirstOrDefault(m => m.Id == id);
            return result;
        }
     





    }
}
