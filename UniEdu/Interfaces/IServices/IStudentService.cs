using UniEdu.Dtos;
using UniEdu.Models;

namespace UniEdu.Interfaces.IServices
{
    public interface IStudentService
    {
        public List<Student> GetAllStudents();
        public Student GetStudentById(Guid id);
        public void Enroll(StudentDto studentDto);
        public void UpdateStudent(StudentUpdateDto studentDto);
        public void DeleteStudent(Guid id);

    }
}
