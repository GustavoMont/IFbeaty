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

    public void CriarProvedimento(ProcedimentoCriarAtualizarRequisicao novoProcedimento) 
    { 
        var procedimento = new Procedimento();
        procedimento.Nome = novoProcedimento.Nome;
        procedimento.Preco = novoProcedimento.Preco;
        procedimento.Duracao = novoProcedimento.Duracao;
        procedimento.Descricao = novoProcedimento.Descricao;
        _procedimentoRepositorio.CriarProcedimento(procedimento);
    }
}
