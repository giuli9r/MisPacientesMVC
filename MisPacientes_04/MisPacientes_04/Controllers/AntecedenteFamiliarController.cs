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
    public class AntecedenteFamiliarController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AntecedenteFamiliarController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: AntecedenteFamiliar
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.AntecedenteFamiliar.Include(a => a.Anamnesis);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: AntecedenteFamiliar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AntecedenteFamiliar == null)
            {
                return NotFound();
            }

            var antecedenteFamiliar = await _context.AntecedenteFamiliar
                .Include(a => a.Anamnesis)
                .FirstOrDefaultAsync(m => m.AnamnesisRefId == id);
            if (antecedenteFamiliar == null)
            {
                return NotFound();
            }

            return View(antecedenteFamiliar);
        }

        // GET: AntecedenteFamiliar/Create
        public IActionResult Create( int? id_anamnesis)
        {
            ViewData["AnamnesisRefId"] = new SelectList(_context.Anamnesis, "Id", "MotivoConsulta");
            //ViewData["AnamnesisRefId"] = new SelectList(_context.Anamnesis.Where( a => a.Id == id_anamnesis), "Id", "MotivoConsulta");
            return View();

        }

        // GET: AntecedenteFamiliar/CreateFrom/Id
        public IActionResult CreateFrom(int id_anamnesis)
        {
            ViewData["AnamnesisRefId"] = new SelectList(_context.Anamnesis.Where(i => i.Id == id_anamnesis).ToList(), "Id", "MotivoConsulta");
            //ViewData["AnamnesisRefId"] = new SelectList(_context.Anamnesis, "Id", "MotivoConsulta");
            return View();


        }

        // POST: AntecedenteFamiliar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("E_Cardios,E_Respiratorias,DescripcionAntecedentes,AnamnesisRefId")] AntecedenteFamiliar antecedenteFamiliar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(antecedenteFamiliar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnamnesisRefId"] = new SelectList(_context.Anamnesis, "Id", "MotivoConsulta", antecedenteFamiliar.AnamnesisRefId);
            return View(antecedenteFamiliar);
        }

        // GET: AntecedenteFamiliar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AntecedenteFamiliar == null)
            {
                return NotFound();
            }

            var antecedenteFamiliar = await _context.AntecedenteFamiliar.FindAsync(id);
            if (antecedenteFamiliar == null)
            {
                return NotFound();
            }
            ViewData["AnamnesisRefId"] = new SelectList(_context.Anamnesis, "Id", "MotivoConsulta", antecedenteFamiliar.AnamnesisRefId);
            return View(antecedenteFamiliar);
        }

        // POST: AntecedenteFamiliar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,E_Cardios,E_Respiratorias,DescripcionAntecedentes,AnamnesisRefId")] AntecedenteFamiliar antecedenteFamiliar)
        {
            if (id != antecedenteFamiliar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(antecedenteFamiliar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AntecedenteFamiliarExists(antecedenteFamiliar.Id))
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
            ViewData["AnamnesisRefId"] = new SelectList(_context.Anamnesis, "Id", "MotivoConsulta", antecedenteFamiliar.AnamnesisRefId);
            return View(antecedenteFamiliar);
        }

        // GET: AntecedenteFamiliar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AntecedenteFamiliar == null)
            {
                return NotFound();
            }

            var antecedenteFamiliar = await _context.AntecedenteFamiliar
                .Include(a => a.Anamnesis)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (antecedenteFamiliar == null)
            {
                return NotFound();
            }

            return View(antecedenteFamiliar);
        }

        // POST: AntecedenteFamiliar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AntecedenteFamiliar == null)
            {
                return Problem("Entity set 'ApplicationDBContext.AntecedenteFamiliar'  is null.");
            }
            var antecedenteFamiliar = await _context.AntecedenteFamiliar.FindAsync(id);
            if (antecedenteFamiliar != null)
            {
                _context.AntecedenteFamiliar.Remove(antecedenteFamiliar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AntecedenteFamiliarExists(int id)
        {
          return (_context.AntecedenteFamiliar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
