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

        private void ValidateStudent(StudentDto studentDto)
        {
            if (studentDto.FirstName == null)
            {
                throw new Exception("O primeiro nome não deve ser nulo");
            }

            if (studentDto.FirstName.Length > 50)
            {
                throw new Exception("O primeiro nome não deve ser maior que 50 caracteres");
            }

        }

        public void DeleteStudent(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Passe um id válido");
            }
            
            var student = _studentRepository.GetById(id);

            if (student == null)
            {
                throw new Exception("Estudante não existe");
            }

            try
            {             
                _studentRepository.Delete(student);
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

        public void UpdateStudent(StudentDto student)
        {
            throw new NotImplementedException();
        }
    }
}
