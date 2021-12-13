using SistemasSeguros.Domain.Aggregates.Segurados;
using SistemasSeguros.Domain.Aggregates.ValueObjects;
using SistemasSeguros.Domain.Aggregates.Veiculos;

namespace SistemasSeguros.Domain.Aggregates
{
    public class Seguro: ISeguro
    {

        public Seguro(SeguroId seguroId)
        {
            this.SeguroId = seguroId;
        }

        public SeguroId SeguroId { get; }

        public Veiculo Veiculo { get; }

        public Segurado Segurado { get; }

        public static decimal MargemSeguranca { get; set; } = 0.03M;

        public static decimal Lucro { get; set; } = 0.05M;

        public decimal TaxaRisco { get; private set; }
        public decimal PremioRisco { get; private set; }
        public decimal PremioPuro { get; private set; }
        public decimal PremioComercial { get; private set; }

        public decimal CalculaValorSeguro(int valorVeiculo)
        {
            this.TaxaRisco = decimal.Round((valorVeiculo * 5), 2) / decimal.Round((2 * valorVeiculo), 2);
            this.PremioRisco = decimal.Round((this.TaxaRisco/100) * valorVeiculo, 2);
            this.PremioPuro = decimal.Round(this.PremioRisco * (1 + Seguro.MargemSeguranca),2);
            this.PremioComercial = decimal.Round((1 + Seguro.Lucro) * this.PremioPuro,2);

            return this.PremioComercial;
        }
    }
}
