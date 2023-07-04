﻿
using System;

namespace iXlsxWriter.ComponentModel;

/// <summary>
/// Specifies the known input type.
/// </summary>
[Serializable]
public enum KnownInputType
{
    /// <summary>
    /// Input file type as path
    /// </summary>
    Filename,

    /// <summary>
    /// Input file type as stream
    /// </summary>
    Stream,

    /// <summary>
    /// Input file type as byte array sequence
    /// </summary>
    ByteArray,

    /// <summary>
    /// Input file type as <see cref="T:iXlsxWriter.XlsxInput"/>
    /// </summary>
    XlsxInput,

    /// <summary>
    /// Input file type not supported
    /// </summary>
    NotSupported
}
