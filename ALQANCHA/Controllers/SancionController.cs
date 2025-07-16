using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ALQANCHA.Models;
using ALQCANCHA.Context;

namespace ALQANCHA.Controllers
{
    public class SancionController : Controller
    {
        private readonly AlqanchaDatabaseContext _context;

        public SancionController(AlqanchaDatabaseContext context)
        {
            _context = context;
        }

        // GET: Sancion
        public async Task<IActionResult> Index()
        {
            var alqanchaDatabaseContext = _context.Sanciones.Include(s => s.Jugador);
            return View(await alqanchaDatabaseContext.ToListAsync());
        }

        // GET: Sancion/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sancion = await _context.Sanciones
                .Include(s => s.Jugador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sancion == null)
            {
                return NotFound();
            }

            return View(sancion);
        }

        // GET: Sancion/Create
        public IActionResult Create()
        {
            ViewData["JugadorId"] = new SelectList(_context.Jugadores, "Id", "Id");
            return View();
        }

        // POST: Sancion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JugadorId,Descripcion,FechaImposicion")] Sancion sancion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sancion);
                await _context.SaveChangesAsync();

                // Buscar al jugador y actualizar su estado EstaSancionado
                var jugador = await _context.Jugadores.FindAsync(sancion.JugadorId);
                if (jugador != null)
                {
                    jugador.EstaSancionado = true;
                    _context.Update(jugador);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["JugadorId"] = new SelectList(_context.Jugadores, "Id", "Id", sancion.JugadorId);
            return View(sancion);
        }

        // GET: Sancion/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sancion = await _context.Sanciones.FindAsync(id);
            if (sancion == null)
            {
                return NotFound();
            }
            ViewData["JugadorId"] = new SelectList(_context.Jugadores, "Id", "Id", sancion.JugadorId);
            return View(sancion);
        }

        // POST: Sancion/Edit/id
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JugadorId,Descripcion,FechaImposicion")] Sancion sancion)
        {
            if (id != sancion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sancion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SancionExists(sancion.Id))
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
            ViewData["JugadorId"] = new SelectList(_context.Jugadores, "Id", "Id", sancion.JugadorId);
            return View(sancion);
        }

        // GET: Sancion/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sancion = await _context.Sanciones
                .Include(s => s.Jugador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sancion == null)
            {
                return NotFound();
            }

            return View(sancion);
        }

        // POST: Sancion/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sancion = await _context.Sanciones.FindAsync(id);
            if (sancion != null)
            {
                _context.Sanciones.Remove(sancion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SancionExists(int id)
        {
            return _context.Sanciones.Any(e => e.Id == id);
        }
    }
}
