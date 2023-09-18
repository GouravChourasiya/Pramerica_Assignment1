using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pramerica_Assignment.Context;
using Pramerica_Assignment.Models.StudentDetails;
using Pramerica_Assignment.Repository;

namespace Pramerica_Assignment.Controllers
{
    
    public class StudentDetailsController : Controller
    {
        private readonly IStudentDetailsRepository _repo;
        private readonly StudentDetailsContext _context;
        //Dependency Injection
        public StudentDetailsController(IStudentDetailsRepository repo,StudentDetailsContext context)
        {
            _repo = repo;
            _context = context;
        }

        // GET: StudentDetails
       
        //Get method to get LIst of student Data
        [Route("{controller}/students")]
        [Authorize]
        public ActionResult ListofStudents()
        {
            var results = _repo.Index();
            return View(results);
        }
        
        // GET: StudentDetails/Details/5
        public  ActionResult Details(int id)
        {
            var result = _repo.Details(id);
            return View(result);
        }

        // GET: StudentDetails/AddStudent
        // Using Authorize Attribute in Add Student 
        [Authorize]
        public ActionResult AddStudent()
        {
            return View();
        }

        // POST: StudentDetails/AddStudent
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddStudent(StudentDetailsModel student)
        {
            try
            {
               

                var result = await _repo.Create(student);
                if (ModelState.IsValid)
                {

                    return RedirectToAction(nameof(ListofStudents));
                }
                return View(result);
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        // GET: StudentDetails/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _repo.Edit(id);
            return View(result);
        }

        private bool StudentDetailsModelExists(int id)
        {
            return _context.StudentDetails.Any(x => x.Id == id);
    }
        // EDit method for updating the data
        // POST: StudentDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, StudentDetailsModel studentDetails)
        {
            if (studentDetails.Id != id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.EditPost(studentDetails);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentDetailsModelExists(studentDetails.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListofStudents));
            }
            return View(studentDetails);
        }
        [Authorize]
        // GET: StudentDetails/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var result =  await _context.StudentDetails.FindAsync(id);
            return View(result);
        }

        // POST: StudentDetails/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var result= await _context.StudentDetails.FindAsync(id);
                _context.StudentDetails.Remove(result);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListofStudents));
               
            }
            catch
            {
                return View();
            }
        }
    }
   
}
