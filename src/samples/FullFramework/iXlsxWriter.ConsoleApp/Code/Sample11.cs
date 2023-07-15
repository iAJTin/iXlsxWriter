
using System.Collections.Generic;
using System.Diagnostics;

using iTin.Core.ComponentModel;
using iTin.Core.Models.Design.Enums;

using iTin.Logging.ComponentModel;

using iTin.Utilities.Xlsx.Design.Shape;
using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Styles;

using iXlsxWriter.Operations.Actions;
using iXlsxWriter.Operations.Insert;

namespace iXlsxWriter.Samples;

/// <summary>
/// Shows how to insert a shapes with shape effects.
/// </summary>
internal class Sample11
{
    // Generates document
    public static void Generate(ILogger logger)
    {
        #region Initialize timer

        var sw = new Stopwatch();
        sw.Start();

        #endregion

        #region Creates xlsx file reference

        var doc = XlsxInput.Create(new[] { "Shadows", "Illumination", "Reflection", "Soft Edge" });

        #endregion

        #region Add cell styles

        var cellStyles = new Dictionary<string, XlsxCellStyle>
        {
            {
                "Illumination",
                new XlsxCellStyle
                {
                    Font = { Color = "Blue", Bold = YesNo.Yes },
                    Content =
                    {
                        Color = "LightGray",
                        Pattern = { PatternType = KnownPatternType.Solid },
                        Alignment = { Horizontal = KnownHorizontalAlignment.Left, Vertical = KnownVerticalAlignment.Center }
                    },
                    Borders =
                    {
                        new XlsxStyleBorder { Color = "Green", Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thick },
                        new XlsxStyleBorder { Color = "Green", Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick }
                    }
                }
            },
            {
                "Shadows",
                new XlsxCellStyle
                {
                    Font = { Color = "Blue", Bold = YesNo.Yes },
                    Content =
                    {
                        Color = "LightGray",
                        Merge = { Cells = 8 },
                        Pattern = { PatternType = KnownPatternType.Solid },
                        Alignment = { Horizontal = KnownHorizontalAlignment.Left, Vertical = KnownVerticalAlignment.Center }
                    },
                    Borders =
                    {
                        new XlsxStyleBorder { Color = "Green", Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thick },
                        new XlsxStyleBorder { Color = "Green", Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick }
                    }
                }
            },
            {
                "Reflection",
                new XlsxCellStyle
                {
                    Font = { Color = "Blue", Bold = YesNo.Yes },
                    Content =
                    {
                        Color = "LightGray",
                        Merge = { Cells = 2 },
                        Pattern = { PatternType = KnownPatternType.Solid },
                        Alignment = { Horizontal = KnownHorizontalAlignment.Left, Vertical = KnownVerticalAlignment.Center }
                    },
                    Borders =
                    {
                        new XlsxStyleBorder { Color = "Green", Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thick },
                        new XlsxStyleBorder { Color = "Green", Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick }
                    }
                }
            },
            {
                "SoftEdge",
                new XlsxCellStyle
                {
                    Font = { Color = "Blue", Bold = YesNo.Yes },
                    Content =
                    {
                        Color = "LightGray",
                        Merge = { Cells = 2 },
                        Pattern = { PatternType = KnownPatternType.Solid },
                        Alignment = { Horizontal = KnownHorizontalAlignment.Left, Vertical = KnownVerticalAlignment.Center }
                    },
                    Borders =
                    {
                        new XlsxStyleBorder { Color = "Green", Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thick },
                        new XlsxStyleBorder { Color = "Green", Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick }
                    }
                }
            }
        };

        #endregion

        #region Sheets

        #region Sheet > Shadows

        doc.Insert(new InsertText
        {
            SheetName = "Shadows",
            Data = "Outer shadows",
            Location = new XlsxPointRange { Column = 2, Row = 2 },
            Style = cellStyles["Shadows"]
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 2, Row = 4 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Rect,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Transparency = 50, Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 1",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxOuterShadow.DownLeft }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 5, Row = 4 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Rect,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 2",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxOuterShadow.Down }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 8, Row = 4 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Rect,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 3",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxOuterShadow.DownRight }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 2, Row = 14 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Rect,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Transparency = 50, Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 4",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxOuterShadow.Left }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 5, Row = 14 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Rect,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 5",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxOuterShadow.Center }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 8, Row = 14 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Rect,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 6",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxOuterShadow.Right }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 2, Row = 24 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Rect,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Transparency = 50, Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 7",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxOuterShadow.TopLeft }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 5, Row = 24 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Rect,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 8",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxOuterShadow.Top }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 8, Row = 24 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Rect,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 9",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxOuterShadow.TopRight }
            }
        }).Insert(new InsertText
        {
            SheetName = "Shadows",
            Data = "Inner shadows",
            Location = new XlsxPointRange { Column = 11, Row = 2 },
            Style = cellStyles["Shadows"]
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 11, Row = 4 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Ellipse,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Transparency = 50, Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 1",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxInnerShadow.DownLeft }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 14, Row = 4 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Ellipse,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 2",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxInnerShadow.Down }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 17, Row = 4 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Ellipse,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 3",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxInnerShadow.DownRight }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 11, Row = 14 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Ellipse,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Transparency = 50, Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 4",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxInnerShadow.Left }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 14, Row = 14 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Ellipse,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 5",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxInnerShadow.Center }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 17, Row = 14 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Ellipse,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 6",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxInnerShadow.Right }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 11, Row = 24 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Ellipse,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Transparency = 50, Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 7",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxInnerShadow.TopLeft }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 14, Row = 24 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Ellipse,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 8",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxInnerShadow.Top }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 17, Row = 24 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Ellipse,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 9",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxInnerShadow.TopRight }
            }
        }).Insert(new InsertText
        {
            SheetName = "Shadows",
            Data = "Perspective shadows",
            Location = new XlsxPointRange { Column = 20, Row = 2 },
            Style = new XlsxCellStyle
            {
                Name = "PerspectiveShadowStyle",
                Font = { Color = "Blue", Bold = YesNo.Yes, Size = 12.0f },
                Content =
                {
                    Merge = { Cells = 5 },
                    Color = "LightGray"
                },
                Borders =
                {
                    new XlsxStyleBorder
                        { Color = "Green", Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thick },
                    new XlsxStyleBorder
                        { Color = "Green", Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick }
                }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 20, Row = 4 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Decagon,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Transparency = 50, Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 1",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxPerspectiveShadow.TopLeft }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 23, Row = 4 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Decagon,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 2",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxPerspectiveShadow.TopRight }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 20, Row = 14 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Decagon,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 3",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxPerspectiveShadow.DownLeft }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 23, Row = 14 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Decagon,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 3",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxPerspectiveShadow.DownRight }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Shadows",
            Location = new XlsxPointRange { Column = 20, Row = 24 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Decagon,
                Size = { Width = 128, Height = 128 },
                Border = { Show = YesNo.Yes, Color = "Yellow", Style = KnownLineStyle.DashDot },
                Content =
                {
                    Text = "Shape 3",
                    Color = "LightGray",
                    Font = { Color = "Red", Bold = YesNo.Yes },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Center }
                },
                ShapeEffects = { Shadow = XlsxPerspectiveShadow.Down }
            }
        });

        #endregion

        #region Sheet > Illumination

        doc.Insert(new InsertText
        {
            SheetName = "Illumination",
            Data = "Accent 1",
            Location = new XlsxPointRange { Column = 2, Row = 2 },
            Style = cellStyles["Illumination"]
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 2, Row = 4 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Rect,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis1Points5 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 2, Row = 9 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Rect,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis1Points8 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 2, Row = 14 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Rect,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis1Points11 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 2, Row = 20 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Rect,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis1Points18 }
            }
        }).Insert(new InsertText
        {
            SheetName = "Illumination",
            Data = "Accent 2",
            Location = new XlsxPointRange { Column = 4, Row = 2 },
            Style = cellStyles["Illumination"]
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 4, Row = 4 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Ellipse,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis2Points5 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 4, Row = 9 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Ellipse,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis2Points8 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 4, Row = 14 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Ellipse,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis2Points11 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 4, Row = 20 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Ellipse,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis2Points18 }
            }
        }).Insert(new InsertText
        {
            SheetName = "Illumination",
            Data = "Accent 3",
            Location = new XlsxPointRange { Column = 6, Row = 2 },
            Style = cellStyles["Illumination"]
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 6, Row = 4 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Hexagon,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "Green" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis3Points5 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 6, Row = 9 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Hexagon,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "Green" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis3Points8 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 6, Row = 14 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Hexagon,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "Green" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis3Points11 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 6, Row = 20 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Hexagon,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "Green" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis3Points18 }
            }
        }).Insert(new InsertText
        {
            SheetName = "Illumination",
            Data = "Accent 4",
            Location = new XlsxPointRange { Column = 8, Row = 2 },
            Style = cellStyles["Illumination"]
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 8, Row = 4 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Decagon,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "Blue" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis4Points5 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 8, Row = 9 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Decagon,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "Blue" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis4Points8 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 8, Row = 14 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Decagon,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "Blue" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis4Points11 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 8, Row = 20 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Decagon,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "Blue" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis4Points18 }
            }
        }).Insert(new InsertText
        {
            SheetName = "Illumination",
            Data = "Accent 5",
            Location = new XlsxPointRange { Column = 10, Row = 2 },
            Style = cellStyles["Illumination"]
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 10, Row = 4 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Ribbon2,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis5Points5 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 10, Row = 9 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Ribbon2,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis5Points8 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 10, Row = 14 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Ribbon2,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis5Points11 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 10, Row = 20 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Ribbon2,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis5Points18 }
            }
        }).Insert(new InsertText
        {
            SheetName = "Illumination",
            Data = "Accent 6",
            Location = new XlsxPointRange { Column = 12, Row = 2 },
            Style = cellStyles["Illumination"]
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 12, Row = 4 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.CircularArrow,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis6Points5 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 12, Row = 9 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Star7,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis6Points8 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 12, Row = 14 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Star10,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis6Points11 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Illumination",
            Location = new XlsxPointRange { Column = 12, Row = 20 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.SmileyFace,
                Size = { Width = 64, Height = 64 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis6Points18 }
            }
        });

        #endregion

        #region Sheet > Reflection

        doc.Insert(new InsertText
        {
            SheetName = "Reflection",
            Data = "Strong",
            Location = new XlsxPointRange { Column = 2, Row = 2 },
            Style = cellStyles["Reflection"]
        }).Insert(new InsertShape
        {
            SheetName = "Reflection",
            Location = new XlsxPointRange { Column = 2, Row = 4 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Rect,
                Size = { Width = 128, Height = 128 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Reflection = XlsxReflectionShapeEffect.StrongNoOffset }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Reflection",
            Location = new XlsxPointRange { Column = 2, Row = 20 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Rect,
                Size = { Width = 128, Height = 128 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Reflection = XlsxReflectionShapeEffect.StrongOffset4 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Reflection",
            Location = new XlsxPointRange { Column = 2, Row = 36 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Rect,
                Size = { Width = 128, Height = 128 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Reflection = XlsxReflectionShapeEffect.StrongOffset8 }
            }
        }).Insert(new InsertText
        {
            SheetName = "Reflection",
            Data = "Semi",
            Location = new XlsxPointRange { Column = 5, Row = 2 },
            Style = cellStyles["Reflection"]
        }).Insert(new InsertShape
        {
            SheetName = "Reflection",
            Location = new XlsxPointRange { Column = 5, Row = 4 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Ellipse,
                Size = { Width = 128, Height = 128 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Reflection = XlsxReflectionShapeEffect.SemiNoOffset }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Reflection",
            Location = new XlsxPointRange { Column = 5, Row = 20 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Ellipse,
                Size = { Width = 128, Height = 128 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Reflection = XlsxReflectionShapeEffect.SemiOffset4 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Reflection",
            Location = new XlsxPointRange { Column = 5, Row = 36 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Ellipse,
                Size = { Width = 128, Height = 128 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Reflection = XlsxReflectionShapeEffect.SemiOffset8 }
            }
        }).Insert(new InsertText
        {
            SheetName = "Reflection",
            Data = "Total",
            Location = new XlsxPointRange { Column = 8, Row = 2 },
            Style = cellStyles["Reflection"]
        }).Insert(new InsertShape
        {
            SheetName = "Reflection",
            Location = new XlsxPointRange { Column = 8, Row = 4 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Star10,
                Size = { Width = 128, Height = 128 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Reflection = XlsxReflectionShapeEffect.TotalNoOffset }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Reflection",
            Location = new XlsxPointRange { Column = 8, Row = 20 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Star10,
                Size = { Width = 128, Height = 128 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Reflection = XlsxReflectionShapeEffect.TotalOffset4 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Reflection",
            Location = new XlsxPointRange { Column = 8, Row = 36 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Star10,
                Size = { Width = 128, Height = 128 },
                Content = { Color = "LightGray" },
                ShapeEffects = { Reflection = XlsxReflectionShapeEffect.TotalOffset8 }
            }
        });

        #endregion

        #region Sheet > SoftEdge

        doc.Insert(new InsertText
        {
            SheetName = "Soft Edge",
            Data = "Soft Edge",
            Location = new XlsxPointRange { Column = 2, Row = 2 },
            Style = cellStyles["SoftEdge"]
        }).Insert(new InsertShape
        {
            SheetName = "Soft Edge",
            Location = new XlsxPointRange { Column = 2, Row = 4 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Rect,
                Size = { Width = 128, Height = 128 },
                Content = { Color = "LightGray" },
                ShapeEffects = { SoftEdge = XlsxSoftEdgeShapeEffect.SoftEdge1 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Soft Edge",
            Location = new XlsxPointRange { Column = 2, Row = 12 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.ActionButtonHome,
                Size = { Width = 128, Height = 128 },
                Content = { Color = "LightGray" },
                ShapeEffects = { SoftEdge = XlsxSoftEdgeShapeEffect.SoftEdge2 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Soft Edge",
            Location = new XlsxPointRange { Column = 2, Row = 20 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Ellipse,
                Size = { Width = 128, Height = 128 },
                Content = { Color = "LightGray" },
                ShapeEffects = { SoftEdge = XlsxSoftEdgeShapeEffect.SoftEdge5 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Soft Edge",
            Location = new XlsxPointRange { Column = 2, Row = 29 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.Star12,
                Size = { Width = 128, Height = 128 },
                Content = { Color = "LightGray" },
                ShapeEffects = { SoftEdge = XlsxSoftEdgeShapeEffect.SoftEdge10 }
            }
        }).Insert(new InsertShape
        {
            SheetName = "Soft Edge",
            Location = new XlsxPointRange { Column = 2, Row = 37 },
            Shape = new XlsxShape
            {
                ShapeType = ShapeType.SmileyFace,
                Size = { Width = 128, Height = 128 },
                Content = { Color = "LightGray" },
                ShapeEffects = { SoftEdge = XlsxSoftEdgeShapeEffect.SoftEdge25 }
            }
        });

        #endregion

        #endregion

        #region Create output result

        var result = doc.CreateResult();
        if (!result.Success)
        {
            logger.Info("   > Error creating output result");
            logger.Info($"     > Error: {result.Errors.AsMessages().ToStringBuilder()}");

            return;
        }

        #endregion

        #region Saves output result

        var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-11/Sample-11" });

        var ts = sw.Elapsed;
        sw.Stop();

        if (!saveResult.Success)
        {
            logger.Info("   > Error while saving to disk");
            logger.Info($"     > Error: {saveResult.Errors.AsMessages().ToStringBuilder()}");
            logger.Info($"   > Elapsed time: { ts.Hours:00}:{ ts.Minutes:00}:{ ts.Seconds:00}.{ ts.Milliseconds / 10:00}");
            return;
        }

        logger.Info("   > Saved to disk correctly");
        logger.Info("     > Path: ~/Output/Sample-11/Sample-11.xlsx");
        logger.Info($"   > Elapsed time: { ts.Hours:00}:{ ts.Minutes:00}:{ ts.Seconds:00}.{ ts.Milliseconds / 10:00}");

        #endregion
    }
}
