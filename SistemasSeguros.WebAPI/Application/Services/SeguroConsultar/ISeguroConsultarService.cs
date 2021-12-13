using SistemasSeguros.WebAPI.Application.Command;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Application.Services.SeguroConsultar
{
    public interface ISeguroConsultarService
    {
        Task Execute(string id);
        void SetOutputPort(IOutputPort outputPort);
    }
}
