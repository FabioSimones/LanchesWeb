using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }

        [Required(ErrorMessage = "Informe o nome do lanche!")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1}, e máximo de {2} caracteres!")]
        [Display(Name = "Nome do Lanche")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do lanche deve ser informada!")]
        [MinLength(20, ErrorMessage = "O tamanho mínimo é de {1} caracteres!")]
        [MaxLength(200, ErrorMessage = "O tamanho máximo é de {1} caracteres!")]
        [Display(Name = "Descrição do Lanche")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "A descrição detalhada do lanche deve ser informada!")]
        [MinLength(20, ErrorMessage = "O tamanho mínimo é de {1} caracteres!")]
        [MaxLength(200, ErrorMessage = "O tamanho máximo é de {1} caracteres!")]
        [Display(Name = "Descrição detalhada do Lanche")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "Informe o preço do lanche!")]
        [Display(Name = "Preço")]
        [Column(TypeName = "Decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "O preço deve estar entre {1} e {2}!")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho da Imagem")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres!")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres!")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name ="Estoque")]
        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
