using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MusicLessonSchedule.Models
{
    public class TeacherViewModel
    {
        [Required]
        public Teacher? Teacher { get; set; }

        [Required, DisplayName("Instrument")]
        public int InstrumentId { get; set; }

        public string? InstrumentName { get; set; }

        public List<Instrument>? Instruments { get; set; }
    }
}
