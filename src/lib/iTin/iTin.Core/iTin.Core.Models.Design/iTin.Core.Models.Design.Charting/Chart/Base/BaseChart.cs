
using System.Diagnostics;
using System.Linq;
using System.IO;

using iTin.Core.Models.Design.Enums;

namespace iTin.Core.Models.Design.Charting;

/// <summary>
/// A Specialization of <see cref="IChart"/> interface.<br/>
/// Defines a generic chart.
/// </summary>
public partial class BaseChart
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShow = YesNo.Yes;

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _show;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseChart"/> class.
    /// </summary>
    protected BaseChart()
    {
        Show = DefaultShow;
    }

    #endregion

    #region public static properties

    /// <summary>
    /// Gets a default chart.
    /// </summary>
    /// <value>
    /// A default chart.
    /// </value>
    public static BaseChart Default => new();

    #endregion

    #region public static methods

    /// <summary>
    /// Returns a random graph name.
    /// </summary>
    /// <returns>
    /// A new graph name.
    /// </returns>
    public static string GenerateRandomChartName() => 
        Path.ChangeExtension(IO.File.GetUniqueTempRandomFile().Segments.Last(), string.Empty)
            .Replace(".", string.Empty);

    #endregion

    #region internal methods

    /// <summary>
    /// Sets the element that owns this <see cref="IChart"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    internal void SetOwner(ICharts reference)
    {
        Owner = reference;
    }

    #endregion
}
