using SistemasSeguros.Domain.Aggregates;
using SistemasSeguros.Domain.Aggregates.ValueObjects;
using SistemasSeguros.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Application.Services.SeguroConsultar
{
    public class SeguroConsultarService: ISeguroConsultarService
    {
        private readonly ISeguroRepository  _seguroRepository;
        private IOutputPort _outputPort;

        public SeguroConsultarService(ISeguroRepository seguroRepository)
        {
            this._seguroRepository = seguroRepository;
            this._outputPort = new SeguroConsultarPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        public Task Execute(string id) =>
            this.ConsultarSeguro(id);

        private async Task ConsultarSeguro(string id)
        {
            SeguroId seguroId = new SeguroId(id);

            ISeguro seguro = await this._seguroRepository
            .GetSeguro(seguroId)
            .ConfigureAwait(false);

            if (seguro is Seguro getSeguro)
            {
                this._outputPort.Ok(getSeguro);
                return;
            }

            this._outputPort.NotFound();
        }
    }
}
