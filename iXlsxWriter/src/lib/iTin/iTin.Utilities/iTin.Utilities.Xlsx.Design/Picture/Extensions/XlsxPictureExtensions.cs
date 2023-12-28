
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using iTin.Core.Drawing.ComponentModel;
using iTin.Core.Helpers;

namespace iTin.Utilities.Xlsx.Design.Picture;

/// <summary>
/// Contains common extensions for data model objects.
/// </summary>
internal static class XlsxPictureExtensions
{
    /// <summary>
    /// Converter for <see cref="XlsxEffectsCollection"/> reference to <see cref="IEnumerable{EffectType}"/>.
    /// </summary>
    /// <param name="effects">Effects collections.</param>
    /// <returns>
    /// A <see cref="IEnumerable{EffectType}"/> containing a effects collection.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="effects"/> is <b>null</b> (<b>Nothing</b> in Visual Basic).</exception>
    public static IEnumerable<EffectType> ToEffectTypeCollection(this XlsxEffectsCollection effects)
    {
        SentinelHelper.ArgumentNull(effects, nameof(effects));

        var result = new Collection<EffectType>();
        foreach (var effect in effects)
        {
            switch (effect)
            {
                case XlsxBrightnessEffect _:
                    result.Add(EffectType.Brightness);
                    break;

                case XlsxDarkEffect _:
                    result.Add(EffectType.Dark);
                    break;

                case XlsxDisabledEffect _:
                    result.Add(EffectType.Disabled);
                    break;

                case XlsxGrayScaleBlueEffect _:
                    result.Add(EffectType.GrayScaleBlue);
                    break;

                case XlsxGrayScaleEffect _:
                    result.Add(EffectType.GrayScale);
                    break;

                case XlsxGrayScaleGreenEffect _:
                    result.Add(EffectType.GrayScaleGreen);
                    break;

                case XlsxGrayScaleRedEffect _:
                    result.Add(EffectType.GrayScaleRed);
                    break;

                case XlsxMoreBrightnessEffect _:
                    result.Add(EffectType.MoreBrightness);
                    break;

                case XlsxMoreDarkEffect _:
                    result.Add(EffectType.MoreDark);
                    break;

                case XlsxOpacityEffect opacityEffect:
                    switch (opacityEffect.Value)
                    {
                        case > 0 and <= 5:
                            result.Add(EffectType.OpacityPercent05);
                            break;

                        case > 5 and <= 10:
                            result.Add(EffectType.OpacityPercent10);
                            break;

                        case > 10 and <= 20:
                            result.Add(EffectType.OpacityPercent20);
                            break;

                        case > 20 and <= 30:
                            result.Add(EffectType.OpacityPercent30);
                            break;

                        case > 30 and <= 40:
                            result.Add(EffectType.OpacityPercent40);
                            break;

                        case > 40 and <= 50:
                            result.Add(EffectType.OpacityPercent50);
                            break;

                        case > 50 and <= 60:
                            result.Add(EffectType.OpacityPercent60);
                            break;

                        case > 60 and <= 70:
                            result.Add(EffectType.OpacityPercent70);
                            break;

                        case > 70 and <= 80:
                            result.Add(EffectType.OpacityPercent80);
                            break;

                        case > 80 and <= 90:
                            result.Add(EffectType.OpacityPercent90);
                            break;

                        default:
                            result.Add(EffectType.OpacityPercent90);
                            break;
                    }
                    break;
            }
        }

        return result;
    }
}
