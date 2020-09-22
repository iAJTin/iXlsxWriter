
namespace iTin.Utilities.Xlsx.Design.Shared
{
    using System;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    /// <summary>
    /// Base class for different address definition types supported.<br />
    /// Which acts as the base class for different address types.
    /// </summary>
    /// <remarks>
    ///   <para>The following table shows different address types.</para>
    ///   <list type="table">
    ///     <listheader>
    ///       <term>Class</term>
    ///       <description>Description</description>
    ///     </listheader>
    ///     <item>
    ///       <term><see cref="XlsxRange"/></term>
    ///       <description>Represents a range of cells by row and column values</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref="XlsxPointRange"/></term>
    ///       <description>Represents a cell by row and column values</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref="XlsxStringRange"/></term>
    ///       <description>Represents a Excel cells range by alphaNumeric representation. Ex. "A1:B2", "A1", "$B$3:$F$33".</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class XlsxBaseRange : ICloneable
    {
        #region interfaces

        #region ICloneable

        #region explicit

        #region (object) ICloneable.Clone(): Creates a new object that is a copy of the current instance
        /// <inheritdoc />
        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone() => Clone();
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly properties

        #region [public] (KnownRangeType) Type: Gets a value indicating range type
        /// <summary>
        /// Gets a value indicating range type.
        /// </summary>
        /// <value>
        /// One of the <see cref="KnownRangeType"/> values.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        public KnownRangeType Type
        {
            get
            {
                var addressType = GetType().Name;
                switch (addressType)
                {
                    case "XlsxPointRange":
                        return KnownRangeType.Point;

                    case "XlsxStringRange":
                        return KnownRangeType.String;

                    case "XlsxRange":
                        return KnownRangeType.Range;
                    
                    default:
                        return KnownRangeType.Point;
                }
            }
        }
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxBaseRange) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxBaseRange Clone() => (XlsxBaseRange) MemberwiseClone();
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(XlsxBaseRange): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference content</param>
        public virtual void Combine(XlsxBaseRange reference)
        {
        }
        #endregion

        #endregion

        #region internal static methods. (Code from ExcelCellBase)

        /// <summary>
        /// Returns the character representation of the numbered column
        /// </summary>
        /// <param name="iColumnNumber">The number of the column</param>
        /// <returns>
        /// The letter representing the column
        /// </returns>
        internal static string GetColumnLetter(int iColumnNumber) => GetColumnLetter(iColumnNumber, false);

        internal static string GetColumnLetter(int iColumnNumber, bool fixedCol)
        {
            if (iColumnNumber < 1)
            {
                return "#REF!";
            }

            string str = string.Empty;

            do
            {
                str = $"{(char) (65 + (iColumnNumber - 1) % 26)}{str}";
                iColumnNumber = (iColumnNumber - (iColumnNumber - 1) % 26) / 26;
            }
            while (iColumnNumber > 0);

            return !fixedCol ? str : $"${str}";
        }

        #endregion
    }
}
