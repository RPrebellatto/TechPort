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
    public class ConteinersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConteinersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Conteiners
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Conteiners.Include(c => c.Empresa);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Conteiners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Conteiners == null)
            {
                return NotFound();
            }

            var conteiner = await _context.Conteiners
                .Include(c => c.Empresa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conteiner == null)
            {
                return NotFound();
            }

            return View(conteiner);
        }

        // GET: Conteiners/Create
        public IActionResult Create()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "Id", "Nome");
            return View();
        }

        // POST: Conteiners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Tipo,EmpresaId")] Conteiner conteiner)
        {
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                _context.Add(conteiner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "Id", "Nome", conteiner.EmpresaId);
            return View(conteiner);
        }

        // GET: Conteiners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Conteiners == null)
            {
                return NotFound();
            }

            var conteiner = await _context.Conteiners.FindAsync(id);
            if (conteiner == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "Id", "Nome", conteiner.EmpresaId);
            return View(conteiner);
        }

        // POST: Conteiners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Tipo,EmpresaId")] Conteiner conteiner)
        {
            if (id != conteiner.Id)
            {
                return NotFound();
            }

            ModelState.Clear();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conteiner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConteinerExists(conteiner.Id))
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
            ViewData["EmpresaId"] = new SelectList(_context.Empresa, "Id", "Nome", conteiner.EmpresaId);
            return View(conteiner);
        }

        // GET: Conteiners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Conteiners == null)
            {
                return NotFound();
            }

            var conteiner = await _context.Conteiners
                .Include(c => c.Empresa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conteiner == null)
            {
                return NotFound();
            }

            return View(conteiner);
        }

        // POST: Conteiners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Conteiners == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Conteiners'  is null.");
            }
            var conteiner = await _context.Conteiners.FindAsync(id);
            if (conteiner != null)
            {
                _context.Conteiners.Remove(conteiner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConteinerExists(int id)
        {
          return _context.Conteiners.Any(e => e.Id == id);
        }
    }
}
