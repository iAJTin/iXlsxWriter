
using System.Diagnostics;
using System.Text.RegularExpressions;

using iTin.Core.Helpers;

namespace iTin.Core.Models.Helpers;

/// <summary> 
/// Static class than contains methods for creates error messages.
/// </summary>
internal static class RegularExpressionHelper
{
    #region private constants

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string IdentifierPattern = @"^[a-zA-Z0-9_%@#-]+";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string FieldNamePattern = @"^[a-zA-Z0-9_*%@#-]+";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string BindingResourcePattern = @"^(\s)*\{(\s)*inding(\s)*:[\s|\w]*[.]*(\w)*}$";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private const string StaticBindingResourcePattern = @"^(\s)*\{(\s)*StaticBinding(\s)*:[\s|\w]*[.]*(\w)*}$";

    #endregion

    #region public static methods

    /// <summary>
    /// Determines whether <paramref name="value"/> is valid identifier.
    /// </summary>
    /// <param name="value">Identifier to check.</param>
    /// <returns>
    /// <strong>true</strong> if identifier is valid; otherwise, <strong>false</strong>.
    /// </returns>
    public static bool IsValidIdentifier(string value)
    {
        SentinelHelper.ArgumentNull(value, nameof(value));

        var val = new Regex(IdentifierPattern);
        return val.IsMatch(value);
    }

    /// <summary>
    /// Determines whether <paramref name="value"/> is valid field name.
    /// </summary>
    /// <param name="value">Field to check.</param>
    /// <returns>
    /// <strong>true</strong> if field name is valid; otherwise, <strong>false</strong>.
    /// </returns>
    public static bool IsValidFieldName(string value)
    {
        SentinelHelper.ArgumentNull(value, nameof(value));

        var val = new Regex(FieldNamePattern);

        return val.IsMatch(value);
    }

    /// <summary>
    /// Determines whether <paramref name="value"/> is valid binding resource.
    /// </summary>
    /// <param name="value">String to check.</param>
    /// <returns>
    /// <strong>true</strong> if string is a valid resource; otherwise, <strong>false</strong>.
    /// </returns>
    public static bool IsBindingResource(string value)
    {
        SentinelHelper.ArgumentNull(value, nameof(value));

        var val = new Regex(BindingResourcePattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        //var val = new Regex(@"^(\s)*\{(\s)*bind(\s)*:(\s)*\w+(\s)*}$", RegexOptions.IgnoreCase | RegexOptions.Singleline);

        return val.IsMatch(value);
    }

    /// <summary>
    /// Determines whether <paramref name="value" /> is valid static resource.
    /// </summary>
    /// <param name="value">String to check.</param>
    /// <returns>
    /// <strong>true</strong> if string is a valid static resource; otherwise, <strong>false</strong>.
    /// </returns>
    public static bool IsStaticBindingResource(string value)
    {
        SentinelHelper.ArgumentNull(value, nameof(value));

        var val = new Regex(StaticBindingResourcePattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        //var val = new Regex(@"^(\s)*\{(\s)*bind(\s)*:(\s)*\w+(\s)*}$", RegexOptions.IgnoreCase | RegexOptions.Singleline);

        return val.IsMatch(value);
    }

    #endregion
}
