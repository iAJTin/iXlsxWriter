
using System.IO;

using iTin.Core.Helpers;

using iXlsxWriter.ComponentModel.Result.Set;

namespace iXlsxWriter.ComponentModel;

/// <summary>
/// Specialization of <see cref="ISet"/> interface.<br/>
/// Acts as base class for set actions
/// </summary>
/// <seealso cref="ISet"/>
public abstract class SetBase : ISet
{
    #region interface

    #region ISet

    #region public properties

    /// <summary>
    /// Gets or sets the name of the sheet where it will be inserted.
    /// </summary>
    /// <value>
    /// A <see cref="string"/> containing the name of the sheet where it will be inserted.
    /// </value>
    public string SheetName { get; set; }

    #endregion

    #region public methods

    /// <summary>
    /// Try to execute the set action.
    /// </summary>
    /// <param name="file">file input</param>
    /// <param name="context">Input context</param>
    /// <returns>
    /// <para>
    /// A <see cref="SetResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return value is <see cref="SetResultData"/>, which contains the operation result
    /// </para>
    /// </returns>
    public SetResult Apply(string file, IInput context) => Apply(StreamHelper.TextFileToStream(file), context);

    /// <summary>
    /// Try to execute the set action.
    /// </summary>
    /// <param name="input">stream input</param>
    /// <param name="context">Input context</param>
    /// <returns>
    /// <para>
    /// A <see cref="SetResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return value is <see cref="SetResultData"/>, which contains the operation result
    /// </para>
    /// </returns>
    public SetResult Apply(Stream input, IInput context) => SetImpl(input, context);

    #endregion

    #endregion

    #endregion

    #region protected abtract methods

    /// <summary>
    /// Implementation to execute when set action.
    /// </summary>
    /// <param name="input">stream input</param>
    /// <param name="context">Input context</param>
    /// <returns>
    /// <para>
    /// A <see cref="SetResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return value is <see cref="SetResultData"/>, which contains the operation result
    /// </para>
    /// </returns>
    protected abstract SetResult SetImpl(Stream input, IInput context);

    #endregion
}
