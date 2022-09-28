using System.ComponentModel.DataAnnotations;

namespace IFBeaty.Models;

public class Usuario
{
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Telefone { get; set; }
    public Endereco Endereco { get; set; }
    public List<Agendamento> Agendamentos { get; set; } 
    public List<Perfil> Perfis { get; set; }
}
