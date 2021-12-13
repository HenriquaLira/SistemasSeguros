using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Application.Command
{
    public class VeiculoCommand
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int ValorDoVeiculo { get; set; }
    }
}
