﻿
namespace iTin.Utilities.Xlsx.Design.Shared
{
    using System;

    /// <summary>
    /// Represents a qualified <b>xlsx</b> point.
    /// </summary>
    public class QualifiedPointDefinition : ICloneable
    {
        #region constructor/s

        #region [public] QualifiedPointDefinition(): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="QualifiedPointDefinition"/> class.
        /// </summary>
        public QualifiedPointDefinition()
        {
            WorkSheet = string.Empty;
            Point = XlsxPoint.Default;
        }
        #endregion

        #endregion

        #region interfaces

        #region ICloneable

        #region explicit

        #region (object) ICloneable.Clone(): Creates a new object that is a copy of the current instance
        /// <inheritdoc />
        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        object ICloneable.Clone() => Clone();
        #endregion

        #endregion

        #endregion

        #endregion

        #region public properties

        #region [public] (string) WorkSheet: Gets or sets a value containing worksheet name
        /// <summary>
        /// Gets or sets a value containing worksheet name.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing worksheet name.
        /// </value>
        public string WorkSheet { get; set; }
        #endregion 

        #region [public] (XlsxPoint) Point: Gets or sets a value containig the data point
        /// <summary>
        /// Gets or sets a value containig the data point.
        /// </summary>
        /// <value>
        /// A <see cref="XlsxPoint"/> containing the data point.
        /// </value>
        public XlsxPoint Point { get; set; }
        #endregion

        #endregion

        #region public methods

        #region [public] (QualifiedPointDefinition) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public QualifiedPointDefinition Clone()
        {
            var cloned = (QualifiedPointDefinition) MemberwiseClone();
            cloned.Point = Point.Clone();

            return cloned;
        }
        #endregion

        #endregion

        #region public override methods

        #region [public] {override} (string) ToString(): Returns a string than represents the current object.
        /// <summary>
        /// Returns a string that represents the current data type.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> than represents the current object.
        /// </returns>
        public override string ToString() => $"WorkSheet=\"{WorkSheet}\", Point=\"{Point}\"";
        #endregion

        #endregion
    }
}
