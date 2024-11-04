using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicLessonSchedule.Data;
using MusicLessonSchedule.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MusicLessonSchedule.Controllers
{
    public class LessonsController : Controller
    {
       private readonly MusicLessonScheduleContext _context;

        public LessonsController(MusicLessonScheduleContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var query = from l in _context.Lesson
                        join s in _context.Student on l.StudentId equals s.Id
                        join t in _context.Teacher on l.TeacherId equals t.Id
                        select new Lesson { Student = s, Teacher = t, LessonDay = l.LessonDay, LessonTime = l.LessonTime };
            var lessons = await query.ToListAsync();
            return View(lessons);
        }
       public async Task<IActionResult> Create()
        {

            var days = new List<Days>
            {
                Days.Monday,
                Days.Tuesday,
                Days.Wednesday,
                Days.Thursday,
                Days.Friday,
            };
            var lessonVM = new LessonViewModel
            {
                Students = await _context.Student.ToListAsync(),
                Teachers = await _context.Teacher.ToListAsync(),
                DayNames = new SelectList(days),
                FirstDate = DateTime.Now
            };

            return View(lessonVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LessonViewModel lessonVM)
        {
            var Lesson = new Lesson
            {
                StudentId = lessonVM.StudentId,
                TeacherId = lessonVM.TeacherId,
                LessonTime = lessonVM.Time,
                FirstLessonDate = lessonVM.FirstDate,
                Duration = 1
            };
            if (ModelState.IsValid)
            {
                _context.Add(Lesson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(lessonVM);
        }
    }

}
