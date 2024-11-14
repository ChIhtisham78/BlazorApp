using StudentManagement.Shared.Models;
using StudentManagement.Shared.StudentRepository;
using System.Net.Http.Json;

namespace StudentManagement.Client.Services
{
    public class StudentService : IStudentRepository
    {
        private readonly HttpClient _httpClient;
        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Students/AddStudent", student);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Student>();
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error adding student: {errorMessage}");
            }
            return null;
        }


        public Task<Student> DeleteStudentAsync(int studentId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Student>> GetAllStudentAsync()
        {
            var response = await _httpClient.GetAsync("api/Student/GetAllStudents");
            if (response.IsSuccessStatusCode)
            {
                var students = await response.Content.ReadFromJsonAsync<List<Student>>();
                return students ?? new List<Student>();
            }
            return new List<Student>();
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            var response = await _httpClient.GetAsync($"api/Student/GetStudentById/{studentId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Student>();
            }
            return null;
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Student/UpdateStudent", student);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Student>();
            }
            return null;
        }
    }
}
