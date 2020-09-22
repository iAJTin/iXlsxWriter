﻿
namespace iTin.Utilities.Xlsx.Design.Settings
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Defines the allowed document sizes.
    /// </summary>
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KnownDocumentSize
    {
        /// <summary>
        /// DIN A0. (841 × 1189)mm, (33.11 × 46.81)in
        /// </summary>
        A0,

        /// <summary>
        /// DIN A1. (594 × 841)mm, (23.39 × 33.11) in
        /// </summary>
        A1,

        /// <summary>
        /// DIN A2. (420 × 594)mm, (16.54 × 23.39)in
        /// </summary>
        A2,

        /// <summary>
        /// DIN A3. (297 × 420)m, (11.69 × 16.54)in
        /// </summary>
        A3,

        /// <summary>
        /// DIN A4. (210 × 297)mm, (8.27 × 11.69)in
        /// </summary>
        A4,

        /// <summary>
        /// DIN A5. (148.5 × 210)mm, (5.83 × 8.27)in
        /// </summary>
        A5,

        /// <summary>
        /// DIN A6. (105 × 148.5)mm, (4.13 × 5.83)in
        /// </summary>
        A6,

        /// <summary>
        /// DIN A7. (74 × 105)mm, (2.91 × 4.13)in
        /// </summary>
        A7,

        /// <summary>
        /// DIN A8. (52 × 74)mm, (2.05 × 2.91)in
        /// </summary>
        A8,

        /// <summary>
        /// DIN A9. (37 × 52)mm, (1.46 × 2.05)in
        /// </summary>
        A9,

        /// <summary>
        /// DIN A10. (26 × 37)mm, (1.02 × 1.46)in
        /// </summary>
        A10,

        /// <summary>
        /// Executive size.
        /// </summary>
        Executive,

        /// <summary>
        /// Half letter size.
        /// </summary>
        HalfLetter,

        /// <summary>
        /// Letter size.
        /// </summary>
        Letter,

        /// <summary>
        /// Note size.
        /// </summary>
        Note,

        /// <summary>
        /// PostCard size.
        /// </summary>
        PostCard
    }
}
