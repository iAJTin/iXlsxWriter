
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
//using System.Data;

using iTin.Core.Helpers;

using iXlsxWriter.ComponentModel.DataProvider;

namespace iXlsxWriter.ComponentModel.DataInput;

/// <summary>
/// Class than allows you to export an object of type <see cref="System.Data.DataRow"/>.
/// </summary>
[InputOptions(AdapterType = typeof(DataSetProvider))]
public class DataRowInput : DataSetInput
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DataRowInput" /> class.
    /// </summary>
    /// <param name="rows">A <see cref="System.Data.DataRow"/> array object than contains the information.</param>
    /// <param name="name">The name.</param>
    protected DataRowInput(IEnumerable<System.Data.DataRow> rows, string name)
        : base(SentinelHelper.PassThroughNonNull(CreateDataSetFrom(rows, name)))
    {
    }

    /// <summary>
    /// Creates the data set from.
    /// </summary>
    /// <param name="rows">The rows.</param>
    /// <param name="name">The name.</param>
    /// <returns>
    /// <see cref="System.Data.DataSet" /> which contains the specified rows.
    /// </returns>
    private static System.Data.DataSet CreateDataSetFrom(IEnumerable<System.Data.DataRow> rows, string name)
    {

        DataTable dt = LoadTableFromEnumerable(rows, table: null, options: null, errorHandler: null);
        //var dt = rows.CopyToDataTable();

        dt.TableName = name;

        using var tempDs = new System.Data.DataSet();
        tempDs.Locale = dt.Locale;
        tempDs.Tables.Add(dt);

        var ds = tempDs;

        return ds;
    }

    private static DataTable LoadTableFromEnumerable<T>(IEnumerable<T> source, DataTable table, LoadOption? options, FillErrorEventHandler errorHandler)
    where T : DataRow
    {
        if (options.HasValue)
        {
            switch (options.Value)
            {
                case LoadOption.OverwriteChanges:
                case LoadOption.PreserveChanges:
                case LoadOption.Upsert:
                    break;
                default:
                    throw new Exception(); //DataSetUtil.InvalidLoadOption(options.Value);
            }
        }


        using (IEnumerator<T> rows = source.GetEnumerator())
        {
            // need to get first row to create table
            if (!rows.MoveNext())
            {
                new Exception(); //return table ?? throw DataSetUtil.InvalidOperation(SR.DataSetLinq_EmptyDataRowSource);
            }

            DataRow current;
            if (table == null)
            {
                current = rows.Current;
                if (current == null)
                {
                    new Exception(); //throw DataSetUtil.InvalidOperation(SR.DataSetLinq_NullDataRow);
                }

                table = new DataTable()
                {
                    Locale = CultureInfo.CurrentCulture
                };

                // We do not copy the same properties that DataView.ToTable does.
                // If user needs that functionality, use other CopyToDataTable overloads.
                // The reasoning being, the IEnumerator<DataRow> can be sourced from
                // different DataTable, so we just use the "Default" instead of resolving the difference.

                foreach (DataColumn column in current.Table.Columns)
                {
                    table.Columns.Add(column.ColumnName, column.DataType);
                }
            }

            table.BeginLoadData();
            try
            {
                do
                {
                    current = rows.Current;
                    if (current == null)
                    {
                        continue;
                    }

                    object[] values = null;
                    try
                    {
                        // 'recoverable' error block
                        switch (current.RowState)
                        {
                            case DataRowState.Detached:
                                if (!current.HasVersion(DataRowVersion.Proposed))
                                {
                                    throw new Exception(); //DataSetUtil.InvalidOperation(SR.DataSetLinq_CannotLoadDetachedRow);
                                }
                                goto case DataRowState.Added;
                            case DataRowState.Unchanged:
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                values = current.ItemArray;
                                if (options.HasValue)
                                {
                                    table.LoadDataRow(values, options.Value);
                                }
                                else
                                {
                                    table.LoadDataRow(values, fAcceptChanges: true);
                                }
                                break;
                            case DataRowState.Deleted:
                                throw new Exception(); // DataSetUtil.InvalidOperation(SR.DataSetLinq_CannotLoadDeletedRow);
                            default:
                                throw new Exception(); //DataSetUtil.InvalidDataRowState(current.RowState);
                        }
                    }
                    catch (Exception e)
                    {
                        //if (!DataSetUtil.IsCatchableExceptionType(e))
                        //{
                        //    throw;
                        //}

                        FillErrorEventArgs fillError = null;
                        if (null != errorHandler)
                        {
                            fillError = new FillErrorEventArgs(table, values)
                            {
                                Errors = e
                            };
                            errorHandler.Invoke(rows, fillError);
                        }
                        if (null == fillError)
                        {
                            throw;
                        }
                        else if (!fillError.Continue)
                        {
                            if (ReferenceEquals(fillError.Errors ?? e, e))
                            {
                                // if user didn't change exception to throw (or set it to null)
                                throw;
                            }
                            else
                            {
                                // user may have changed exception to throw in handler
                                throw fillError.Errors;
                            }
                        }
                    }
                } while (rows.MoveNext());
            }
            finally
            {
                table.EndLoadData();
            }
        }

        return table;
    }

}
