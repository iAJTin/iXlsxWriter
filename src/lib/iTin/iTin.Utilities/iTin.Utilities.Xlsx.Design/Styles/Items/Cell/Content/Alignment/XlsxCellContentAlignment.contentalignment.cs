
namespace iTin.Utilities.Xlsx.Design.Styles;

public partial class XlsxCellContentAlignment
{
    #region public new static properties

    /// <summary>
    /// Returns a new instance containing default cell content alignment style settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxCellContentAlignment"/> reference containing the default content alignment settings.
    /// </value>
    public new static XlsxCellContentAlignment Default => new();

    #endregion

    #region public override readonly properties

    /// <inheritdoc />
    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault => base.IsDefault && Vertical.Equals(DefaultVerticalAlignment);

    #endregion
}
