namespace MusicLessonSchedule.Models
{
    public class TeacherInstrument
    {
        public int Id { get; set; }
        public Teacher? Teacher { get; set; }
        public int TeacherId { get; set; }
        public Instrument? Instrument { get; set; }
        public int InstrumentId { get; set; }
    }
}
