
using System.Threading.Tasks;

namespace SistemasSeguros.Infrastructure
{
    public interface IUnitOfWork
    {
        Task<int> Save();
    }
}
