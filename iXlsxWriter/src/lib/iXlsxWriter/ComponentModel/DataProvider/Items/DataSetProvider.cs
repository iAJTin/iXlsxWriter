
using System;
using System.Data;
using System.Diagnostics;
using System.IO;

using iTin.Core.IO;

namespace iXlsxWriter.ComponentModel.DataProvider;

/// <summary>
/// A Specialization of <see cref="BaseDataProvider" /><br/>
/// Represents a source object based on the <see cref="DataSet" />.
/// </summary>
public class DataSetProvider : BaseDataProvider
{
    #region private readonly members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly DataSet _dataSet;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="DataSetProvider" /> class.
    /// </summary>
    /// <param name="dataSet">A <see cref="DataSet" /> object than contains the information.</param>            
    public DataSetProvider(DataSet dataSet) 
    {
        _dataSet = dataSet;
    }

    #endregion

    #region public override readonly properties

    /// <summary>
    /// Gets a value indicating whether you can create an <strong>Xml</strong> file from the current instance of the object.
    /// </summary>
    /// <value>
    /// Always returns <strong>true</strong>.
    /// </value>
    public override bool CanCreateInputXml => true;

    /// <summary>
    /// Gets a value indicating whether this instance can get data table.
    /// </summary>
    /// <value>
    /// Always returns <strong>true</strong>.
    /// </value>
    public override bool CanGetDataTable => true;

    #endregion

    #region protected override methods

    /// <inheritdoc />

    protected override void OnCreateInputXml()
    {
        if (_dataSet == null)
        {
            return;
        }

        if (!_dataSet.GetType().Name.Equals("GenericDataLinkDataSet", StringComparison.OrdinalIgnoreCase))
        {
            using var ds = _dataSet.Copy();
            var tables = ds.Tables;
            foreach (DataTable table in tables)
            {
                var columns = table.Columns;
                foreach (DataColumn column in columns)
                {
                    column.ColumnName = column.ColumnName.ToUpperInvariant();
                    column.ColumnMapping = MappingType.Attribute;
                }
            }

            using var stream = new MemoryStream();
            ds.WriteXml(stream);
            stream.SaveToFile(InputUri.AbsolutePath);
        }
        else
        {
            var tables = _dataSet.Tables;
            foreach (DataTable table in tables)
            {
                var columns = table.Columns;
                foreach (DataColumn column in columns)
                {
                    column.ColumnMapping = MappingType.Attribute;
                }
            }

            using var stream = new MemoryStream();
            _dataSet.WriteXml(stream);
            stream.SaveToFile(InputUri.AbsolutePath);
        }
    }

    /// <summary>
    /// Gets a reference to the <see cref="DataTable" /> object that contains the data this instance.
    /// </summary>
    /// <returns>
    /// Reference to the <see cref="DataTable" /> object.
    /// </returns>
    protected override DataTable OnGetDataTable()
    {
        if (_dataSet == null)
        {
            return null;
        }

        DataTable dt;
        if (!_dataSet.GetType().Name.Equals("GenericDataLinkDataSet", StringComparison.OrdinalIgnoreCase))
        {
            var ds = _dataSet.Copy();
            dt = ds.Tables[""]; //Input.Model.Table.Name];
        }
        else
        {
            dt = _dataSet.Tables[""]; //Input.Model.Table.Name];                
        }

        return dt;
    }

    #endregion
}
