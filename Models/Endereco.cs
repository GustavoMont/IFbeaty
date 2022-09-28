namespace IFBeaty.Models;

public class Endereco
{
    public int Id { get; set; }
    public string Rua { get; set; }
    public string Numero { get; set; }
    public string Bairro { get; set; }
    public string Complemento { get; set; }
    public string Cidade { get; set; }
    public string Cep { get; set; }
    public Usuario Usuario { get; set; }
    public int UsuarioId { get; set; }
}
