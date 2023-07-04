
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Collections;

using iTin.Utilities.Xlsx.Design.Shared;

namespace iTin.Utilities.Xlsx.Design.Charts;

/// <summary>
/// Defines plots collection settings. Allows to set the chart plot.
/// </summary>
public partial class XlsxChartPlotsCollection : ICloneable
{
    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxBorder _border;

    #endregion

    #region constructor/s

    /// <inheritdoc />
    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxChartPlotsCollection"/> class.
    /// </summary>
    public XlsxChartPlotsCollection() : base(null)
    {
    }

    /// <inheritdoc />
    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxChartPlotsCollection"/> class.
    /// </summary>
    /// <param name="parent">The parent.</param>
    public XlsxChartPlotsCollection(XlsxChart parent) : base(parent)
    {
    }

    #endregion

    #region interfaces

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

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets a value that tells the serializer if the referenced item is to be included.
    /// </summary>
    /// <value>
    /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [Browsable(false)]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public bool BorderSpecified => !Border.IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference that contains the visual setting for common border of plots.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxBorder"/> reference that contains the visual setting for border of plots.
    /// </value>
    [XmlElement]
    [JsonProperty("border")]
    public XlsxBorder Border
    {
        get => _border ??= XlsxBorder.Default;
        set => _border = value;
    }

    #endregion

    #region protected override methods

    /// <summary>
    /// Returns the element specified.
    /// </summary>
    /// <param name="value">The object to locate in the <see cref="BaseComplexModelCollection{TItem,TParent,TSearch}"/>.</param>
    /// <returns>
    /// Returns the specified element.
    /// </returns>
    public override XlsxChartPlot GetBy(string value) => Find(plot => plot.Name.Equals(value, StringComparison.OrdinalIgnoreCase));

    /// <inheritdoc/>
    /// <summary>
    /// Sets this collection as the owner of the specified item.
    /// </summary>
    /// <param name="item">Target item to set owner.</param>
    protected override void SetOwner(XlsxChartPlot item)
    {
        SentinelHelper.ArgumentNull(item, nameof(item));

        item.SetOwner(this);
    }

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxChartPlotsCollection Clone()
    {
        var cloned = new XlsxChartPlotsCollection(Parent)
        {
            Properties = Properties.Clone()
        };

        foreach (var plot in this)
        {
            cloned.Add(plot.Clone());
        }

        return cloned;
    }

    #endregion

    #region public virtual methods

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxChartPlotsCollection reference)
    {
        if (reference == null)
        {
            return;
        }

        var hasElements = this.Any();
        if (!hasElements)
        {
            foreach (var referencePlot in reference)
            {
                var sheet = referencePlot.Clone();
                sheet.SetOwner(this);
                Add(sheet);
            }
        }
        else
        {
            foreach (var plot in this)
            {
                var refPlot = reference.GetBy(plot.Name);
                if (refPlot != null)
                {
                    plot.Combine(refPlot);
                }
            }

            foreach (var referencePlot in reference)
            {
                var plot = GetBy(referencePlot.Name);
                if (plot != null)
                {
                    continue;
                }

                var newPlot = referencePlot.Clone();
                newPlot.SetOwner(this);
                Add(newPlot);
            }
        }
    }

    #endregion
}
