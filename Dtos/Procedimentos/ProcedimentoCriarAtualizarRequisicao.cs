using System.ComponentModel.DataAnnotations;

namespace IFBeaty.Dtos.Procedimentos;

public class ProcedimentoCriarAtualizarRequisicao
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} a {1} caracteres")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "A duração é obrigatória")]
    [Range(1, 1000)]
    public int? Duracao { get; set; }

    [Required(ErrorMessage = "O Preço é obrigatório")]
    [Range(1, 1_000_000)]
    public decimal? Preco { get; set; }

    [Required(ErrorMessage = "A descrição é obrigatória")]
    public string Descricao { get; set; }
}
