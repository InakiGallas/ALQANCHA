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
    public class JugadorController : Controller
    {
        private readonly AlqanchaDatabaseContext _context;

        public JugadorController(AlqanchaDatabaseContext context)
        {
            _context = context;
        }

        // GET: Jugador
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jugadores.ToListAsync());
        }

        // GET: Jugador/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // GET: Jugador/Create
        public IActionResult Create()
        {
            ViewData["HorasDisponibles"] = new SelectList(Enumerable.Range(10, 15).Select(h => new { Value = new TimeSpan(h, 0, 0), Text = $"{h}:00" }), "Value", "Text");
            return View();
        }

        // POST: Jugador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dni,Nombre,Apellido,Email,Telefono,EsArquero,EsJugador,FechaDisponible,HoraInicio,EstaSancionado")] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jugador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HorasDisponibles"] = new SelectList(Enumerable.Range(10, 15).Select(h => new { Value = new TimeSpan(h, 0, 0), Text = $"{h}:00" }), "Value", "Text", jugador.HoraInicio);
            return View(jugador);
        }

        // GET: Jugador/Edit/id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugadores.FindAsync(id);
            if (jugador == null)
            {
                return NotFound();
            }
            ViewData["HorasDisponibles"] = new SelectList(Enumerable.Range(10, 15).Select(h => new { Value = new TimeSpan(h, 0, 0), Text = $"{h}:00" }), "Value", "Text", jugador.HoraInicio);
            return View(jugador);
        }

        // POST: Jugador/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dni,Nombre,Apellido,Email,Telefono,EsArquero,EsJugador,FechaDisponible,HoraInicio,EstaSancionado")] Jugador jugador)
        {
            if (id != jugador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jugador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JugadorExists(jugador.Id))
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
            ViewData["HorasDisponibles"] = new SelectList(Enumerable.Range(10, 15).Select(h => new { Value = new TimeSpan(h, 0, 0), Text = $"{h}:00" }), "Value", "Text", jugador.HoraInicio);
            return View(jugador);
        }

        // GET: Jugador/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // POST: Jugador/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jugador = await _context.Jugadores.FindAsync(id);
            if (jugador != null)
            {
                _context.Jugadores.Remove(jugador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JugadorExists(int id)
        {
            return _context.Jugadores.Any(e => e.Id == id);
        }
    }
}
