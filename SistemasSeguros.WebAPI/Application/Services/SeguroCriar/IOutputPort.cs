using SistemasSeguros.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Application.Services.SeguroCriar
{
    public interface IOutputPort
    {
        void Ok(Seguro seguro);

        /// <summary>
        ///     Resource not found.
        /// </summary>
        void NotFound();

        /// <summary>
        ///     Invalid input.
        /// </summary>
        void Invalid();
    }
}
