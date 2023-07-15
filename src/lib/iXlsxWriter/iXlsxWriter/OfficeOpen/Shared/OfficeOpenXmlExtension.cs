﻿
using System;
using System.ComponentModel;
using System.Linq;

using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;

using iTin.Core.Models.Design.ComponentModel;
using iTin.Core.Models.Design.Enums;

using iTin.Utilities.Xlsx.Design.Charts;
using iTin.Utilities.Xlsx.Design.Shared;
using iTin.Utilities.Xlsx.Design.Settings.Document;
using iTin.Utilities.Xlsx.Design.Styles;
using iTin.Utilities.Xlsx.Writer;
using System.IO.Packaging;

namespace OfficeOpenXml;

/// <summary>
/// Static class than contains common extension methods for objects of the namespace <see cref="N:OfficeOpenXml"/>.
/// </summary>
internal static class OfficeOpenXmlExtension
{
    #region public static methods

    /// <summary>
    /// Writes a error comment for specified cell.
    /// </summary>
    /// <param name="cell">Cell to try apply specified comment.</param>
    /// <param name="value">Reference to value information.</param>
    public static void AddErrorComment(this ExcelRangeBase cell, FieldValueInformation value)
    {
        var comment = value.Comment;
        if (comment == null)
        {
            return;
        }

        var showComment = comment.Show == YesNo.Yes;
        if (!showComment)
        {
            return;
        }

        var font = comment.Font;
        var text = $"{comment.Text} {value.Value}";
        var autorComment = $"{Environment.MachineName}\\{Environment.UserName}";

        var cellComment = cell.AddComment(text, autorComment);
        cellComment.Font.Size = font.Size;
        cellComment.Font.FontName = font.Name;
        cellComment.Font.Color = font.GetColor();
        cellComment.Font.Bold = font.Bold == YesNo.Yes;
        cellComment.Font.Italic = font.Italic == YesNo.Yes;
        cellComment.Font.UnderLine = font.Underline == YesNo.Yes;
    }

    /// <summary>
    /// Creates list of styles.
    /// </summary>
    /// <param name="styles">The styles.</param>
    /// <param name="styleName">The style name.</param>
    public static void CreateEmptyStyleFromModel(this ExcelStyles styles, string styleName)
    {
        try
        {
            styles.CreateNamedStyle(styleName);

            var alternateStyleName = $"{styleName}_Alternate";
            styles.CreateNamedStyle(alternateStyleName);
        }
        catch
        {
            // Already exist.
        }
    }

    /// <summary>
    /// Creates list of styles.
    /// </summary>
    /// <param name="styles">The styles.</param>
    /// <param name="model">The model.</param>
    public static void CreateFromModel(this ExcelStyles styles, XlsxStylesCollection model)
    {
        var defaultStyle = XlsxCellStyle.Default;

        var xlsxStyle = styles.CreateNamedStyle(defaultStyle.Name);
        xlsxStyle.Style.FormatFromModel(defaultStyle);

        foreach (var style in model)
        {
            xlsxStyle = styles.CreateNamedStyle(style.Name);
            xlsxStyle.Style.FormatFromModel((XlsxCellStyle)style);

            var alternateStyleName = $"{style.Name}_Alternate";
            xlsxStyle = styles.CreateNamedStyle(alternateStyleName);
            xlsxStyle.Style.FormatFromModel((XlsxCellStyle)style, true);
        }
    }

    /// <summary>
    /// Returns the index of specified style name into the styles collection.
    /// </summary>
    /// <param name="styles">Target styles collection.</param>
    /// <param name="styleName">The style name.</param>
    /// <returns>
    /// Index of specified style name into the styles collection.
    /// </returns>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    public static int GetNamedStyleId(this ExcelStyles styles, string styleName) =>
        styles.NamedStyles.TakeWhile(namedStyle => namedStyle.Name != styleName).Count();

    /// <summary>
    ///  Returns pixels convert to excel column width.
    /// </summary>
    /// <param name="worksheet">The worksheet.</param>
    /// <param name="pixels">The pixels.</param>
    /// <returns>
    /// A <see cref="T:System.Double" /> which contains specified pixels convert into excel column width.
    /// </returns>
    public static double PixelsToColumnWidth(this ExcelWorksheet worksheet, int pixels)
    {
        // The correct method to convert pixel to width is:
        // 1. use the formula =Truncate(({pixels}-5)/{Maximum Digit Width} * 100+0.5)/100 to convert pixel to character number.
        // 2. use the formula width = Truncate([{Number of Characters} * {Maximum Digit Width} + {5 pixel padding}]/{Maximum Digit Width}*256)/256 to convert the character number to width.

        // Get the maximum digit width
        decimal mdw = worksheet.Workbook.MaxFontWidth;

        // Convert pixel to character number
        var numChars = decimal.Truncate(decimal.Add((pixels - 5) / mdw * 100, (decimal)0.5)) / 100;

        // Convert the character number to width
        var excelColumnWidth = decimal.Truncate((decimal.Add(numChars * mdw, 5)) / mdw * 256) / 256;

        return Convert.ToDouble(excelColumnWidth);
    }

    /// <summary>
    /// Set picture border.
    /// </summary>
    /// <param name="border">Target border.</param>
    /// <param name="model">Border to draw.</param>
    public static void SetBorder(this ExcelDrawingBorder border, XlsxBorder model)
    {
        if (model.Show == YesNo.No)
        {
            return;
        }

        border.Fill.Style = eFillStyle.SolidFill;
        border.Fill.Color = model.GetColor();
        border.Fill.Transparancy = model.Transparency;
        border.LineStyle = model.Style.ToEppLineStyle();
        border.Width = model.Width;
    }

    /// <summary>
    /// Sets the document metadata from model.
    /// </summary>
    /// <param name="properties">The document properties.</param>
    /// <param name="metadata">Model metadata information.</param>
    /// <returns>
    /// An <see cref="OfficeProperties"/> reference which contains the document metadata.
    /// </returns>
    public static OfficeProperties SetDocumentMetadata(this OfficeProperties properties, XlsxDocumentMetadataSettings metadata)
    {
        // Core properties
        properties.Created = DateTime.Now;
        properties.Modified = DateTime.Now;
            
        if (!string.IsNullOrEmpty(metadata.Title))
        {
            properties.Title = metadata.Title;
        }

        if (!string.IsNullOrEmpty(metadata.Subject))
        {
            properties.Subject = metadata.Subject;
        }

        if (!string.IsNullOrEmpty(metadata.Author))
        {
            properties.Author = metadata.Author;
        }

        if (!string.IsNullOrEmpty(metadata.Manager))
        {
            properties.Manager = metadata.Manager;
        }

        if (!string.IsNullOrEmpty(metadata.Company))
        {
            properties.Company = metadata.Company;
        }

        if (!string.IsNullOrEmpty(metadata.Category))
        {
            properties.Category = metadata.Category;
        }

        if (!string.IsNullOrEmpty(metadata.Keywords))
        {
            properties.Keywords = metadata.Keywords;
        }

        if (!string.IsNullOrEmpty(metadata.Comments))
        {
            properties.Comments = metadata.Comments;
        }

        if (!string.IsNullOrEmpty(metadata.Url))
        {
            var isValid = Uri.IsWellFormedUriString(metadata.Url, UriKind.RelativeOrAbsolute);
            if (isValid)
            {
                try
                {
                    properties.HyperlinkBase = new Uri(metadata.Url, UriKind.RelativeOrAbsolute);
                }
                catch
                {
                    // ignored
                }
            }
        }

        return properties;
    }

    /// <summary>
    /// Converter for <see cref="TextOrientation"/> enumeration type to angle degree.
    /// </summary>
    /// <param name="orientation">Orientation style from model.</param>
    /// <returns>
    /// Orientation as angle in degrees.
    /// </returns>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    public static float ToAngle(this TextOrientation orientation) =>
        orientation switch
        {
            TextOrientation.Upward => 270,
            TextOrientation.Horizontal => 0,
            TextOrientation.Vertical => 0,
            _ => 90
        };

    /// <summary>
    /// Converter for <see cref="LabelOrientation"/> enumeration type to angle degree.
    /// </summary>
    /// <param name="orientation">Orientation style from model.</param>
    /// <returns>
    /// Orientation as angle in degrees.
    /// </returns>
    /// <exception cref="InvalidEnumArgumentException">The value specified is outside the range of valid values.</exception>
    public static float ToAngle(this LabelOrientation orientation) =>
        orientation switch
        {
            LabelOrientation.Upward => -5400000,
            LabelOrientation.Downward => 5400000,
            LabelOrientation.Vertical => 0,
            LabelOrientation.Horizontal => 0,
            _ => 0
        };

    #endregion
}
