
namespace iXlsxWriter.Samples
{
    using iTin.Core.ComponentModel;
    using iTin.Core.Models.Design.Enums;

    using iTin.Logging.ComponentModel;

    using iTin.Utilities.Xlsx.Design.Picture;
    using iTin.Utilities.Xlsx.Design.Shared;
    using iTin.Utilities.Xlsx.Design.Styles;

    using iTin.Utilities.Xlsx.Writer;
    using iTin.Utilities.Xlsx.Writer.ComponentModel;
    using iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Action.Save;

    /// <summary>
    /// Shows how to insert a pictures with shape effects.
    /// </summary>
    internal class Sample10
    {
        // Generates document
        public static void Generate(ILogger logger)
        {
            #region Creates xlsx file reference

            XlsxInput doc = XlsxInput.Create(new[] { "Shadows", "Illumination", "Reflection", "Soft Edge" });

            #endregion

            #region Cell styles

            var headerStyle = new XlsxCellStyle
            {
                Font = {Color = "Blue", Bold = YesNo.Yes},
                Content =
                {
                    Color = "LightGray",
                    Merge = {Cells = 8},
                    Pattern = {PatternType = KnownPatternType.Solid},
                    Alignment = {Horizontal = KnownHorizontalAlignment.Left, Vertical = KnownVerticalAlignment.Center}
                },
                Borders =
                {
                    new XlsxStyleBorder {Color = "Green", Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thick},
                    new XlsxStyleBorder {Color = "Green", Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick}
                }
            };

            var illuminationHeaderStyle = new XlsxCellStyle
            {
                Font = { Color = "Blue", Bold = YesNo.Yes },
                Content =
                {
                    Color = "LightGray",
                    Alignment = {Horizontal = KnownHorizontalAlignment.Center, Vertical = KnownVerticalAlignment.Center}
                },
                Borders =
                {
                    new XlsxStyleBorder {Color = "Green", Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thick},
                    new XlsxStyleBorder {Color = "Green", Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick}
                }
            };

            var reflectionHeaderStyle = new XlsxCellStyle
            {
                Font = { Color = "Blue", Bold = YesNo.Yes },
                Content =
                {
                    Color = "LightGray",
                    Merge = {Cells = 2},
                    Pattern = {PatternType = KnownPatternType.Solid},
                    Alignment = {Horizontal = KnownHorizontalAlignment.Left, Vertical = KnownVerticalAlignment.Center}
                },
                Borders =
                {
                    new XlsxStyleBorder {Color = "Green", Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thick},
                    new XlsxStyleBorder {Color = "Green", Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick}
                }
            };

            var softEdgeHeaderStyle = new XlsxCellStyle
            {
                Font = { Color = "Blue", Bold = YesNo.Yes },
                Content =
                {
                    Color = "LightGray",
                    Merge = {Cells = 2},
                    Pattern = {PatternType = KnownPatternType.Solid},
                    Alignment = {Horizontal = KnownHorizontalAlignment.Left, Vertical = KnownVerticalAlignment.Center}
                },
                Borders =
                {
                    new XlsxStyleBorder {Color = "Green", Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thick},
                    new XlsxStyleBorder {Color = "Green", Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick}
                }
            };

            #endregion

            #region Sheets

            #region Sheet > Shadows

            var shadowsInsertResult = doc.Insert(new InsertText
            {
                SheetName = "Shadows",
                Data = "Outer shadows",
                Location = new XlsxPointRange {Column = 2, Row = 2},
                Style = headerStyle
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange {Column = 2, Row = 4},
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize {Width = 142, Height = 142},
                    Border = {Color = "Green", Show = YesNo.Yes},
                    ShapeEffects = {Shadow = XlsxOuterShadow.DownLeft}
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange {Column = 5, Row = 4},
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize {Width = 142, Height = 142},
                    Border = {Color = "Green", Show = YesNo.Yes},
                    ShapeEffects = {Shadow = XlsxOuterShadow.Down}
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange {Column = 8, Row = 4},
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize {Width = 142, Height = 142},
                    Border = {Color = "Green", Show = YesNo.Yes},
                    ShapeEffects = {Shadow = XlsxOuterShadow.DownLeft}
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange {Column = 2, Row = 14},
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize {Width = 142, Height = 142},
                    Border = {Color = "Green", Show = YesNo.Yes},
                    ShapeEffects = {Shadow = XlsxOuterShadow.Left}
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange {Column = 5, Row = 14},
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize {Width = 142, Height = 142},
                    Border = {Color = "Green", Show = YesNo.Yes},
                    ShapeEffects = {Shadow = XlsxOuterShadow.Center}
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange {Column = 8, Row = 14},
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize {Width = 142, Height = 142},
                    Border = {Color = "Green", Show = YesNo.Yes},
                    ShapeEffects = {Shadow = XlsxOuterShadow.Right}
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange {Column = 2, Row = 24},
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize {Width = 142, Height = 142},
                    Border = {Color = "Green", Show = YesNo.Yes},
                    ShapeEffects = {Shadow = XlsxOuterShadow.TopLeft}
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange {Column = 5, Row = 24},
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize {Width = 142, Height = 142},
                    Border = {Color = "Green", Show = YesNo.Yes},
                    ShapeEffects = {Shadow = XlsxOuterShadow.Top}
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange {Column = 8, Row = 24},
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize {Width = 142, Height = 142},
                    Border = {Color = "Green", Show = YesNo.Yes},
                    ShapeEffects = {Shadow = XlsxOuterShadow.TopRight}
                }
            }).Insert(new InsertText
            {
                SheetName = "Shadows",
                Data = "Inner shadows",
                Location = new XlsxPointRange {Column = 11, Row = 2},
                Style = headerStyle
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange {Column = 11, Row = 4},
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize {Width = 142, Height = 142},
                    Border = {Color = "Green", Show = YesNo.Yes},
                    ShapeEffects = {Shadow = XlsxInnerShadow.TopLeft}
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange {Column = 14, Row = 4},
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize {Width = 142, Height = 142},
                    Border = {Color = "Green", Show = YesNo.Yes},
                    ShapeEffects = {Shadow = XlsxInnerShadow.Top}
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange {Column = 17, Row = 4},
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize {Width = 142, Height = 142},
                    Border = {Color = "Green", Show = YesNo.Yes},
                    ShapeEffects = {Shadow = XlsxInnerShadow.TopRight}
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange {Column = 11, Row = 14},
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize {Width = 142, Height = 142},
                    Border = {Color = "Green", Show = YesNo.Yes},
                    ShapeEffects = {Shadow = XlsxInnerShadow.Left}
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange {Column = 14, Row = 14},
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize {Width = 142, Height = 142},
                    Border = {Color = "Green", Show = YesNo.Yes},
                    ShapeEffects = {Shadow = XlsxInnerShadow.Center}
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange {Column = 17, Row = 14},
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize {Width = 142, Height = 142},
                    Border = {Color = "Green", Show = YesNo.Yes},
                    ShapeEffects = {Shadow = XlsxInnerShadow.Right}
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange {Column = 11, Row = 24},
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize {Width = 142, Height = 142},
                    Border = {Color = "Green", Show = YesNo.Yes},
                    ShapeEffects = {Shadow = XlsxInnerShadow.DownLeft}
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange {Column = 14, Row = 24},
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize {Width = 142, Height = 142},
                    Border = {Color = "Green", Show = YesNo.Yes},
                    ShapeEffects = {Shadow = XlsxInnerShadow.Down}
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange {Column = 17, Row = 24},
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize {Width = 142, Height = 142},
                    Border = {Color = "Green", Show = YesNo.Yes},
                    ShapeEffects = {Shadow = XlsxInnerShadow.DownRight}
                }
            }).Insert(new InsertText
            {
                SheetName = "Shadows",
                Data = "Perspective shadows",
                Location = new XlsxPointRange { Column = 20, Row = 2 },
                Style = new XlsxCellStyle
                {
                    Font = { Color = "Blue", Bold = YesNo.Yes },
                    Content =
                    {
                        Color = "LightGray",
                        Merge = {Cells = 5},
                        Alignment = {Horizontal = KnownHorizontalAlignment.Left, Vertical = KnownVerticalAlignment.Center}
                    },
                    Borders =
                    {
                        new XlsxStyleBorder {Color = "Green", Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thick},
                        new XlsxStyleBorder {Color = "Green", Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick}
                    }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange { Column = 20, Row = 4 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 142, Height = 142 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = {Shadow = XlsxPerspectiveShadow.TopLeft}
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange { Column = 23, Row = 4 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 142, Height = 142 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = {Shadow = XlsxPerspectiveShadow.TopRight}
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange { Column = 20, Row = 14 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 142, Height = 142 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = {Shadow = XlsxPerspectiveShadow.DownLeft}
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange { Column = 23, Row = 14 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 142, Height = 142 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = {Shadow = XlsxPerspectiveShadow.DownRight}
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Shadows",
                Location = new XlsxPointRange { Column = 20, Row = 24 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 142, Height = 142 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = {Shadow = XlsxPerspectiveShadow.Down}
                }
            });

            #endregion

            #region Sheet > Illumination

            var illuminationInsertResult = doc.Insert(new InsertText
            {
                SheetName = "Illumination",
                Data = "Accent 1",
                Location = new XlsxPointRange { Column = 2, Row = 2 },
                Style = illuminationHeaderStyle
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 2, Row = 4 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis1Points5 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 2, Row = 9 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis1Points8 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 2, Row = 14 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis1Points11 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 2, Row = 20 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis1Points18 }
                }
            }).Insert(new InsertText
            {
                SheetName = "Illumination",
                Data = "Accent 2",
                Location = new XlsxPointRange { Column = 4, Row = 2 },
                Style = illuminationHeaderStyle
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 4, Row = 4 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis2Points5 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 4, Row = 9 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis2Points8 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 4, Row = 14 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis2Points11 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 4, Row = 20 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis2Points18 }
                }
            }).Insert(new InsertText
            {
                SheetName = "Illumination",
                Data = "Accent 3",
                Location = new XlsxPointRange { Column = 6, Row = 2 },
                Style = illuminationHeaderStyle
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 6, Row = 4 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis3Points5 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 6, Row = 9 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis3Points8 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 6, Row = 14 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis3Points11 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 6, Row = 20 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis3Points18 }
                }
            }).Insert(new InsertText
            {
                SheetName = "Illumination",
                Data = "Accent 4",
                Location = new XlsxPointRange { Column = 8, Row = 2 },
                Style = illuminationHeaderStyle
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 8, Row = 4 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis4Points5 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 8, Row = 9 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis4Points8 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 8, Row = 14 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis4Points11 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 8, Row = 20 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis4Points18 }
                }
            }).Insert(new InsertText
            {
                SheetName = "Illumination",
                Data = "Accent 5",
                Location = new XlsxPointRange { Column = 10, Row = 2 },
                Style = illuminationHeaderStyle
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 10, Row = 4 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis5Points5 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 10, Row = 9 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis4Points8 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 10, Row = 14 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis5Points11 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 10, Row = 20 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis5Points18 }
                }
            }).Insert(new InsertText
            {
                SheetName = "Illumination",
                Data = "Accent 6",
                Location = new XlsxPointRange { Column = 12, Row = 2 },
                Style = illuminationHeaderStyle
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 12, Row = 4 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis6Points5 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 12, Row = 9 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis6Points8 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 12, Row = 14 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis6Points11 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Illumination",
                Location = new XlsxPointRange { Column = 12, Row = 20 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 71, Height = 71 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis6Points18 }
                }
            });

            #endregion

            #region Sheet > Reflection

            var reflectionInsertResult = doc.Insert(new InsertText
            {
                SheetName = "Reflection",
                Data = "Strong",
                Location = new XlsxPointRange { Column = 2, Row = 2 },
                Style = reflectionHeaderStyle
            }).Insert(new InsertPicture
            {
                SheetName = "Reflection",
                Location = new XlsxPointRange { Column = 2, Row = 4 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 142, Height = 142 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Reflection = XlsxReflectionShapeEffect.StrongNoOffset }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Reflection",
                Location = new XlsxPointRange { Column = 2, Row = 20 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 142, Height = 142 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Reflection = XlsxReflectionShapeEffect.StrongOffset4 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Reflection",
                Location = new XlsxPointRange { Column = 2, Row = 36 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 142, Height = 142 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Reflection = XlsxReflectionShapeEffect.StrongOffset8 }
                }
            }).Insert(new InsertText
            {
                SheetName = "Reflection",
                Data = "Semi",
                Location = new XlsxPointRange { Column = 5, Row = 2 },
                Style = reflectionHeaderStyle
            }).Insert(new InsertPicture
            {
                SheetName = "Reflection",
                Location = new XlsxPointRange { Column = 5, Row = 4 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 142, Height = 142 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Reflection = XlsxReflectionShapeEffect.SemiNoOffset }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Reflection",
                Location = new XlsxPointRange { Column = 5, Row = 20 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 142, Height = 142 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Reflection = XlsxReflectionShapeEffect.SemiOffset4 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Reflection",
                Location = new XlsxPointRange { Column = 5, Row = 36 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 142, Height = 142 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Reflection = XlsxReflectionShapeEffect.SemiOffset8 }
                }
            }).Insert(new InsertText
            {
                SheetName = "Reflection",
                Data = "Total",
                Location = new XlsxPointRange { Column = 8, Row = 2 },
                Style = reflectionHeaderStyle
            }).Insert(new InsertPicture
            {
                SheetName = "Reflection",
                Location = new XlsxPointRange { Column = 8, Row = 4 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 142, Height = 142 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Reflection = XlsxReflectionShapeEffect.TotalNoOffset }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Reflection",
                Location = new XlsxPointRange { Column = 8, Row = 20 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 142, Height = 142 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Reflection = XlsxReflectionShapeEffect.TotalOffset4 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Reflection",
                Location = new XlsxPointRange { Column = 8, Row = 36 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 142, Height = 142 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { Reflection = XlsxReflectionShapeEffect.TotalOffset8 }
                }
            });

            #endregion

            #region Sheet > SoftEdge

            var softEdgeInsertResult = doc.Insert(new InsertText
            {
                SheetName = "Soft Edge",
                Data = "Soft edge",
                Location = new XlsxPointRange { Column = 2, Row = 2 },
                Style = softEdgeHeaderStyle
            }).Insert(new InsertPicture
            {
                SheetName = "Soft Edge",
                Location = new XlsxPointRange { Column = 2, Row = 4 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 142, Height = 142 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { SoftEdge = XlsxSoftEdgeShapeEffect.SoftEdge1 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Soft Edge",
                Location = new XlsxPointRange { Column = 2, Row = 12 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 142, Height = 142 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { SoftEdge = XlsxSoftEdgeShapeEffect.SoftEdge2 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Soft Edge",
                Location = new XlsxPointRange { Column = 2, Row = 20 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 142, Height = 142 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { SoftEdge = XlsxSoftEdgeShapeEffect.SoftEdge5 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Soft Edge",
                Location = new XlsxPointRange { Column = 2, Row = 29 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 142, Height = 142 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { SoftEdge = XlsxSoftEdgeShapeEffect.SoftEdge10 }
                }
            }).Insert(new InsertPicture
            {
                SheetName = "Soft Edge",
                Location = new XlsxPointRange { Column = 2, Row = 37 },
                Picture = new XlsxPicture
                {
                    Path = "~/Resources/Sample-10/bar-chart.png",
                    Size = new XlsxSize { Width = 142, Height = 142 },
                    Border = { Color = "Green", Show = YesNo.Yes },
                    ShapeEffects = { SoftEdge = XlsxSoftEdgeShapeEffect.SoftEdge25 }
                }
            });

            #endregion

            #endregion

            #region Evaluate insert(s) operation(s)

            if (!shadowsInsertResult.Success)
            {
                logger.Info("   > Error while creating insert");
                logger.Info($"     > Error: {shadowsInsertResult.Errors.AsMessages().ToStringBuilder()}");
                return;
            }

            if (!illuminationInsertResult.Success)
            {
                logger.Info("   > Error while creating shapes with illuminations");
                logger.Info($"     > Error: {illuminationInsertResult.Errors.AsMessages().ToStringBuilder()}");
                return;
            }

            if (!reflectionInsertResult.Success)
            {
                logger.Info("   > Error while creating shapes with reflection");
                logger.Info($"     > Error: {reflectionInsertResult.Errors.AsMessages().ToStringBuilder()}");
                return;
            }

            if (!softEdgeInsertResult.Success)
            {
                logger.Info("   > Error while creating shapes with soft-edge");
                logger.Info($"     > Error: {softEdgeInsertResult.Errors.AsMessages().ToStringBuilder()}");
                return;
            }

            #endregion

            #region Create output result

            var result = doc.CreateResult(new OutputResultConfig {AutoFitColumns = true});
            if (!result.Success)
            {
                logger.Info("   > Error creating output result");
                logger.Info($"     > Error: {result.Errors.AsMessages().ToStringBuilder()}");
                return;
            }

            #endregion

            #region Saves output result

            var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample10/Sample-10" });
            if (!saveResult.Success)
            {
                logger.Info("   > Error while saving to disk");
                logger.Info($"     > Error: {saveResult.Errors.AsMessages().ToStringBuilder()}");
                return;
            }

            logger.Info("   > Saved to disk correctly");
            logger.Info("     > Path: ~/Output/Sample10/Sample-10.xlsx");

            #endregion
        }
    }
}
