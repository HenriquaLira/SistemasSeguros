using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemasSeguros.Domain.Aggregates;
using SistemasSeguros.WebAPI.Application.Responses;
using SistemasSeguros.WebAPI.Application.Services;
using SistemasSeguros.WebAPI.Application.Services.SeguroCalculaMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguroCalculaMediaController : ControllerBase, IOutputPort
    {
        private readonly Notification _notification;
        private readonly ISeguroCalculaMediaService _service;

        private IActionResult? _viewModel;

        public SeguroCalculaMediaController(ISeguroCalculaMediaService service, Notification notification)
        {
            this._service = service;
            this._notification = notification;
        }
        
        void IOutputPort.Ok(IList<Seguro> seguros) => this._viewModel = this.Ok(new SeguroCalculaMediaResponse(seguros));

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SeguroCalculaMediaResponse))]
        public async Task<IActionResult> Get()
        {
            _service.SetOutputPort(this);

            await _service.Execute()
                .ConfigureAwait(false);

            return this._viewModel;
        }
    }
}
