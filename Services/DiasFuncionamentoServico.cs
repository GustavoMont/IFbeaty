using IFBeaty.Dtos.DiaFuncionamento;
using IFBeaty.Models;
using IFBeaty.Repositorios;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace IFBeaty.Services;

public class DiaFuncionamentoServico
{
  private readonly DiaFuncionamentoRepositorio _diaFuncionamentoRepositorio;

  public DiaFuncionamentoServico([FromServices] DiaFuncionamentoRepositorio repositorio)
  {
    _diaFuncionamentoRepositorio = repositorio;
  }

  public DiaFuncionamentoResposta
    CriarDiaFuncionamento(DiaFuncionamentoCriarRequisicao novoDiaFuncionamento)
  {
    //Não pode cadastrar data passada
    if (novoDiaFuncionamento.Inicio.Date < DateTime.Now.Date)
    {
      throw new BadHttpRequestException("Não pode cadastrar dia de funcionamento passado");
    }

    //Inicio e Fim tem que ser na mesma data
    if (novoDiaFuncionamento.Inicio.Date != novoDiaFuncionamento.Fim.Date)
    {
      throw new BadHttpRequestException("Início e Fim tem que ser no mesmo dia");
    }

    //Deve ter no mínimo 1 hora de diferença entre o início e o fim
    var tempoFuncionamento = novoDiaFuncionamento.Fim - novoDiaFuncionamento.Inicio;
    if (tempoFuncionamento.TotalHours < 1)
    {
      throw new BadHttpRequestException("Deve ter no mínimo uma hora de funcionamento no dia");
    }

    //Não pode ter dia que já esteja cadastrado
    var diaFuncionamentoExistente =
      _diaFuncionamentoRepositorio.BuscarDiaFuncionamentoPelaDataInicio(novoDiaFuncionamento.Inicio);
    if (diaFuncionamentoExistente is not null)
    {
      throw new BadHttpRequestException("Esse dia de funcionamento já está cadastrado");
    }

    //Copiar da Requisicao para o Modelo
    var diaFuncionamento = novoDiaFuncionamento.Adapt<DiaFuncionamento>();

    //Mandar salvar no repositorio
    diaFuncionamento = _diaFuncionamentoRepositorio.CriarDiaFuncionamento(diaFuncionamento);

    //Copiar do modelo pra resposta
    var diaFuncionamentoResposta = diaFuncionamento.Adapt<DiaFuncionamentoResposta>();

    return diaFuncionamentoResposta;
  }

  public List<DiaFuncionamentoResposta> ListarDiasFuncionamento()
  {
    //modelos
    var diasFuncionamento = _diaFuncionamentoRepositorio.ListarDiasFuncionamento();

    //converter de modelo para resposta
    return diasFuncionamento.Adapt<List<DiaFuncionamentoResposta>>();
  }

  private DiaFuncionamento BuscarPeloId(int id, bool tracking = true)
  {
    var diaFuncionamento = _diaFuncionamentoRepositorio.BuscarDiaFuncionamentoPeloId(id, tracking);

    if (diaFuncionamento is null)
    {
      throw new Exception("Dia de funcionamento não encontrado");
    }

    return diaFuncionamento;
  }

  public DiaFuncionamentoResposta BuscarDiaFuncionamentoPeloId(int id)
  {
    var diaFuncionamento = BuscarPeloId(id, false);

    //modelo para resposta
    return diaFuncionamento.Adapt<DiaFuncionamentoResposta>();
  }

  public void RemoverDiaFuncionamento(int id)
  {
    //buscar no repositorio
    var diaFuncionamento = BuscarPeloId(id);

    //Não pode excluir dia de funcionamento passado ou atual
    if (diaFuncionamento.Inicio.Date <= DateTime.Now.Date)
    {
      throw new BadHttpRequestException("Não pode excluir dia de funcionamento menor ou igual a data atual");
    }

    //No Futuro não vaou permitir remover um dia de funcionamento que esteja associado a um agendamento

    //mandar o repositorio excluir
    _diaFuncionamentoRepositorio.RemoverDiaFuncionamento(diaFuncionamento);
  }
}
