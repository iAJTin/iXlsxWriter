
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using iTin.Core;

using iXlsxWriter.Operations.Insert;
using iXlsxWriter.Operations.Replace;
using iXlsxWriter.Operations.Set;

namespace iXlsxWriter.Input;

/// <summary>
/// 
/// </summary>
public class XlsxInputCache
{
    #region private static readonly members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static IDictionary<IXlsxInput, IEnumerable<ISet>> SetsCacheDictionary { get; } = new Dictionary<IXlsxInput, IEnumerable<ISet>>();

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static IDictionary<IXlsxInput, IEnumerable<IInsert>> InsertsCacheDictionary { get; } = new Dictionary<IXlsxInput, IEnumerable<IInsert>>();

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static IDictionary<IXlsxInput, IEnumerable<IReplace>> ReplacementsCacheDictionary { get; } = new Dictionary<IXlsxInput, IEnumerable<IReplace>>();

    #endregion

    #region public static readonly properties

    /// <summary>
    /// Gets a reference to the available <see cref="XlsxInput"/> cache.
    /// </summary>
    /// <value>
    /// A unique <see cref="XlsxInputCache"/> reference that handles <see cref="XlsxInput"/> items.
    /// </value>
    /// <remarks>
    /// Static members are 'eagerly initialized', that is, immediately when class is loaded for the first time.
    /// .NET guarantees thread safety for static initialization.
    /// </remarks>
    public static XlsxInputCache Cache { get; } = new();

    #endregion

    #region public methods

    /// <summary>
    /// Add a collection of <see cref="IInsert"/> items for specified <see cref="XlsxInput"/> key.
    /// </summary>
    /// <param name="key">Target <see cref="XlsxInput"/>.</param>
    /// <param name="data">Target <see cref="IInsert"/> item.</param>
    public void AddInsert(IXlsxInput key, IInsert data)
    {
        var existKey = InsertsCacheDictionary.ContainsKey(key);
        if (!existKey)
        {
            InsertsCacheDictionary.Add(key, data.Yield());
        }
        else
        {
            var currentKey = InsertsCacheDictionary[key];
            var alreadyExistValue = currentKey.Contains(data);
            if (alreadyExistValue)
            {
                return;
            }

            var items = InsertsCacheDictionary[key].ToList();
            items.Add(data);
            InsertsCacheDictionary[key] = items;
        }
    }

    /// <summary>
    /// Add a collection of <see cref="IReplace"/> items for specified <see cref="XlsxInput"/> key.
    /// </summary>
    /// <param name="key">Target <see cref="XlsxInput"/>.</param>
    /// <param name="data">Target <see cref="IReplace"/> item.</param>
    public void AddReplacement(IXlsxInput key, IReplace data)
    {
        var existKey = ReplacementsCacheDictionary.ContainsKey(key);
        if (!existKey)
        {
            ReplacementsCacheDictionary.Add(key, data.Yield());
        }
        else
        {
            var currentKey = ReplacementsCacheDictionary[key];
            var alreadyExistValue = currentKey.Contains(data);
            if (alreadyExistValue)
            {
                return;
            }

            var items = ReplacementsCacheDictionary[key].ToList();
            items.Add(data);
            ReplacementsCacheDictionary[key] = items;
        }
    }

    /// <summary>
    /// Add a collection of <see cref="IReplace"/> items for specified <see cref="XlsxInput"/> key.
    /// </summary>
    /// <param name="key">Target <see cref="XlsxInput"/>.</param>
    /// <param name="data">Target <see cref="ISet"/> item.</param>
    public void AddSet(IXlsxInput key, ISet data)
    {
        var existKey = SetsCacheDictionary.ContainsKey(key);
        if (!existKey)
        {
            SetsCacheDictionary.Add(key, data.Yield());
        }
        else
        {
            var currentKey = SetsCacheDictionary[key];
            var alreadyExistValue = currentKey.Contains(data);
            if (alreadyExistValue)
            {
                return;
            }

            var items = SetsCacheDictionary[key].ToList();
            items.Add(data);
            SetsCacheDictionary[key] = items;
        }
    }



    /// <summary>
    /// 
    /// </summary>
    /// <param name="key">Target <see cref="IXlsxInput"/>.</param>
    /// <returns>
    /// The collection of available <see cref="IInsert"/> items.
    /// </returns>
    public bool AnyInserts(IXlsxInput key) => InsertsCacheDictionary.ContainsKey(key);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key">Target <see cref="IXlsxInput"/>.</param>
    /// <returns>
    /// The collection of available <see cref="IReplace"/> items.
    /// </returns>
    public bool AnyReplacements(IXlsxInput key) => ReplacementsCacheDictionary.ContainsKey(key);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key">Target <see cref="IXlsxInput"/>.</param>
    /// <returns>
    /// The collection of available <see cref="IReplace"/> items.
    /// </returns>
    public bool AnySets(IXlsxInput key) => SetsCacheDictionary.ContainsKey(key);



    /// <summary>
    /// 
    /// </summary>
    /// <param name="key">Target <see cref="IXlsxInput"/>.</param>
    /// <returns>
    /// The collection of available <see cref="IInsert"/> items.
    /// </returns>
    public IEnumerable<IInsert> GetInserts(IXlsxInput key) => InsertsCacheDictionary[key];

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key">Target <see cref="IXlsxInput"/>.</param>
    /// <returns>
    /// The collection of available <see cref="IReplace"/> items.
    /// </returns>
    public IEnumerable<IReplace> GetReplacements(IXlsxInput key) => ReplacementsCacheDictionary[key];

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key">Target <see cref="IXlsxInput"/>.</param>
    /// <returns>
    /// The collection of available <see cref="ISet"/> items.
    /// </returns>
    public IEnumerable<ISet> GetSets(IXlsxInput key) => SetsCacheDictionary[key];

    #endregion
}
