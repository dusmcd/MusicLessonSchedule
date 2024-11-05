using System.ComponentModel;

namespace MusicLessonSchedule.Models
{
    public class Instrument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Minimum Age")]
        public int? MinAge { get; set; }
    }
}
