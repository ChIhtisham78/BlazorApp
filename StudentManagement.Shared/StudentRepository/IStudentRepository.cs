using StudentManagement.Shared.Models;

namespace StudentManagement.Shared.StudentRepository
{
	public interface IStudentRepository
	{
		Task<Student> AddStudentAsync(Student student);
		Task<Student> UpdateStudentAsync(Student student);
		Task<Student> DeleteStudentAsync(int studentId);
		Task<List<Student>> GetAllStudentAsync();
		Task<Student> GetStudentByIdAsync(int studentId);
	}
}
