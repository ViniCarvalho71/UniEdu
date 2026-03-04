using UniEdu.Data;
using UniEdu.Interfaces.IRepositories;
using UniEdu.Models;

namespace UniEdu.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context) { 
            _context = context;
        }
        public void Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Delete(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public List<Student> Get()
        {
            return _context.Students.ToList();
        }

        public Student GetById(Guid Id)
        {
            return _context.Students.FirstOrDefault(u => u.Id == Id);
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();

        }
    }
}
