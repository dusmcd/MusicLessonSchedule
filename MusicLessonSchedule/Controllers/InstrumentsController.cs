using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicLessonSchedule.Data;
using MusicLessonSchedule.Models;
using System.Runtime.InteropServices;

namespace MusicLessonSchedule.Controllers
{
    public class InstrumentsController : Controller
    {
        private readonly MusicLessonScheduleContext _context;

        public InstrumentsController(MusicLessonScheduleContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var instruments = await _context.Instrument.ToListAsync();
            return View(instruments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id", "Name", "MinAge")] Instrument instrument)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instrument);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
