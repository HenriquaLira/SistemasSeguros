using SistemasSeguros.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Application.Services.SeguroCalculaMedia
{
    public class SeguroCalculaMediaPresenter:IOutputPort
    {
        public IList<Seguro>? Seguros { get; private set; }
        public void Ok(IList<Seguro> seguros) => this.Seguros = seguros;
    }
}
