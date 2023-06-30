
using System;
using System.Diagnostics;
using System.Xml.Serialization;

using Newtonsoft.Json;

using iTin.Core.Helpers;

namespace iTin.Utilities.Xlsx.Design.Shared
{
    /// <summary>
    /// A Specialization of <see cref="XlsxBaseRange"/> class.<br/>
    /// Represents a Excel cells range by alphaNumeric representation. Ex. "A1:B2", "A1", "$B$3:$F$33"
    /// </summary>
    public partial class XlsxStringRange : ICloneable
    {
        #region private field members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _address;
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

        #region [public] (string) Address: Gets or sets the cell(s) address
        /// <summary>
        /// Gets or sets the cell(s) address.
        /// </summary>
        /// <value>
        /// Horizontal cells
        /// </value>
        /// <exception cref="ArgumentNullException">The value specified is <b>null</b> (<b>Nothing</b> in Visual Basic) or empty.</exception>
        [XmlAttribute]
        [JsonProperty("address")]
        public string Address
        {
            get => _address;
            set
            {
                SentinelHelper.ArgumentNull(value, nameof(Address));
                _address = value;
            }
        }
        #endregion

        #endregion

        #region public override properties

        #region [public] {overide} (bool) IsDefault: Gets a value indicating whether this instance is default
        /// <inheritdoc />
        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        /// <b>true</b> if this instance contains the default; otherwise <b>false</b>.
        /// </value>
        public override bool IsDefault => base.IsDefault && string.IsNullOrEmpty(Address);
        #endregion

        #endregion

        #region public new methods

        #region [public] {new} (XlsxMiniChartStringRange) Clone(): Clones this instance
        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public new XlsxStringRange Clone()
        {
            var cloned = (XlsxStringRange)MemberwiseClone();
            cloned.Properties = Properties.Clone();

            return cloned;
        }
        #endregion

        #endregion

        #region public virtual methods

        //#region [public] {virtual} (void) ApplyOptions(XlsxStringRangeOptions): Apply specified options to this alignment
        ///// <summary>
        ///// Apply specified options to this alignment.
        ///// </summary>
        //public virtual void ApplyOptions(XlsxStringRangeOptions options)
        //{
        //    if (options == null)
        //    {
        //        return;
        //    }

        //    if (options.IsDefault)
        //    {
        //        return;
        //    }

        //    #region HorizontalCells
        //    int? horizontalCellsOption = options.HorizontalCells;
        //    bool horizontalCellsHasValue = horizontalCellsOption.HasValue;
        //    if (horizontalCellsHasValue)
        //    {
        //        HorizontalCells = horizontalCellsOption.Value;
        //    }
        //    #endregion

        //    #region VerticalCells
        //    int? verticalCellsOption = options.HorizontalCells;
        //    bool verticalCellsHasValue = verticalCellsOption.HasValue;
        //    if (verticalCellsHasValue)
        //    {
        //        VerticalCells = verticalCellsOption.Value;
        //    }
        //    #endregion
        //}
        //#endregion

        #region [public] {virtual} (void) Combine(XlsxStringRange): Combines this instance with reference parameter
        /// <summary>
        /// Combines this instance with reference parameter.
        /// </summary>
        /// <param name="reference">The reference.</param>
        public virtual void Combine(XlsxStringRange reference)
        {
            if (reference == null)
            {
                return;
            }

            Address = reference.Address;
        }
        #endregion

        #endregion

        #region public override methods

        #region [public] {override} (string) ToString(): Returns a string that represents the current object
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> that represents the current object.
        /// </returns>
        public override string ToString() => Address;
        #endregion

        #endregion
    }
}
