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
    public class EstadisticasController : Controller
    {
        private readonly EntregafinalpspContext _context;

        public EstadisticasController(EntregafinalpspContext context)
        {
            _context = context;
        }

        // GET: Estadisticas
        public async Task<IActionResult> Index()
        {
            var entregafinalpspContext = _context.Estadisticas.Include(e => e.IdEjercicioNavigation).Include(e => e.IdUsuarioNavigation);
            return View(await entregafinalpspContext.ToListAsync());
        }

        // GET: Estadisticas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadistica = await _context.Estadisticas
                .Include(e => e.IdEjercicioNavigation)
                .Include(e => e.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadistica == null)
            {
                return NotFound();
            }

            return View(estadistica);
        }

        // GET: Estadisticas/Create
        public IActionResult Create()
        {
            ViewData["IdEjercicio"] = new SelectList(_context.Ejercicios, "Id", "Id");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: Estadisticas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUsuario,IdEjercicio,TiempoEmpleado,Intentos,Resultado,FechaRealizacion")] Estadistica estadistica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadistica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEjercicio"] = new SelectList(_context.Ejercicios, "Id", "Id", estadistica.IdEjercicio);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", estadistica.IdUsuario);
            return View(estadistica);
        }

        // GET: Estadisticas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadistica = await _context.Estadisticas.FindAsync(id);
            if (estadistica == null)
            {
                return NotFound();
            }
            ViewData["IdEjercicio"] = new SelectList(_context.Ejercicios, "Id", "Id", estadistica.IdEjercicio);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", estadistica.IdUsuario);
            return View(estadistica);
        }

        // POST: Estadisticas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUsuario,IdEjercicio,TiempoEmpleado,Intentos,Resultado,FechaRealizacion")] Estadistica estadistica)
        {
            if (id != estadistica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadistica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadisticaExists(estadistica.Id))
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
            ViewData["IdEjercicio"] = new SelectList(_context.Ejercicios, "Id", "Id", estadistica.IdEjercicio);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", estadistica.IdUsuario);
            return View(estadistica);
        }

        // GET: Estadisticas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadistica = await _context.Estadisticas
                .Include(e => e.IdEjercicioNavigation)
                .Include(e => e.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadistica == null)
            {
                return NotFound();
            }

            return View(estadistica);
        }

        // POST: Estadisticas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadistica = await _context.Estadisticas.FindAsync(id);
            if (estadistica != null)
            {
                _context.Estadisticas.Remove(estadistica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadisticaExists(int id)
        {
            return _context.Estadisticas.Any(e => e.Id == id);
        }
    }
}
