using System.ComponentModel.DataAnnotations;

namespace Task2_Web_API_CoreApplication.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        public string Department { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be 10 digits.")]
        public string MobileNo { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
