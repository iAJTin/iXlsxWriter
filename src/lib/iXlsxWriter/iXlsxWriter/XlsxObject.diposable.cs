
using System;
using System.Diagnostics;
using System.IO;

using iXlsxWriter.ComponentModel;

namespace iXlsxWriter;

public partial class XlsxObject : IDisposable
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
}
