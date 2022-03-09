using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRODUTOSTORE.Models;

namespace PRODUTOSTORE.Controllers
{
    public class CategoriaProdutoController : Controller
    {
        private readonly ProdutostoreContext _context;

        public CategoriaProdutoController(ProdutostoreContext context)
        {
            _context = context;
        }

        // GET: CategoriaProduto
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaProduto.ToListAsync());
        }

        // GET: CategoriaProduto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProdutoModel = await _context.CategoriaProduto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaProdutoModel == null)
            {
                return NotFound();
            }

            return View(categoriaProdutoModel);
        }

        // GET: CategoriaProduto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaProduto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Ativo")] CategoriaProdutoModel categoriaProdutoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaProdutoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaProdutoModel);
        }

        // GET: CategoriaProduto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProdutoModel = await _context.CategoriaProduto.FindAsync(id);
            if (categoriaProdutoModel == null)
            {
                return NotFound();
            }
            return View(categoriaProdutoModel);
        }

        // POST: CategoriaProduto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Ativo")] CategoriaProdutoModel categoriaProdutoModel)
        {
            if (id != categoriaProdutoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaProdutoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaProdutoModelExists(categoriaProdutoModel.Id))
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
            return View(categoriaProdutoModel);
        }

        // GET: CategoriaProduto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProdutoModel = await _context.CategoriaProduto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoriaProdutoModel == null)
            {
                return NotFound();
            }

            return View(categoriaProdutoModel);
        }

        // POST: CategoriaProduto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaProdutoModel = await _context.CategoriaProduto.FindAsync(id);
            _context.CategoriaProduto.Remove(categoriaProdutoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaProdutoModelExists(int id)
        {
            return _context.CategoriaProduto.Any(e => e.Id == id);
        }
    }
}
