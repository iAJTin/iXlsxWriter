
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iTin.Core.Models.Design;

/// <summary>
/// A Specialization of <see cref="BaseError"/> class.<br/>
/// Represents the error structure for datetime data type. Allows us to set a default value and an additional comment.
/// </summary>
/// <remarks>
/// <para>Belongs to: <strong><c>DateTime</c></strong>. For more information, please see <see cref="DateTimeDataType"/>.</para>
/// <para><u><strong>Usage</strong></u></para>
/// <code lang="xml" title="ITEE Object Element Usage">
/// <![CDATA[
/// <Error ...>
///   <Comment/>
/// </Error>
/// ]]>
/// </code>
/// <para><strong><u>Attributes</u></strong></para>
/// <table>
///   <thead>
///     <tr>
///       <th>Attribute</th>
///       <th>Optional</th>
///       <th>Description</th>
///       </tr>
///   </thead>
///   <tbody>
///     <tr>
///       <td><see cref="Value"/></td>
///       <td align="center">Yes</td>
///       <td>Preferred default value when occurs an error. The default is "<c>MinValue</c>".</td>
///     </tr>
///   </tbody>
/// </table>
/// <para><strong><u>Elements</u></strong></para>
/// <list type="table">
///   <listheader>
///     <term>Element</term>
///     <description>Description</description>
///   </listheader>
///   <item>
///     <term><see cref="BaseError.Comment"/></term> 
///     <description>Reference for error comment. Includes comment text, format, including font face, size, and style attributes.</description>
///   </item>
/// </list>
/// <para><strong><u>Examples</u></strong></para>
/// <example>
/// In the following example shows how create a new datetime data type with error.
/// <code lang="xml">
/// <![CDATA[
/// <DateTime Format="Year-Month" Locale="en-US">
///   <Error Value="Today">
///     <Comment Show="Yes">
///       <Font Name="Comic Sans MS" Size="16" Bold="Yes" Italic="Yes" Underline="Yes"/>
///     </Comment>
///    </Error>
///  </DateTime>
/// </Style>
/// ]]>
/// </code>
/// </example>    
/// </remarks>
public partial class DateTimeError
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string DefaultValue = "MinValue";

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string _value;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="DateTimeError"/> class.
    /// </summary>
    public DateTimeError()
    {
        Value = DefaultValue;
    }

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets a value that represent the date time value.
    /// </summary>
    /// <value>
    /// A <see cref="DateTime"/> that represent the date time value.
    /// </value>
    public DateTime DateTimeValue
    {
        get
        {
            DateTime value;

            switch (Value)
            {
                case "MinValue":
                    value = new DateTime(1900, 1, 1);
                    break;

                case "MaxValue":
                    value = DateTime.MaxValue;
                    break;

                case "Today":
                    value = DateTime.Today;
                    break;

                default:
                    var isValid = DateTime.TryParse(Value, out value);
                    if (!isValid)
                    {
                        value = new DateTime(1900, 1, 1);
                    }                            
                    break;
            }

            return value;
        }
    }

    #endregion
        
    #region public properties

    /// <summary>
    /// Gets or sets preferred default value when occurs an error.
    /// </summary>
    /// <value>
    /// Preferred default value when occurs an error. The default is "<c>MinValue</c>".
    /// <para><strong><u>Examples</u></strong></para>
    /// <example>
    /// In the following example shows how create a new datetime data type with error.
    /// <code lang="xml">
    /// <![CDATA[
    /// <DateTime Format="Year-Month" Locale="en-US">
    ///   <Error Value="Today">
    ///     <Comment Show="Yes">
    ///       <Font Name="Comic Sans MS" Size="16" Bold="Yes" Italic="Yes" Underline="Yes"/>
    ///     </Comment>
    ///   </Error>
    /// </DateTime>
    /// ]]>
    /// </code>
    /// </example>
    /// </value>
    /// <remarks>
    /// <para><u><strong>Usage</strong></u></para>
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// <Error Value="string" ...>
    ///   ...
    /// </Error&gt;
    /// ]]>
    /// </code>
    /// <para>
    /// <c>ITEE</c> recognizes the following strings as valid values:
    /// <list type="table">
    ///   <listheader>
    ///     <term>Value</term>
    ///     <description>Description</description>
    ///   </listheader>
    ///   <item>
    ///     <term>MinValue</term> 
    ///     <description>Represents date '01/01/1900'.</description>
    ///   </item>
    ///   <item>
    ///     <term>MaxValue</term> 
    ///     <description>Represents maximum system date.</description>
    ///   </item>
    ///   <item>
    ///     <term>Today</term> 
    ///     <description>Represents today date.</description>
    ///   </item>
    ///   <item>
    ///     <term>Other value</term> 
    ///     <description>Defined by user. If the value is not correct will used <string><c>MinValue</c></string>.</description>
    ///   </item>
    /// </list>
    /// </para>
    /// </remarks>
    [XmlAttribute]
    [DefaultValue(DefaultValue)]
    public string Value
    {
        get => _value;
        set => _value = value;
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
        Value.Equals(DefaultValue);

    #endregion
}
