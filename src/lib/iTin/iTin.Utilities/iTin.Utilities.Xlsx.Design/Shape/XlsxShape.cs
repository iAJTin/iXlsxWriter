
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;

using iTin.Utilities.Xlsx.Design.Shared;

namespace iTin.Utilities.Xlsx.Design.Shape
{
    /// <summary>
    /// Defines a <b>xlsx</b> shape.
    /// </summary>
    public partial class XlsxShape : ICombinable<XlsxShape>, ICloneable
    {
        #region private constants
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const YesNo DefaultShow = YesNo.Yes;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private const ShapeType DefaultShapeType = ShapeType.Rect;
        #endregion

        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private YesNo _show;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxSize _size;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ShapeType _type;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxBorder _border;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxShapeContent _content;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private XlsxShapeEffects _shapeEffects;
        #endregion

        #region constructor/s

        #region [public] XlsxShape(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxShape"/> class.
        /// </summary>
        public XlsxShape()
        {
            Show = DefaultShow;
            ShapeType = DefaultShapeType;
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

        #region ICombinable

        #region explicit

        #region (object) ICombinable<XlsxShape>.Combine(XlsxShape): Creates a new object that is a copy of the current instance
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">Reference pattern</param>
        void ICombinable<XlsxShape>.Combine(XlsxShape reference) => Combine(reference);
        #endregion

        #endregion

        #endregion

        #endregion

        #region public readonly static properties

        #region [public] {static} (XlsxShape) Default: Returns a new instance containing default shape settings
        /// <summary>
        /// Returns a new instance containing default shape settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxShape"/> reference containing the default shape settings.
        /// </value>
        public static XlsxShape Default => new XlsxShape();
        #endregion

        #endregion

        #region public readonly properties

        #region [public] (bool) BorderSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool BorderSpecified => !Border.IsDefault;
        #endregion

        #region [public] (bool) ContentSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool ContentSpecified => !Content.IsDefault;
        #endregion

        #region [public] (bool) ShapeEffectsSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool ShapeEffectsSpecified => !ShapeEffects.IsDefault;
        #endregion

        #region [public] (bool) SizeSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <b>true</b> if the serializer has to include the element; otherwise, <b>false</b>.
        /// </value>
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool SizeSpecified => !Size.IsDefault;
        #endregion

        #endregion

        #region public properties

        #region [public] (XlsxBorder) Border: Gets or sets a value containing border shape settings
        /// <summary>
        /// Gets or sets a value containing border shape settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxBorder"/> reference containing border shape settings.
        /// </value>
        [XmlElement]
        [JsonProperty("border")]
        public XlsxBorder Border
        {
            get => _border ?? (_border = new XlsxBorder());
            set => _border = value;
        }
        #endregion

        #region [public] (XlsxShapeContent) Content: Gets or sets a value containing shape content settings
        /// <summary>
        /// Gets or sets a value containing shape content settings.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxShapeContent"/> reference containing shape content settings.
        /// </value>
        [XmlElement]
        [JsonProperty("content")]
        public XlsxShapeContent Content
        {
            get => _content ?? (_content = new XlsxShapeContent());
            set => _content = value;
        }
        #endregion

        #region [public] (string) Name: Gets or sets the shape name
        /// <summary>
        ///  Gets or sets the shape name
        /// </summary>
        /// <value>
        /// The shape name.
        /// </value>
        [XmlAttribute]
        [JsonProperty("name")]
        public string Name { get; set; }
        #endregion

        #region [public] (YesNo) Show: Gets or sets a value that determines whether displays this shape
        /// <summary>
        /// Gets or sets a value that determines whether displays this shape. The default is <see cref="YesNo.Yes"/>.
        /// </summary>
        /// <value>
        /// <see cref="YesNo.Yes"/> displays this shape; Otherwise, <see cref="YesNo.No"/>. 
        /// </value>
        /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
        [XmlAttribute]
        [JsonProperty("show")]
        [DefaultValue(DefaultShow)]
        public YesNo Show
        {
            get => _show;
            set
            {
                SentinelHelper.IsEnumValid(value);
                _show = value;
            }
        }
        #endregion

        #region [public] (XlsxSize) Size: Gets or sets a value containing shape size
        /// <summary>
        /// Gets or sets a value containing shape size.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxSize"/> reference containing shape size.
        /// </value>
        [XmlElement]
        [JsonProperty("size")]
        public XlsxSize Size
        {
            get => _size ?? (_size = new XlsxSize());
            set => _size = value;
        }
        #endregion

        #region [public] (XlsxShapeEffects) ShapeEffects: Gets or sets a value containing shape effects reference
        /// <summary>
        /// Gets or sets a value containing shape effects reference.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxBaseShadow"/> reference containing shape effects reference.
        /// </value>
        [XmlElement]
        [JsonProperty("shape-effects")]
        public XlsxShapeEffects ShapeEffects
        {
            get => _shapeEffects ?? (_shapeEffects = XlsxShapeEffects.Default);
            set => _shapeEffects = value;
        }
        #endregion

        #region [public] (ShapeType) ShapeType: Gets or sets the preferred active mini-chart type
        /// <summary>
        /// Gets or sets the preferred shape type. The default is <see cref="Shape.ShapeType.Rect"/>.
        /// </summary>
        /// <value>
        /// Preferred shape type.
        /// </value>
        [XmlAttribute]
        [JsonProperty("shape-type")]
        [DefaultValue(DefaultShapeType)]
        public ShapeType ShapeType
        {
            get => _type;
            set
            {
                SentinelHelper.IsEnumValid(value);

                _type = value;
            }
        }
        #endregion

        #endregion

        #region public override properties

        #region [public] {overide} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise <b>false</b>.
        /// </value>
        public override bool IsDefault =>
            Size.IsDefault &&
            Border.IsDefault &&
            Content.IsDefault &&
            ShapeEffects.IsDefault &&
            string.IsNullOrEmpty(Name) &&
            Show.Equals(DefaultShow) &&
            ShapeType.Equals(DefaultShapeType);
        #endregion

        #endregion

        #region public methods

        #region [public] (XlsxShape) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public XlsxShape Clone()
        {
            var cloned = (XlsxShape)MemberwiseClone();
            cloned.Size = Size.Clone();
            cloned.Border = Border.Clone();
            cloned.Content = Content.Clone();
            cloned.ShapeEffects = ShapeEffects.Clone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (void) Combine(XlsxShape): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">The reference.</param>
        public virtual void Combine(XlsxShape reference)
        {
            if (reference == null)
            {
                return;
            }

            if (Show.Equals(DefaultShow))
            {
                Show = reference.Show;
            }

            if (Name == null)
            {
                Name = reference.Name;
            }

            if (ShapeType.Equals(DefaultShapeType))
            {
                ShapeType = reference.ShapeType;
            }

            Border.Combine(reference.Border);
            Content.Combine(reference.Content);
            ShapeEffects.Combine(reference.ShapeEffects);
            //Size.Combine(reference.Size);
        }
        #endregion

        #endregion
    }
}
