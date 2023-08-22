
using System.Diagnostics;
using System.Xml;

namespace OfficeOpenXml.Helpers;

/// <summary>
/// A Specialization of <see cref="XmlBaseHelper"/> class.<br/>
/// Allows manipulate the underliying <b>XML</b> drawing document (pictures, shapes).
/// </summary>
internal class XmlDrawingHelper : XmlBaseHelper
{
    #region public constants

    /// <summary>
    /// A <see cref="T:System.String"/> than represents <b>xdr</b> namespace.
    /// </summary>
    public const string XdrNamespace = "http://schemas.openxmlformats.org/drawingml/2006/spreadsheetDrawing";

    /// <summary>
    /// A <see cref="T:System.String"/> than represents <b>a</b> namespace.
    /// </summary>
    public const string LetterANamespace = "http://schemas.openxmlformats.org/drawingml/2006/main";

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private XmlNamespaceManager _manager;

    #endregion

    #region private new static members

    private new static readonly XmlDrawingHelper Instance = new();

    #endregion

    #region protected override methods

    /// <summary>
    /// Resolves the namespace manager to use for this <b>XML</b> document.
    /// </summary>
    protected override void ResolveNamespaceManager()
    {
        var manager = new XmlNamespaceManager(XmlDocument.NameTable);
        manager.AddNamespace("xdr", XdrNamespace);
        manager.AddNamespace("a", LetterANamespace);

        NamespaceManager = manager;
    }

    #endregion
}
