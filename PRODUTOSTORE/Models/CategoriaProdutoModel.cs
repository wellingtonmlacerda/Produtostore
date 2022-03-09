using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRODUTOSTORE.Models
{
    [Table("tblCategoriaProduto")]
    public class CategoriaProdutoModel
    {
        public CategoriaProdutoModel()
        {
            Produtos = new HashSet<ProdutoModel>();
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        public bool Ativo { get; set; }

        public virtual ICollection<ProdutoModel> Produtos { get; set; }
    }
}
