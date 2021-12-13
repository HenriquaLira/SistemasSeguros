using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemasSeguros.Domain.Aggregates;
using SistemasSeguros.Domain.Aggregates.ValueObjects;
using SistemasSeguros.Infrastructure;
using SistemasSeguros.Infrastructure.Repositories;
using SistemasSeguros.WebAPI.Application.Command;
using SistemasSeguros.WebAPI.Application.Services;
using SistemasSeguros.WebAPI.Application.Services.SeguroConsultar;
using SistemasSeguros.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemasSeguros.UnitTest.Controllers
{
    [TestClass]
    public class SeguroConsultarServiceUnitTest
    {
        SeguroConsultarService service;
        Mock<ISeguroRepository> _repository;

        public SeguroConsultarServiceUnitTest()
        {
            _repository = new Mock<ISeguroRepository>();
            service = new SeguroConsultarService(_repository.Object);
        }

        [TestMethod]
        public void SeguroConsultarService_Consultar_Seguro()
        {
            _repository.Setup(x => x.GetSeguro(It.IsAny<SeguroId>())).Returns(It.IsAny<Task<ISeguro>>());
            var result = service.Execute(It.IsAny<string>());
        }

        [TestMethod]
        public void SeguroConsultarService_SetOutputPort_Ok()
        {
            SeguroConsultarPresenter outputPort = new SeguroConsultarPresenter();
            outputPort.Ok(new Seguro(new SeguroId()));
           service.SetOutputPort(outputPort);
        }

        [TestMethod]
        public void SeguroConsultarService_SetOutputPort_NotFound()
        {
            SeguroConsultarPresenter outputPort = new SeguroConsultarPresenter();
            outputPort.NotFound();
            service.SetOutputPort(outputPort);
        }

        [TestMethod]
        public void SeguroConsultarService_SetOutputPort_Invalid()
        {
            SeguroConsultarPresenter outputPort = new SeguroConsultarPresenter();
            outputPort.Invalid();
            service.SetOutputPort(outputPort);
        }
    }
}
