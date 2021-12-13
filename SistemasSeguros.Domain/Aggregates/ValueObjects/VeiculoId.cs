using System;
using System.Collections.Generic;
using System.Text;

namespace SistemasSeguros.Domain.Aggregates.ValueObjects
{
    public readonly struct VeiculoId : IEquatable<VeiculoId>
    {
        public string Id { get; }

        public VeiculoId(string id) =>
            this.Id = id;

        public override bool Equals(object? obj) =>
            obj is SeguradoId o && this.Equals(o);

        public bool Equals(VeiculoId other) => this.Id == other.Id;

        public override int GetHashCode() =>
            HashCode.Combine(this.Id);

        public static bool operator ==(VeiculoId left, VeiculoId right) => left.Equals(right);

        public static bool operator !=(VeiculoId left, VeiculoId right) => !(left == right);

        public override string ToString() => this.Id.ToString();
    }
}
