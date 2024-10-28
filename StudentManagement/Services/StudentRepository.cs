using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Shared.Models;
using StudentManagement.Shared.StudentRepository;

namespace StudentManagement.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Student> AddStudentAsync(Student student)
        {
            var addstudent = new Student();
            {
                addstudent.Name = student.Name;
                addstudent.Email = student.Email;
                addstudent.Country = student.Country;
                addstudent.Address = student.Address;
                addstudent.PhoneNumber = student.PhoneNumber;
            }
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteStudentAsync(int studentId)
        {
            var student = await _context.Students.Where(x => x.Id == studentId).FirstOrDefaultAsync();
            if (student == null) throw new ArgumentException();
            _context.Students.RemoveRange(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<List<Student>> GetAllStudentAsync()
        {
            var allstudent = await _context.Students.ToListAsync();
            return allstudent;
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            var singlestudent = await _context.Students.Where(x => x.Id == studentId).FirstOrDefaultAsync();
            if (singlestudent == null)
            {
                throw new ArgumentException();
            }
            return singlestudent;
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            if (student == null) throw new ArgumentNullException();
            var existingstudent = _context.Students.Update(student).Entity;
            await _context.SaveChangesAsync();
            return existingstudent;

        }
    }
}
