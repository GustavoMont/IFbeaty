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

    private Procedimento BuscarProcedimento(int id)
    {
        var procedimento = _procedimentoRepositorio.BuscarPeloId(id);
        if (procedimento is null)
        {
            throw new Exception("Procedimento não encontrado");
        }
        return procedimento;
    }

    public ProcedimentoResposta CriarProvedimento(ProcedimentoCriarAtualizarRequisicao novoProcedimento) 
    { 
        var procedimento = new Procedimento();
        procedimento.Nome = novoProcedimento.Nome;
        procedimento.Preco = (decimal)novoProcedimento.Preco;
        procedimento.Duracao = (int)novoProcedimento.Duracao;
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

    public ProcedimentoResposta BuscarPeloId(int id) 
    {  
        var procedimento = BuscarProcedimento(id);;
        return ModelToDto(procedimento);
    }

    public void RemoverProcedimento(int id) 
    {   
        var procedimento = BuscarProcedimento(id);
        _procedimentoRepositorio.RemoverProcedimento(procedimento);
    }

    public ProcedimentoResposta AtualizarProcedimento
    (int id, ProcedimentoCriarAtualizarRequisicao alteracoes)
    {
        var procedimento = BuscarProcedimento(id);
        RequisicaoToModelo(alteracoes, procedimento);
        return ModelToDto(procedimento);
    }

    private void RequisicaoToModelo
    (ProcedimentoCriarAtualizarRequisicao requisicao, Procedimento modelo)
    {
        modelo.Duracao = (int)requisicao.Duracao;
        modelo.Nome = requisicao.Nome;
        modelo.Descricao = requisicao.Descricao;
        modelo.Preco = (decimal)requisicao.Preco;
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
