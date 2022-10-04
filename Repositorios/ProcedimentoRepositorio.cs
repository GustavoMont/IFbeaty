using IFBeaty.Data;
using IFBeaty.Models;
using Microsoft.AspNetCore.Mvc;

namespace IFBeaty.Repositorios;

public class ProcedimentoRepositorio
{   
    private ContextoBD _contextoDb;
    public ProcedimentoRepositorio ([FromServices] ContextoBD contexto) 
    { 
        _contextoDb = contexto;
    }
    public void CriarProcedimento(Procedimento procedimento) 
    { 
        _contextoDb.Procedimentos.Add(procedimento);
        _contextoDb.SaveChanges();
    }
}
