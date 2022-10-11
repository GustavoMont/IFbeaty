using IFBeaty.Dtos.Procedimentos;
using IFBeaty.Models;
using IFBeaty.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace IFBeaty.Services;

public class ProcedimentoServico
{
    private ProcedimentoRepositorio _procedimentoRepositorio;

    public ProcedimentoServico([FromServices] ProcedimentoRepositorio procedimentoRepositorio) 
    { 
        _procedimentoRepositorio = procedimentoRepositorio;
    }

    public ProcedimentoResposta CriarProvedimento(ProcedimentoCriarAtualizarRequisicao novoProcedimento) 
    { 
        var procedimento = new Procedimento();
        procedimento.Nome = novoProcedimento.Nome;
        procedimento.Preco = novoProcedimento.Preco;
        procedimento.Duracao = novoProcedimento.Duracao;
        procedimento.Descricao = novoProcedimento.Descricao;
        _procedimentoRepositorio.CriarProcedimento(procedimento);

        var response = new ProcedimentoResposta();
        response.Id = procedimento.Id;
        response.Duracao = procedimento.Duracao;
        response.Preco = procedimento.Preco;
        response.Descricao = procedimento.Descricao;
        response.Nome = procedimento.Nome;

        return response;
    }
    public List<ProcedimentoResposta> ListarProcedimentos()
    {
        var procedimentos = _procedimentoRepositorio.ListarProcedimentos();
        List<ProcedimentoResposta> procedimentoResponse = new();
        foreach (var procedimento in procedimentos)
        {
            ProcedimentoResposta procedimentoResposta = ModelToDto(procedimento);
            procedimentoResponse.Add(procedimentoResposta);
        }
        return procedimentoResponse;
    }

    private ProcedimentoResposta ModelToDto(Procedimento procedimento)
    {
        var response = new ProcedimentoResposta();
        response.Id = procedimento.Id;
        response.Duracao = procedimento.Duracao;
        response.Preco = procedimento.Preco;
        response.Descricao = procedimento.Descricao;
        response.Nome = procedimento.Nome;

        return response;
    }

}
