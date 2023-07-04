
using System.ComponentModel;
using System.Diagnostics;

namespace iTin.Core.Models.Design;

/// <summary>
/// A Specialization of <see cref="RealDataType"/> class.<br/>.
/// Which acts as base class for the data types negative numbers with decimals .
/// </summary>
/// <remarks>
///   <para>
///   The following table shows the different numeric data field types.
///   </para>
///   <list type="table">
///     <listheader>
///       <term>Class</term>
///       <description>Description</description>
///     </listheader>
///     <item>
///       <term><see cref="NumberDataType"/></term>
///       <description>Represents number format, You can specify the number of decimal places that you want to use, whether you want to use a thousands separator, and how you want to display negative numbers.</description>
///     </item>
///     <item>
///       <term><see cref="CurrencyDataType"/></term>
///       <description>Represents currency format. The currency symbol appears right next to the first digit. You can specify the number of decimal places that you want to use and how you want to display negative numbers.</description>
///     </item>
///   </list>
/// </remarks>
public partial class NumericDataType
{
    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private Negative _negative;

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private NumericError _error;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference that contains numeric data type error settings.
    /// </summary>
    /// <value>
    /// Numeric data type error settings
    /// <para><strong><u>Examples</u></strong>:</para>
    /// <example>
    /// In the following example shows how create a new style with a currency data type.
    /// <code lang="xml">
    /// <![CDATA[
    /// <Currency Decimals="1" Locale="mk">
    ///   <Negative Color="Red" Sign="Parenthesis"/>
    ///   <Error Value="-1000">
    ///     <Comment Show="Yes">
    ///       <Text>Database value: </Text>
    ///       <Font Size="12" Color="Navy"/>
    ///     </Comment>
    ///   </Error>
    /// </Currency>
    /// ]]>
    /// </code>
    /// <para>Another example for the number data type.</para>
    /// <code lang="xml">
    /// <![CDATA[
    /// <Number Decimals="1">
    ///   <Negative Color="Red" Sign="Parenthesis"/>
    ///   <Error Value="99">
    ///     <Comment Show="Yes">
    ///       <Text>Wrong value: </Text>
    ///     </Comment>
    ///   </Error>
    /// </Number>
    /// ]]>
    /// </code>
    /// </example>
    /// </value>
    /// <remarks>
    /// <para><strong><u>Usage</u></strong>:</para>
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// <Number ...>
    ///   <Error/>
    ///   ...
    /// </Number>
    /// ]]>
    /// </code>
    /// <para>- Or -</para>
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// <Currency ...>
    ///   <Error/>
    ///   ...
    /// </Currency>
    /// ]]>
    /// </code>
    /// </remarks>
    public NumericError Error
    {
        get => _error ??= new NumericError();
        set => _error = value;
    }

    /// <summary>
    /// Gets or sets a reference that contains the negative number format.
    /// </summary>
    /// <value>
    /// Negative number format.
    /// <para><strong><u>Examples</u></strong>:</para>
    /// <example>
    /// In the following example shows how create a new style with a currency data type.
    /// <code lang="xml">
    /// <![CDATA[
    /// <Currency Decimals="1" Locale="mk">
    ///   <Negative Color="Red" Sign="Parenthesis">
    /// </Currency>
    /// ]]>
    /// </code>
    /// <para>Another example for the number data type.</para>
    /// <code lang="xml">
    /// <![CDATA[
    /// <Number Decimals="1">
    ///   <Negative Color="Green" Sign="Parenthesis">
    /// </Number>
    /// ]]>
    /// </code>
    /// </example>
    /// </value>
    /// <remarks>
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// <Number ...>
    ///   <Negative/>
    ///   ...
    /// </Number>
    /// ]]>
    /// </code>
    /// <para>- Or -</para>
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// <Currency ...>
    ///   <Negative/>
    ///   ...
    /// </Currency>
    /// ]]>
    /// </code>
    /// </remarks>
    public Negative Negative
    {
        get => _negative ??= new Negative();
        set => _negative = value;
    }

    #endregion

    #region public override readonly properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    [Browsable(false)]
    public override bool IsDefault =>
        base.IsDefault &&
        Error.IsDefault &&
        Negative.IsDefault;

    #endregion
}
