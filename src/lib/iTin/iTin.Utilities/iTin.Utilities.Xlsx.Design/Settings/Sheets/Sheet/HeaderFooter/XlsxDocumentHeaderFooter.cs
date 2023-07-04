
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace iTin.Utilities.Xlsx.Design.Settings.Sheets;

/// <summary>
/// Defines header and footer document configuration, it allow define margin and data.
/// </summary>
public partial class XlsxDocumentHeaderFooter : ICloneable
{
    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XlsxDocumentHeaderFooterSections _sections;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxDocumentHeaderFooter"/> class.
    /// </summary>
    public XlsxDocumentHeaderFooter()
    {
    }

    #endregion

    #region interfaces

    #region ICloneable

    /// <inheritdoc/>
    /// <summary>
    /// Create a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new <see cref="object"/> that is a copy of this instance.
    /// </returns>
    object ICloneable.Clone() => Clone();

    #endregion

    #endregion

    #region public readonly static properties

    /// <summary>
    /// Returns a new instance containing default header or footer document settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxDocumentHeaderFooter"/> reference containing the default header or footer document settings.
    /// </value>
    public static XlsxDocumentHeaderFooter Default => new();

    #endregion

    #region public readonly properties

    /// <summary>
    /// Gets the parent element of this element.
    /// </summary>
    /// <value>
    /// The element that represents the container element of this element.
    /// </value>
    [XmlIgnore]
    [JsonIgnore]
    [Browsable(false)]
    public XlsxSheetSettings Parent { get; private set; }

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
    public bool SectionsSpecified => !Sections.IsDefault;

    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets a reference that allows you to define the sections settings.
    /// </summary>
    /// <value>
    /// A <see cref="XlsxDocumentHeaderFooterSections"/> refetence containing the sections settings.
    /// </value>
    [JsonProperty("sections")]
    [XmlArrayItem("Section", typeof(XlsxDocumentHeaderFooterSection), IsNullable = false)]
    public XlsxDocumentHeaderFooterSections Sections
    {
        get => _sections ??= new XlsxDocumentHeaderFooterSections(this);
        set => _sections = value;
    }

    #endregion

    #region public override properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public override bool IsDefault => base.IsDefault && Sections.IsDefault;

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxDocumentHeaderFooter Clone()
    {
        var cloned = (XlsxDocumentHeaderFooter) MemberwiseClone();
        cloned.Sections = Sections.Clone();
        cloned.Properties = Properties.Clone();
            
        return cloned;
    }

    #endregion

    #region public virtual methods

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxDocumentHeaderFooter reference)
    {
        if (reference == null)
        {
            return;
        }

        Sections.Combine(reference.Sections);
    }

    #endregion

    #region internal methods

    /// <summary>
    /// Sets the parent element of this element.
    /// </summary>
    /// <param name="reference">Reference to parent.</param>
    internal void SetParent(XlsxSheetSettings reference)
    {
        Parent = reference;
    }

    #endregion
}
