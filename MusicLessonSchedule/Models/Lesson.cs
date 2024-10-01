using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicLessonSchedule.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set;}
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public Days LessonDay { get; set; }

        [DataType(DataType.Time)]
        public DateTime LessonTime { get; set; }
        public int Duration { get; set; }
        [DataType(DataType.Date)]
        public DateTime FirstLessonDate { get; set; }
    }
}

public enum Days
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday
}
