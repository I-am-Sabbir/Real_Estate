using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Real_Estate.Models;

namespace Real_Estate.Controllers
{
    public class RequestedsController : Controller
    {
        private readonly AppDbContext _context;

        public RequestedsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Requesteds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Requesteds.ToListAsync());
        }

        // GET: Requesteds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requested = await _context.Requesteds
                .FirstOrDefaultAsync(m => m.ID == id);
            if (requested == null)
            {
                return NotFound();
            }

            return View(requested);
        }

        // GET: Requesteds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Requesteds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID")] Requested requested)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requested);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requested);
        }

        // GET: Requesteds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requested = await _context.Requesteds.FindAsync(id);
            if (requested == null)
            {
                return NotFound();
            }
            return View(requested);
        }

        // POST: Requesteds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID")] Requested requested)
        {
            if (id != requested.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requested);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestedExists(requested.ID))
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
            return View(requested);
        }

        // GET: Requesteds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requested = await _context.Requesteds
                .FirstOrDefaultAsync(m => m.ID == id);
            if (requested == null)
            {
                return NotFound();
            }

            return View(requested);
        }

        // POST: Requesteds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requested = await _context.Requesteds.FindAsync(id);
            _context.Requesteds.Remove(requested);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestedExists(int id)
        {
            return _context.Requesteds.Any(e => e.ID == id);
        }
    }
}
