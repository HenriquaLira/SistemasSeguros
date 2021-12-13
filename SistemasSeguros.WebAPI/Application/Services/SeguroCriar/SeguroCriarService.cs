using SistemasSeguros.Domain.Aggregates;
using SistemasSeguros.Domain.Aggregates.ValueObjects;
using SistemasSeguros.Domain.Aggregates.Veiculos;
using SistemasSeguros.Domain.Aggregates.Segurados;
using SistemasSeguros.Infrastructure;
using SistemasSeguros.Infrastructure.Repositories;
using SistemasSeguros.WebAPI.Application.Command;
using System;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Application.Services.SeguroCriar
{
    public class SeguroCriarService: ISeguroCriarService
    {
        private readonly ISeguroRepository  _seguroRepository;
        private Seguro _seguro; 
        private Veiculo _veiculo;
        private Segurado _segurado;
        private readonly IUnitOfWork _unitOfWork;
        private IOutputPort _outputPort;

        public SeguroCriarService(ISeguroRepository seguroRepository, IUnitOfWork unitOfWork)
        {
            this._seguroRepository = seguroRepository;
            this._unitOfWork = unitOfWork;
            this._outputPort = new SeguroCriarPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        public Task Execute(SeguroCommand command) =>
            this.SalvarSeguro(command);

        private async Task SalvarSeguro(SeguroCommand command)
        {

            _seguro = new Seguro(new SeguroId(Guid.NewGuid().ToString()));
            _seguro.CalculaValorSeguro(command.Veiculo.ValorDoVeiculo);

            _segurado = new Segurado(_seguro.SeguroId, new SeguradoId(Guid.NewGuid().ToString()), command.Segurado.Nome, command.Segurado.Idade, command.Segurado.CPF);
            _veiculo = new Veiculo(_seguro.SeguroId, new VeiculoId(Guid.NewGuid().ToString()), command.Veiculo.ValorDoVeiculo, command.Veiculo.Marca, command.Veiculo.Modelo);

            await this.Salvar(_seguro, _segurado, _veiculo)
                .ConfigureAwait(false);

            this._outputPort?.Ok(_seguro);
        }

        private async Task Salvar(Seguro seguro, Segurado segurado, Veiculo veiculo)
        {
            await _seguroRepository.Add(seguro, segurado, veiculo);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }

    }
}
