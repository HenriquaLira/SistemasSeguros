using SistemasSeguros.Domain.Aggregates.Veiculos;
using System.ComponentModel.DataAnnotations;

namespace SistemasSeguros.WebAPI.Application.ViewModel
{
    public class VeiculoModel
    {
        public VeiculoModel(Veiculo veiculo)
        {
            this.Marca = veiculo.Marca;
            this.Modelo = veiculo.Modelo;
            this.ValorDoVeiculo = veiculo.ValorDoVeiculo;
        }

        [Required]
        public string Marca { get; }

        [Required]
        public string Modelo { get; }
        [Required]
        public int ValorDoVeiculo { get; }
    }
}
