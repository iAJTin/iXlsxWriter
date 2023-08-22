
using System;

namespace iTin.Utilities.Xlsx.Design.Shared;

public partial class XlsxPoint : IEquatable<XlsxPoint>
{
    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>
    /// <b>true</b> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <b>false</b>.
    /// </returns>
    public bool Equals(XlsxPoint other) => other != null && other.Equals((object)this);


    /// <summary>
    /// Returns a value that represents the hash code for this class.
    /// </summary>
    /// <returns>
    /// Hash code for this class.
    /// </returns>
    public override int GetHashCode() => Column.GetHashCode() ^ Row.GetHashCode() ^ AbsoluteStrategy.GetHashCode();

    /// <summary>
    /// Returns a value that indicates whether this class is equal to another
    /// </summary>
    /// <param name="obj">Class with which to compare.</param>
    /// <returns>
    /// Results equality comparison.
    /// </returns>
    public override bool Equals(object obj)
    {
        if (obj is not XlsxPoint other)
        {
            return false;
        }

        return 
            other.Column == Column &&
            other.Row == Row;
    }
}
