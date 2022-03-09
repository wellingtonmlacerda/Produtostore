using Microsoft.EntityFrameworkCore;

namespace PRODUTOSTORE.Models
{
    public class ProdutostoreContext:DbContext
    {
        public ProdutostoreContext(DbContextOptions<ProdutostoreContext> options) : base(options)
        {
        }

        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<CategoriaProdutoModel> CategoriaProduto { get; set; }
    }
}
