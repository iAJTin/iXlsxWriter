
using System;
using System.Linq;
using System.Reflection;
using iXlsxWriter.ComponentModel.DataProvider;

namespace iXlsxWriter.ComponentModel.DataInput;

/// <summary>
/// Base class for the different input types.
/// Which acts as the base class for the different input types.
/// </summary>
/// <remarks>
///   <para>
///   The following table shows the different input types.
///   </para>
///   <list type="table">
///     <listheader>
///       <term>Class</term>
///       <description>Description</description>
///     </listheader>
///     <item>
///       <term><see cref="T:iTin.Export.Inputs.ArraListInput" /></term>
///       <description>Represents an input for array of <see cref="T:System.Collections.ArrayList" /> types. For more information please see <see cref="T:iTin.Export.Inputs.ArraListInput" /></description>
///     </item>
///     <item>
///       <term><see cref="T:iTin.Export.Inputs.DataRowInput" /></term>
///       <description>Represents an input for array of <see cref="T:System.Data.DataRow" /> types. For more information please see <see cref="T:iTin.Export.Inputs.DataRowInput" /></description>
///     </item>
///     <item>
///       <term><see cref="T:iTin.Export.Inputs.DataSetInput" /></term>
///       <description>Represents an input for <see cref="T:System.Data.DataSet" /> types. For more information please see <see cref="T:iTin.Export.Inputs.DataSetInput" /></description>
///     </item>
///     <item>
///       <term><see cref="T:iTin.Export.Inputs.DataTableInput" /></term>
///       <description>Represents an input for <see cref="T:System.Data.DataTable" /> types. For more information please see <see cref="T:iTin.Export.Inputs.DataTableInput" /></description>
///     </item>
///     <item>
///       <term><see cref="T:iTin.Export.Inputs.EnumerableInput" /></term>
///       <description>Represents an input for <see cref="T:System.Collections.Generic.IEnumerable{DataRow}" /> types. For more information please see <see cref="T:iTin.Export.Inputs.EnumerableInput" /></description>
///     </item>
///     <item>
///       <term><see cref="T:iTin.Export.Inputs.XmlInput" /></term>
///       <description>Represents an input for <c>Xml</c> type. For more information please see <see cref="T:iTin.Export.Inputs.XmlInput" /></description>
///     </item>
///     <item>
///       <term><see cref="T:iTin.Export.Inputs.JsonInput" /></term>
///       <description>Represents an input for <c>Json</c> type. For more information please see <see cref="T:iTin.Export.Inputs.JsonInput" /></description>
///     </item>
///   </list>
/// </remarks>
public abstract class BaseDataInput : IDataInput
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseDataInput" /> class.
    /// </summary>
    /// <param name="data">The data.</param>
    protected BaseDataInput(object data)
    {
        Data = data;
    }

    #endregion

    #region public properties

    /// <summary>
    /// Gets a reference that contains the input data to export.
    /// </summary>
    /// <value>
    /// A <see cref="T:System.Object" /> that contains the input data to export.
    /// </value>
    public object Data
    {
        get; protected set;
    }

    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public IDataProvider GetDataProvider()
    {
        var attributes = this.GetType().GetCustomAttributes(false);
        var inputOptionAttribute = (InputOptionsAttribute)attributes.SingleOrDefault(attr => attr is InputOptionsAttribute);

        var dataProvider = inputOptionAttribute!.AdapterType;
        var dataProviderInstance = Activator.CreateInstance(dataProvider, args: new[] { Data });

        return (IDataProvider)dataProviderInstance;
    }
}
