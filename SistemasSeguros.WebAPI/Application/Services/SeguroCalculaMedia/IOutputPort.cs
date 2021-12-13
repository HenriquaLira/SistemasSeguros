using SistemasSeguros.Domain.Aggregates;
using System.Collections.Generic;

namespace SistemasSeguros.WebAPI.Application.Services.SeguroCalculaMedia
{
    public interface IOutputPort
    {
        void Ok(IList<Seguro> seguros);
    }
}
