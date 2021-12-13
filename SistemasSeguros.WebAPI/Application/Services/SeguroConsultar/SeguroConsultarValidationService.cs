using SistemasSeguros.WebAPI.Application.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Application.Services.SeguroConsultar
{
    public class SeguroConsultarValidationService : ISeguroConsultarService
    {
        private readonly Notification _notification;
        private readonly ISeguroConsultarService _service;
        private IOutputPort _outputPort;

        public SeguroConsultarValidationService(ISeguroConsultarService useCase, Notification notification)
        {
            this._service = useCase;
            this._notification = notification;
            this._outputPort = new SeguroConsultarPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._service.SetOutputPort(outputPort);
        }

        public async Task Execute(string id)
        {
            if (id == null || id == String.Empty)
            {
                this._notification
                    .Add("SeguradoId", "Id do Segurado é necessário.");
            }
            

            if (!this._notification
                .IsValid)
            {
                this._outputPort
                    .Invalid();
                return;
            }

            await this._service
                .Execute(id)
                .ConfigureAwait(false);
        }
    }
}
