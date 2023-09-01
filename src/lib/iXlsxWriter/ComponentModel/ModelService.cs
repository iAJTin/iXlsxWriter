
using System.Linq;
using System.Xml.Linq;

using iTin.Core.Models.Data.Input;
using iTin.Core.Models.Data.Provider;
using iTin.Core.Models.Design;
using iTin.Core.Models.Design.Enums;
using iTin.Core.Models.Design.Table.Fields;

namespace iXlsxWriter.ComponentModel;

/// <summary>
/// 
/// </summary>
public class ModelService
{
    #region public static properties

    /// <summary>
    /// Returns a unique instance of the class
    /// </summary>
    public static ModelService Instance { get; } = new();

    #endregion

    #region public properties

    /// <summary>
    /// 
    /// </summary>
    public int CurrentCol { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public BaseDataField CurrentField { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public IFilter CurrentFilter { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public int CurrentRow { get; private set; }


    /// <summary>
    /// 
    /// </summary>
    public IDataInput DataInput { get; private set; }
    /// <summary>
    /// 
    /// </summary>
    public IDataProvider DataProvider { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public XElement[] RawData { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public XElement[] RawDataFiltered
    {
        get
        {
            if (CurrentFilter.Active == YesNo.No)
            {
                return RawData;
            }

            if(string.IsNullOrEmpty(CurrentFilter.Value))
            {
                return RawData;
            }

            var expression = CurrentFilter.BuildFilterExpression();
            var rows = RawData.ToList().FindAll(item => expression.IsSatisfiedBy(item));

            return (XElement[])rows.ToArray().Clone();
        }
    }

    #endregion

    #region public methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="col"></param>
    public void SetCurrentCol(int col)
    {
        CurrentCol = col;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataInput"></param>
    /// <param name="name"></param>
    public void SetDataInput(IDataInput dataInput, string name)
    {
        DataInput = dataInput;

        DataProvider = dataInput.GetDataProvider();
        DataProvider.SetInputDataName(name);
        RawData  = DataProvider.ToXml().ToArray();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filter"></param>
    public void SetFilter(IFilter filter)
    {
        CurrentFilter = filter;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="field"></param>
    public void SetCurrentField(BaseDataField field)
    {
        CurrentField = field;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="row"></param>
    public void SetCurrentRow(int row)
    {
        CurrentRow = row;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    public void SetRawData(XElement[] data)
    {
        RawData = data;
    }

    #endregion

    #region public override methods

    /// <summary>
    /// Returns a <see cref="T:System.String" /> that represents this instance.
    /// </summary>
    /// <returns>A <see cref="T:System.String" /> that represents this instance.</returns>
    public override string ToString() => 
        $"Model=\"\"";

    #endregion
}
