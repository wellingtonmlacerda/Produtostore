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
    public class ProdutoController : Controller
    {
        private readonly ProdutostoreContext _context;

        public ProdutoController(ProdutostoreContext context)
        {
            _context = context;
        }

        // GET: Produto
        public async Task<IActionResult> Index(int? id)
        {
            var Produto = _context.Produtos.Include(x => x.CategoriaProduto);
            ViewBag.btnCadastro = "Cadastro";
            ProdutoModel AtualizaProduto = new ProdutoModel();
            if (id != null)
            {
                AtualizaProduto = Produto.FirstOrDefault(x => x.Id == id);
                ViewBag.Id = AtualizaProduto.Id;
                ViewBag.Nome = AtualizaProduto.Nome;
                ViewBag.Descricao = AtualizaProduto.Descricao;
                ViewBag.PerecivelChecked = AtualizaProduto.Perecivel ? "checked" : null;
                ViewBag.AtivoChecked = AtualizaProduto.Ativo ? "checked" : null;
                ViewBag.btnCadastro = "Atualizar";
            }

            ViewBag.CategoriaProduto = _context.CategoriaProduto.OrderBy(x => x.Nome)
                                                      .Select(c => new SelectListItem
                                                      {
                                                          Value = c.Id.ToString(),
                                                          Text = c.Nome,
                                                          Selected = c.Id == AtualizaProduto.CategoriaID
                                                      });
            return View(await Produto.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Ativo,Perecivel,CategoriaID")] ProdutoModel produtoModel)
        {
            if (produtoModel.Nome == null)
            {
                TempData["ErrorMessage"] = "O campo Nome nao pode ser nulo";
                return RedirectToAction(nameof(Index));
            }
            if (produtoModel.Descricao == null)
            {
                TempData["ErrorMessage"] = "O campo Descricao nao pode ser nulo";
                return RedirectToAction(nameof(Index));
            }

            if (produtoModel.Id == 0)
            {
                _context.Add(produtoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else if (produtoModel.Id > 0)
            {
                _context.Update(produtoModel);
                await _context.SaveChangesAsync();
            }
            ViewBag.btnCadastro = "Cadastro";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Codigo)
        {
            if (Codigo > 0)
            {
                var produtoModel = await _context.Produtos.FindAsync(Codigo);
                if (produtoModel == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.Produtos.Remove(produtoModel);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction(nameof(Index));
        }
        private bool ProdutoModelExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
