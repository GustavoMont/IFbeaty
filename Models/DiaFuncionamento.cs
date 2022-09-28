namespace IFBeaty.Models;

public class DiaFuncionamento
{
    public int Id { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
    public List<Agendamento> Agendamentos { get; set; }
}
