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
            var students = await _context.Student.ToListAsync();
            return View(students);
        }

        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id", "Name", "Phone", "Email", "Age")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Student.Add(student);
            }
            else
            {
                return Problem("There was a problem");
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
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
