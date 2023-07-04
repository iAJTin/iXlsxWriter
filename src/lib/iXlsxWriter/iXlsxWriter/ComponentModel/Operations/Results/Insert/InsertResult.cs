
using System;
using System.Collections.Generic;

using iTin.Core.ComponentModel;

using iXlsxWriter.ComponentModel.Result.Replace;
using iXlsxWriter.ComponentModel.Result.Set;

namespace iXlsxWriter.ComponentModel.Result.Insert;

/// <summary>
/// Specialization of <see cref="ResultBase{InsertResultData}"/> interface.<br/>
/// Represents result after insert an element in <b>xlsx</b> document.
/// </summary>
public class InsertResult : ResultBase<InsertResultData>
{
    #region public new static methods

    /// <summary>
    /// Returns a new <see cref="InsertResult"/> with specified detailed error.
    /// </summary>
    /// <param name="message">Error message</param>
    /// <param name="code">Error code</param>
    /// <returns>
    /// A new invalid <see cref="InsertResult"/> with specified detailed error.
    /// </returns>
    public new static InsertResult CreateErrorResult(string message, string code = "") =>
        CreateErrorResult(
            new IResultError[]
            {
                new ResultError
                {
                    Code = code,
                    Message = message
                }
            });

    /// <summary>
    /// Returns a new <see cref="InsertResult"/> with specified detailed errors collection.
    /// </summary>
    /// <param name="errors">A errors collection</param>
    /// <returns>
    /// A new invalid <see cref="InsertResult"/> with specified detailed errors collection.
    /// </returns>
    public new static InsertResult CreateErrorResult(IResultError[] errors) =>
        new()
        {
            Result = default,
            Success = false,
            Errors = (IResultError[])errors.Clone()
        };

    /// <summary>
    /// Returns a new <see cref="InsertResult"/> with specified detailed error.
    /// </summary>
    /// <param name="message">Error message</param>
    /// <param name="result">Response Result</param>
    /// <param name="code">Error code</param>
    /// <returns>
    /// A new invalid <see cref="InsertResult"/> with specified detailed errors collection.
    /// </returns>
    public new static InsertResult CreateErrorResult(string message, InsertResultData result, string code = "") =>
        CreateErrorResult(
            new IResultError[]
            {
                new ResultError
                {
                    Code = code,
                    Message = message
                }
            },
            result);

    /// <summary>
    /// Returns a new <see cref="InsertResult"/> with specified detailed errors collection.
    /// </summary>
    /// <param name="errors">A errors collection</param>
    /// <param name="result">Response Result</param>
    /// <returns>
    /// A new invalid <see cref="InsertResult"/> with specified detailed errors collection.
    /// </returns>
    public new static InsertResult CreateErrorResult(IResultError[] errors, InsertResultData result) =>
        new()
        {
            Result = result,
            Success = false,
            Errors = (IResultError[])errors.Clone()
        };

    /// <summary>
    /// Returns a new success result.
    /// </summary>
    /// <param name="result">Response Result</param>
    /// <returns>
    /// A new valid <see cref="InsertResult"/>.
    /// </returns>
    public new static InsertResult CreateSuccessResult(InsertResultData result) =>
        new()
        {
            Result = result,
            Success = true,
            Errors = Array.Empty<IResultError>()
        };

    /// <summary>
    /// Creates a new <see cref="InsertResult"/> instance from known exception.
    /// </summary>
    /// <param name="exception">Target exception.</param>
    /// <returns>
    /// A new <see cref="InsertResult"/> instance for specified exception.
    /// </returns>
    public new static InsertResult FromException(Exception exception) => FromException(exception, default);

    /// <summary>
    /// Creates a new <see cref="InsertResult"/> instance from known exception.
    /// </summary>
    /// <param name="exception">Target exception.</param>
    /// <param name="result">Response Result</param>
    /// <returns>
    /// A new <see cref="InsertResult"/> instance for specified exception.
    /// </returns>
    public new static InsertResult FromException(Exception exception, InsertResultData result) =>
        new()
        {
            Result = result,
            Success = false,
            Errors = new List<IResultError>
            {
                new ResultExceptionError
                {
                    Exception = exception
                }
            }
        };

    #endregion

    #region public methods 

    /// <summary>
    /// Try to insert an element in this input.
    /// </summary>
    /// <param name="data">Reference to insertable object information</param>
    /// <param name="canInsert">Determines if can insert. Default is <b>true</b>.</param>
    /// <returns>
    /// Operation result.
    /// </returns>
    public InsertResult Insert(IInsert data, bool canInsert = true)
    {
        if (!canInsert)
        {
            return data == null
                ? CreateErrorResult("Missing data")
                : CreateSuccessResult(new InsertResultData
                {
                    Context = Result.Context,
                    InputStream = Result.OutputStream,
                    OutputStream = Result.OutputStream
                });
        }

        InsertResult result = InsertImplStrategy(data, Result.Context);

        if (Result.Context.AutoUpdateChanges)
        {
            Result.Context.Input = result.Result.OutputStream;
        }

        return result;
    }

    /// <summary>
    /// Try to replace an element in this input.
    /// </summary>
    /// <param name="data">Reference to replaceable object information</param>
    /// <param name="canReplace">Determines if can replace. Default is <b>true</b>.</param>
    /// <returns>
    /// Operation result.
    /// </returns>
    public ReplaceResult Replace(IReplace data, bool canReplace = true)
    {
        if (!canReplace)
        {
            return data == null
                ? ReplaceResult.CreateErrorResult("Missing data")
                : ReplaceResult.CreateSuccessResult(new ReplaceResultData
                {
                    Context = Result.Context,
                    InputStream = Result.OutputStream,
                    OutputStream = Result.OutputStream
                });
        }

        ReplaceResult result = ReplaceImplStrategy(data, Result.Context);

        if (Result.Context.AutoUpdateChanges)
        {
            Result.Context.Input = result.Result.OutputStream;
        }

        return result;
    }

    /// <summary>
    /// Try to set an element in this input.
    /// </summary>
    /// <param name="data">Reference to seteable object information</param>
    /// <param name="canSet">Determines if can set. Default is <b>true</b>.</param>
    /// <returns>
    /// Operation result.
    /// </returns>
    public SetResult Set(ISet data, bool canSet = true)
    {
        if (!canSet)
        {
            return data == null
                ? SetResult.CreateErrorResult("Missing data")
                : SetResult.CreateSuccessResult(new SetResultData
                {
                    Context = Result.Context,
                    InputStream = Result.OutputStream,
                    OutputStream = Result.OutputStream
                });
        }

        SetResult result = SetImplStrategy(data, Result.Context);

        if (Result.Context.AutoUpdateChanges)
        {
            Result.Context.Input = result.Result.OutputStream;
        }

        return result;
    }

    #endregion

    #region private methods

    private InsertResult InsertImplStrategy(IInsert data, IInput context)
        => data == null ? InsertResult.CreateErrorResult("Missing data") : data.Apply(Result.OutputStream, context);

    private ReplaceResult ReplaceImplStrategy(IReplace data, IInput context)
        => data == null ? ReplaceResult.CreateErrorResult("Missing data") : data.Apply(Result.OutputStream, context);

    private SetResult SetImplStrategy(ISet data, IInput context)
        => data == null ? SetResult.CreateErrorResult("Missing data") : data.Apply(Result.OutputStream, context);

    #endregion
}