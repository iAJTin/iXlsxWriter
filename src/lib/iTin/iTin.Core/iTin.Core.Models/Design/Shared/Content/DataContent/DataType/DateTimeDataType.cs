
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Xml.Serialization;

using iTin.Core.Helpers;

namespace iTin.Core.Models.Design.Styling.Style.Content
{
    using Enums;
    using Shared.Error;

    /// <summary>
    /// A Specialization of <see cref="BaseDataType"/> class.<br/>
    /// Displays data field as datetime format. You can specify the output culture.
    /// </summary>
    /// <remarks>
    /// <para>Belongs to: <strong><see cref="BaseDataContent"/></strong>. For more information, please see <see cref="IContent"/>.</para>
    /// <para><strong><u>Usage</u></strong>:</para>
    /// <code lang="xml" title="ITEE Object Element Usage">
    /// <![CDATA[
    /// <Datetime ...>
    ///   <Error/>
    /// <Datetime/>
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
    ///       <td><see cref="Format"/></td>
    ///       <td align="center">Yes</td>
    ///       <td>Preferred output date time format. The default is <see cref="KnownDateTimeFormat.ShortDatePattern"/>.</td>
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
    ///     <term><see cref="Error"/></term> 
    ///     <description>Reference for datetime data type error settings.</description>
    ///   </item>
    /// </list>
    /// <para><strong><u>Examples</u></strong>:</para>
    /// <example>
    /// The following example indicate that the content should be datetime data type.
    /// <code lang="xml">
    /// <![CDATA[
    /// <Style Name="DateValue">
    ///   <Content Color="sc# 0.15 0.15 0.15">
    ///     <Alignment Horizontal="Center"/>
    ///     <DateTime Format="Year-Month" Locale="en-US">
    ///       <Error Value="Today">
    ///         <Comment Show="Yes">
    ///           <Font Name="Comic Sans MS" Size="16" Bold="Yes" Italic="Yes" Underline="Yes"/>
    ///         </Comment>
    ///       </Error>
    ///     </DateTime>
    ///   </Content>
    /// </Style>
    /// ]]>
    /// </code>
    /// </example>
    /// </remarks>
    public partial class DateTimeDataType
    {
        #region private constants

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownCulture DefaultLocale = KnownCulture.Current;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const KnownDateTimeFormat DefaultFormat = KnownDateTimeFormat.ShortDatePattern;

        #endregion

        #region private members

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownCulture _locale;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DateTimeError _error;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private KnownDateTimeFormat _format;

        #endregion

        #region constructor/s

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeDataType"/> class.
        /// </summary>
        public DateTimeDataType()
        {
            Locale = DefaultLocale;
            Format = DefaultFormat;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets a reference that contains datetime data type error settings.
        /// </summary>
        /// <value>
        /// Datetime data type error settings
        /// <para><strong><u>Examples</u></strong>:</para>
        /// <example>
        /// The following example indicate that the content should be datetime data type.
        /// <code lang="xml">
        /// <![CDATA[
        /// <Style Name="DateValue">
        ///   <Content Color="sc# 0.15 0.15 0.15">
        ///     <Alignment Horizontal="Center"/>
        ///     <DateTime Format="Year-Month" Locale="en-US">
        ///       <Error Value="Today">
        ///         <Comment Show="Yes">
        ///           <Font Name="Comic Sans MS" Size="16" Bold="Yes" Italic="Yes" Underline="Yes"/>
        ///         </Comment>
        ///       </Error>
        ///     </DateTime>
        ///   </Content>
        /// </Style>
        /// ]]>
        /// </code>
        /// </example>
        /// </value>
        /// <remarks>
        /// <para><strong><u>Usage</u></strong>:</para>
        /// <code lang="xml" title="ITEE Object Element Usage">
        /// <![CDATA[
        /// <Datetime ...>
        ///   <Error/>
        /// </Datetime>
        /// ]]>
        /// </code>
        /// </remarks>
        public DateTimeError Error
        {
            get => _error ??= new DateTimeError();
            set => _error = value;
        }

        /// <summary>
        /// Gets or sets preferred output date time format.
        /// </summary>
        /// <value>
        /// One of the <see cref="KnownDateTimeFormat"/> values. The default is <see cref="KnownDateTimeFormat.ShortDatePattern"/>.
        /// <para><strong><u>Examples</u></strong>:</para>
        /// <example>
        /// The following example indicate that the content should be datetime data type.
        /// <code lang="xml">
        /// <![CDATA[
        /// <Style Name="DateValue">
        ///   <Content Color="sc# 0.15 0.15 0.15">
        ///     <Alignment Horizontal="Center"/>
        ///     <DateTime Format="Year-Month" Locale="en-US">
        ///       <Error Value="Today">
        ///         <Comment Show="Yes">
        ///           <Font Name="Comic Sans MS" Size="16" Bold="Yes" Italic="Yes" Underline="Yes"/>
        ///         </Comment>
        ///       </Error>
        ///     </DateTime>
        ///   </Content>
        /// </Style>
        /// ]]>
        /// </code>
        /// </example>
        /// </value>
        /// <remarks>
        /// <para><strong><u>Usage</u></strong>:</para>
        /// <code lang="xml" title="ITEE Object Element Usage">
        /// <![CDATA[
        /// <Datetime Format="GeneralDatePattern|ShortDatePattern|MediumDatePattern|LongDatePattern|FullDatePattern|RFC1123Pattern|ShortTimePattern|LongTimePattern|MonthDayPattern|YearMonthPattern" ...>
        /// ...
        /// </Datetime>
        /// ]]>
        /// </code>
        /// </remarks>
        /// <exception cref="InvalidEnumArgumentException">
        /// <paramref name="value"/> is not part of the enumeration.
        /// 
        /// -or-
        /// 
        /// <paramref name="value"/> is not an enumerated type.
        /// </exception>
        [XmlAttribute]
        [DefaultValue(DefaultFormat)]
        public KnownDateTimeFormat Format
        {
            get => _format;
            set
            {
                SentinelHelper.IsEnumValid(value);

                _format = value;
            }
        }

        /// <summary>
        /// Gets or sets preferred output culture.
        /// </summary>
        /// <value>
        /// One of the <see cref="KnownCulture"/> values. The default is <see cref="KnownCulture.Current"/>.
        /// <para><strong><u>Examples</u></strong>:</para>
        /// <example>
        /// The following example indicate that the content should be datetime data type.
        /// <code lang="xml">
        /// <![CDATA[
        /// <Style Name="DateValue">
        ///   <Content Color="sc# 0.15 0.15 0.15">
        ///     <Alignment Horizontal="Center"/>
        ///     <DateTime Format="Year-Month" Locale="en-US">
        ///       <Error Value="Today">
        ///         <Comment Show="Yes">
        ///           <Font Name="Comic Sans MS" Size="16" Bold="Yes" Italic="Yes" Underline="Yes"/>
        ///         </Comment>
        ///       </Error>
        ///     </DateTime>
        ///   </Content>
        /// </Style>
        /// ]]>
        /// </code>
        /// </example>
        /// </value>
        /// <remarks>
        /// <para><strong><u>Usage</u></strong>:</para>
        /// <code lang="xml" title="ITEE Object Element Usage">
        /// <![CDATA[
        /// <Datetime Locale="string" ...>
        /// ...
        /// </Datetime>
        /// ]]>
        /// </code>
        /// </remarks>
        [XmlAttribute]
        [DefaultValue(DefaultLocale)]
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
                    : DefaultLocale;
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
            Error.IsDefault &&
            Format.Equals(DefaultFormat) &&
            Locale.Equals(DefaultLocale);

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
