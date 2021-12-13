using SistemasSeguros.WebAPI.Application.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Application.Services.SeguroCriar
{
    public class SeguroCriarValidationService : ISeguroCriarService
    {
        private readonly Notification _notification;
        private readonly ISeguroCriarService _service;
        private IOutputPort _outputPort;

        public SeguroCriarValidationService(ISeguroCriarService useCase, Notification notification)
        {
            this._service = useCase;
            this._notification = notification;
            this._outputPort = new SeguroCriarPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._service.SetOutputPort(outputPort);
        }

        public async Task Execute(SeguroCommand command)
        {
            if (command.Segurado.CPF == null || command.Segurado.CPF == String.Empty)
            {
                this._notification
                    .Add(nameof(command.Segurado.CPF), "CPF do Segurado é necessário.");
            }
            if (command.Segurado.Idade == 0)
            {
                this._notification
                    .Add(nameof(command.Segurado.Idade), "Idade do Seguro é necessário.");
            }
            if (command.Segurado.Nome == null || command.Segurado.Nome == String.Empty)
            {
                this._notification
                    .Add(nameof(command.Segurado.Nome), "Nome do Segurado é necessário");
            }
            if (command.Veiculo.Marca == null || command.Veiculo.Marca == String.Empty)
            {
                this._notification
                    .Add(nameof(command.Veiculo.Marca), "Marca do Veiculo é necessário.");
            }
            if (command.Veiculo.Modelo == "" || command.Veiculo.Modelo == String.Empty)
            {
                this._notification
                    .Add(nameof(command.Veiculo.Modelo), "Modelo do Veiculo é necessário");
            }
            if (command.Veiculo.ValorDoVeiculo == 0)
            {
                this._notification
                    .Add(nameof(command.Veiculo.ValorDoVeiculo), "Valor do Veiculo é necessário");
            }


            if (!this._notification
                .IsValid)
            {
                this._outputPort
                    .Invalid();
                return;
            }

            await this._service
                .Execute(command)
                .ConfigureAwait(false);
        }
    }
}
