using SistemasSeguros.Domain.Aggregates.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemasSeguros.Domain.Aggregates.Segurados
{
    public interface ISegurado
    {
        SeguroId SeguroId { get; }
        SeguradoId SeguradoId { get; }

    }
}
