using SistemasSeguros.Domain.Aggregates;
using SistemasSeguros.WebAPI.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Application.Responses
{
    public class SeguroCalculaMediaResponse
    {
        public SeguroCalculaMediaResponse(IEnumerable<Seguro> seguros)
        {
            this.MediaSeguros = CalculaMediaAritmetica(seguros);
            this.Quantidade = seguros.Count();

            foreach (Seguro seguro in seguros)
            {
                SegurosDetalhesModel seguroDetalhesModel = new SegurosDetalhesModel(seguro);
                this.Seguros.Add(seguroDetalhesModel);
            }
        }


        [Required]
        public decimal MediaSeguros { get; }

        [Required]
        public int Quantidade { get; }

        [Required]
        public List<SegurosDetalhesModel> Seguros { get; } = new List<SegurosDetalhesModel>();


        private decimal CalculaMediaAritmetica(IEnumerable<Seguro> seguros)
        {
            return seguros.Count() > 0 ? seguros.Sum(x => x.PremioComercial) / seguros.Count() : 0;
        }
    }
}
