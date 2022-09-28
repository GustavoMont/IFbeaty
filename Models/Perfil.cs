namespace IFBeaty.Models;

public class Perfil
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<Usuario> Usuarios { get; set; }
    
}
