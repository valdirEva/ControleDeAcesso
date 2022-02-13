using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleDeAcesso.Data;
using ControleDeAcesso.Models;

namespace ControleDeAcesso.Controllers
{
    public class ApartamentosController : Controller
    {
        private readonly ControleDeAcessoContext _context;

        public ApartamentosController(ControleDeAcessoContext context)
        {
            _context = context;
        }

        // GET: Apartamentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Apartamento.ToListAsync());
        }

        // GET: Apartamentos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartamento = await _context.Apartamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartamento == null)
            {
                return NotFound();
            }

            return View(apartamento);
        }

        // GET: Apartamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Apartamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,Bloco")] Apartamento apartamento)
        {
            if (ModelState.IsValid)
            {
                apartamento.Id = Guid.NewGuid();
                _context.Add(apartamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apartamento);
        }

        // GET: Apartamentos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartamento = await _context.Apartamento.FindAsync(id);
            if (apartamento == null)
            {
                return NotFound();
            }
            return View(apartamento);
        }

        // POST: Apartamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Numero,Bloco")] Apartamento apartamento)
        {
            if (id != apartamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartamentoExists(apartamento.Id))
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
            return View(apartamento);
        }

        // GET: Apartamentos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartamento = await _context.Apartamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartamento == null)
            {
                return NotFound();
            }

            return View(apartamento);
        }

        // POST: Apartamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var apartamento = await _context.Apartamento.FindAsync(id);
            _context.Apartamento.Remove(apartamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartamentoExists(Guid id)
        {
            return _context.Apartamento.Any(e => e.Id == id);
        }
    }
}
