using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APIDesafio.DataContext;
using APIDesafio.Entities;

namespace APIDesafio.Controllers
{
    public class AluguelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AluguelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Aluguel
        public async Task<IActionResult> Index()
        {
              return View(await _context.Alugueis.ToListAsync());
        }

        // GET: Aluguel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Alugueis == null)
            {
                return NotFound();
            }

            var aluguel = await _context.Alugueis
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aluguel == null)
            {
                return NotFound();
            }

            return View(aluguel);
        }

        // GET: Aluguel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aluguel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDCliente,IDFilme,DataLocacao")] Aluguel aluguel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluguel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluguel);
        }

        // GET: Aluguel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Alugueis == null)
            {
                return NotFound();
            }

            var aluguel = await _context.Alugueis.FindAsync(id);
            if (aluguel == null)
            {
                return NotFound();
            }
            return View(aluguel);
        }

        // POST: Aluguel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDCliente,IDFilme,DataLocacao")] Aluguel aluguel)
        {
            if (id != aluguel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluguel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AluguelExists(aluguel.ID))
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
            return View(aluguel);
        }

        // GET: Aluguel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Alugueis == null)
            {
                return NotFound();
            }

            var aluguel = await _context.Alugueis
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aluguel == null)
            {
                return NotFound();
            }

            return View(aluguel);
        }

        // POST: Aluguel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Alugueis == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Alugueis'  is null.");
            }
            var aluguel = await _context.Alugueis.FindAsync(id);
            if (aluguel != null)
            {
                _context.Alugueis.Remove(aluguel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AluguelExists(int id)
        {
          return _context.Alugueis.Any(e => e.ID == id);
        }
    }
}
