using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemasSeguros.Domain.Aggregates;
using SistemasSeguros.WebAPI.Application.Responses;
using SistemasSeguros.WebAPI.Application.Services;
using SistemasSeguros.WebAPI.Application.Services.SeguroConsultar;
using SistemasSeguros.WebAPI.Application.ViewModel;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguroConsultarController : ControllerBase, IOutputPort
    {
        private readonly Notification _notification;
        private readonly ISeguroConsultarService _service;

        private IActionResult? _viewModel;

        public SeguroConsultarController(ISeguroConsultarService service, Notification notification)
        {
            this._service = service;
            this._notification = notification;
        }


        void IOutputPort.Invalid()
        {
            ValidationProblemDetails problemDetails = new ValidationProblemDetails(this._notification.ModelState);
            this._viewModel = this.BadRequest(problemDetails);
        }

        void IOutputPort.NotFound() => this._viewModel = this.NotFound();

        void IOutputPort.Ok(Seguro seguro) => this._viewModel = this.Ok(new SeguroConsultarResponse(new SeguroModel(seguro)));

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SeguroConsultarResponse))]
        public async Task<IActionResult> Get(
        [FromQuery] string id)
        {
            _service.SetOutputPort(this);

            await _service.Execute(id)
                .ConfigureAwait(false);

            return this._viewModel;
        }
    }
}
