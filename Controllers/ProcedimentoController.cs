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
    public ActionResult<List<ProcedimentoResposta>> ListarProcedimentos()
    { 
        return Ok(_procedimentoServico.ListarProcedimentos());
    }
    [HttpGet("{id:int}")]
    public ActionResult<ProcedimentoResposta> BuscarPeloId([FromRoute] int id) 
    { 
        try
        {
            return Ok(_procedimentoServico.BuscarPeloId(id));
        }
        catch (Exception e)
        {
            
            return NotFound(new { message = e.Message });
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult RemoverProcedimento([FromRoute] int id) 
    {
        try
        {
            _procedimentoServico.RemoverProcedimento(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(new {message = e.Message} );
        }
    }
    [HttpPut("{id:int}")]
    public ProcedimentoResposta AtualizarProcedimento
    ([FromRoute] int id, [FromBody] ProcedimentoCriarAtualizarRequisicao alteracoes)
    {
        try
        {
            return _procedimentoServico.AtualizarProcedimento(id, alteracoes);
        }
        catch (Exception)
        {
            return null;
        }
    }
}
