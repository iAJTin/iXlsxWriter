
namespace iTin.Utilities.Xlsx.Writer.ComponentModel
{
    using System.IO;

    using Result.Set;

    /// <summary>
    /// Defines allowed actions for set features to worksheets.
    /// </summary>
    public interface ISet
    {
        /// <summary>
        /// Gets or sets the name of the sheet where it will be setted.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing the name of the sheet where it will be setted.
        /// </value>
        string SheetName { get; set; }


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
        SetResult Apply(string file, IInput context);

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
        SetResult Apply(Stream input, IInput context);
    }
}
