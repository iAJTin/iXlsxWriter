
using System.IO;

using iXlsxWriter.ComponentModel.Result.Insert;

namespace iXlsxWriter.ComponentModel
{
    /// <summary>
    /// Defines allowed actions for insert objects
    /// </summary>
    public interface IInsert
    {
        /// <summary>
        /// Gets or sets the name of the sheet where it will be inserted.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing the name of the sheet where it will be inserted.
        /// </value>
        string SheetName { get; set; }


        /// <summary>
        /// Try to execute the insert action.
        /// </summary>
        /// <param name="file">file input</param>
        /// <param name="context">Input context</param>
        /// <returns>
        /// <para>
        /// A <see cref="InsertResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
        /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
        /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
        /// </para>
        /// <para>
        /// The type of the return value is <see cref="InsertResultData"/>, which contains the operation result
        /// </para>
        /// </returns>
        InsertResult Apply(string file, IInput context);

        /// <summary>
        /// Try to execute the inseert action.
        /// </summary>
        /// <param name="input">stream input</param>
        /// <param name="context">Input context</param>
        /// <returns>
        /// <para>
        /// A <see cref="InsertResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
        /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
        /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
        /// </para>
        /// <para>
        /// The type of the return value is <see cref="InsertResultData"/>, which contains the operation result
        /// </para>
        /// </returns>
        InsertResult Apply(Stream input, IInput context);
    }
}
