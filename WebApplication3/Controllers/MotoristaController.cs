using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class MotoristaController : Controller
    {
        private readonly Contexto _context;

        public MotoristaController(Contexto context)
        {
            _context = context;
        }

        // GET: Motorista
        public async Task<IActionResult> Index()
        {
            return View(await _context.motoristas.ToListAsync());
        }

        // GET: Motorista/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorista = await _context.motoristas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motorista == null)
            {
                return NotFound();
            }

            return View(motorista);
        }

        // GET: Motorista/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Motorista/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Telefone,Endereco,Cnh,Cpf")] Motorista motorista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motorista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(motorista);
        }

        // GET: Motorista/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorista = await _context.motoristas.FindAsync(id);
            if (motorista == null)
            {
                return NotFound();
            }
            return View(motorista);
        }

        // POST: Motorista/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Telefone,Endereco,Cnh,Cpf")] Motorista motorista)
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

        // GET: Motorista/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motorista = await _context.motoristas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motorista == null)
            {
                return NotFound();
            }

            return View(motorista);
        }

        // POST: Motorista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motorista = await _context.motoristas.FindAsync(id);
            _context.motoristas.Remove(motorista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotoristaExists(int id)
        {
            return _context.motoristas.Any(e => e.Id == id);
        }
    }
}
