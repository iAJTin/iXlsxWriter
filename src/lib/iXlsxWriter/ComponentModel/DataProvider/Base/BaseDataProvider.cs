
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

using iTin.Core.Helpers;

namespace iXlsxWriter.ComponentModel.DataProvider;

/// <summary>
/// Implements interface <see cref="IDataProvider" />.<br/>
/// Which acts as the base class for future providers.
/// </summary>
/// <remarks>
///   <para>
///   The following table shows the different provider types.
///   </para>
///   <list type="table">
///     <listheader>
///       <term>Class</term>
///       <description>Description</description>
///     </listheader>
///     <item>
///       <term><see cref="DataSetProvider" /></term>
///       <description>Represents a custom provider for <see cref="T:System.Data.DataSet" /> inputs. For more information please see <see cref="DataSetProvider" /></description>
///     </item>
///     <item>
///       <term><see cref="XmlProvider" /></term>
///       <description>Represents a custom provider for <c>Xml</c> types. For more information please see <see cref="XmlProvider" /></description>
///     </item>
///   </list>
/// </remarks>
public abstract class BaseDataProvider : IDataProvider
{
    #region private static readonly members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly char[] EmptySpecialCharsArray = { };

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseDataProvider"/> class.
    /// </summary>
    protected BaseDataProvider()
    {
        SpecialChars = EmptySpecialCharsArray;
        InputUri = iTin.Core.IO.File.GetUniqueTempRandomFile();
    }

    #endregion

    #region public properties

    /// <inheritdoc />
    public string InputDataName { get; protected set; }

    /// <inheritdoc />
    public Uri InputUri { get; protected set; }

    /// <inheritdoc />
    public IEnumerable<char> SpecialChars { get; protected set; }

    #endregion

    #region public virtual properties
        
    /// <inheritdoc />
    public virtual bool CanCreateInputXml => false;

    /// <inheritdoc />
    public virtual bool CanGetDataTable => false;

    #endregion

    #region protected static properties

    /// <summary>
    /// Gets the empty special chars.
    /// </summary>
    /// <returns>
    /// Empty special chars array.
    /// </returns>
    protected static IEnumerable<char> EmptySpecialChars => (char[])EmptySpecialCharsArray.Clone();

    #endregion

    #region public static methods

    /// <summary>
    /// Parse an <see cref="string" /> and replace the special chars defined in <paramref name="specialChars"/> by a hexadecimal pattern.
    /// </summary>
    /// <param name="value"><see cref="string" /> to parse</param>
    /// <param name="specialChars">Special chars to replace</param>
    /// <returns>
    /// The parsed string.
    /// </returns>
    /// <remarks>
    /// Analyzes the argument <paramref name="value"/>, replacing <paramref name="specialChars"/> by the pattern '_x####_', where:
    /// ####: Represents ASCII char code in Hexadecimal format
    /// If the argument <paramref name="value"/> does not contain any special characters returns the argument unchanged.
    /// </remarks>
    public static string Parse(string value, IEnumerable<char> specialChars)
    {
        SentinelHelper.ArgumentNull(value, nameof(value));

        if (specialChars == null)
        {
            return value;
        }

        var parsedField = value;
        var chars = specialChars.ToList();
        foreach (var specialchar in chars)
        {
            if (!value.StartsWith(specialchar.ToString(CultureInfo.InvariantCulture), StringComparison.Ordinal))
            {
                continue;
            }

            var charAsString = specialchar.ToString(CultureInfo.InvariantCulture);
            var asciicode = Encoding.ASCII.GetBytes(charAsString)[0];
            var cleanedfield = value.Replace(charAsString, string.Empty);
            parsedField =$"_x{asciicode.ToString("x4", CultureInfo.InvariantCulture).ToUpper(CultureInfo.InvariantCulture)}_{cleanedfield}";
        }

        return parsedField;
    }

    #endregion

    #region public methods

    /// <inheritdoc />
    public void CreateInputXml()
    {
        if (CanCreateInputXml)
        {
            OnCreateInputXml();
        }
    }

    /// <inheritdoc />
    public string Parse(string value) => Parse(value, SpecialChars);

    /// <inheritdoc />
    public void SetSpecialChars(IEnumerable<char> value)
    {
        SpecialChars = value;
    }

    /// <inheritdoc />
    public DataTable ToDataTable()
    {
        if (CanGetDataTable)
        {
            return OnGetDataTable();
        }

        throw new InvalidOperationException();
    }

    /// <inheritdoc />
    public IEnumerable<XElement> ToXml()
    {
        CreateInputXml();

        return LoadXmlFromFile(InputUri.OriginalString, InputDataName);
    }

    #endregion

    #region public override methods

    /// <inheritdoc />
    public override string ToString() => $"Type=\"{GetType().Name}\"";

    #endregion

    #region protected static methods

    /// <summary>
    /// Retrieves <c>Xml</c> content of specified <paramref name="table" /> in a file.
    /// </summary>
    /// <param name="fileName">Target filename</param>
    /// <param name="table">Table to retrieve</param>
    /// <returns>
    /// A collection of <see cref="T:System.Xml.Linq.XElement"/> that contains the table content as <strong>XML</strong>.
    /// </returns>
    protected static IEnumerable<XElement> LoadXmlFromFile(string fileName, string table)
    {
        SentinelHelper.IsTrue(string.IsNullOrEmpty(table));
        SentinelHelper.IsTrue(string.IsNullOrEmpty(fileName));

        IEnumerable<XElement> nodes = null;
        using var stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);
        var reader = new XmlTextReader(stream);
        var document = XDocument.Load(reader);
        var root = document.Root;
        if (root != null)
        {
            nodes = table == "*"
                ? root.Elements()
                : root.Elements(table);
        }

        ////var query = from element in root.Elements()
        ////            group element.Attributes().FirstOrDefault() by element.Name;
        ////var qq = from e in query let c = e.Count() where c > 1 select e.GetEnumerator();
        ////var vvvv = qq.Cast<XAttribute>().ToList();

        return nodes;
    }
        
    #endregion
        
    #region protected virtual methods

    /// <summary>
    /// Concrete implementation by object type.
    /// </summary>
    protected virtual void OnCreateInputXml()
    {
    }

    /// <summary>
    /// Concrete implementation by object type.
    /// </summary>
    /// <returns>
    /// The data Table
    /// </returns>
    protected virtual DataTable OnGetDataTable()
    {
        return null;
    }

    #endregion

    /// <inheritdoc />
    /// <summary>
    /// Add a data model to this provider.
    /// </summary>
    /// <param name="inputDataName">Data model.</param>
    public void SetInputDataName(string inputDataName)
    {
        InputDataName = inputDataName;
    }
}
