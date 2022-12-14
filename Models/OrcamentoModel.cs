using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Auth.Models;

public class OrcamentoModel
{
    [Key]
    [Display(Name = "Código Orçamento")]
    public int Id { get; set; }

    [Display(Name = "Faixa de Valor Desejado")]
    public double ValorDesejado { get; set; }

    [Display(Name = "Número de Convidados")]
    public int NumConvidados { get; set; }

    [Display(Name = "Valor do Orçamento")]
    public double ValorOrcamento { get; set; }

    [NotMapped]
    public string [] fornecedores { get; set; }

    [NotMapped]
    public double Sobra
    {
        get { return this.ValorDesejado - this.ValorOrcamento; }
    }


}