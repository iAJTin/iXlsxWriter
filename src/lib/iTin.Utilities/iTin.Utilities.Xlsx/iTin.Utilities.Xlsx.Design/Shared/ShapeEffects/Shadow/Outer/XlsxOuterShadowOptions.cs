﻿
namespace iTin.Utilities.Xlsx.Design.Shared
{
    using System;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    /// <summary>
    /// A Specialization of <see cref="XlsxBaseShadowOptions"/> class.<br/>
    /// Defines a set of options that we can use to quickly adjust an existing <see cref="XlsxOuterShadow"/> instance.
    /// </summary>
    [Serializable]
    public class XlsxOuterShadowOptions : XlsxBaseShadowOptions, ICloneable
    {
        #region constructor/s

        #region [public] XlsxOuterShadowOptions(): Initializes a new instance of this class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxOuterShadowOptions"/> class.
        /// </summary>
        public XlsxOuterShadowOptions()
        {
            Size = null;
        }
        #endregion

        #endregion

        #region interfaces

        #region ICloneable

        #region private methods

        #region [private] (object) Clone(): Creates a new object that is a copy of the current instance
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

        #region [public] {static} (XlsxOuterShadowOptions) Default: Gets a reference that contains the set of available settings to model an existing XlsxOuterShadow instance
        /// <summary>
        /// Gets a reference that contains the set of available settings to model an existing <see cref="XlsxOuterShadow"/> instance.
        /// </summary>
        /// <value>
        /// Set of default options.
        /// </value>
        public new static XlsxOuterShadowOptions Default => new XlsxOuterShadowOptions();
        #endregion

        #endregion

        #region public properties

        #region [public] (int?) Size: Gets or sets a value that contains the preferred shadow size, expressed in % in an existing in an existing XlsxOuterShadow instance
        /// <summary>
        /// Gets or sets a value that contains the preferred shadow size, expressed in % in an existing <see cref="XlsxOuterShadow"/> instance. The default value is <b>(null)</b>, Nothing in Visual Basic.
        /// </summary>
        /// <value>
        /// <b>null</b>, (Nothing in Visual Basic) do not modify the value of the reference model or an <see cref="int"/> value that represents the preferred shadow size value, expressed in %.
        /// </value>
        [XmlAttribute]
        [JsonProperty("size")]
        public int? Size { get; set; }
        #endregion

        #endregion

        #region public override readonly properties

        #region [public] {override} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
        /// </value>
        public override bool IsDefault => base.IsDefault && Size == null;
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (XlsxOuterShadowOptions) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new XlsxOuterShadowOptions Clone() => (XlsxOuterShadowOptions)MemberwiseClone();
        #endregion

        #endregion
    }
}
