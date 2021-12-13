using SistemasSeguros.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Application.Services.SeguroCriar
{
    public class SeguroCriarPresenter:IOutputPort
    {
        public Seguro? Seguro { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.NotFoundOutput = true;
        public void Ok(Seguro seguro) => this.Seguro = seguro;
    }
}
