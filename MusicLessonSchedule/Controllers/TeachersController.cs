using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicLessonSchedule.Data;
using MusicLessonSchedule.Models;

namespace MusicLessonSchedule.Controllers
{
    public class TeachersController : Controller
    {
        private readonly MusicLessonScheduleContext _context;

        public TeachersController(MusicLessonScheduleContext context)
        {
            _context = context;
        }

        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            var query = from t in _context.Teacher
                        join ti in _context.TeacherInstrument on t.Id equals ti.TeacherId
                        join i in _context.Instrument on ti.InstrumentId equals i.Id
                        select new TeacherViewModel { Teacher = t, InstrumentId = ti.InstrumentId, InstrumentName = i.Name };
            return View(await query.ToListAsync());
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teacher
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        public async Task<IActionResult> Create()
        {
            var instruments = await _context.Instrument.ToListAsync();
            TeacherViewModel teacherVM = new TeacherViewModel
            {
                Instruments = instruments
            };
            return View(teacherVM);
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherViewModel teacherVM)
        {
            if (ModelState.IsValid)
            {
                Teacher teacher = new Teacher
                {
                    Name = teacherVM.Teacher!.Name,
                    DateOfBirth = teacherVM.Teacher!.DateOfBirth,
                    PhoneNumber = teacherVM.Teacher!.PhoneNumber,
                    Email = teacherVM.Teacher!.Email
                };
                _context.Teacher.Add(teacher);
                await _context.SaveChangesAsync();
                int id = teacher.Id;
                TeacherInstrument teacherInstrument = new TeacherInstrument
                {
                    InstrumentId = teacherVM.InstrumentId,
                    TeacherId = id
                };
                _context.TeacherInstrument.Add(teacherInstrument);
                 await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacherVM);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teacher.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PhoneNumber,Email,DateOfBirth")] Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teacher
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacher = await _context.Teacher.FindAsync(id);
            if (teacher != null)
            {
                _context.Teacher.Remove(teacher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            return _context.Teacher.Any(e => e.Id == id);
        }
    }
}
