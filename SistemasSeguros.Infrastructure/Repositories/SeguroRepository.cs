using Microsoft.EntityFrameworkCore;
using SistemasSeguros.Domain.Aggregates;
using SistemasSeguros.Domain.Aggregates.Veiculos;
using SistemasSeguros.Domain.Aggregates.Segurados;
using SistemasSeguros.Domain.Aggregates.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasSeguros.Infrastructure.Repositories
{
    public class SeguroRepository : ISeguroRepository
    {
        private readonly SisSeguroContext _context;

        public SeguroRepository(SisSeguroContext context) => this._context = context ??
                                                                      throw new ArgumentNullException(
                                                                          nameof(context));

        public async Task Add(Seguro seguro, Segurado segurado, Veiculo veiculo)
        {
            await this._context
                .Seguros
                .AddAsync(seguro)
                .ConfigureAwait(false);

            await this._context
                .Segurados
                .AddAsync(segurado)
                .ConfigureAwait(false);

            await this._context
                .Veiculos
                .AddAsync(veiculo)
                .ConfigureAwait(false);
        }

        public async Task<ISeguro> GetSeguro(SeguroId segurotId)
        {
            Seguro? seguro = await this._context
                .Seguros
                .Where(e => e.SeguroId == segurotId)
                .Select(e => e)
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            if (seguro is Seguro findSeguro)
            {
                await this.LoadTransactions(findSeguro)
                    .ConfigureAwait(false);

                return seguro;
            }

            return null;
        }

        public async Task<IList<Seguro>> GetSeguros()
        {
            List<Seguro> seguros = await this._context
                .Seguros
                .ToListAsync()
                .ConfigureAwait(false);

            foreach (Seguro findSeguro in seguros)
            {
                await this.LoadTransactions(findSeguro)
                    .ConfigureAwait(false);
            }

            return seguros;
        }

        private async Task LoadTransactions(Seguro seguro)
        {
            await this._context
                .Segurados
                .Where(e => e.SeguroId.Equals(seguro.SeguroId))
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            await this._context
                .Veiculos
                .Where(e => e.SeguroId.Equals(seguro.SeguroId))
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);
        }
    }
}
