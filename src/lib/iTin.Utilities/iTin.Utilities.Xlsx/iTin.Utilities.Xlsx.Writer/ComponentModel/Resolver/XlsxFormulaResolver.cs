
namespace iTin.Utilities.Xlsx.Writer.ComponentModel
{
    using System.Diagnostics;

    using iTin.Core.Models.Design.Enums;

    using Design.Shared;

    /// <summary>
    /// Represents a qualified <b>xlsx</b> aggregate definition.
    /// </summary>
    public class XlsxFormulaResolver
    {
        #region private readonly members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly QualifiedAggregateDefinition _model;
        #endregion

        #region constructor/s

        #region [public] XlsxFormulaResolver(QualifiedAggregateDefinition): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxFormulaResolver"/> class.
        /// </summary>
        /// <param name="aggregate">Aggregate's data.</param>
        public XlsxFormulaResolver(QualifiedAggregateDefinition aggregate)
        {
            _model = aggregate;

            WorkSheet = string.Empty;
            HasAutoFilter = YesNo.No;
        }
        #endregion

        #endregion

        #region public properties

        #region [public] (YesNo) HasAutofilter: Gets or sets a value indicating whether the auto filter is enabled
        /// <summary>
        /// Gets or sets a value indicating whether the auto filter is enabled. The dafault is <see cref="YesNo.No"/>.
        /// </summary>
        /// <value>
        /// <see cref="YesNo.Yes"/> if auto filter is enabled; otherwise, <see cref="YesNo.No"/>.
        /// </value>
        public YesNo HasAutoFilter { get; set; }
        #endregion

        #region [public] (string) WorkSheet: Gets or sets a value containing worksheet name
        /// <summary>
        /// Gets or sets a value containing worksheet name.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing worksheet name.
        /// </value>
        public string WorkSheet { get; set; }
        #endregion 

        #endregion

        #region public methods

        #region [public] (string) Resolve(): Returns string containing aggregate's formula
        /// <summary>
        /// Returns string containing aggregate's formula.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> containing the formula.
        /// </returns>
        public string Resolve()
        {
            if (_model.AggregateType == KnownAggregateType.None)
            {
                return string.Empty;
            }

            int type;
            switch (_model.AggregateType)
            {
                case KnownAggregateType.Average:
                    type = HasAutoFilter == YesNo.Yes ? 101 : 1;
                    break;

                case KnownAggregateType.Count:
                    type = HasAutoFilter == YesNo.Yes ? 103 : 3;
                    break;

                case KnownAggregateType.Max:
                    type = HasAutoFilter == YesNo.Yes ? 104 : 4;
                    break;

                case KnownAggregateType.Min:
                    type = HasAutoFilter == YesNo.Yes ? 105 : 5;
                    break;

                default:
                case KnownAggregateType.Sum:
                    type = HasAutoFilter == YesNo.Yes ? 109 : 9;
                    break;
            }

            return string.IsNullOrEmpty(WorkSheet)
                ? $"SUBTOTAL({type}, {_model.Range})"
                : $"SUBTOTAL({type}, '{WorkSheet}'!{_model.Range})";
        }
        #endregion

        #endregion
    }
}
