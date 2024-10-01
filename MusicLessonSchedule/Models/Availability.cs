using System.ComponentModel.DataAnnotations;

namespace MusicLessonSchedule.Models
{
    public class Availability
    {
        public int Id { get; set; }
        public Teacher? Teacher { get; set; }
        public int TeacherId { get; set; }
        public Days Day { get; set; }
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
    }
}
