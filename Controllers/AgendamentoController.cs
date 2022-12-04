using IFbeaty.Services;
using Microsoft.AspNetCore.Mvc;

namespace IFbeaty.Controllers;

[ApiController]
[Route("agendamentos")]
public class AgendamentoController : ControllerBase
{
    private readonly AgendamentoServico _servico;

    public AgendamentoController([FromServices] AgendamentoServico servico)
    {
        _servico = servico;
    }
    
}
