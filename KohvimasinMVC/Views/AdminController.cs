using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KohvimasinMVC.Data;

namespace KohvimasinMVC.Views
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kohvimasin.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kohvimasin = await _context.Kohvimasin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kohvimasin == null)
            {
                return NotFound();
            }

            return View(kohvimasin);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Jooginimi,JoogiKogus,Topsikogus,Topsejuua")] Kohvimasin kohvimasin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kohvimasin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kohvimasin);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kohvimasin = await _context.Kohvimasin.FindAsync(id);
            if (kohvimasin == null)
            {
                return NotFound();
            }
            return View(kohvimasin);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Jooginimi,JoogiKogus,Topsikogus,Topsejuua")] Kohvimasin kohvimasin)
        {
            if (id != kohvimasin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kohvimasin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KohvimasinExists(kohvimasin.Id))
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
            return View(kohvimasin);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kohvimasin = await _context.Kohvimasin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kohvimasin == null)
            {
                return NotFound();
            }

            return View(kohvimasin);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kohvimasin = await _context.Kohvimasin.FindAsync(id);
            _context.Kohvimasin.Remove(kohvimasin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KohvimasinExists(int id)
        {
            return _context.Kohvimasin.Any(e => e.Id == id);
        }
    }
}
