using UniEdu.Models;

namespace UniEdu.Interfaces.IRepositories
{
    public interface IStudentRepository
    {
        public void Create(Student student);
        public void Delete(Guid id);
        public void Update(Student student);
        public Student Get();
        public Student Get(Guid id);

        
    }
}
