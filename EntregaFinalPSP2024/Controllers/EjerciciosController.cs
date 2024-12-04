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
    public class EjerciciosController : Controller
    {
        private readonly EntregafinalpspContext _context;

        public EjerciciosController(EntregafinalpspContext context)
        {
            _context = context;
        }

        // GET: Ejercicios
        public async Task<IActionResult> Index()
        {
            var entregafinalpspContext = _context.Ejercicios.Include(e => e.IdCategoriaNavigation);
            return View(await entregafinalpspContext.ToListAsync());
        }

        // GET: Ejercicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejercicio = await _context.Ejercicios
                .Include(e => e.IdCategoriaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ejercicio == null)
            {
                return NotFound();
            }

            return View(ejercicio);
        }

        // GET: Ejercicios/Create
        public IActionResult Create()
        {
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "Id", "Id");
            return View();
        }

        // POST: Ejercicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Dificultad,IdCategoria")] Ejercicio ejercicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ejercicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "Id", "Id", ejercicio.IdCategoria);
            return View(ejercicio);
        }

        // GET: Ejercicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejercicio = await _context.Ejercicios.FindAsync(id);
            if (ejercicio == null)
            {
                return NotFound();
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "Id", "Id", ejercicio.IdCategoria);
            return View(ejercicio);
        }

        // POST: Ejercicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Dificultad,IdCategoria")] Ejercicio ejercicio)
        {
            if (id != ejercicio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ejercicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EjercicioExists(ejercicio.Id))
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
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "Id", "Id", ejercicio.IdCategoria);
            return View(ejercicio);
        }

        // GET: Ejercicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejercicio = await _context.Ejercicios
                .Include(e => e.IdCategoriaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ejercicio == null)
            {
                return NotFound();
            }

            return View(ejercicio);
        }

        // POST: Ejercicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ejercicio = await _context.Ejercicios.FindAsync(id);
            if (ejercicio != null)
            {
                _context.Ejercicios.Remove(ejercicio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EjercicioExists(int id)
        {
            return _context.Ejercicios.Any(e => e.Id == id);
        }
    }
}
