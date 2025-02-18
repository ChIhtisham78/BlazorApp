using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Shared.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }

    }
}
