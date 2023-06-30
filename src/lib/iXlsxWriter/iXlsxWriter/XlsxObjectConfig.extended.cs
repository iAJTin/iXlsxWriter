
namespace iXlsxWriter
{
    public sealed partial class XlsxObjectConfig
    {
        /// <summary>
        /// Returns a string that represents the current data type.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> than represents the current object.
        /// </returns>
        public override string ToString() => $"UseIndex={UseIndex}, DeletePhysicalFilesAfterMerge={DeletePhysicalFilesAfterMerge}";
    }
}
