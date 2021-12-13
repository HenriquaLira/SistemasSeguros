using SistemasSeguros.WebAPI.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasSeguros.WebAPI.Application.Responses
{
    public class SeguroCriarResponse
    {
        public SeguroCriarResponse(SeguroModel seguroModel) => this.Seguro = seguroModel;

        [Required]
        public SeguroModel Seguro { get; }
    }
}
