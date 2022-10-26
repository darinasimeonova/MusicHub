using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Models;

namespace MusicHub.Controllers
{
    public class SongPerformersController : Controller
    {
        private readonly MusicHubContext _context;

        public SongPerformersController(MusicHubContext context)
        {
            _context = context;
        }

        // GET: SongPerformers
        public async Task<IActionResult> Index()
        {
            var musicHubContext = _context.SongPerformers.Include(s => s.Performer).Include(s => s.Songs);
            return View(await musicHubContext.ToListAsync());
        }

        // GET: SongPerformers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songPerformer = await _context.SongPerformers
                .Include(s => s.Performer)
                .Include(s => s.Songs)
                .FirstOrDefaultAsync(m => m.PerformerId == id);
            if (songPerformer == null)
            {
                return NotFound();
            }

            return View(songPerformer);
        }

        // GET: SongPerformers/Create
        public IActionResult Create()
        {
            ViewData["PerformerId"] = new SelectList(_context.Performers, "Id", "FirstName");
            ViewData["SongId"] = new SelectList(_context.Songs, "Id", "Name");
            return View();
        }

        // POST: SongPerformers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SongId,PerformerId")] SongPerformer songPerformer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(songPerformer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PerformerId"] = new SelectList(_context.Performers, "Id", "FirstName", songPerformer.PerformerId);
            ViewData["SongId"] = new SelectList(_context.Songs, "Id", "Name", songPerformer.SongId);
            return View(songPerformer);
        }

        // GET: SongPerformers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songPerformer = await _context.SongPerformers.FindAsync(id);
            if (songPerformer == null)
            {
                return NotFound();
            }
            ViewData["PerformerId"] = new SelectList(_context.Performers, "Id", "FirstName", songPerformer.PerformerId);
            ViewData["SongId"] = new SelectList(_context.Songs, "Id", "Name", songPerformer.SongId);
            return View(songPerformer);
        }

        // POST: SongPerformers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SongId,PerformerId")] SongPerformer songPerformer)
        {
            if (id != songPerformer.PerformerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(songPerformer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongPerformerExists(songPerformer.PerformerId))
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
            ViewData["PerformerId"] = new SelectList(_context.Performers, "Id", "FirstName", songPerformer.PerformerId);
            ViewData["SongId"] = new SelectList(_context.Songs, "Id", "Name", songPerformer.SongId);
            return View(songPerformer);
        }

        // GET: SongPerformers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songPerformer = await _context.SongPerformers
                .Include(s => s.Performer)
                .Include(s => s.Songs)
                .FirstOrDefaultAsync(m => m.PerformerId == id);
            if (songPerformer == null)
            {
                return NotFound();
            }

            return View(songPerformer);
        }

        // POST: SongPerformers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var songPerformer = await _context.SongPerformers.FindAsync(id);
            _context.SongPerformers.Remove(songPerformer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongPerformerExists(int id)
        {
            return _context.SongPerformers.Any(e => e.PerformerId == id);
        }
    }
}
