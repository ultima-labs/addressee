using JetBrains.Annotations;

namespace Addressee
{
    [PublicAPI]
    public static class AddresseeFormats
    {
        /// <summary>
        /// Addressee format for domestic purposes.
        /// </summary>
        public const string Domestic = "D";

        /// <summary>
        /// Addressee format for international purposes.
        /// </summary>
        public const string International = "I";

        /// <summary>
        /// Addressee multiline format for domestic purposes.
        /// </summary>
        public const string DomesticMultiline = "DM";

        /// <summary>
        /// Addressee multiline format for international purposes.
        /// </summary>
        public const string InternationalMultiline = "IM";
    }
}