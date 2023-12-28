
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Utilities.Xlsx.Design.Shared;

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
public partial class XlsxBaseRange
{
    #region public readonly properties

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

            return addressType switch
            {
                nameof(XlsxPointRange) => KnownRangeType.Point,
                nameof(XlsxStringRange) => KnownRangeType.String,
                nameof(XlsxRange) => KnownRangeType.Range,
                _ => KnownRangeType.Point
            };
        }
    }

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

        var str = string.Empty;

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
