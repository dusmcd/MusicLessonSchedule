using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicLessonSchedule.Models;

namespace MusicLessonSchedule.Data
{
    public class MusicLessonScheduleContext : DbContext
    {
        public MusicLessonScheduleContext (DbContextOptions<MusicLessonScheduleContext> options)
            : base(options)
        {
        }

        public DbSet<MusicLessonSchedule.Models.Teacher> Teacher { get; set; } = default!;
        public DbSet<MusicLessonSchedule.Models.Student> Student { get; set; } = default!;
        public DbSet<MusicLessonSchedule.Models.Lesson> Lesson { get; set; } = default!;
        public DbSet<MusicLessonSchedule.Models.Availability> Availability { get; set; } = default!;
        public DbSet<MusicLessonSchedule.Models.Instrument> Instrument { get; set; } = default!;
        public DbSet<MusicLessonSchedule.Models.TeacherInstrument> TeacherInstrument { get; set;} = default!;
        public DbSet<MusicLessonSchedule.Models.StudentInstrument> StudentInstrument { get; set;} = default!;
    }
}
