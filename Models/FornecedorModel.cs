using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Auth.Models;

public class FornecedorModel
{
    [Key]
    [Display(Name = "Código")]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [StringLength(64, ErrorMessage = "O campo {0} comporta até {1} caracteres apenas.")]
    [Display(Name = "Nome")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [StringLength(12, ErrorMessage = "O campo {0} comporta até {1} caracteres apenas.")]
    public string Telefone { get; set; }

    [StringLength(64, ErrorMessage = "O campo {0} comporta até {1} caracteres apenas.")]
    [Display(Name = "Cidade")]
    public string Cidade { get; set; }

    [StringLength(2, ErrorMessage = "O campo {0} comporta até {1} caracteres apenas.")]
    [Display(Name = "Estado(UF)")]
    public string UF { get; set; }

    [Display(Name = "Valor à partir de...")]
    public double aPartir { get; set; }

    [Display(Name = "Valor por Pessoa")]
    public double ValorPessoa { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Valor Total")]
    public double ValorTotal { get; set; }

    [Display(Name = "Caracteristicas")]
    public string Caracteristicas { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "É Premium?")]
    public bool IsPremium { get; set; }

    [NotMapped]
    [Required(ErrorMessage = "A imagem não foi enviada.")]
    [Display(Name = "Arquivo de Imagem")]
    public IFormFile ArquivoImagem { get; set; }

    [NotMapped]
    public string CaminhoImagem
    {
        get
        {
            var caminhoImagem = Path.Combine($"\\img\\fornecedor\\", this.Id.ToString("D6") + ".jpg");
            return caminhoImagem;
        }
    }

    [ForeignKey("Categoria")]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Categoria")]
    public int? IdCategoria { get; set; }

    [Display(Name = "Categoria")]
    public CategoriaModel Categoria { get; set; }
}