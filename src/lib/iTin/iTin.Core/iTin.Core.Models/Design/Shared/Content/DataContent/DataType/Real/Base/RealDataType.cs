
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using iTin.Core.Helpers;

namespace iTin.Core.Models.Design.Styling.Style.Content
{
    /// <summary>
    /// A Specialization of <see cref="BaseDataType"/> class.<br/>
    /// Which acts as the base class for data types with decimal numbers.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///   The following table shows the different data field types.
    ///   </para>
    ///   <list type="table">
    ///     <listheader>
    ///       <term>Class</term>
    ///       <description>Description</description>
    ///     </listheader>
    ///     <item>
    ///       <term><see cref="NumericDataType"/></term>
    ///       <description>Represents base class for the data types negative numbers with decimals.</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref="PercentageDataType"/></term>
    ///       <description>Displays the result with a percent sign (%). You can specify the number of decimal places to use.</description>
    ///     </item>
    ///     <item>
    ///       <term><see cref="ScientificDataType"/></term>
    ///       <description>Displays a number in exponential notation, which replaces part of the number with E + n, where E (exponent) multiplies the preceding number by 10 to n. You can specify the number of decimal places you want to use.</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    public partial class RealDataType
    {
        #region private constants

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const int DefaultDecimals = 2;

        #endregion

        #region private members

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int _decimals;

        #endregion

        #region constructor/s

        /// <summary>
        /// Initializes a new instance of the <see cref="RealDataType"/> class.
        /// </summary>
        protected RealDataType()
        {
            Decimals = DefaultDecimals;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Gets or sets number of decimal places.
        /// </summary>
        /// <value>
        /// Number of decimal places. The default is <c>2</c>.
        /// <para><strong><u>Examples</u></strong>:</para>
        /// <example>
        /// In the following example shows how create a new style with a currency data type, contains negative format (inherits <see cref="NumericDataType"/>).
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
        /// <para>Another example for the percentage data type (inherits <see cref="RealDataType"/>).</para>
        /// <code lang="xml">
        /// <![CDATA[
        /// <Style Name="PercentValue">
        ///   <Content Color="DarkGray">
        ///     <Alignment Horizontal="Right" />
        ///     <Percentage Decimals="1" />
        ///   </Content>
        ///   <Font Size="10" Bold="Yes" />
        /// </Style>
        /// ]]>
        /// </code>
        /// </example>
        /// </value>
        /// <remarks>
        /// <para><strong><u>Usage</u></strong>:</para>
        /// <code lang="xml" title="ITEE Object Element Usage">
        /// <![CDATA[
        /// <Percentage|Numeric|Scientific Decimals="int" ...>
        /// ...
        /// </Percentage|Numeric|Scientific>
        /// ]]>
        /// </code>
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value" /> is less than 0.</exception>
        [XmlAttribute]
        [DefaultValue(DefaultDecimals)]
        public int Decimals
        {
            get => _decimals;
            set
            {
                SentinelHelper.ArgumentLessThan("value", value, 0);

                _decimals = value;
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
            Decimals.Equals(DefaultDecimals);

        #endregion
    }
}
