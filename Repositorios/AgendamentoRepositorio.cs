namespace IFbeaty.Repositorios;
using IFBeaty.Data;
using Microsoft.AspNetCore.Mvc;

public class AgendamentoRepositorio
{
    private readonly ContextoBD _context;

    public AgendamentoRepositorio([FromServices] ContextoBD contexto)
    {
        _context = contexto;
    }
}
