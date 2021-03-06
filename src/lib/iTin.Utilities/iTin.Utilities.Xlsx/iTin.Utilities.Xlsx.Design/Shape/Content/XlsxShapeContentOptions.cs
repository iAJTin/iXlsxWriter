﻿
namespace iTin.Utilities.Xlsx.Design.Shape
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using iTin.Core.Models.Design.Enums;
    using iTin.Core.Models.Design.Options;

    /// <summary>
    /// A Specialization of <see cref="BaseOptions"/> class.<br/>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxShapeContent"/> instance.
    /// </summary>
    [Serializable]
    public class XlsxShapeContentOptions : BaseOptions, ICloneable
    {
        #region constructor/s

        #region [public] XlsxShapeContentOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxShapeContentOptions"/> class.
        /// </summary>
        public XlsxShapeContentOptions()
        {
            Show = null;
            Color = null;
            Alignment = null;
            Transparency = null;
        }
        #endregion

        #endregion

        #region interfaces

        #region ICloneable

        #region explicit

        #region (object) ICloneable.Clone(): Creates a new object that is a copy of the current instance
        /// <inheritdoc />
        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone() => Clone();
        #endregion

        #endregion

        #endregion

        #endregion

        #region public static properties

        #region [public] {static} (XlsxShapeContentOptions) Default: Returns a new instance containing the set of available settings to model an existing XlsxShapeContent instance
        /// <summary>
        /// Returns a new instance containing the set of available settings to model an existing <see cref="XlsxShapeContent"/> instance.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxShapeContentOptions"/> reference containing the set of available settings to model an existing <see cref="XlsxShapeContent"/> instance.
        /// </value>
        public static XlsxShapeContentOptions Default => new XlsxShapeContentOptions();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) AlignmentSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool AlignmentSpecified => Alignment != null;
        #endregion

        #region [public] (bool) FontSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool FontSpecified => Font != null;
        #endregion

        #endregion

        #region public properties

        #region [public] (XlsxShapeContentAlignmentOptions) Alignment: Gets or sets a value that defines shape content alignment in an existing XlsxShapeContent instance.
        /// <summary>
        /// Gets or sets a value that defines shape content alignment in an existing <see cref="XlsxShapeContent"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="XlsxShapeContentAlignmentOptions"/> instance.
        /// </value>
        [XmlElement]
        [JsonProperty("alignment")]
        public XlsxShapeContentAlignmentOptions Alignment { get; set; }
        #endregion

        #region [public] (string) Color: Gets or sets the preferred shape content color in an existing XlsxShapeContent instance
        /// <summary>
        /// Gets or sets the preferred shape content color in an existing <see cref="XlsxShapeContent"/>" instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// Preferred shape content color.
        /// </value>
        [XmlAttribute]
        [JsonProperty("color")]
        public string Color { get; set; }
        #endregion

        #region [public] (FontOptions) Font: Gets or sets a value that defines font shape content in an existing XlsxShapeContent instance.
        /// <summary>
        /// Gets or sets a value that defines font shape content in an existing <see cref="XlsxShapeContent"/> instance.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or a <see cref="FontOptions"/> instance.
        /// </value>
        [XmlElement]
        [JsonProperty("font")]
        public FontOptions Font { get; set; }
        #endregion

        #region [public] (YesNo?) Show: Gets or sets a value that indicates whether an existing XlsxShapeContent instance is displayed
        /// <summary>
        /// Gets or sets a value that indicates whether an existing <see cref="XlsxShapeContent"/> instance is displayed. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model, <b>YesNo.Yes</b> if the instance is displayed or <b>YesNo.No</b> if the instance is not displayed. 
        /// </value>
        [XmlAttribute]
        [JsonProperty("show")]
        public YesNo? Show { get; set; }
        #endregion

        #region [public] (int?) Transparency: Gets or sets the preferred shape content transparency percentage value in an existing XlsxShapeContent instance
        /// <summary>
        /// Gets or sets the preferred shape content transparency percentage value in an existing <see cref="XlsxShapeContent"/>" instance.
        /// </summary>
        /// <value>
        /// Preferred shape content transparency percentage value.
        /// </value>
        [XmlAttribute]
        [JsonProperty("transparency")]
        public int? Transparency { get; set; }
        #endregion

        #endregion

        #region public override readonly properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault =>
            base.IsDefault &&
            Font == null &&
            Show == null &&
            Color == null &&
            Alignment == null &&
            Transparency == null;
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxShapeContentOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxShapeContentOptions Clone()
        {
            var cloned = (XlsxShapeContentOptions)MemberwiseClone();

            if (Alignment != null)
            {
                cloned.Alignment = Alignment.Clone();
            }

            if (Font != null)
            {
                cloned.Font = Font.Clone();
            }

            return cloned;
        }
        #endregion

        #endregion
    }
}
