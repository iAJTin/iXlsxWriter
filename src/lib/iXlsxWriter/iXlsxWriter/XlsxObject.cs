
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using iXlsxWriter.Abstractions.Writer;

namespace iXlsxWriter;

/// <summary>
/// Represents a generic xlsx object, this allows add docx files to <see cref="XlsxObject.Items"/> property and specify a user custom configuration.
/// </summary>
public class XlsxObject : IDisposable

#if NETCOREAPP3_1 || NETSTANDARD2_1 || NET5_0_OR_GREATER

, IAsyncDisposable

#endif

{
    #region private field members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private bool _isDisposed;

    #endregion

    #region constructor/s

    /// <inheritdoc />
    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxObject"/> class with default configuration.
    /// </summary>
    public XlsxObject() : this(XlsxObjectConfig.Default)
    {     
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XlsxObject"/> class with specified configuration
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    public XlsxObject(XlsxObjectConfig configuration)
    {
        Configuration = configuration;
        Items = new List<XlsxInput>();
    }

    #endregion

    #region finalizer

    /// <summary>
    /// Finalizer
    /// </summary>
    ~XlsxObject()
    {
        Dispose(false);
    }

    #endregion

    #region interfaces

    #region IDisposable

    #region public methods

    /// <summary>
    /// Clean managed resources
    /// </summary>
    public void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }

    #endregion

    #endregion

#if NETCOREAPP3_1 || NETSTANDARD2_1 || NET5_0_OR_GREATER

    #region IAsyncDisposable

    #region public async methods

    /// <summary>
    /// Clean managed resources
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true);

        GC.SuppressFinalize(this);
    }

    #endregion

    #endregion

#endif


    #endregion

    #region public properties

    /// <summary>
    /// Gets or sets the xlsx input list.
    /// </summary>
    /// <value>
    /// The items.
    /// </value>
    public IEnumerable<XlsxInput> Items { get; set; }

    /// <summary>
    /// Gets the configuration settings.
    /// </summary>
    /// <value>
    /// The object configuration.
    /// </value>
    public XlsxObjectConfig Configuration { get; }

    #endregion
    
    #region public override methods

    /// <summary>
    /// Returns a string that represents the current data type.
    /// </summary>
    /// <returns>
    /// A <see cref="string"/> than represents the current object.
    /// </returns>
    public override string ToString() =>
        $"Count={Items.Count()}";

    #endregion

    #region protected virtual methods

    /// <summary>
    /// Cleans managed and unmanaged resources.
    /// </summary>
    /// <param name="disposing">
    /// If it is <b>true</b>, the method is invoked directly or indirectly from the user code.
    /// If it is <b>false</b>, the method is called the finalizer and only unmanaged resources are finalized.
    /// </param>
    protected virtual void Dispose(bool disposing)
    {
        if (_isDisposed)
        {
            return;
        }

        // free managed resources
        if (disposing)
        {
            foreach (var item in Items)
            {
                switch (item.InputType)
                {
                    case KnownInputType.Stream:
                        ((Stream)item.Input)?.Dispose();
                        break;

                    case KnownInputType.ByteArray:
                        item.Input = null;
                        break;

                    case KnownInputType.Filename:
                        item.Input = null;
                        break;

                    case KnownInputType.NotSupported:
                        // nothing to do
                        break;
                }
            }

            Items = null;
        }

        // free native resources

        // avoid seconds calls 
        _isDisposed = true;
    }

    #endregion

#if NETCOREAPP3_1 || NETSTANDARD2_1 || NET5_0_OR_GREATER

    #region protected virtual async methods

    /// <summary>
    /// Cleans managed and unmanaged resources.
    /// </summary>
    /// <param name="disposing">
    /// If it is <b>true</b>, the method is invoked directly or indirectly from the user code.
    /// If it is <b>false</b>, the method is called the finalizer and only unmanaged resources are finalized.
    /// </param>
    protected virtual async ValueTask DisposeAsync(bool disposing)
    {
        if (_isDisposed)
        {
            return;
        }

        // free managed resources
        if (disposing)
        {
            foreach (var item in Items)
            {
                switch (item.InputType)
                {
                    case KnownInputType.Stream:

                        var inputAsStream = (Stream)item.Input;
                        if (inputAsStream != null)
                        {
                            await inputAsStream.DisposeAsync();
                        }
                        break;

                    case KnownInputType.ByteArray:
                        item.Input = null;
                        break;

                    case KnownInputType.Filename:
                        item.Input = null;
                        break;

                    case KnownInputType.NotSupported:
                        // nothing to do
                        break;
                }
            }

            Items = null;
        }

        // free native resources

        // avoid seconds calls 
        _isDisposed = true;
    }

    #endregion

#endif
}
