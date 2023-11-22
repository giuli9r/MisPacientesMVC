using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MisPacientes_04.Data;
using MisPacientes_04.Models;
using MisPacientes_04.ViewModels;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Text;

namespace MisPacientes_04.Controllers
{
    public class ExamenFisicoController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ExamenFisicoController(ApplicationDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        //GET: ExamenFisico/Index
        public async Task<IActionResult> Index(int? Id)
        {
            if (Id != null)
            {
                // Filtrar los Examen_Fisicos por Anamnesis_Id
                var examenFisicos = _context.ExamenFisico
                    .Where(e => e.AnamnesisId == Id)
                    .Include(e => e.Anamnesis);

                return View(await examenFisicos.ToListAsync());
            }
            var applicationDBContext = _context.ExamenFisico.Include(e => e.Anamnesis);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: ExamenFisico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ExamenFisico == null)
            {
                return NotFound();
            }

            var examenFisico = await _context.ExamenFisico
                .Include(e => e.Anamnesis)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examenFisico == null)
            {
                return NotFound();
            }

            return View(examenFisico);
        }

        // GET: ExamenFisico/Create
        public IActionResult Create()
        {
            ViewData["AnamnesisId"] = new SelectList(_context.Anamnesis, "Id", "MotivoConsulta");
            return View();

        }

        // POST: ExamenFisico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ExamenFisicoViewModel examenFisico)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(examenFisico);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["AnamnesisId"] = new SelectList(_context.Anamnesis, "Id", "MotivoConsulta", examenFisico.AnamnesisId);
            //return View(examenFisico);


            string uniqueFileName = UploadedFile(examenFisico);
            if (ModelState.IsValid)
            {
                ExamenFisico exFisico = new ExamenFisico()
                {
                    ImagenExamenFisico = uniqueFileName,
                    Descripcion = examenFisico.Descripcion,
                    AnamnesisId = examenFisico.AnamnesisId,
                    FechaRegistro = examenFisico.FechaRegistro
                };
                _context.Add(exFisico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(examenFisico);

        }

        // GET: ExamenFisico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExamenFisico == null)
            {
                return NotFound();
            }
            var examenFisico = await _context.ExamenFisico.FindAsync(id);

            ExamenFisicoViewModel exFisicoViewModel = new ExamenFisicoViewModel()
            {
                Descripcion = examenFisico.Descripcion,
                AnamnesisId = examenFisico.AnamnesisId,
                FechaRegistro = examenFisico.FechaRegistro
            };
            
            if (examenFisico == null)
            {
                return NotFound();
            }


            ViewData["AnamnesisId"] = new SelectList(_context.Anamnesis, "Id", "MotivoConsulta", examenFisico.AnamnesisId);
            return View(exFisicoViewModel);
        }

        // POST: ExamenFisico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ExamenFisicoViewModel examenFisicoViewModel)
        {

            string uniqueFileName = UploadedFile(examenFisicoViewModel);

            if (id != examenFisicoViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    var examenFisico = await _context.ExamenFisico.FindAsync(id);

                    examenFisico.ImagenExamenFisico = uniqueFileName;
                    examenFisico.Descripcion = examenFisicoViewModel.Descripcion;
                    examenFisico.FechaRegistro = examenFisicoViewModel.FechaRegistro;

                    _context.Update(examenFisico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamenFisicoExists(examenFisicoViewModel.Id))
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
            ViewData["AnamnesisId"] = new SelectList(_context.Anamnesis, "Id", "MotivoConsulta", examenFisicoViewModel.AnamnesisId);
            return View(examenFisicoViewModel);
        }

        // GET: ExamenFisico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExamenFisico == null)
            {
                return NotFound();
            }

            var examenFisico = await _context.ExamenFisico
                .Include(e => e.Anamnesis)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examenFisico == null)
            {
                return NotFound();
            }

            return View(examenFisico);
        }

        // POST: ExamenFisico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExamenFisico == null)
            {
                return Problem("Entity set 'ApplicationDBContext.ExamenFisico'  is null.");
            }
            var examenFisico = await _context.ExamenFisico.FindAsync(id);
            if (examenFisico != null)
            {
                _context.ExamenFisico.Remove(examenFisico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamenFisicoExists(int id)
        {
          return (_context.ExamenFisico?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private string UploadedFile(ExamenFisicoViewModel model)
        {
            string uniqueFileName = null;

            if (model.Imagen != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Imagen.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Imagen.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


    }
}
