using UniEdu.Dtos;
using UniEdu.Models;

namespace UniEdu.Interfaces.IServices
{
    public interface IStudentService
    {
        public Task<IEnumerable<Student>> GetAllStudents();
        public Task<Student> GetStudentById(Guid id);
        public void Enroll(StudentDto student);
        public void UpdateStudent(StudentDto student);
        public void DeleteStudent(Guid id);

    }
}
