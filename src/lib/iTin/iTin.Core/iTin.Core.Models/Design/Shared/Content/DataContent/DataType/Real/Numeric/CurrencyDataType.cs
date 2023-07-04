
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Xml.Serialization;

namespace iTin.Core.Models.Design.Styling.Style.Content
{
    using Enums;

    /// <summary>
    /// A Specialization of <see cref="NumericDataType"/> class.<br/>
    /// Represents currency format, the currency symbol appears right next to the first digit.
    /// You can specify the number of decimal places that you want to use and how you want to display negative numbers.
    /// </summary>
    /// <remarks>
    /// <para>Belongs to: <strong><see cref="BaseDataContent"/></strong>. For more information, please see <see cref="IContent"/>.</para>
    /// <para><strong><u>Usage</u></strong>:</para>
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// <Currency ...>
    ///   <Negative/>
    ///   <Error/>
    /// <Currency/>
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
    ///       <td><see cref="RealDataType.Decimals"/></td>
    ///       <td align="center">Yes</td>
    ///       <td>Number of decimal places. The default is <c>2</c>.</td>
    ///     </tr>
    ///     <tr>
    ///       <td><see cref="Locale"/></td>
    ///       <td align="center">Yes</td>
    ///       <td>Use this attribute for select preferred output culture. The default is <see cref="KnownCulture.Current"/>.</td>
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
    ///     <term><see cref="NumericDataType.Error"/></term> 
    ///     <description>Reference for numeric data type error settings.</description>
    ///   </item>
    ///   <item>
    ///     <term><see cref="NumericDataType.Negative"/></term> 
    ///     <description>Reference for negative number format.</description>
    ///   </item>
    /// </list>
    /// <para><strong><u>Examples</u></strong>:</para>
    /// <example>
    /// The following example indicate that the content should be currency type.
    /// <code lang="xml">
    /// <![CDATA[
    /// <Style Name="AccountValue">
    ///   <Content Color="Blue">
    ///     <Currency Decimals="1" Locale="mk">
    ///       <Negative Color="Red" Sign="Parenthesis"/>
    ///     </Currency>
    ///   </Content>
    ///   <Font Size="8" Color="White"/>
    /// </Style>
    /// ]]>
    /// </code>
    /// </example>
    /// </remarks>
    public partial class CurrencyDataType
    {
        #region private constants

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownCulture LocaleDefault = KnownCulture.Current;

        #endregion

        #region private members

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownCulture _locale;

        #endregion

        #region constructor/s

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyDataType"/> class.
        /// </summary>
        public CurrencyDataType()
        {
            _locale = LocaleDefault;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets preferred output culture.
        /// </summary>
        /// <value>
        /// One of the <see cref="KnownCulture"/> values. The default is <see cref="KnownCulture.Current"/>.
        /// <para><strong><u>Examples</u></strong>:</para>
        /// <example>
        /// In the following example shows how create a new style.
        /// <code lang="xml">
        /// <![CDATA[
        /// <Style Name="AccountValue">
        ///   <Content Color="Blue">
        ///     <Currency Decimals="1" Locale="mk">
        ///       <Negative Color="Red" Sign="Parenthesis">
        ///     </Currency>
        ///   </Content>
        ///   <Font Size="8" Color="White"/>
        /// </Style>
        /// ]]>
        /// </code>
        /// </example>
        /// </value>
        /// <remarks>
        /// <para><strong><u>Usage</u></strong>:</para>
        /// <code lang="xml" title="ITEE Object Element Usage">
        /// <![CDATA[
        /// <Currency Locale="string" ...>
        /// ...
        /// </Currency>
        /// ]]>
        /// </code>
        /// </remarks>
        [XmlAttribute]
        [DefaultValue(LocaleDefault)]
        public KnownCulture Locale
        {
            get => _locale;
            set
            {
                var isValidLocale = true;
                if (!value.Equals(KnownCulture.Current))
                {
                    var isValidCulture = IsValidCulture(value);
                    if (!isValidCulture)
                    {
                        isValidLocale = false;
                    }
                }

                _locale = isValidLocale 
                    ? value 
                    : LocaleDefault;
            }
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
            Locale.Equals(LocaleDefault);

        #endregion

        #region private static methods

        private static bool IsValidCulture(KnownCulture culture)
        {
            var iw32C = CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures);
            return iw32C.Any(clt => clt.Name == ExportsModel.GetXmlEnumAttributeFromItem(culture));
        }

        #endregion 
    }
}
