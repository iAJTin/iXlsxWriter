
using System;
using System.Collections.Generic;

using iTin.Core.ComponentModel;

namespace iXlsxWriter.ComponentModel.Result.Output
{
    /// <summary>
    /// Specialization of <see cref="ResultBase{OutputResultData}"/> interface.<br/>
    /// Represents configuration information for an object <see cref="OutputResult"/>.
    /// </summary>
    public class OutputResult : ResultBase<OutputResultData>
    {
        /// <summary>
        /// Returns a new <see cref="OutputResult"/> with specified detailed error.
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="code">Error code</param>
        /// <returns>
        /// A new invalid <see cref="OutputResult"/> with specified detailed error.
        /// </returns>
        public new static OutputResult CreateErrorResult(string message, string code = "") =>
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
        /// Returns a new <see cref="OutputResult"/> with specified detailed errors collection.
        /// </summary>
        /// <param name="errors">A errors collection</param>
        /// <returns>
        /// A new invalid <see cref="OutputResult"/> with specified detailed errors collection.
        /// </returns>
        public new static OutputResult CreateErrorResult(IResultError[] errors) =>
            new()
            {
                Result = default,
                Success = false,
                Errors = (IResultError[])errors.Clone()
            };

        /// <summary>
        /// Returns a new <see cref="OutputResult"/> with specified detailed error.
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="result">Response Result</param>
        /// <param name="code">Error code</param>
        /// <returns>
        /// A new invalid <see cref="OutputResult"/> with specified detailed errors collection.
        /// </returns>
        public new static OutputResult CreateErrorResult(string message, OutputResultData result, string code = "") =>
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
        /// Returns a new <see cref="OutputResult"/> with specified detailed errors collection.
        /// </summary>
        /// <param name="errors">A errors collection</param>
        /// <param name="result">Response Result</param>
        /// <returns>
        /// A new invalid <see cref="OutputResult"/> with specified detailed errors collection.
        /// </returns>
        public new static OutputResult CreateErrorResult(IResultError[] errors, OutputResultData result) =>
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
        /// A new valid <see cref="OutputResult"/>.
        /// </returns>
        public new static OutputResult CreateSuccessResult(OutputResultData result) =>
            new()
            {
                Result = result,
                Success = true,
                Errors = Array.Empty<IResultError>()
            };

        /// <summary>
        /// Creates a new <see cref="OutputResult"/> instance from known exception.
        /// </summary>
        /// <param name="exception">Target exception.</param>
        /// <returns>
        /// A new <see cref="OutputResult"/> instance for specified exception.
        /// </returns>
        public new static OutputResult FromException(Exception exception) => FromException(exception, default);

        /// <summary>
        /// Creates a new <see cref="OutputResult"/> instance from known exception.
        /// </summary>
        /// <param name="exception">Target exception.</param>
        /// <param name="result">Response Result</param>
        /// <returns>
        /// A new <see cref="OutputResult"/> instance for specified exception.
        /// </returns>
        public new static OutputResult FromException(Exception exception, OutputResultData result) =>
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
    }
}
