using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PRODUTOSTORE
{
    public partial class PRODUTOSTOREContext : DbContext
    {
        public PRODUTOSTOREContext(
             DbContextOptions<PRODUTOSTOREContext> options)
             : base(options)
        {
        }

        public DbSet<tblCategoriaProduto> tblCategoriaProdutos { get; set; }
        public DbSet<tblProduto> tblProdutos { get; set; }

    }
}
