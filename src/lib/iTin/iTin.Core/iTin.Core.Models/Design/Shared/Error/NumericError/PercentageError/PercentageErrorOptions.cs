
using System;

namespace iTin.Core.Models.Design.Options;

/// <summary>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="PercentageError"/> instance.
/// </summary>
[Serializable]
public partial class PercentageErrorOptions : NumericErrorOptions
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="NumericErrorOptions"/> class.
    /// </summary>
    public PercentageErrorOptions()
    {
    }

    #endregion

    #region public new static properties

    /// <summary>
    /// Gets a reference that contains the set of available settings to model an existing <see cref="PercentageError"/> instance.
    /// </summary>
    /// <value>
    /// Set of default options.
    /// </value>
    public new static PercentageErrorOptions Default => new();

    #endregion
}