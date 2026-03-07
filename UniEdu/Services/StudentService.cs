using System.Text.RegularExpressions;
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

            var regex = new Regex(@"^[^@\s]+@faculdade\.edu$", RegexOptions.IgnoreCase);

            if (!regex.IsMatch(studentDto.Email))
            {
                throw new Exception("O email precisa ser do domínio @faculdade.edu");
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
            ValidateStudent(studentDto);

            var hasEmail = _studentRepository.Get().FirstOrDefault(s => s.Email == studentDto.Email);
            if (hasEmail != null)
            {
                throw new Exception("O email já está em uso por outro estudante");
            }

            var student = new Student
            {
                Id = Guid.NewGuid(),
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Email = studentDto.Email,
                Phone = studentDto.Phone,
                CreatedAt = DateTime.Now
            };

            try
            {
                _studentRepository.Create(student);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao matricular estudante: {ex.Message}");
            }

        }

        public List<Student> GetAllStudents()
        {
           var students = _studentRepository.Get();

           return students;
        }

        public Student GetStudentById(Guid id)
        {
            if (id == null)
            {
                throw new Exception("Passe um id válido");
            }
            return _studentRepository.GetById(id);
        }

        public void UpdateStudent(StudentUpdateDto studentDto)
        {
            ValidateStudent(studentDto);

            var student = new Student
            {
                Id = studentDto.Id,
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Email = studentDto.Email,
                Phone = studentDto.Phone,
                UpdatedAt = DateTime.Now
            };

            try
            {
                _studentRepository.Update(student);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar estudante: {ex.Message}");
            }
        }
    }
}
