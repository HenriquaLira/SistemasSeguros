using SistemasSeguros.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Application.ViewModel
{
    public class SegurosDetalhesModel
    {
        public SegurosDetalhesModel(Seguro seguro)
        {
            this.SeguroId = seguro.SeguroId.Id;
            this.PremioComercial = seguro.PremioComercial;
            this.Veiculo = new VeiculoModel(seguro.Veiculo);
            this.Segurado = new SeguradoModel(seguro.Segurado);
        }


        [Required]
        public String SeguroId { get; }

        [Required]
        public decimal PremioComercial { get; }

        [Required]
        public VeiculoModel Veiculo { get; }

        [Required]
        public SeguradoModel Segurado { get; }
    }
}
