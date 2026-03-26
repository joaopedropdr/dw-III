using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.Data;
using ControleFinanceiro.Models;

namespace ControleFinanceiro.Controllers
{
    public class ContaBancariaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContaBancariaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContaBancaria
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ContasBancarias.Include(c => c.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ContaBancaria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaBancaria = await _context.ContasBancarias
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contaBancaria == null)
            {
                return NotFound();
            }

            return View(contaBancaria);
        }

        // GET: ContaBancaria/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: ContaBancaria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InstituicaoBancaria,valorEntrada,valorAnterior,valorPosterior,Saldo,Observacao,DataAtualizacao,UsuarioId")] ContaBancaria contaBancaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contaBancaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", contaBancaria.UsuarioId);
            return View(contaBancaria);
        }

        // GET: ContaBancaria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaBancaria = await _context.ContasBancarias.FindAsync(id);
            if (contaBancaria == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", contaBancaria.UsuarioId);
            return View(contaBancaria);
        }

        // POST: ContaBancaria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InstituicaoBancaria,valorEntrada,valorAnterior,valorPosterior,Saldo,Observacao,DataAtualizacao,UsuarioId")] ContaBancaria contaBancaria)
        {
            if (id != contaBancaria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contaBancaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaBancariaExists(contaBancaria.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", contaBancaria.UsuarioId);
            return View(contaBancaria);
        }

        // GET: ContaBancaria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaBancaria = await _context.ContasBancarias
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contaBancaria == null)
            {
                return NotFound();
            }

            return View(contaBancaria);
        }

        // POST: ContaBancaria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contaBancaria = await _context.ContasBancarias.FindAsync(id);
            if (contaBancaria != null)
            {
                _context.ContasBancarias.Remove(contaBancaria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContaBancariaExists(int id)
        {
            return _context.ContasBancarias.Any(e => e.Id == id);
        }
    }
}
