using Microsoft.AspNetCore.Mvc;
using MusicLessonSchedule.Models;
using MusicLessonSchedule.Data;
using Microsoft.CodeAnalysis.Scripting.Hosting;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace MusicLessonSchedule.Controllers
{
    public class StudentsController : Controller
    {
        private readonly MusicLessonScheduleContext _context;

        public StudentsController(MusicLessonScheduleContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var query = from s in _context.Student
                        join si in _context.StudentInstrument on s.Id equals si.StudentId
                        join i in _context.Instrument on si.InstrumentId equals i.Id
                        select new StudentViewModel { Student = s, InstrumentName = i.Name, InstrumentId = i.Id };
            var students = await query.ToListAsync();
            return View(students);
        }

        public async Task<IActionResult> Create()
        {

            var instruments = await _context.Instrument.ToListAsync();
            var studentVM = new StudentViewModel
            {
                Instruments = instruments
            };
            return View(studentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentViewModel studentVM)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    Name = studentVM.Student!.Name,
                    Phone = studentVM.Student!.Phone,
                    Email = studentVM.Student!.Email,
                    Age = studentVM.Student!.Age,
                };
                _context.Student.Add(student);
                await _context.SaveChangesAsync();
                int id = student.Id;
                var instrumentStudent = new StudentInstrument
                {
                    StudentId = id,
                    InstrumentId = studentVM.InstrumentId
                };
                _context.Add(instrumentStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return Problem("There was a problem");
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _context.Student.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id", "Name", "PhoneNumber", "Email","Age")]  Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                } catch(DbUpdateConcurrencyException exp)
                {
                    throw new Exception(exp.Message);
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
