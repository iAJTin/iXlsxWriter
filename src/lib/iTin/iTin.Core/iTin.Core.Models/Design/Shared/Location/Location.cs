
using System;
using System.Xml.Serialization;

using iTin.Core.Models.Design.Enums;

namespace iTin.Core.Models.Design;

/// <summary>
/// 
/// </summary>
public partial class Location 
{
    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="Location"/> class.
    /// </summary>
    public Location()
    {
        Mode = new ByCoordenates();
    }

    #endregion

    #region public readonly properties

    /// <summary>
    /// 
    /// </summary>
    /// <value>
    ///
    /// </value>
    public KnownElementLocation LocationType
    {
        get
        {
            var positionTypeValue = Mode.GetType().Name;

            return positionTypeValue switch
            {
                "ByAlignment" => KnownElementLocation.ByAlignment,
                "ByCoordenates" => KnownElementLocation.ByCoordenates,
                _ => throw new InvalidOperationException()
            };
        }
    }

    #endregion

    #region public properties

    /// <summary>
    /// 
    /// </summary>
    /// <value>
    ///
    /// </value>
    [XmlElement("ByAlignment", typeof(ByAlignment))]
    [XmlElement("ByCoordenates", typeof(ByCoordenates))]
    public object Mode { get; set; }

    #endregion

    #region public override readonly properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    public override bool IsDefault =>
        base.IsDefault &&
        LocationType.Equals(KnownElementLocation.ByCoordenates);

    #endregion
}
