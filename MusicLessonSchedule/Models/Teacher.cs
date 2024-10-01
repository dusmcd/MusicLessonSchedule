using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MusicLessonSchedule.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required, DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required, DisplayName("Date of Birth"), DataType(DataType.Date)]
        public string? DateOfBirth { get; set; }
    }
}
