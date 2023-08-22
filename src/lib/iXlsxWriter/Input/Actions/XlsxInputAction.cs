
using iXlsxWriter.Operations.Insert;
using iXlsxWriter.Operations.Replace;
using iXlsxWriter.Operations.Set;

namespace iXlsxWriter.Input;

/// <summary>
/// 
/// </summary>
public class XlsxInputAction : IXlsxInputAction
{
    #region constructor/s

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    internal XlsxInputAction(IXlsxInput input)
    {
        Input = input;
    }

    #endregion

    #region private readonly properties

    private IXlsxInput Input { get; }

    #endregion

    #region public methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public IXlsxInputAction Insert(IInsert data)
    {
        XlsxInputCache.Cache.AddInsert(Input, data);

        return new XlsxInputAction(Input);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public IXlsxInputAction Replace(IReplace data)
    {
        XlsxInputCache.Cache.AddReplacement(Input, data);

        return new XlsxInputAction(Input);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public IXlsxInputAction Set(ISet data)
    {
        XlsxInputCache.Cache.AddSet(Input, data);

        return new XlsxInputAction(Input);
    }

    #endregion
}
