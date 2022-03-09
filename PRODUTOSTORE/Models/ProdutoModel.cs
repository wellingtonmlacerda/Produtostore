using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRODUTOSTORE.Models
{
    [Table("tblProduto")]
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public bool Perecivel { get; set; }
        [ForeignKey("CategoriaProduto")]
        public int? CategoriaID { get; set; }

        public CategoriaProdutoModel CategoriaProduto { get; set; }
    }
}
