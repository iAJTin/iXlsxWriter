
using System;

using iTin.Core;

namespace iXlsxWriter;

public partial class XlsxInput : ICloneable
{
    /// <summary>
    /// Create a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new <see cref="object"/> that is a copy of this instance.
    /// </returns>
    object ICloneable.Clone() => Clone();


    /// <summary>
    /// Create a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new <see cref="XlsxInput"/> that is a copy of this instance.
    /// </returns>
    public XlsxInput Clone()
    {
        var clonned = (XlsxInput)MemberwiseClone();
        clonned.Input = ToStream().Clone();

        return clonned;
    }
}
