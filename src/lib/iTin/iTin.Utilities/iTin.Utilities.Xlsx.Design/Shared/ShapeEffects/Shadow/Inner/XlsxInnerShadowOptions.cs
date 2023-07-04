
using System;

namespace iTin.Utilities.Xlsx.Design.Shared;

/// <summary>
/// A Specialization of <see cref="XlsxBaseShadowOptions"/> class.<br/>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxInnerShadow"/> instance.
/// </summary>
[Serializable]
public class XlsxInnerShadowOptions : XlsxBaseShadowOptions, ICloneable
{
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

    #region public static properties

    /// <summary>
    /// Gets a reference that contains the set of available settings to model an existing <see cref="XlsxInnerShadow"/> instance.
    /// </summary>
    /// <value>
    /// Set of default options.
    /// </value>
    public new static XlsxInnerShadowOptions Default => new XlsxInnerShadowOptions();

    #endregion

    #region public new methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxInnerShadowOptions Clone() => (XlsxInnerShadowOptions)MemberwiseClone();

    #endregion
}
