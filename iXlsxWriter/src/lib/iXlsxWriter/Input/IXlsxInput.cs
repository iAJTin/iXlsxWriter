
using System;

using iXlsxWriter.Abstractions.Writer.Input;
using iXlsxWriter.Operations.Insert;
using iXlsxWriter.Operations.Replace;
using iXlsxWriter.Operations.Set;

namespace iXlsxWriter.Input;

/// <summary>
/// Defines a generic input
/// </summary>
public interface IXlsxInput : IInput, IDisposable
{
    /// <summary>
    /// Try to insert an element in this input.
    /// </summary>
    /// <param name="data">Reference to insertable object information</param>
    /// <returns>
    /// <para>
    /// A <see cref="IXlsxInputAction"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return value is <see cref="IXlsxInputAction"/>, which contains the operation result
    /// </para>
    /// </returns>
    IXlsxInputAction Insert(IInsert data);

    /// <summary>
    /// Try to replace an element in this input.
    /// </summary>
    /// <param name="data">Reference to replazable object information</param>
    /// <returns>
    /// <para>
    /// A <see cref="IXlsxInputAction"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return value is <see cref="IXlsxInputAction"/>, which contains the operation result
    /// </para>
    /// </returns>
    IXlsxInputAction Replace(IReplace data);

    /// <summary>
    /// Try to set an element in this input.
    /// </summary>
    /// <param name="data">Reference to insertable object information</param>
    /// <returns>
    /// <para>
    /// A <see cref="IXlsxInputAction"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return value is <see cref="IXlsxInputAction"/>, which contains the operation result
    /// </para>
    /// </returns>
    IXlsxInputAction Set(ISet data);
}
