using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Application.Command
{
    public class SeguroCommand
    {
        public VeiculoCommand Veiculo { get; set; }
        public SeguradoCommand Segurado { get; set; }
    }
}
