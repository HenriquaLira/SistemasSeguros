using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemasSeguros.Domain.Aggregates;
using SistemasSeguros.WebAPI.Application.Command;
using SistemasSeguros.WebAPI.Application.Responses;
using SistemasSeguros.WebAPI.Application.Services;
using SistemasSeguros.WebAPI.Application.Services.SeguroCriar;
using SistemasSeguros.WebAPI.Application.ViewModel;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguroCriarController: ControllerBase, IOutputPort
    {
        private readonly Notification _notification;
        private readonly ISeguroCriarService _service;

        private IActionResult? _viewModel;

        public SeguroCriarController(ISeguroCriarService service, Notification notification)
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

        void IOutputPort.Ok(Seguro seguro) => this._viewModel = this.Ok(new SeguroCriarResponse(new SeguroModel(seguro)));

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SeguroCriarResponse))]
        public async Task<IActionResult> Post(
        [FromBody]SeguroCommand seguro)
        {
            _service.SetOutputPort(this);


            await _service.Execute(seguro)
                .ConfigureAwait(false);

            return this._viewModel;
        }
    }
}
