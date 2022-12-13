using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Auth.Models;

public class OrcamentoModel
{
    [Key]
    [Display(Name = "Código Orçamento")]
    public int Id { get; set; }

    [ForeignKey("Usuario")]
    public int IdUsuario { get; set; }
    public UsuarioModel Usuario { get; set; }

    [NotMapped]
    [ForeignKey("Fornecedor")]
    public int idFornecedor { get; set; }
    public FornecedorModel Fornecedor { get; set; }

    [Display(Name = "Faixa de Valor Desejado")]
    public double ValorDesejado { get; set; }

    [Display(Name = "Número de Convidados")]
    public int NumConvidados { get; set; }

    [Display(Name = "Valor do Orçamento")]
    public double ValorOrcamento { get; set; }

    [NotMapped]
    public ICollection<FornecedorModel> ListaFornecedores { get; set; }

}