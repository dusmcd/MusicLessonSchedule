namespace MusicLessonSchedule.Models
{
    public class StudentInstrument
    {
        public int Id { get; set; }
        public Student? Student { get; set; }
        public int StudentId { get; set; }
        public Instrument? Instrument { get; set; }
        public int InstrumentId { get; set; }
    }
}
