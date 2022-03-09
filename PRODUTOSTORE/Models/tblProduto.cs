using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PRODUTOSTORE
{
    public class tblProduto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        public bool Ativo { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        public bool Perecivel { get; set; }
        public int? CategoriaId { get; set; }

        public virtual tblCategoriaProduto Categoria { get; set; }
    }
}
