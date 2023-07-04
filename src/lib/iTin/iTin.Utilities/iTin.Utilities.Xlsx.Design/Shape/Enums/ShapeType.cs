
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iTin.Utilities.Xlsx.Design.Shape;

/// <summary>
/// Specifies shape type values
/// </summary>
[Serializable]
[JsonConverter(typeof(StringEnumConverter))]
public enum ShapeType {
    /// <summary>
    /// 
    /// </summary>
    AccentBorderCallout1,

    /// <summary>
    /// 
    /// </summary>
    AccentBorderCallout2,

    /// <summary>
    /// 
    /// </summary>
    AccentBorderCallout3,

    /// <summary>
    /// 
    /// </summary>
    AccentCallout1,

    /// <summary>
    /// 
    /// </summary>
    AccentCallout2,

    /// <summary>
    /// 
    /// </summary>
    AccentCallout3,

    /// <summary>
    /// 
    /// </summary>
    ActionButtonBackPrevious,

    /// <summary>
    /// 
    /// </summary>
    ActionButtonBeginning,

    /// <summary>
    /// 
    /// </summary>
    ActionButtonBlank,

    /// <summary>
    /// 
    /// </summary>
    ActionButtonDocument,

    /// <summary>
    /// 
    /// </summary>
    ActionButtonEnd,

    /// <summary>
    /// 
    /// </summary>
    ActionButtonForwardNext,

    /// <summary>
    /// 
    /// </summary>
    ActionButtonHelp,

    /// <summary>
    /// 
    /// </summary>
    ActionButtonHome,

    /// <summary>
    /// 
    /// </summary>
    ActionButtonInformation,

    /// <summary>
    /// 
    /// </summary>
    ActionButtonMovie,

    /// <summary>
    /// 
    /// </summary>
    ActionButtonReturn,

    /// <summary>
    /// 
    /// </summary>
    ActionButtonSound,

    /// <summary>
    /// 
    /// </summary>
    Arc,

    /// <summary>
    /// 
    /// </summary>
    BentArrow,

    /// <summary>
    /// 
    /// </summary>
    BentConnector2,

    /// <summary>
    /// 
    /// </summary>
    BentConnector3,

    /// <summary>
    /// 
    /// </summary>
    BentConnector4,

    /// <summary>
    /// 
    /// </summary>
    BentConnector5,

    /// <summary>
    /// 
    /// </summary>
    BentUpArrow,

    /// <summary>
    /// 
    /// </summary>
    Bevel,

    /// <summary>
    /// 
    /// </summary>
    BlockArc,

    /// <summary>
    /// 
    /// </summary>
    BorderCallout1,

    /// <summary>
    /// 
    /// </summary>
    BorderCallout2,

    /// <summary>
    /// 
    /// </summary>
    BorderCallout3,

    /// <summary>
    /// 
    /// </summary>
    BracePair,

    /// <summary>
    /// 
    /// </summary>
    BracketPair,

    /// <summary>
    /// 
    /// </summary>
    Callout1,

    /// <summary>
    /// 
    /// </summary>
    Callout2,

    /// <summary>
    /// 
    /// </summary>
    Callout3,

    /// <summary>
    /// 
    /// </summary>
    Can,

    /// <summary>
    /// 
    /// </summary>
    ChartPlus,

    /// <summary>
    /// 
    /// </summary>
    ChartStar,

    /// <summary>
    /// 
    /// </summary>
    ChartX,

    /// <summary>
    /// 
    /// </summary>
    Chevron,

    /// <summary>
    /// 
    /// </summary>
    Chord,

    /// <summary>
    /// 
    /// </summary>
    CircularArrow,

    /// <summary>
    /// 
    /// </summary>
    Cloud,

    /// <summary>
    /// 
    /// </summary>
    CloudCallout,

    /// <summary>
    /// 
    /// </summary>
    Corner,

    /// <summary>
    /// 
    /// </summary>
    CornerTabs,

    /// <summary>
    /// 
    /// </summary>
    Cube,

    /// <summary>
    /// 
    /// </summary>
    CurvedConnector2,

    /// <summary>
    /// 
    /// </summary>
    CurvedConnector3,

    /// <summary>
    /// 
    /// </summary>
    CurvedConnector4,

    /// <summary>
    /// 
    /// </summary>
    CurvedConnector5,

    /// <summary>
    /// 
    /// </summary>
    CurvedDownArrow,

    /// <summary>
    /// 
    /// </summary>
    CurvedLeftArrow,

    /// <summary>
    /// 
    /// </summary>
    CurvedRightArrow,

    /// <summary>
    /// 
    /// </summary>
    CurvedUpArrow,

    /// <summary>
    /// 
    /// </summary>
    Decagon,

    /// <summary>
    /// 
    /// </summary>
    DiagStripe,

    /// <summary>
    /// 
    /// </summary>
    Diamond,

    /// <summary>
    /// 
    /// </summary>
    Dodecagon,

    /// <summary>
    /// 
    /// </summary>
    Donut,

    /// <summary>
    /// 
    /// </summary>
    DoubleWave,

    /// <summary>
    /// 
    /// </summary>
    DownArrow,

    /// <summary>
    /// 
    /// </summary>
    DownArrowCallout,

    /// <summary>
    /// 
    /// </summary>
    Ellipse,

    /// <summary>
    /// 
    /// </summary>
    EllipseRibbon,

    /// <summary>
    /// 
    /// </summary>
    EllipseRibbon2,

    /// <summary>
    /// 
    /// </summary>
    FlowChartAlternateProcess,

    /// <summary>
    /// 
    /// </summary>
    FlowChartCollate,

    /// <summary>
    /// 
    /// </summary>
    FlowChartConnector,

    /// <summary>
    /// 
    /// </summary>
    FlowChartDecision,

    /// <summary>
    /// 
    /// </summary>
    FlowChartDelay,

    /// <summary>
    /// 
    /// </summary>
    FlowChartDisplay,

    /// <summary>
    /// 
    /// </summary>
    FlowChartDocument,

    /// <summary>
    /// 
    /// </summary>
    FlowChartExtract,

    /// <summary>
    /// 
    /// </summary>
    FlowChartInputOutput,

    /// <summary>
    /// 
    /// </summary>
    FlowChartInternalStorage,

    /// <summary>
    /// 
    /// </summary>
    FlowChartMagneticDisk,
        
    /// <summary>
    /// 
    /// </summary>
    FlowChartMagneticDrum,

    /// <summary>
    /// 
    /// </summary>
    FlowChartMagneticTape,

    /// <summary>
    /// 
    /// </summary>
    FlowChartManualInput,
        
    /// <summary>
    /// 
    /// </summary>
    FlowChartManualOperation,

    /// <summary>
    /// 
    /// </summary>
    FlowChartMerge,

    /// <summary>
    /// 
    /// </summary>
    FlowChartMultidocument,

    /// <summary>
    /// 
    /// </summary>
    FlowChartOfflineStorage,

    /// <summary>
    /// 
    /// </summary>
    FlowChartOffpageConnector,

    /// <summary>
    /// 
    /// </summary>
    FlowChartOnlineStorage,

    /// <summary>
    /// 
    /// </summary>
    FlowChartOr,

    /// <summary>
    /// 
    /// </summary>
    FlowChartPredefinedProcess,

    /// <summary>
    /// 
    /// </summary>
    FlowChartPreparation,

    /// <summary>
    /// 
    /// </summary>
    FlowChartProcess,

    /// <summary>
    /// 
    /// </summary>
    FlowChartPunchedCard,

    /// <summary>
    /// 
    /// </summary>
    FlowChartPunchedTape,

    /// <summary>
    /// 
    /// </summary>
    FlowChartSort,

    /// <summary>
    /// 
    /// </summary>
    FlowChartSummingJunction,

    /// <summary>
    /// 
    /// </summary>
    FlowChartTerminator,

    /// <summary>
    /// 
    /// </summary>
    FoldedCorner,

    /// <summary>
    /// 
    /// </summary>
    Frame,

    /// <summary>
    /// 
    /// </summary>
    Funnel,

    /// <summary>
    /// 
    /// </summary>
    Gear6,

    /// <summary>
    /// 
    /// </summary>
    Gear9,

    /// <summary>
    /// 
    /// </summary>
    HalfFrame,

    /// <summary>
    /// 
    /// </summary>
    Heart,

    /// <summary>
    /// 
    /// </summary>
    Heptagon,

    /// <summary>
    /// 
    /// </summary>
    Hexagon,

    /// <summary>
    /// 
    /// </summary>
    HomePlate,

    /// <summary>
    /// 
    /// </summary>
    HorizontalScroll,

    /// <summary>
    /// 
    /// </summary>
    IrregularSeal1,

    /// <summary>
    /// 
    /// </summary>
    IrregularSeal2,

    /// <summary>
    /// 
    /// </summary>
    LeftArrow,

    /// <summary>
    /// 
    /// </summary>
    LeftArrowCallout,

    /// <summary>
    /// 
    /// </summary>
    LeftBrace,

    /// <summary>
    /// 
    /// </summary>
    LeftBracket,

    /// <summary>
    /// 
    /// </summary>
    LeftCircularArrow,

    /// <summary>
    /// 
    /// </summary>
    LeftRightArrow,

    /// <summary>
    /// 
    /// </summary>
    LeftRightArrowCallout,

    /// <summary>
    /// 
    /// </summary>
    LeftRightCircularArrow,

    /// <summary>
    /// 
    /// </summary>
    LeftRightRibbon,

    /// <summary>
    /// 
    /// </summary>
    LeftRightUpArrow,

    /// <summary>
    /// 
    /// </summary>
    LeftUpArrow,

    /// <summary>
    /// 
    /// </summary>
    LightningBolt,

    /// <summary>
    /// 
    /// </summary>
    Line,

    /// <summary>
    /// 
    /// </summary>
    LineInv,

    /// <summary>
    /// 
    /// </summary>
    MathDivide,

    /// <summary>
    /// 
    /// </summary>
    MathEqual,

    /// <summary>
    /// 
    /// </summary>
    MathMinus,

    /// <summary>
    /// 
    /// </summary>
    MathMultiply,

    /// <summary>
    /// 
    /// </summary>
    MathNotEqual,

    /// <summary>
    /// 
    /// </summary>
    MathPlus,

    /// <summary>
    /// 
    /// </summary>
    Moon,

    /// <summary>
    /// 
    /// </summary>
    NonIsoscelesTrapezoid,

    /// <summary>
    /// 
    /// </summary>
    NoSmoking,

    /// <summary>
    /// 
    /// </summary>
    NotchedRightArrow,

    /// <summary>
    /// 
    /// </summary>
    Octagon,

    /// <summary>
    /// 
    /// </summary>
    Parallelogram,

    /// <summary>
    /// 
    /// </summary>
    Pentagon,

    /// <summary>
    /// 
    /// </summary>
    Pie,

    /// <summary>
    /// 
    /// </summary>
    PieWedge,

    /// <summary>
    /// 
    /// </summary>
    Plaque,

    /// <summary>
    /// 
    /// </summary>
    PlaqueTabs,

    /// <summary>
    /// 
    /// </summary>
    Plus,

    /// <summary>
    /// 
    /// </summary>
    QuadArrow,

    /// <summary>
    /// 
    /// </summary>
    QuadArrowCallout,

    /// <summary>
    /// 
    /// </summary>
    Rect,

    /// <summary>
    /// 
    /// </summary>
    Ribbon,

    /// <summary>
    /// 
    /// </summary>
    Ribbon2,

    /// <summary>
    /// 
    /// </summary>
    RightArrow,

    /// <summary>
    /// 
    /// </summary>
    RightArrowCallout,

    /// <summary>
    /// 
    /// </summary>
    RightBrace,

    /// <summary>
    /// 
    /// </summary>
    RightBracket,

    /// <summary>
    /// 
    /// </summary>
    Round1Rect,

    /// <summary>
    /// 
    /// </summary>
    Round2DiagRect,

    /// <summary>
    /// 
    /// </summary>
    Round2SameRect,

    /// <summary>
    /// 
    /// </summary>
    RoundRect,

    /// <summary>
    /// 
    /// </summary>
    RtTriangle,

    /// <summary>
    /// 
    /// </summary>
    SmileyFace,

    /// <summary>
    /// 
    /// </summary>
    Snip1Rect,

    /// <summary>
    /// 
    /// </summary>
    Snip2DiagRect,

    /// <summary>
    /// 
    /// </summary>
    Snip2SameRect,

    /// <summary>
    /// 
    /// </summary>
    SnipRoundRect,

    /// <summary>
    /// 
    /// </summary>
    SquareTabs,

    /// <summary>
    /// 
    /// </summary>
    Star10,

    /// <summary>
    /// 
    /// </summary>
    Star12,

    /// <summary>
    /// 
    /// </summary>
    Star16,

    /// <summary>
    /// 
    /// </summary>
    Star24,

    /// <summary>
    /// 
    /// </summary>
    Star32,

    /// <summary>
    /// 
    /// </summary>
    Star4,

    /// <summary>
    /// 
    /// </summary>
    Star5,

    /// <summary>
    /// 
    /// </summary>
    Star6,

    /// <summary>
    /// 
    /// </summary>
    Star7,

    /// <summary>
    /// 
    /// </summary>
    Star8,

    /// <summary>
    /// 
    /// </summary>
    StraightConnector1,

    /// <summary>
    /// 
    /// </summary>
    StripedRightArrow,

    /// <summary>
    /// 
    /// </summary>
    Sun,

    /// <summary>
    /// 
    /// </summary>
    SwooshArrow,

    /// <summary>
    /// 
    /// </summary>
    Teardrop,

    /// <summary>
    /// 
    /// </summary>
    Trapezoid,

    /// <summary>
    /// 
    /// </summary>
    Triangle,

    /// <summary>
    /// 
    /// </summary>
    UpArrow,

    /// <summary>
    /// 
    /// </summary>
    UpArrowCallout,

    /// <summary>
    /// 
    /// </summary>
    UpDownArrow,

    /// <summary>
    /// 
    /// </summary>
    UpDownArrowCallout,

    /// <summary>
    /// 
    /// </summary>
    UturnArrow,

    /// <summary>
    /// 
    /// </summary>
    Wave,

    /// <summary>
    /// 
    /// </summary>
    WedgeEllipseCallout,

    /// <summary>
    /// 
    /// </summary>
    WedgeRectCallout,

    /// <summary>
    /// 
    /// </summary>
    WedgeRoundRectCallout,

    /// <summary>
    /// 
    /// </summary>
    VerticalScroll,
}
