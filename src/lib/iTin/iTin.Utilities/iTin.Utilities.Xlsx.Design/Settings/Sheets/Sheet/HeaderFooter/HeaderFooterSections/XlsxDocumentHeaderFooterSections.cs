
using System;
using System.Linq;

using iTin.Core.Helpers;
using iTin.Core.Models.Collections;

namespace iTin.Utilities.Xlsx.Design.Settings.Sheets;

/// <summary>
/// Defines the <b>xlsx</b> header or footer sections.
/// </summary>
public partial class XlsxDocumentHeaderFooterSections : ICloneable
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxDocumentHeaderFooterSections"/> class.
    /// </summary>
    public XlsxDocumentHeaderFooterSections() : base(null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxDocumentHeaderFooterSections"/> class.
    /// </summary>
    public XlsxDocumentHeaderFooterSections(XlsxDocumentHeaderFooter parent) : base(parent)
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

    #region protected override methods

    /// <summary>
    /// Returns the element specified.
    /// </summary>
    /// <param name="value">The object to locate in the <see cref="BaseComplexModelCollection{TItem, TParent, TSearch}"/>.</param>
    /// <returns>
    /// Returns the specified element.
    /// </returns>
    public override XlsxDocumentHeaderFooterSection GetBy(string value) => Find(section => section.Name.Equals(value, StringComparison.OrdinalIgnoreCase));

    /// <summary>
    /// Sets this collection as the owner of the specified item.
    /// </summary>
    /// <param name="item">Target item to set owner.</param>
    protected override void SetOwner(XlsxDocumentHeaderFooterSection item)
    {
        SentinelHelper.ArgumentNull(item, nameof(item));

        item.SetOwner(this);
    }

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxDocumentHeaderFooterSections Clone()
    {
        var cloned = new XlsxDocumentHeaderFooterSections(Parent)
        {
            Properties = Properties.Clone()
        };

        foreach (XlsxDocumentHeaderFooterSection section in this)
        {
            cloned.Add(section.Clone());
        }

        return cloned;
    }

    #endregion

    #region public virtual methods

    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxDocumentHeaderFooterSections reference)
    {
        if (reference == null)
        {
            return;
        }

        var hasElements = this.Any();
        if (!hasElements)
        {
            foreach (var referenceSection in reference)
            {
                var sheet = referenceSection.Clone();
                sheet.SetOwner(this);
                Add(sheet);
            }
        }
        else
        {
            foreach (var section in this)
            {
                var refSheet = reference.GetBy(section.Name);
                if (refSheet != null)
                {
                    section.Combine(refSheet);
                }
            }

            foreach (var referenceSection in reference)
            {
                var sheet = GetBy(referenceSection.Name);
                if (sheet != null)
                {
                    continue;
                }

                var newSection = referenceSection.Clone();
                newSection.SetOwner(this);
                Add(newSection);
            }
        }
    }

    #endregion
}
