
using System;

namespace iTin.Core.Models.Design.Options;

/// <summary>
/// Defines a set of options that we can use to quickly adjust an existing <see cref="ScientificError"/> instance.
/// </summary>
[Serializable]
public partial class ScientificErrorOptions : NumericErrorOptions
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="ScientificErrorOptions"/> class.
    /// </summary>
    public ScientificErrorOptions()
    {
    }

    #endregion

    #region public new static properties

    /// <summary>
    /// Gets a reference that contains the set of available settings to model an existing <see cref="ScientificError"/> instance.
    /// </summary>
    /// <value>
    /// Set of default options.
    /// </value>
    public new static ScientificErrorOptions Default => new();

    #endregion
}