using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PRODUTOSTORE
{
    public partial class tblCategoriaProduto
    {
        public tblCategoriaProduto()
        {
            Produtos = new HashSet<tblProduto>();
        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<tblProduto> Produtos { get; set; }
    }
}
