using IFBeaty.Dtos.DiaFuncionamento;
using IFBeaty.Services;
using Microsoft.AspNetCore.Mvc;

namespace IFBeaty.Controllers;

[ApiController]
[Route("dias-funcionamento")]
public class DiaFuncionamentoController : ControllerBase
{
  private readonly DiaFuncionamentoServico _diaFuncionamentoServico;

  public DiaFuncionamentoController([FromServices] DiaFuncionamentoServico servico)
  {
    _diaFuncionamentoServico = servico;
  }

  [HttpPost]
  public ActionResult<DiaFuncionamentoResposta>
    PostDiaFuncionamento([FromBody] DiaFuncionamentoCriarRequisicao novoDiaFuncionamento)
  {
    try
    {
      var diaFuncionamentoResposta = _diaFuncionamentoServico.CriarDiaFuncionamento(novoDiaFuncionamento);
      return StatusCode(201, diaFuncionamentoResposta);
    }
    catch (BadHttpRequestException e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<DiaFuncionamentoResposta>> GetDiasFuncionamento()
  {
    return Ok(_diaFuncionamentoServico.ListarDiasFuncionamento());
  }

  [HttpGet("{id:int}")]
  public ActionResult<DiaFuncionamentoResposta> GetDiaFuncionamento([FromRoute] int id)
  {
    try
    {
      var diaFuncionamentoResposta = _diaFuncionamentoServico.BuscarDiaFuncionamentoPeloId(id);

      return Ok(diaFuncionamentoResposta);
    }
    catch (Exception e)
    {
      return NotFound(e.Message);
    }
  }

  [HttpDelete("{id:int}")]
  public ActionResult DeleteDiaFuncionamento([FromRoute] int id)
  {
    try
    {
      _diaFuncionamentoServico.RemoverDiaFuncionamento(id);
      return NoContent();
    }
    catch (BadHttpRequestException e)
    {
      return BadRequest(e.Message);
    }
    catch (Exception e)
    {
      return NotFound(e.Message);
    }
  }
}
