using SistemasSeguros.Domain.Aggregates.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemasSeguros.Domain.Aggregates.Veiculos
{
    public interface IVeiculo
    {
        SeguroId SeguroId { get; }
        VeiculoId VeiculoId { get; }
    }
}
