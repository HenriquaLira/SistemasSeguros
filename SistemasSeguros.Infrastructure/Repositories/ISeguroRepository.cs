using SistemasSeguros.Domain.Aggregates;
using SistemasSeguros.Domain.Aggregates.ValueObjects;
using SistemasSeguros.Domain.Aggregates.Veiculos;
using SistemasSeguros.Domain.Aggregates.Segurados;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemasSeguros.Infrastructure.Repositories
{
    public interface ISeguroRepository
    {
        Task Add(Seguro seguro, Segurado segurado, Veiculo veiculo);
        Task<ISeguro> GetSeguro(SeguroId segurotId);
        Task<IList<Seguro>> GetSeguros();
    }
}
