using UniEdu.Dtos;
using UniEdu.Interfaces.IRepositories;
using UniEdu.Interfaces.IServices;
using UniEdu.Models;

namespace UniEdu.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void DeleteStudent(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Passe um id válido");
            }

            try
            {
                _studentRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar estudante: {ex.Message}");
            }

            }

        public void Enroll(StudentDto studentDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudentById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
