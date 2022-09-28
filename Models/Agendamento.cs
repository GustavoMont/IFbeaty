namespace IFBeaty.Models;

public class Agendamento
{
    public int Id { get; set; }
    public DateTime Horario { get; set; }
    public bool Confirmado { get; set; }
    public DateTime DataCriacao { get; set; }
    public Procedimento Procedimento { get; set; }
    public int ProcedimentoId { get; set; }
    public DiaFuncionamento DiaFuncionamento { get; set; }
    public int DiaFuncionamentoId { get; set; }
    public Usuario Usuario { get; set; }
    public int UsuarioId { get; set; }
}
