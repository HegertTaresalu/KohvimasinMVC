using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KohvimasinMVC.Data;

namespace KohvimasinMVC.Controllers
{
    public class KohvimasinsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KohvimasinsController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> VõtaJook(int id)
        {

            var model = await _context.Kohvimasin.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            try
            {
                model.JoogiKogus -= 1;
                model.Topsikogus -= 1;
                _context.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KohvimasinExists(model.Id))
                {
                    return NotFound();
                }
            }

            return RedirectToAction(nameof(Admin));

        }

        public async Task<IActionResult> Klient()
        {
            var model = _context.Kohvimasin.Where(e => e.Topsikogus != 0 | e.JoogiKogus != 0);
            return View(await model.ToListAsync());
        }

        public async Task<IActionResult> Kustuta(int? id)
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
        [HttpPost, ActionName("Kustuta")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> KustutaKinnitatud(int id)
        {
            var kohvimasin = await _context.Kohvimasin.FindAsync(id);
            _context.Kohvimasin.Remove(kohvimasin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Admin));
        }



        public async Task<IActionResult> Muuda(int? id)
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
        // GET: Kohvimasins
        public async Task<IActionResult> Admin()
        {
            return View(await _context.Kohvimasin.ToListAsync());
        }


        // GET: Kohvimasins
        public async Task<IActionResult> LisaToode()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LisaToode([Bind("Id,Jooginimi,JoogiKogus,Topsikogus,Topsejuua")] Kohvimasin kohvimasin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kohvimasin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Admin));
            }
            return View(kohvimasin);
        }

        public async Task<IActionResult> LisaTäitepakk(int id)
        {
            var model = await _context.Kohvimasin.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            try
            {
                model.JoogiKogus += model.Topsepakis;
                _context.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KohvimasinExists(model.Id))
                {
                    return NotFound();
                }
            }

            return RedirectToAction(nameof(Admin));

        }
        public async Task<IActionResult> LisaTopsiTäitepakk(int id)
        {
            var model = await _context.Kohvimasin.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            try
            {
                model.Topsikogus += model.Topsepakis;
                _context.Update(model);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KohvimasinExists(model.Id))
                {
                    return NotFound();
                }
            }

            return RedirectToAction(nameof(Admin));

        }



        // GET: Kohvimasins
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kohvimasin.ToListAsync());
        }

        // GET: Kohvimasins/Details/5
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

        // GET: Kohvimasins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kohvimasins/Create
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

        // GET: Kohvimasins/Edit/5
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

        // POST: Kohvimasins/Edit/5
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

        // GET: Kohvimasins/Delete/5
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

        // POST: Kohvimasins/Delete/5
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
