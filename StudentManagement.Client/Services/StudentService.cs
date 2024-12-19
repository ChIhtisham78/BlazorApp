using StudentManagement.Shared.Models;
using StudentManagement.Shared.StudentRepository;

namespace StudentManagement.Client.Services
{
    public class StudentService : IStudentRepository
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            return await _studentRepository.AddStudentAsync(student);

        }

        public async Task<Student> DeleteStudentAsync(int studentId)
        {
            return await _studentRepository.DeleteStudentAsync(studentId);
        }

        public async Task<List<Student>> GetAllStudentAsync()
        {
            return await _studentRepository.GetAllStudentAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            return await _studentRepository.GetStudentByIdAsync(studentId);
        }

        public async Task<Student> UpdateStudentAsync(int id, Student student)
        {
            return await _studentRepository.UpdateStudentAsync(id, student);

        }
    }
}
