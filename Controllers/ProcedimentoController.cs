using IFBeaty.Dtos.Procedimentos;
using IFBeaty.Services;
using Microsoft.AspNetCore.Mvc;

namespace IFBeaty.Controllers;

[ApiController]
[Route("procedimentos")]
public class ProcedimentoController : ControllerBase
{
    private ProcedimentoServico _procedimentoServico;

    public ProcedimentoController([FromServices] ProcedimentoServico servico)
    {
        _procedimentoServico = servico;
    }
    
    [HttpPost]
    public void PostProcedimento
        ([FromBody] ProcedimentoCriarAtualizarRequisicao  novoProcedimento) 
    {
        _procedimentoServico.CriarProvedimento(novoProcedimento);
    }
}
