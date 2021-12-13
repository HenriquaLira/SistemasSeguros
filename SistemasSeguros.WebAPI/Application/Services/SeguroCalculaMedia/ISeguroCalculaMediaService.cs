using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Application.Services.SeguroCalculaMedia
{
    public interface ISeguroCalculaMediaService
    {
        Task Execute();

        void SetOutputPort(IOutputPort outputPort);
    }
}
