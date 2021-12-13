using SistemasSeguros.Domain.Aggregates.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasSeguros.Domain.Aggregates.Veiculos
{
    public class Veiculo: IVeiculo
    {
        public Veiculo(SeguroId seguroId, VeiculoId veiculoId, int valorDoVeiculo, string marca, string modelo)
        {
            this.SeguroId = seguroId;
            this.VeiculoId = veiculoId;
            this.ValorDoVeiculo = valorDoVeiculo;
            this.Marca = marca;
            this.Modelo = modelo;
        }

        public SeguroId SeguroId { get; }
        public VeiculoId VeiculoId { get; }
        public int ValorDoVeiculo { get; protected set; }
        public string Marca { get; protected set; }
        public string Modelo { get; protected set; }
        public Seguro? Seguro { get; set; }
    }
}
