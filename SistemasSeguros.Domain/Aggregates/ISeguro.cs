using SistemasSeguros.Domain.Aggregates.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemasSeguros.Domain.Aggregates
{
    public interface ISeguro
    {
        SeguroId SeguroId { get; }
        decimal CalculaValorSeguro(int valorVeiculo);
    }
}
