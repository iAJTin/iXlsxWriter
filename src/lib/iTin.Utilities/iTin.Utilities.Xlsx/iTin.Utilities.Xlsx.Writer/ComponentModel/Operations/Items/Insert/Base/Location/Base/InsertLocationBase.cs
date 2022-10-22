
using System.IO;

using iTin.Core.Helpers;

using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Insert;

namespace iTin.Utilities.Xlsx.Writer.ComponentModel
{
    /// <summary>
    /// Specialization of <see cref="ILocationInsert"/> interface.<br/>
    /// Acts as base class for insert actions
    /// </summary>
    /// <seealso cref="ILocationInsert"/>
    public abstract class InsertLocationBase : ILocationInsert
    {
        #region interface

        #region IInsert

        #region public properties

        #region [public] (string) SheetName: Gets or sets the name of the sheet where it will be inserted
        /// <summary>
        /// Gets or sets the name of the sheet where it will be inserted.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing the name of the sheet where it will be inserted.
        /// </value>
        public string SheetName { get; set; }
        #endregion

        #endregion

        #region public methods

        #region [public] (InsertResult) Apply(string, IInput): Try to execute the insert action 
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
        public InsertResult Apply(string file, IInput context) => Apply(StreamHelper.TextFileToStream(file), context);
        #endregion

        #region [public] (InsertResult) Apply(Stream, IInput): Try to execute the insert action 
        /// <summary>
        /// Try to execute the insert action.
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
        public InsertResult Apply(Stream input, IInput context) => InsertImpl(input, context);
        #endregion

        #endregion

        #endregion

        #region ILocationInsert

        #region public properties

        #region [public] (XlsxBaseRange) Location: Gets or sets a reference a XlsxBaseRange which represents the insert location
        /// <summary>
        /// Gets or sets a reference a <see cref="XlsxBaseRange"/> which represents the insert location.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxBaseRange"/> object that contains the insert location.
        /// </value>
        public XlsxBaseRange Location { get; set; }
        #endregion

        #endregion

        #endregion

        #endregion

        #region protected abtract methods

        #region [public] {abstract} (InsertResult) InsertImpl(Stream, IInput): Implementation to execute when insert action 
        /// <summary>
        /// Implementation to execute when insert action.
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
        protected abstract InsertResult InsertImpl(Stream input, IInput context);
        #endregion

        #endregion
    }
}
