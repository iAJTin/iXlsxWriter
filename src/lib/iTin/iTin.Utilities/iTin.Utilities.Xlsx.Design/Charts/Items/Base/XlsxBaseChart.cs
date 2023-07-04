
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;

using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Charting;
using iTin.Core.Models.Design.Enums;

using iTinIO = iTin.Core.IO;

namespace iTin.Utilities.Xlsx.Design.Charts;

/// <summary>
/// A Specialization of <see cref="IXlsxChart"/> interface.<br/>
/// Defines a generic <b>xlsx</b> chart.
/// </summary>
public partial class XlsxBaseChart : IXlsxChart, ICombinable<XlsxBaseChart>
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
    /// Initializes a new instance of the <see cref="XlsxBaseChart"/> class.
    /// </summary>
    protected XlsxBaseChart()
    {
        Show = DefaultShow;
        Name = string.Empty;
    }

    #endregion

    #region interfaces

    #region IChart

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    bool IChart.IsDefault => IsDefault;

    /// <summary>
    /// Gets the element that owns this <see cref="IChart"/>.
    /// </summary>
    /// <value>
    /// The <see cref="ICharts"/> that owns this <see cref="IChart"/>.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    ICharts IChart.Owner => Owner;

    /// <summary>
    /// Gets or sets the name of the chart.
    /// </summary>
    /// <value>
    /// The name of the chart.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    string IChart.Name { get => Name; set => Name = value; }

    /// <summary>
    /// Gets or sets a value that determines whether to display the chart. The default is <see cref="YesNo.Yes"/>.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes"/> if display the chart; otherwise, <see cref="YesNo.No"/>.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    YesNo IChart.Show { get => Show; set => Show = value; }

    /// <summary>
    /// Sets the element that owns this <see cref="IChart"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    void IChart.SetOwner(ICharts reference) => SetOwner((IXlsxCharts)reference);

    #endregion

    #region ICloneable

    /// <inheritdoc />
    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    object ICloneable.Clone() => Clone();

    #endregion

    #region IXlsxChart

    /// <summary>
    /// Gets the element that owns this <see cref="IXlsxChart"/>.
    /// </summary>
    /// <value>
    /// The <see cref="IXlsxCharts"/> that owns this <see cref="IXlsxChart"/>.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    IXlsxCharts IXlsxChart.Owner => Owner;
    /// <summary>
    /// Sets the element that owns this <see cref="IXlsxChart"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    void IXlsxChart.SetOwner(IXlsxCharts reference) => SetOwner(reference);

    #endregion

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets the element that owns this <see cref="IXlsxChart"/>.
    /// </summary>
    /// <value>
    /// The <see cref="IXlsxCharts"/> that owns this <see cref="IXlsxChart"/>.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [Browsable(false)]
    public IXlsxCharts Owner { get; private set; }

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the name of the chart.
    /// </summary>
    /// <value>
    /// The name of the chart.
    /// </value>
    [XmlAttribute]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a value that determines whether to display the chart. The default is <see cref="YesNo.Yes"/>.
    /// </summary>
    /// <value>
    /// <see cref="YesNo.Yes"/> if display the chart; otherwise, <see cref="YesNo.No"/>.
    /// </value>
    [XmlAttribute]
    [DefaultValue(DefaultShow)]
    public YesNo Show
    {
        get => _show;
        set
        {
            SentinelHelper.IsEnumValid(value);
            _show = value;
        }
    }

    #endregion

    #region public override properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault => base.IsDefault && Show.Equals(DefaultShow);

    #endregion

    #region ICombinable<IChart>

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    void ICombinable<IChart>.Combine(IChart reference) => Combine((XlsxBaseChart)reference);

    #endregion

    #region ICombinable<IXlsxChart>

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    void ICombinable<IXlsxChart>.Combine(IXlsxChart reference) => Combine((XlsxBaseChart)reference);

    #endregion

    #region public static properties

    /// <summary>
    /// Gets a default chart.
    /// </summary>
    /// <value>
    /// A default chart.
    /// </value>
    public static XlsxBaseChart Default => new();

    #endregion

    #region public static methods

    /// <summary>
    /// Returns a random graph name.
    /// </summary>
    /// <returns>
    /// A new graph name.
    /// </returns>
    public static string GenerateRandomChartName() 
        => System.IO.Path.ChangeExtension(iTinIO.File.GetUniqueTempRandomFile().Segments.Last(), string.Empty).Replace(".", string.Empty);

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxBaseChart Clone()
    {
        var cloned = (XlsxBaseChart)MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }

    #endregion

    #region public virtual methods

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    public virtual void Combine(XlsxBaseChart reference)
    {
        if (reference == null)
        {
            return;
        }

        if (string.IsNullOrEmpty(Name))
        {
            throw new NullReferenceException("Primero asignar un nombre al gráfico antes de combinar");
        }

        //Borders.Combine(reference.Borders);
        //Content.Combine(reference.Content);
    }

    #endregion

    #region internal methods

    /// <summary>
    /// Sets the element that owns this <see cref="IXlsxChart"/>.
    /// </summary>
    /// <param name="reference">Reference to owner.</param>
    internal void SetOwner(IXlsxCharts reference)
    {
        Owner = reference;
    }

    #endregion
}
