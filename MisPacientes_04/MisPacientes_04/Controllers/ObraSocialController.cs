using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MisPacientes_04.Data;
using MisPacientes_04.Models;

namespace MisPacientes_04.Controllers
{
    public class ObraSocialController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ObraSocialController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: ObraSocial
        public async Task<IActionResult> Index()
        {
              return _context.ObraSocial != null ? 
                          View(await _context.ObraSocial.ToListAsync()) :
                          Problem("Entity set 'ApplicationDBContext.ObraSocial'  is null.");
        }

        // GET: ObraSocial/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ObraSocial == null)
            {
                return NotFound();
            }

            var obraSocial = await _context.ObraSocial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obraSocial == null)
            {
                return NotFound();
            }

            return View(obraSocial);
        }

        // GET: ObraSocial/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ObraSocial/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Plan,Descripcion,FechaRegistro")] ObraSocial obraSocial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obraSocial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obraSocial);
        }

        // GET: ObraSocial/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ObraSocial == null)
            {
                return NotFound();
            }

            var obraSocial = await _context.ObraSocial.FindAsync(id);
            if (obraSocial == null)
            {
                return NotFound();
            }
            return View(obraSocial);
        }

        // POST: ObraSocial/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Plan,Descripcion,FechaRegistro")] ObraSocial obraSocial)
        {
            if (id != obraSocial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obraSocial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObraSocialExists(obraSocial.Id))
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
            return View(obraSocial);
        }

        // GET: ObraSocial/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ObraSocial == null)
            {
                return NotFound();
            }

            var obraSocial = await _context.ObraSocial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obraSocial == null)
            {
                return NotFound();
            }

            return View(obraSocial);
        }

        // POST: ObraSocial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ObraSocial == null)
            {
                return Problem("Entity set 'ApplicationDBContext.ObraSocial'  is null.");
            }
            var obraSocial = await _context.ObraSocial.FindAsync(id);
            if (obraSocial != null)
            {
                _context.ObraSocial.Remove(obraSocial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObraSocialExists(int id)
        {
          return (_context.ObraSocial?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
