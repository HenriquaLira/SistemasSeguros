using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemasSeguros.Domain.Aggregates;
using SistemasSeguros.Domain.Aggregates.Segurados;
using SistemasSeguros.Domain.Aggregates.ValueObjects;
using SistemasSeguros.Domain.Aggregates.Veiculos;
using SistemasSeguros.Infrastructure;
using SistemasSeguros.Infrastructure.Repositories;
using SistemasSeguros.WebAPI.Application.Command;
using SistemasSeguros.WebAPI.Application.Services.SeguroCriar;

namespace SistemasSeguros.UnitTest.Controllers
{
    [TestClass]
    public class SeguroCriarServiceUnitTest
    {
        SeguroCriarService service;
        Mock<ISeguroRepository> _repository;
        Mock<IUnitOfWork> _unitOfWork;

        public SeguroCriarServiceUnitTest()
        {
            _repository = new Mock<ISeguroRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            service = new SeguroCriarService(_repository.Object, _unitOfWork.Object);
        }

        [TestMethod]
        public void SeguroCriarService_Salvar_Seguro()
        {
            _repository.Setup(x => x.Add(It.IsAny<Seguro>(), It.IsAny<Segurado>(), It.IsAny<Veiculo>()));
            var result = service.Execute(new SeguroCommand { 
                Segurado = new SeguradoCommand{ CPF = "423424", Idade = 12, Nome = "Henrique"}, 
                Veiculo = new VeiculoCommand { Marca = "VOLKS", Modelo = "GOL", ValorDoVeiculo = 10000 } });
        }

        [TestMethod]
        public void SeguroCriarService_SetOutputPort_Ok()
        {
            SeguroCriarPresenter outputPort = new SeguroCriarPresenter();
            outputPort.Ok(new Seguro(new SeguroId()));
            service.SetOutputPort(outputPort);
        }

        [TestMethod]
        public void SeguroCriarService_SetOutputPort_NotFound()
        {
            SeguroCriarPresenter outputPort = new SeguroCriarPresenter();
            outputPort.NotFound();
            service.SetOutputPort(outputPort);
        }

        [TestMethod]
        public void SeguroCriarService_SetOutputPort_Invalid()
        {
            SeguroCriarPresenter outputPort = new SeguroCriarPresenter();
            outputPort.Invalid();
            service.SetOutputPort(outputPort);
        }
    }
}
