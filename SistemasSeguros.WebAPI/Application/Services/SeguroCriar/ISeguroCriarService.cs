using SistemasSeguros.WebAPI.Application.Command;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Application.Services.SeguroCriar
{
    public interface ISeguroCriarService
    {
        Task Execute(SeguroCommand command);
        void SetOutputPort(IOutputPort outputPort);
    }
}
