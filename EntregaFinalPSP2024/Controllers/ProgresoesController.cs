using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntregaFinalPSP2024.Models;

namespace EntregaFinalPSP2024.Controllers
{
    public class ProgresoesController : Controller
    {
        private readonly EntregafinalpspContext _context;

        public ProgresoesController(EntregafinalpspContext context)
        {
            _context = context;
        }

        // GET: Progresoes
        public async Task<IActionResult> Index()
        {
            var entregafinalpspContext = _context.Progresos.Include(p => p.IdEjercicioNavigation).Include(p => p.IdUsuarioNavigation);
            return View(await entregafinalpspContext.ToListAsync());
        }

        // GET: Progresoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var progreso = await _context.Progresos
                .Include(p => p.IdEjercicioNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (progreso == null)
            {
                return NotFound();
            }

            return View(progreso);
        }

        // GET: Progresoes/Create
        public IActionResult Create()
        {
            ViewData["IdEjercicio"] = new SelectList(_context.Ejercicios, "Id", "Id");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: Progresoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUsuario,IdEjercicio,Estado,FechaInicio,FechaFinalizacion")] Progreso progreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(progreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEjercicio"] = new SelectList(_context.Ejercicios, "Id", "Id", progreso.IdEjercicio);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", progreso.IdUsuario);
            return View(progreso);
        }

        // GET: Progresoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var progreso = await _context.Progresos.FindAsync(id);
            if (progreso == null)
            {
                return NotFound();
            }
            ViewData["IdEjercicio"] = new SelectList(_context.Ejercicios, "Id", "Id", progreso.IdEjercicio);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", progreso.IdUsuario);
            return View(progreso);
        }

        // POST: Progresoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUsuario,IdEjercicio,Estado,FechaInicio,FechaFinalizacion")] Progreso progreso)
        {
            if (id != progreso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(progreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgresoExists(progreso.Id))
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
            ViewData["IdEjercicio"] = new SelectList(_context.Ejercicios, "Id", "Id", progreso.IdEjercicio);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", progreso.IdUsuario);
            return View(progreso);
        }

        // GET: Progresoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var progreso = await _context.Progresos
                .Include(p => p.IdEjercicioNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (progreso == null)
            {
                return NotFound();
            }

            return View(progreso);
        }

        // POST: Progresoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var progreso = await _context.Progresos.FindAsync(id);
            if (progreso != null)
            {
                _context.Progresos.Remove(progreso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgresoExists(int id)
        {
            return _context.Progresos.Any(e => e.Id == id);
        }
    }
}
