using System;
using JetBrains.Annotations;

namespace Addressee.AU
{
    [PublicAPI]
    //// TODO: serialization support
    public sealed class AustralianLocality : 
        IEquatable<AustralianLocality>,
        IComparable<AustralianLocality>,
        IFormattable
    {
        private static readonly StringComparer _comparer = StringComparer.CurrentCultureIgnoreCase;

        private readonly string _sanitized;

        public AustralianLocality([CanBeNull] string source)
        {
            _sanitized = source.TrimOrEmpty();
        }

        [Pure]
        public override string ToString() => ToString(null, null);

        [Pure]
        public string ToString([CanBeNull] string format, [CanBeNull] IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "L": return _sanitized.ToLower();
                case "U": return _sanitized.ToUpper();
                case "C": return _sanitized.ToCamel();
                case "G": return _sanitized;
                default: return _sanitized;
            }
        }

        [Pure]
        public override int GetHashCode() => _comparer.GetHashCode(_sanitized);

        [Pure]
        public override bool Equals([CanBeNull] object obj) => Equals(obj as AustralianLocality);

        [Pure]
        public bool Equals([CanBeNull] AustralianLocality other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _comparer.Equals(_sanitized, other._sanitized);
        }

        [Pure]
        public int CompareTo([CanBeNull] AustralianLocality other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return _comparer.Compare(_sanitized, other._sanitized);
        }

        [NotNull, Pure]
        public static explicit operator AustralianLocality([CanBeNull] string locality) => new AustralianLocality(locality);

        [CanBeNull, Pure]
        public static implicit operator string([CanBeNull] AustralianLocality locality) => locality?._sanitized;

        [Pure]
        public static bool operator ==([CanBeNull] AustralianLocality l, [CanBeNull] AustralianLocality r) => _comparer.Equals(l?._sanitized, r?._sanitized);

        [Pure]
        public static bool operator !=([CanBeNull] AustralianLocality l, [CanBeNull] AustralianLocality r) => !_comparer.Equals(l?._sanitized, r?._sanitized);

        [Pure]
        public static bool operator <([CanBeNull] AustralianLocality l, [CanBeNull] AustralianLocality r) => _comparer.Compare(l?._sanitized, r?._sanitized) < 0;

        [Pure]
        public static bool operator <=([CanBeNull] AustralianLocality l, [CanBeNull] AustralianLocality r) => _comparer.Compare(l?._sanitized, r?._sanitized) <= 0;

        [Pure]
        public static bool operator >([CanBeNull] AustralianLocality l, [CanBeNull] AustralianLocality r) => _comparer.Compare(l?._sanitized, r?._sanitized) > 0;

        [Pure]
        public static bool operator >=([CanBeNull] AustralianLocality l, [CanBeNull] AustralianLocality r) => _comparer.Compare(l?._sanitized, r?._sanitized) >= 0;
    }
}
