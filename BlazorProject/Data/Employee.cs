using System.ComponentModel.DataAnnotations;

namespace BlazorProject.Data
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name...")]
        public string Name { get; set; }

        public string? email { get; set; }

        public string? role { get; set; }

        public long? PhoneNumber { get; set; }
    }
}
