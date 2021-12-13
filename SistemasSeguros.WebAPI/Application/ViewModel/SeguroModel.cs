using SistemasSeguros.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Application.ViewModel
{
    public class SeguroModel
    {
        public SeguroModel(Seguro seguro)
        {
            this.SeguroId = seguro.SeguroId.Id;
            this.TaxaRisco = seguro.TaxaRisco;
            this.PremioRisco = seguro.PremioRisco;
            this.PremioPuro = seguro.PremioPuro;
            this.PremioComercial = seguro.PremioComercial;
        }

        [Required]
        public string SeguroId { get; }

        [Required]
        public decimal TaxaRisco { get; }

        [Required]
        public decimal PremioRisco { get; }

        [Required]
        public decimal PremioPuro { get; }

        [Required]
        public decimal PremioComercial { get; }
    }
}
