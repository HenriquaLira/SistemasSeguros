using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemasSeguros.Domain.Aggregates;
using SistemasSeguros.Domain.Aggregates.ValueObjects;
using SistemasSeguros.WebAPI.Application.Command;
using SistemasSeguros.WebAPI.Application.Responses;
using SistemasSeguros.WebAPI.Application.Services;
using SistemasSeguros.WebAPI.Application.Services.SeguroCalculaMedia;
using SistemasSeguros.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemasSeguros.UnitTest.Controllers
{
    [TestClass]
    public class SeguroCalculaMediaControllerUnitTest
    {
        SeguroCalculaMediaController controller;
        Mock<ISeguroCalculaMediaService> _service;
        Mock<Notification> _notification;
        Mock<IOutputPort> _output;

        public SeguroCalculaMediaControllerUnitTest()
        {
            _service = new Mock<ISeguroCalculaMediaService>();
            _notification = new Mock<Notification>();
            _output = new Mock<IOutputPort>(); 
            controller = new SeguroCalculaMediaController(_service.Object, _notification.Object);
        }

        [TestMethod]
        public void SeguroCriar_TestMock_Ok()
        {
            SeguroCalculaMediaPresenter outputPort = new SeguroCalculaMediaPresenter();
            outputPort.Ok(new List<Seguro>());

            _service.Setup(x => x.Execute()).Returns(Task.FromResult(_output.Setup(x => x.Ok(new List<Seguro>()))));
            _service.Setup(x => x.SetOutputPort(outputPort));

            var resultOK = controller.Ok(new SeguroCalculaMediaResponse(new List<Seguro>())).Value;
            var result = controller.Get();

            Assert.IsNotNull(resultOK);
            Assert.AreEqual(resultOK.GetType(), new SeguroCalculaMediaResponse(new List<Seguro>()).GetType());
        }
    }
}
