using SistemasSeguros.Domain.Aggregates;
using SistemasSeguros.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Application.Services.SeguroCalculaMedia
{
    public class SeguroCalculaMediaService : ISeguroCalculaMediaService
    {
        private readonly ISeguroRepository _seguroRepository;
        private IOutputPort _outputPort;

        public SeguroCalculaMediaService(ISeguroRepository seguroRepository)
        {
            this._seguroRepository = seguroRepository;
            this._outputPort = new SeguroCalculaMediaPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        public Task Execute() =>
            this.BuscarSeguros();

        private async Task BuscarSeguros()
        {

            IList<Seguro>? seguros = await this._seguroRepository
            .GetSeguros()
            .ConfigureAwait(false);

            this._outputPort.Ok(seguros);
        }
    }
}
