
using System;

namespace iTin.Utilities.Xlsx.Design.Picture;

/// <summary>
/// Specifies the known scale strategy.
/// </summary>
[Serializable]
public enum ScaleStrategy
{
    /// <summary>
    /// Automatically determine escalation strategy
    /// </summary>
    Auto,

    /// <summary>
    /// Horizontal scaling
    /// </summary>
    Horizontal,

    /// <summary>
    /// Vertical scaling
    /// </summary>
    Vertical
}
