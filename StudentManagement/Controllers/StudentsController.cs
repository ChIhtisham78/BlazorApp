using Microsoft.AspNetCore.Mvc;
using StudentManagement.Shared.Models;
using StudentManagement.Shared.StudentRepository;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<List<Student>>> GettAllStudentAsync()
        {
            var students = await _studentRepository.GetAllStudentAsync();
            return Ok(students);
        }

        [HttpGet("GetStudent/{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            return Ok(student);
        }

        [HttpPost("AddStudent")]
        public async Task<ActionResult<Student>> AddStudentAsync([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Student data is null");
            }

            var addStudent = await _studentRepository.AddStudentAsync(student);
            return Ok(addStudent);
        }


        [HttpPut("UpdateStudent")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, [FromBody] Student student)
        {
            var existingstudent = await _studentRepository.UpdateStudentAsync(id, student);
            return Ok(existingstudent);
        }

        [HttpDelete("DeleteStudent")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var delstudent = await _studentRepository.DeleteStudentAsync(id);
            return Ok(delstudent);
        }
    }
}
