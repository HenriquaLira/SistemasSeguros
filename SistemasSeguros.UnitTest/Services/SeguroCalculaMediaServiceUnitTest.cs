using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemasSeguros.Domain.Aggregates;
using SistemasSeguros.Domain.Aggregates.ValueObjects;
using SistemasSeguros.Infrastructure;
using SistemasSeguros.Infrastructure.Repositories;
using SistemasSeguros.WebAPI.Application.Command;
using SistemasSeguros.WebAPI.Application.Services;
using SistemasSeguros.WebAPI.Application.Services.SeguroCalculaMedia;
using SistemasSeguros.WebAPI.Application.Services.SeguroConsultar;
using SistemasSeguros.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemasSeguros.UnitTest.Controllers
{
    [TestClass]
    public class SeguroCalculaMediaServiceUnitTest
    {
        SeguroCalculaMediaService service;
        Mock<ISeguroRepository> _repository;

        public SeguroCalculaMediaServiceUnitTest()
        {
            _repository = new Mock<ISeguroRepository>();
            service = new SeguroCalculaMediaService(_repository.Object);
        }

        [TestMethod]
        public void SeguroCalculaMediaService_Buscar_Seguros()
        {
            _repository.Setup(x => x.GetSeguros()).Returns(It.IsAny<Task<IList<Seguro>>>());
            var result = service.Execute();
        }

        [TestMethod]
        public void SeguroCalculaMediaService_SetOutputPort_Ok()
        {
            SeguroCalculaMediaPresenter outputPort = new SeguroCalculaMediaPresenter();
            outputPort.Ok(new List<Seguro>());
            service.SetOutputPort(outputPort);
        }
    }
}
