using IFbeaty.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace IFbeaty.Services;

public class AgendamentoServico
{
    private readonly AgendamentoRepositorio _repositorio;

    public AgendamentoServico([FromServices] AgendamentoRepositorio repositorio)
    {
        _repositorio = repositorio;
    }
}
