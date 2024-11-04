using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MusicLessonSchedule.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required, DisplayName("Student Name")]
        public string? Name { get; set; }
        [Required, DisplayName("Phone Number")]
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? Age { get; set; }
    }
}
