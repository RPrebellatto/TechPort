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
    public class MotoristasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MotoristasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Motoristas
        public async Task<IActionResult> Index()
        {
              return _context.Motorista != null ? 
                          View(await _context.Motorista.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Motorista'  is null.");
        }

        //,lmkljjljnljn

        // GET: Motoristas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Motorista == null)
            {
                return NotFound();
            }

            var motorista = await _context.Motorista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motorista == null)
            {
                return NotFound();
            }

            return View(motorista);
        }

        // GET: Motoristas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Motoristas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CNH")] Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motorista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motorista);
        }

        // GET: Motoristas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Motorista == null)
            {
                return NotFound();
            }

            var motorista = await _context.Motorista.FindAsync(id);
            if (motorista == null)
            {
                return NotFound();
            }
            return View(motorista);
        }

        // POST: Motoristas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CNH")] Motorista motorista)
        {
            if (id != motorista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motorista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotoristaExists(motorista.Id))
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
            return View(motorista);
        }

        // GET: Motoristas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Motorista == null)
            {
                return NotFound();
            }

            var motorista = await _context.Motorista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motorista == null)
            {
                return NotFound();
            }

            return View(motorista);
        }

        // POST: Motoristas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Motorista == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Motorista'  is null.");
            }
            var motorista = await _context.Motorista.FindAsync(id);
            if (motorista != null)
            {
                _context.Motorista.Remove(motorista);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotoristaExists(int id)
        {
          return (_context.Motorista?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
