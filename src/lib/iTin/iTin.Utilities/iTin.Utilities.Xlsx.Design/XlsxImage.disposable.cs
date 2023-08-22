
using System;
using System.Diagnostics;

namespace iTin.Utilities.Xlsx.Design;

/// <summary>
/// Defines a <b>xlsx</b> image object.
/// </summary>
public partial class XlsxImage : IDisposable
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private bool _isDisposed;


    /// <summary>
    /// Clean managed resources
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }


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
            Image = null;
            OriginalImage?.Dispose();
            ProcessedImage?.Dispose();
        }

        // free native resources

        // avoid seconds calls 
        _isDisposed = true;
    }
}
