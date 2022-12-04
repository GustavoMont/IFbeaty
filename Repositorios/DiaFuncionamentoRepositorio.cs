using IFBeaty.Data;
using IFBeaty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IFBeaty.Repositorios;

public class DiaFuncionamentoRepositorio
{

    private readonly ContextoBD _contexto;

    public DiaFuncionamentoRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }

    public DiaFuncionamento CriarDiaFuncionamento(DiaFuncionamento diaFuncionamento)
    {
        _contexto.DiaFuncionamentos.Add(diaFuncionamento);
        _contexto.SaveChanges();

        return diaFuncionamento;
    }

    public DiaFuncionamento BuscarDiaFuncionamentoPelaDataInicio(DateTime inicio)
    {
        return _contexto.DiaFuncionamentos
        .AsNoTracking()
        .FirstOrDefault(df => df.Inicio.Date == inicio.Date);
    }

    public List<DiaFuncionamento> ListarDiasFuncionamento()
    {
        return _contexto.DiaFuncionamentos.AsNoTracking().ToList();
    }

    public DiaFuncionamento BuscarDiaFuncionamentoPeloId(int id, bool tracking = true)
    {
        return
        tracking ?
            _contexto.DiaFuncionamentos.FirstOrDefault(df => df.Id == id) :
            _contexto.DiaFuncionamentos.AsNoTracking().FirstOrDefault(df => df.Id == id);
    }

    public void RemoverDiaFuncionamento(DiaFuncionamento diaFuncionamento)
    {
        //Remover do contexto
        _contexto.Remove(diaFuncionamento);

        //Mandando atualizar o BD
        _contexto.SaveChanges();
    }
}
