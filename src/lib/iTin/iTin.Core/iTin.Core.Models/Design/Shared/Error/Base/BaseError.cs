
using System.ComponentModel;
using System.Diagnostics;

namespace iTin.Core.Models.Design;

/// <summary>
/// Base class for different data types errors.
/// Which acts as the base class for the different data types errors.
/// </summary>
/// <remarks>
///   <para>
///   The following table shows the different data types errors.
///   </para>
///   <list type="table">
///     <listheader>
///       <term>Class</term>
///       <description>Description</description>
///     </listheader>
///     <item>
///       <term><see cref="NumericError"/></term>
///       <description>Reference for numeric data type error settings.</description>
///     </item>
///     <item>
///       <term><see cref="DateTimeError"/></term>
///       <description>Reference for datetime data type error settings.</description>
///     </item>
///   </list>
/// </remarks>
public partial class BaseError
{
    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private Comment _comment;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference that contains the error comment.
    /// </summary>
    /// <value>
    /// The error comment.
    /// <para><u><strong>Examples</strong></u></para>
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
    ///   <Negative Color="Red" Sign="Parenthesis">
    ///   <Error Value="99">
    ///     <Comment Show="Yes">
    ///       <Text>Wrong value: </Text>
    ///     </Comment>
    ///   </Error>
    /// </Currency>
    /// ]]>
    /// </code>
    /// </example>
    /// </value>
    /// <remarks>
    /// <para><u><strong>Usage</strong></u></para>
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// <Comment>
    ///   <Text/>
    ///   <Font/>
    /// </Comment>
    /// ]]>
    /// </code>
    /// </remarks>
    public Comment Comment
    {
        get => _comment ??= new Comment();
        set => _comment = value;
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
    public override bool IsDefault => Comment.IsDefault;

    #endregion
}
