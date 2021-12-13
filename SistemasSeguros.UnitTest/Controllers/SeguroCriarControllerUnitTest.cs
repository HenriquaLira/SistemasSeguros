using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SistemasSeguros.Domain.Aggregates;
using SistemasSeguros.Domain.Aggregates.ValueObjects;
using SistemasSeguros.WebAPI.Application.Command;
using SistemasSeguros.WebAPI.Application.Responses;
using SistemasSeguros.WebAPI.Application.Services;
using SistemasSeguros.WebAPI.Application.Services.SeguroCriar;
using SistemasSeguros.WebAPI.Application.ViewModel;
using SistemasSeguros.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemasSeguros.UnitTest.Controllers
{
    [TestClass]
    public class SeguroCriarControllerUnitTest
    {
        SeguroCriarController controller;
        Mock<ISeguroCriarService> _service;
        Mock<Notification> _notification;
        Mock<IOutputPort> _output;

        public SeguroCriarControllerUnitTest()
        {
            _service = new Mock<ISeguroCriarService>();
            _notification = new Mock<Notification>();
            _output = new Mock<IOutputPort>(); 
            controller = new SeguroCriarController(_service.Object, _notification.Object);
        }

        [TestMethod]
        public void SeguroCriar_TestMock_NotFound()
        {
            SeguroCriarPresenter outputPort = new SeguroCriarPresenter();
            outputPort.NotFound();

            _service.Setup(x => x.Execute(It.IsAny<SeguroCommand>())).Returns(Task.FromResult(_output.Setup(x => x.NotFound())));
            _service.Setup(x => x.SetOutputPort(outputPort));

            var resultNotFound = controller.NotFound();
            var result = controller.Post(It.IsAny<SeguroCommand>());

            Assert.IsNotNull(resultNotFound);
            Assert.AreEqual(resultNotFound.StatusCode, 404);
        }

        [TestMethod]
        public void SeguroCriar_TestMock_Ok()
        {
            SeguroCriarPresenter outputPort = new SeguroCriarPresenter();
            outputPort.Ok(new Seguro(new SeguroId()));

            _service.Setup(x => x.Execute(It.IsAny<SeguroCommand>())).Returns(Task.FromResult(_output.Setup(x => x.Ok(new Seguro(It.IsAny<SeguroId>())))));
            _service.Setup(x => x.SetOutputPort(outputPort));

            var resultOK = controller.Ok(new SeguroCriarResponse(new SeguroModel(new Seguro(new SeguroId())))).Value;
            var result = controller.Post(It.IsAny<SeguroCommand>());

            Assert.IsNotNull(resultOK);
            Assert.AreEqual(resultOK.GetType(), new SeguroCriarResponse(new SeguroModel(new Seguro(new SeguroId()))).GetType());
        }

        [TestMethod]
        public void SeguroCriar_TestMock_Invalid()
        {
            SeguroCriarPresenter outputPort = new SeguroCriarPresenter();
            outputPort.Invalid();

            _service.Setup(x => x.Execute(It.IsAny<SeguroCommand>())).Returns(Task.FromResult(_output.Setup(x => x.Invalid())));
            _service.Setup(x => x.SetOutputPort(outputPort));

            var resultInvalid = controller.BadRequest(new ValidationProblemDetails(_notification.Object.ModelState)).Value;
            var result = controller.Post(It.IsAny<SeguroCommand>());

            Assert.IsNotNull(resultInvalid);
            Assert.AreEqual(resultInvalid.GetType(), new ValidationProblemDetails(_notification.Object.ModelState).GetType());
        }
    }
}
