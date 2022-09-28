using IFBeaty.Models;
using Microsoft.AspNetCore.Mvc;

namespace IFBeaty.Controllers;

[ApiController]
[Route("/procedimentos")]
public class ProcedimentoController : ControllerBase
{
    public Procedimento Create([FromBody] Procedimento procedimentoData)
    {   
        Procedimento procedimento = new Procedimento();

        return procedimento;
    }
}
