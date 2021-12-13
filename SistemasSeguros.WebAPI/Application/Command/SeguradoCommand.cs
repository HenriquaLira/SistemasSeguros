using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Application.Command
{
    public class SeguradoCommand
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int Idade { get; set; }
    }
}
