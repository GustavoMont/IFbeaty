using IFBeaty.Models;
using Microsoft.EntityFrameworkCore;

namespace IFBeaty.Data;
    
public class ContextoBD : DbContext
{
    public ContextoBD(DbContextOptions<ContextoBD> options) : base(options)
    {

    }
    //TABELAS
    public DbSet<Procedimento> Procedimentos { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<DiaFuncionamento> DiaFuncionamentos { get; set; }
    public DbSet<Agendamento> Agendamentos { get; set; }
    public DbSet<Perfil> Perfils { get; set; }
}
