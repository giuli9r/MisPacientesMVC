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
    public class AnamnesisController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AnamnesisController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Anamnesis
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.Anamnesis.Include(a => a.Paciente);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: Anamnesis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Anamnesis == null)
            {
                return NotFound();
            }

            var anamnesis = await _context.Anamnesis
                .Include(a => a.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anamnesis == null)
            {
                return NotFound();
            }

            return View(anamnesis);
        }

        // GET: Anamnesis/Create
        public IActionResult Create()
        {
            ViewData["PacienteRefId"] = new SelectList(_context.Paciente, "Id", "PacienteNombre");
            return View();
        }

        // POST: Anamnesis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MotivoConsulta,EnfermedadActual,FechaRegistro,PacienteRefId")] Anamnesis anamnesis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anamnesis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacienteRefId"] = new SelectList(_context.Paciente, "Id", "Apellido", anamnesis.PacienteRefId);
            return View(anamnesis);
        }

        // GET: Anamnesis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Anamnesis == null)
            {
                return NotFound();
            }

            var anamnesis = await _context.Anamnesis.FindAsync(id);
            if (anamnesis == null)
            {
                return NotFound();
            }
            ViewData["PacienteRefId"] = new SelectList(_context.Paciente, "Id", "Apellido", anamnesis.PacienteRefId);
            return View(anamnesis);
        }

        // POST: Anamnesis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MotivoConsulta,EnfermedadActual,FechaRegistro,PacienteRefId")] Anamnesis anamnesis)
        {
            if (id != anamnesis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anamnesis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnamnesisExists(anamnesis.Id))
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
            ViewData["PacienteRefId"] = new SelectList(_context.Paciente, "Id", "Apellido", anamnesis.PacienteRefId);
            return View(anamnesis);
        }

        // GET: Anamnesis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Anamnesis == null)
            {
                return NotFound();
            }

            var anamnesis = await _context.Anamnesis
                .Include(a => a.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anamnesis == null)
            {
                return NotFound();
            }

            return View(anamnesis);
        }

        // POST: Anamnesis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Anamnesis == null)
            {
                return Problem("Entity set 'ApplicationDBContext.Anamnesis'  is null.");
            }
            var anamnesis = await _context.Anamnesis.FindAsync(id);
            if (anamnesis != null)
            {
                _context.Anamnesis.Remove(anamnesis);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnamnesisExists(int id)
        {
          return (_context.Anamnesis?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
