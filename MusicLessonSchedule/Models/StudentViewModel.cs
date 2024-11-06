using MusicLessonSchedule.Controllers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MusicLessonSchedule.Models
{
    public class StudentViewModel
    {
        public Student? Student { get; set; }
        public string? InstrumentName { get; set; }
        [Required, DisplayName("Instrument")]
        public int InstrumentId { get; set; }
        public List<Instrument>? Instruments { get; set; }
    }
}
