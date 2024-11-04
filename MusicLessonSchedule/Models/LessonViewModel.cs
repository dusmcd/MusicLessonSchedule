using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MusicLessonSchedule.Models
{
    public class LessonViewModel
    {
        public List<Teacher>? Teachers { get; set; }

        [Required, DisplayName("Teacher")]
        public int TeacherId { get; set; }

        public List<Student>? Students { get; set; }

        [Required, DisplayName("Student")]
        public int StudentId { get; set; }

        [DataType(DataType.Time), Required]
        public DateTime Time { get; set; }

        [DataType(DataType.Date), DisplayName("Date of First Lesson"), Required]
        public DateTime FirstDate { get; set; }

        [DisplayName("Day of Week"), Required]
        public Days Day {  get; set; }

        public SelectList? DayNames { get; set; }

    }
}
