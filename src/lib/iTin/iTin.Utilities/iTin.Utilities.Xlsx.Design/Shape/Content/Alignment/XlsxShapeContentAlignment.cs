
using iTin.Core.Models.Design.Content;
using iTin.Core.Models.Design.Enums;

namespace iTin.Utilities.Xlsx.Design.Shape;

/// <summary>
/// A Specialization of <see cref="ContentAlignment"/> class.<br/>
/// Defines a <b>xlsx</b> shape content alignment.
/// </summary>
public partial class XlsxShapeContentAlignment
{
    #region public new static properties

    /// <summary>
    /// Returns a new instance containing default shape content alignment style settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxShapeContentAlignment"/> reference containing the default shape content alignment settings.
    /// </value>
    public new static XlsxShapeContentAlignment Default => new();

    #endregion

    #region public new methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public new XlsxShapeContentAlignment Clone()
    {
        var cloned = (XlsxShapeContentAlignment)MemberwiseClone();
        cloned.Properties = Properties.Clone();

        return cloned;
    }

    #endregion

    #region public virtual methods

    /// <summary>
    /// Apply specified options to this content.
    /// </summary>
    public virtual void ApplyOptions(XlsxShapeContentAlignmentOptions options)
    {
        if (options == null)
        {
            return;
        }

        if (options.IsDefault)
        {
            return;
        }

        #region Horizontal
        KnownHorizontalAlignment? horizontalOption = options.Horizontal;
        bool horizontalHasValue = horizontalOption.HasValue;
        if (horizontalHasValue)
        {
            Horizontal = horizontalOption.Value;
        }
        #endregion
    }
    #endregion

    #region [public] {virtual} (void) Combine(XlsxShapeContentAlignment): Combines this instance with reference parameter
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference style</param>
    public virtual void Combine(XlsxShapeContentAlignment reference)
    {
        if (reference == null)
        {
            return;
        }

        base.Combine(reference);
    }

    #endregion
}
