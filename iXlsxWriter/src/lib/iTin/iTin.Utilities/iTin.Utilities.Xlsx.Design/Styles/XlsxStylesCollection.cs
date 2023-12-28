
using System;

using iTin.Core.Helpers;

using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Styles;

/// <summary>
/// Defines a styles collection.
/// </summary>
public partial class XlsxStylesCollection : IXlsxStyles
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxStylesCollection"/> class.
    /// </summary>
    public XlsxStylesCollection() : base(null)
    {
    }

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
