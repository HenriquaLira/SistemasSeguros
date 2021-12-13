using SistemasSeguros.Domain.Aggregates.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasSeguros.Domain.Aggregates.Segurados
{
    public class Segurado : ISegurado
    {
        public Segurado(SeguroId seguroId, SeguradoId seguradoId, string nome, int idade, string cpf)
        {
            this.SeguroId = seguroId;
            this.SeguradoId = seguradoId;
            this.Nome = nome;
            this.Idade = idade;
            this.Cpf = cpf;
        }

        public SeguroId SeguroId { get; }
        public SeguradoId SeguradoId { get; }
        public Seguro? Seguro { get; set; }
        public string Nome { get;  set; }
        public int Idade { get;  set; }
        public string Cpf { get; set; }
    }
}
