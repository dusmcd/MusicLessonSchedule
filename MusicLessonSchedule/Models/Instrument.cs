using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MusicLessonSchedule.Models
{
    public class Instrument
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [DisplayName("Minimum Age")]
        public int? MinAge { get; set; }
    }
}
