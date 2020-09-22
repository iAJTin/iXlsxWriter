
namespace iTin.Utilities.Xlsx.Design.Picture
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using iTin.Core.Drawing.ComponentModel;
    using iTin.Core.Helpers;

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

            Collection<EffectType> result = new Collection<EffectType>();
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
                        if (opacityEffect.Value > 0 && opacityEffect.Value <= 5)
                        {
                            result.Add(EffectType.OpacityPercent05);
                        }
                        else if (opacityEffect.Value > 5 && opacityEffect.Value <= 10)
                        {
                            result.Add(EffectType.OpacityPercent10);
                        }
                        else if (opacityEffect.Value > 10 && opacityEffect.Value <= 20)
                        {
                            result.Add(EffectType.OpacityPercent20);
                        }
                        else if (opacityEffect.Value > 20 && opacityEffect.Value <= 30)
                        {
                            result.Add(EffectType.OpacityPercent30);
                        }
                        else if (opacityEffect.Value > 30 && opacityEffect.Value <= 40)
                        {
                            result.Add(EffectType.OpacityPercent40);
                        }
                        else if (opacityEffect.Value > 40 && opacityEffect.Value <= 50)
                        {
                            result.Add(EffectType.OpacityPercent50);
                        }
                        else if (opacityEffect.Value > 50 && opacityEffect.Value <= 60)
                        {
                            result.Add(EffectType.OpacityPercent60);
                        }
                        else if (opacityEffect.Value > 60 && opacityEffect.Value <= 70)
                        {
                            result.Add(EffectType.OpacityPercent70);
                        }
                        else if (opacityEffect.Value > 70 && opacityEffect.Value <= 80)
                        {
                            result.Add(EffectType.OpacityPercent80);
                        }
                        else if (opacityEffect.Value > 80 && opacityEffect.Value <= 90)
                        {
                            result.Add(EffectType.OpacityPercent90);
                        }
                        else
                        {
                            result.Add(EffectType.OpacityPercent90);
                        }
                        break;
                }
            }

            return result;
        }
    }
}
