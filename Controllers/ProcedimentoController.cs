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
    public ProcedimentoResposta PostProcedimento
        ([FromBody] ProcedimentoCriarAtualizarRequisicao  novoProcedimento) 
    {
        return _procedimentoServico.CriarProvedimento(novoProcedimento);
    }
    [HttpGet]
    public List<ProcedimentoResposta> ListarProcedimentos()
    { 
        return _procedimentoServico.ListarProcedimentos();
    }
    [HttpGet("{id:int}")]
    public ProcedimentoResposta BuscarPeloId([FromRoute] int id) 
    { 
        return _procedimentoServico.BuscarPeloId(id);
    }

    [HttpDelete("{id:int}")]
    public void RemoverProcedimento([FromRoute] int id) 
    {
        _procedimentoServico.RemoverProcedimento(id);
    }
    [HttpPut("{id:int}")]
    public ProcedimentoResposta AtualizarProcedimento
    ([FromRoute] int id, [FromBody] ProcedimentoCriarAtualizarRequisicao alteracoes)
    {
        return _procedimentoServico.AtualizarProcedimento(id, alteracoes);
    }
}
