using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemasSeguros.Domain.Aggregates;
using SistemasSeguros.Domain.Aggregates.ValueObjects;
using SistemasSeguros.WebAPI.Application.Command;
using SistemasSeguros.WebAPI.Application.Responses;
using SistemasSeguros.WebAPI.Application.Services;
using SistemasSeguros.WebAPI.Application.Services.SeguroConsultar;
using SistemasSeguros.WebAPI.Application.ViewModel;
using SistemasSeguros.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemasSeguros.UnitTest.Controllers
{
    [TestClass]
    public class SeguroConsultarControllerUnitTest
    {
        SeguroConsultarController controller;
        Mock<ISeguroConsultarService> _service;
        Mock<Notification> _notification;
        Mock<IOutputPort> _output;

        public SeguroConsultarControllerUnitTest()
        {
            _service = new Mock<ISeguroConsultarService>();
            _notification = new Mock<Notification>();
            _output = new Mock<IOutputPort>(); 
            controller = new SeguroConsultarController(_service.Object, _notification.Object);
        }

        [TestMethod]
        public void SeguroCriar_TestMock_NotFound()
        {
            SeguroConsultarPresenter outputPort = new SeguroConsultarPresenter();
            outputPort.NotFound();

            _service.Setup(x => x.Execute(It.IsAny<string>())).Returns(Task.FromResult(_output.Setup(x => x.NotFound())));
            _service.Setup(x => x.SetOutputPort(outputPort));

            var resultNotFound = controller.NotFound();
            var result = controller.Get(It.IsAny<string>()).Result;

            Assert.IsNotNull(resultNotFound);
            Assert.AreEqual(resultNotFound.StatusCode, 404);
        }

        [TestMethod]
        public void SeguroCriar_TestMock_Ok()
        {
            SeguroConsultarPresenter outputPort = new SeguroConsultarPresenter();
            outputPort.Ok(new Seguro(new SeguroId()));

            _service.Setup(x => x.Execute(It.IsAny<string>())).Returns(Task.FromResult(_output.Setup(x => x.Ok(new Seguro(new SeguroId())))));
            _service.Setup(x => x.SetOutputPort(outputPort));

            var resultOK = controller.Ok(new SeguroConsultarResponse(new SeguroModel(new Seguro(new SeguroId())))).Value;
            var result = controller.Get(It.IsAny<string>()).Result;

            Assert.IsNotNull(resultOK);
            Assert.AreEqual(resultOK.GetType(), new SeguroConsultarResponse(new SeguroModel(new Seguro(new SeguroId()))).GetType());
        }

        [TestMethod]
        public void SeguroCriar_TestMock_Invalid()
        {
            SeguroConsultarPresenter outputPort = new SeguroConsultarPresenter();
            outputPort.Invalid();

            _service.Setup(x => x.Execute(It.IsAny<string>())).Returns(Task.FromResult(_output.Setup(x => x.Invalid())));
            _service.Setup(x => x.SetOutputPort(outputPort));

            var resultInvalid = controller.BadRequest(new ValidationProblemDetails(_notification.Object.ModelState)).Value;
            var result = controller.Get(It.IsAny<string>());

            Assert.IsNotNull(resultInvalid); 
            Assert.AreEqual(resultInvalid.GetType(), new ValidationProblemDetails(_notification.Object.ModelState).GetType());

        }
    }
}
