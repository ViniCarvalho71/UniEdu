using UniEdu.Models;

namespace UniEdu.Interfaces.IRepositories
{
    public interface IStudentRepository
    {
        public void Create(Student student);
        public void Delete(Student student);
        public void Update(Student student);
        public List<Student> Get();
        public Student GetById(Guid Id);

        
    }
}
