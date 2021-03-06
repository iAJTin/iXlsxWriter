﻿
namespace iTin.Utilities.Xlsx.Writer.ComponentModel
{
    using System.IO;

    using iTin.Core.Helpers;

    using Result.Insert;

    /// <summary>
    /// Specialization of <see cref="IInsert"/> interface.<br/>
    /// Acts as base class for insert actions.
    /// </summary>
    /// <seealso cref="IInsert"/>
    public abstract class InsertBase : IInsert
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
