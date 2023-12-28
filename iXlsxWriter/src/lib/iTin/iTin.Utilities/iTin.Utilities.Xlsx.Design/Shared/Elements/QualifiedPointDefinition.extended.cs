﻿
namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class QualifiedPointDefinition
{
    /// <summary>
    /// Returns a string that represents the current data type.
    /// </summary>
    /// <returns>
    /// A <see cref="string"/> than represents the current object.
    /// </returns>
    public override string ToString() => $"WorkSheet=\"{WorkSheet}\", Point=\"{Point}\"";
}