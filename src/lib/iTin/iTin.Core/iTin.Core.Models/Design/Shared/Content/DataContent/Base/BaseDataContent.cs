
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Helpers;
using iTin.Core.Models.Design.Styling.Style;
using iTin.Core.Models.Design.Styling.Style.Content;

namespace iTin.Core.Models.Design.Styling.Style
{
    /// <summary>
    /// A Specialization of <see cref="IDataContent"/> interface.<br/>
    /// Which acts as the base class for different contents.
    /// </summary>
    public partial class BaseDataContent : IDataContent
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private BaseDataType _dataType;

        public void Combine(IContent reference)
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public bool IsDefault { get; }
        public bool IsEmpty { get; }
        public IParent Parent { get; }
        public string Color { get; set; }
        public string AlternateColor { get; set; }
        public YesNo Show { get; set; }
        public Color GetAlternateColor()
        {
            throw new NotImplementedException();
        }

        public Color GetColor()
        {
            throw new NotImplementedException();
        }

        public void SetParent(IParent reference)
        {
            throw new NotImplementedException();
        }

        public void Combine(IBasicContent reference)
        {
            throw new NotImplementedException();
        }

        public IContentAlignment Alignment { get; set; }
        public void Combine(IDataContent reference)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Gets or sets content data type.
        /// </summary>
        /// <value>
        /// Reference to content data type.
        /// <example>
        /// In the following example shows how create a new text content.
        /// <code lang="xml">
        /// <![CDATA[
        /// <Content Color="DarkBlue">
        ///   <Alignment Horizontal="Left"/>
        ///   <Text/>
        /// </Content>
        /// ]]>
        /// </code>
        /// <para>In the following example shows how create a new text data content (c#).</para>
        /// <code lang="C#">
        /// var content = new ContentModel
        /// {
        ///     Color = "DarkBlue",
        ///     DataType = new TextDataTypeModel(),
        ///     Alignment = new ContentAlignmentModel { Horizontal = KnownHorizontalAlignment.Left }
        /// };
        /// </code>
        /// <para>In the following example shows how create a new text data content (VB.NET).</para>
        /// <code lang="VB#">
        /// Dim content = New ContentModel With
        /// {
        ///     .Color = "DarkBlue",
        ///     .DataType = New TextDataTypeModel(),
        ///     .Alignment = New ContentAlignmentModel With { .Horizontal = KnownHorizontalAlignment.Left }
        /// }
        /// </code>
        /// <para>In the following example shows how create a new currency content (XML).</para>
        /// <code lang="xml">
        /// <![CDATA[
        /// <Content Color="Beige">
        ///   <Alignment Vertical="Bottom" Horizontal="Right"/>
        ///   <Currency Decimals="1" Locale="mk">
        ///     <Negative Color="Red" Sign="Parenthesis"/>
        ///   </Currency>
        /// </Content>
        /// ]]>
        /// </code>
        /// <para>In the following example shows how create a new currency content (c#).</para>
        /// <code lang="C#">
        /// var content = new ContentModel
        /// {
        ///     Color = "Beige",
        ///     Alignment = new ContentAlignmentModel 
        ///     { 
        ///         Horizontal = KnownHorizontalAlignment.Left, 
        ///         Vertical = KnownVerticalAlignment.Bottom 
        ///     },
        ///     DataType = new CurrencyDataTypeModel
        ///     { 
        ///         Decimals = 1,
        ///         Locale = KnownCulture.mk,
        ///         Negative = new NegativeModel
        ///         {
        ///             Color = KnownBasicColor.Red,
        ///             Sign = KnownNegativeSign.Parenthesis
        ///         }
        ///     }
        /// };
        /// </code>
        /// <para>In the following example shows how create a new currency content (VB.NET).</para>
        /// <code lang="VB#">
        /// Dim content = New ContentModel With
        /// {
        ///     .Color = "Beige",
        ///     .Alignment = New ContentAlignmentModel With
        ///      { 
        ///          .Horizontal = KnownHorizontalAlignment.Left, 
        ///          .Vertical = KnownVerticalAlignment.Bottom 
        ///      },
        ///     .DataType = New CurrencyDataTypeModel With
        ///      { 
        ///          .Decimals = 1,
        ///          .Locale = KnownCulture.mk,
        ///          .Negative = New NegativeModel With
        ///           {
        ///               .Color = KnownBasicColor.Red,
        ///               .Sign = KnownNegativeSign.Parenthesis
        ///           }
        ///      }
        /// }
        /// </code>
        /// </example>
        /// </value>
        /// <remarks>
        /// <code lang="xml" title="ITEE Object Element Usage">
        /// <![CDATA[
        /// <Content>
        ///   <Number/> | <Currency/> | <Percentage/> | <Scientific/> | <Datetime/> | <Special/> | <Text/>
        ///   ...
        /// </Content>
        /// ]]>
        /// </code>
        /// </remarks>
        [XmlElement("Currency", typeof(CurrencyDataType))]
        [XmlElement("DateTime", typeof(DateTimeDataType))]
        [XmlElement("Number", typeof(NumberDataType))]
        [XmlElement("Percentage", typeof(PercentageDataType))]
        [XmlElement("Scientific", typeof(ScientificDataType))]
        [XmlElement("Text", typeof(TextDataType))]
        public BaseDataType DataType
        {
            get
            {
                if (_dataType != null)
                {
                    _dataType.SetParent(this);
                }
                else
                {
                    if (Parent.Inherits == null)
                    {
                        _dataType = new TextDataType();
                    }

                }

                return _dataType;
            }
            set
            {
                if (value != null)
                {
                    _dataType = value;
                }
            }
        }
    }
}
