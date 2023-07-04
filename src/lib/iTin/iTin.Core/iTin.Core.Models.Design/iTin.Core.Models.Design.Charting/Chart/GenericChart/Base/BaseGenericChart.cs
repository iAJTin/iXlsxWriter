
using System.Diagnostics;

using iTin.Core.Models.Design.Enums;

namespace iTin.Core.Models.Design.Charting;

/// <summary>
/// A Specialization of <see cref="IGenericChart"/> interface.<br/>
/// Defines a generic chart.
/// </summary>
public partial class BaseGenericChart
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string DefaultBackColor = "White";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const YesNo DefaultShow = YesNo.Yes;

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private YesNo _show;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseGenericChart"/> class.
    /// </summary>
    protected BaseGenericChart()
    {
        Show = DefaultShow;
        BackColor = DefaultBackColor;
    }

    #endregion

    #region public static properties

    /// <summary>
    /// Gets a default generic chart.
    /// </summary>
    /// <value>
    /// A default generic chart.
    /// </value>
    public static BaseGenericChart Default => new();

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
