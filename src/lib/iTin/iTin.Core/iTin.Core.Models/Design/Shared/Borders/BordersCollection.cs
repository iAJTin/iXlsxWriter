
using iTin.Core.Helpers;
using iTin.Core.Models.Collections;
using iTin.Core.Models.Design.Enums;

using iTin.Core.Models.Design.Borders;

namespace iTin.Core.Models.Design;

/// <summary>
/// Defines a borders collection.
/// </summary>
public partial class BordersCollection : IBorders
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="BordersCollection"/> class.
    /// </summary>
    public BordersCollection() : base(null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BordersCollection"/> class.
    /// </summary>
    /// <param name="parent">The parent.</param>
    public BordersCollection(object parent) : base(parent)
    {
    }

    #endregion

    #region public static methods

    /// <summary>
    /// Returns a new border collection for specified color.
    /// </summary>
    /// <param name="borderColor">Border color</param>
    /// <value>
    /// A <see cref="BordersCollection"/> reference.
    /// </value>
    public static BordersCollection FromCustomColor(string borderColor) => new()
    {
        new BaseBorder { Color = borderColor, Position = KnownBorderPosition.Left, Show = YesNo.Yes },
        new BaseBorder { Color = borderColor, Position = KnownBorderPosition.Top, Show = YesNo.Yes },
        new BaseBorder { Color = borderColor, Position = KnownBorderPosition.Right, Show = YesNo.Yes },
        new BaseBorder { Color = borderColor, Position = KnownBorderPosition.Bottom, Show = YesNo.Yes }
    };

    /// <summary>
    /// Returns a new border collection for specified color.
    /// </summary>
    /// <param name="borderColor">Border color</param>
    /// <value>
    /// A <see cref="BordersCollection"/> reference.
    /// </value>
    public static BordersCollection FromKnownColor(KnownBorderColor borderColor) => new()
    {
        new BaseBorder { Color = borderColor.ToString(), Position = KnownBorderPosition.Left, Show = YesNo.Yes },
        new BaseBorder { Color = borderColor.ToString(), Position = KnownBorderPosition.Top, Show = YesNo.Yes },
        new BaseBorder { Color = borderColor.ToString(), Position = KnownBorderPosition.Right, Show = YesNo.Yes },
        new BaseBorder { Color = borderColor.ToString(), Position = KnownBorderPosition.Bottom, Show = YesNo.Yes }
    };

    #endregion

    #region public override methods

    /// <summary>
    /// Returns the element specified.
    /// </summary>
    /// <param name="value">The object to locate in the <see cref="BaseComplexModelCollection{TItem, TParent, TSearch}"/>.</param>
    /// <returns>
    /// Returns the specified element.
    /// </returns>
    public override BaseBorder GetBy(KnownBorderPosition value) => Find(border => border.Position == value);

    #endregion

    #region protected override methods

    /// <summary>
    /// Sets this collection as the owner of the specified item.
    /// </summary>
    /// <param name="item">Target item to set owner.</param>
    protected override void SetOwner(BaseBorder item)
    {
        SentinelHelper.ArgumentNull(item, nameof(item));

        item.SetOwner(this);
    }

    #endregion
}
