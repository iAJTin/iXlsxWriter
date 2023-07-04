
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Xml.Serialization;

using iTin.Core.Helpers;

namespace iTin.Core.Models.Design;

/// <summary>
/// 
/// </summary>
public partial class ByCoordenates
{
    #region private static readonly

    private static readonly int[] DefaultCoordenates = { 1, 1 };

    #endregion

    #region private members

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private int[] _coordenates;

    #endregion

    #region constructor/s

    /// <summary>
    /// Initializes a new instance of the <see cref="ByCoordenates"/> class.
    /// </summary>
    public ByCoordenates()
    {
        Coordenates = DefaultCoordenates;
    }

    #endregion

    #region public readonly properties

    /// <summary>
    /// 
    /// </summary>
    /// <value>
    ///
    /// </value>
    public Point TableCoordenates => new(Coordenates[0], Coordenates[1]);

    #endregion

    #region public properties

    /// <summary>
    /// 
    /// </summary>
    /// <value>
    /// 
    /// </value>
    [XmlAttribute]
    [DefaultValue(new[] { 1, 1 })]
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    public int[] Coordenates
    {
        get => _coordenates ??= DefaultCoordenates;
        set
        {
            if (value != null)
            {
                SentinelHelper.IsTrue(value.Length > 2, "Maximum 2 values");
                SentinelHelper.IsTrue(value[0] < 0, "The horizontal coordinate cannot be less than zero");
                SentinelHelper.IsTrue(value[1] < 0, "The vertical coordinate cannot be less than zero");

                _coordenates = value;
            }
        }
    }

    #endregion

    #region public override readonly properties

    /// <summary>
    /// Gets a value indicating whether this instance is default.
    /// </summary>
    /// <value>
    /// <b>true</b> if this instance contains the default; otherwise, <b>false</b>.
    /// </value>
    [Browsable(false)]
    public override bool IsDefault => 
        base.IsDefault &&
        Coordenates.SequenceEqual(DefaultCoordenates);

    #endregion
}
