using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechPort.Data;
using TechPort.Models;

namespace TechPort.Controllers
{
    public class ViagensController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ViagensController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Viagens
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Viagens.Include(v => v.Navio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Viagens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Viagens == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagens
                .Include(v => v.Navio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viagem == null)
            {
                return NotFound();
            }

            return View(viagem);
        }

        // GET: Viagens/Create
        public IActionResult Create()
        {
            ViewData["NavioId"] = new SelectList(_context.Navios, "Id", "Nome");
            return View();
        }

        // POST: Viagens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,NavioId,TipoViagem")] Viagem viagem)
        {
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                _context.Add(viagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NavioId"] = new SelectList(_context.Navios, "Id", "Nome", viagem.NavioId);
            return View(viagem);
        }

        // GET: Viagens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Viagens == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagens.FindAsync(id);
            if (viagem == null)
            {
                return NotFound();
            }
            ViewData["NavioId"] = new SelectList(_context.Navios, "Id", "Nome", viagem.NavioId);
            return View(viagem);
        }

        // POST: Viagens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,NavioId,TipoViagem")] Viagem viagem)
        {
            if (id != viagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViagemExists(viagem.Id))
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
            ViewData["NavioId"] = new SelectList(_context.Navios, "Id", "Nome", viagem.NavioId);
            return View(viagem);
        }

        // GET: Viagens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Viagens == null)
            {
                return NotFound();
            }

            var viagem = await _context.Viagens
                .Include(v => v.Navio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viagem == null)
            {
                return NotFound();
            }

            return View(viagem);
        }

        // POST: Viagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Viagens == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Viagens'  is null.");
            }
            var viagem = await _context.Viagens.FindAsync(id);
            if (viagem != null)
            {
                _context.Viagens.Remove(viagem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViagemExists(int id)
        {
          return _context.Viagens.Any(e => e.Id == id);
        }
    }
}
