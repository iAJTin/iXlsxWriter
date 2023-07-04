
using System;

using iTin.Core.Helpers;

using iTin.Core.Models.Collections;
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// Defines a styles collection.
/// </summary>
public partial class XlsxStylesCollection : IXlsxStyles
{
    #region constructor/s

    /// <inheritdoc/>
    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxStylesCollection"/> class.
    /// </summary>
    public XlsxStylesCollection() : base(null)
    {
    }

    /// <inheritdoc/>
    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxStylesCollection"/> class.
    /// </summary>
    /// <param name="parent">The parent.</param>
    public XlsxStylesCollection(object parent) : base(parent)
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

    #region IStyles

    /// <summary>
    /// Returns specified style by name.
    /// </summary>
    /// <param name="value">Style name to get</param>
    /// <returns>
    /// A <see cref="IStyle"/> reference.
    /// </returns>
    IStyle IStyles.GetBy(string value) => GetBy(value);

    #endregion

    #region IXlsxStyles

    /// <summary>
    /// Returns specified style by name.
    /// </summary>
    /// <param name="value">Style name to get</param>
    /// <returns>
    /// A <see cref="IStyle"/> reference.
    /// </returns>
    IXlsxStyle IXlsxStyles.GetBy(string value) => GetBy(value);

    #endregion

    #endregion

    #region protected override methods

    /// <inheritdoc />
    /// <summary>
    /// Returns the element specified.
    /// </summary>
    /// <param name="value">The object to locate in the <see cref="BaseComplexModelCollection{TItem,TParent,TSearch}"/>.</param>
    /// <returns>
    /// Returns the specified element.
    /// </returns>
    public override XlsxBaseStyle GetBy(string value) 
    {
        if (string.IsNullOrEmpty(value))
        {
            return XlsxBaseStyle.Default;
        }

        var style = Find(s => s.Name.Equals(value));

        return style ?? XlsxBaseStyle.Default;
    }

    /// <inheritdoc />
    /// <summary>
    /// Sets this collection as the owner of the specified item.
    /// </summary>
    /// <param name="item">Target item to set owner.</param>
    protected override void SetOwner(XlsxBaseStyle item)
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
    public XlsxStylesCollection Clone() => CopierHelper.DeepCopy(this);

    #endregion
}
