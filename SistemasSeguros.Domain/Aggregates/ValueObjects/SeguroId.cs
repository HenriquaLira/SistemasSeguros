using System;
using System.Collections.Generic;
using System.Text;

namespace SistemasSeguros.Domain.Aggregates.ValueObjects
{
    public readonly struct SeguroId : IEquatable<SeguroId>
    {
        public string Id { get; }

        public SeguroId(string id) =>
            this.Id = id;

        public override bool Equals(object? obj) =>
            obj is SeguroId o && this.Equals(o);

        public bool Equals(SeguroId other) => this.Id == other.Id;

        public override int GetHashCode() =>
            HashCode.Combine(this.Id);

        public static bool operator ==(SeguroId left, SeguroId right) => left.Equals(right);

        public static bool operator !=(SeguroId left, SeguroId right) => !(left == right);

        public override string ToString() => this.Id.ToString();
    }
}
