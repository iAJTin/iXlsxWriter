
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;

namespace iXlsxWriter.ComponentModel.DataProvider;

/// <summary>
/// Declares a generic data provider.
/// </summary>
public interface IDataProvider
{        
    /// <summary>
    /// 
    /// </summary>
    string InputDataName { get; }

    /// <summary>
    /// Gets a value indicating whether you can create an <strong>Xml</strong> file from the current instance of the object.
    /// </summary>
    /// <value>
    /// <strong>true</strong> if you can create an <strong>Xml</strong>; otherwise, <strong>false</strong>.
    /// </value>
    bool CanCreateInputXml { get; }

    /// <summary>
    /// Gets a value indicating whether this instance can get data table.
    /// </summary>
    /// <value>
    /// <strong>true</strong> if this instance can get data table; otherwise, <strong>false</strong>.
    /// </value>
    bool CanGetDataTable { get; }

    /// <summary>
    /// Gets the input Uri.
    /// </summary>
    /// <value>
    /// Reference to the input file.
    /// </value>
    Uri InputUri { get; }

    /// <summary>
    /// Gets an special char array.
    /// </summary>
    /// <value>
    /// Special char array.
    /// </value>
    IEnumerable<char> SpecialChars { get; }

    /// <summary>
    /// Gets a reference to the <see cref="DataTable" /> object than contains the data this instance.
    /// </summary>
    /// <returns>
    /// Reference to the <see cref="DataTable" /> object.
    /// </returns>
    DataTable ToDataTable();

    /// <summary>
    /// Gets a reference to the <see cref="IEnumerable{XElement}" /> object than contains the data this instance.
    /// </summary>
    /// <returns>
    /// Reference to the <see cref="IEnumerable{XElement}" /> object.
    /// </returns>
    IEnumerable<XElement> ToXml();

    /// <summary>
    /// Parse an <see cref="string" /> and replace the special chars defined in <see cref="SpecialChars" /> by a hexadecimal pattern.
    /// </summary>
    /// <param name="value"><see cref="string" /> to parse</param>
    /// <returns>
    /// Parsed <see cref="string" />.
    /// </returns>
    /// <remarks>
    /// Analyzes the argument <paramref name="value" />, replacing <see cref="SpecialChars" /> by the pattern '_x####_', where:
    /// ####: Represents ASCII char code in Hexadecimal format
    /// If the argument <paramref name="value" /> does not contain any <see cref="SpecialChars" /> returns the argument unchanged.
    /// </remarks>        
    string Parse(string value);

    /// <summary>
    /// Sets an special char array to this provider.
    /// </summary>
    /// <param name="value">Special chars array.</param>
    void SetSpecialChars(IEnumerable<char> value);

    /// <summary>
    /// Creates the <b>Xml</b> source file from.
    /// </summary>
    void CreateInputXml();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="inputDataName"></param>
    void SetInputDataName(string inputDataName);
}
