using SistemasSeguros.Domain.Aggregates.Segurados;
using System.ComponentModel.DataAnnotations;

namespace SistemasSeguros.WebAPI.Application.ViewModel
{
    public class SeguradoModel
    {
        public SeguradoModel(Segurado segurado)
        {
            this.Nome = segurado.Nome;
            this.Cpf = segurado.Cpf;
            this.Idade = segurado.Idade;
        }

        [Required]
        public string Nome { get; }

        [Required]
        public string Cpf { get; }
        [Required]
        public int Idade { get; }
    }
}
