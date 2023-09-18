using Pramerica_Assignment.Models.StudentDetails;

namespace Pramerica_Assignment.Repository
{
    public interface IStudentDetailsRepository
    {
        Task<StudentDetailsModel> Create(StudentDetailsModel StudentDetails);
        StudentDetailsModel Details(int? id);
        Task<StudentDetailsModel> Edit(int? id);
        Task<StudentDetailsModel> EditPost(StudentDetailsModel StudentDetails);
       /* Task<List<StudentDetailsModel>> GetMyEventList();*/
        List<StudentDetailsModel>? Index();
    }
}