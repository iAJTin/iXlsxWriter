
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Table;

using System;

namespace iTin.Utilities.Xlsx.Design.Table.Headers;

/// <summary>
/// Defines a column headers collection.
/// </summary>
public partial class XlsxColumnsHeadersCollection : IXlsxColumnsHeaders
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxColumnsHeadersCollection"/> class.
    /// </summary>
    public XlsxColumnsHeadersCollection() : base(null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ColumnsHeadersCollection"/> class.
    /// </summary>
    /// <param name="parent">The parent.</param>
    public XlsxColumnsHeadersCollection(IParent parent) : base(parent)
    {
    }

    #endregion

    #region interfaces

    #region ICloneable

    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    object ICloneable.Clone() => Clone();

    #endregion

    #endregion

    #region public methods

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public XlsxColumnsHeadersCollection Clone()
    {
        var cloned = new XlsxColumnsHeadersCollection(Parent)
        {
            Properties = Properties.Clone()
        };

        foreach (var columnHeader in this)
        {
            cloned.Add((XlsxColumnHeader)columnHeader.Clone());
        }

        return cloned;
    }

    #endregion
}
