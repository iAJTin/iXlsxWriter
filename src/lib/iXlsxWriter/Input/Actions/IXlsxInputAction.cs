
using iXlsxWriter.Operations.Insert;
using iXlsxWriter.Operations.Replace;
using iXlsxWriter.Operations.Set;

namespace iXlsxWriter.Input
{
    /// <summary>
    /// 
    /// </summary>
    public interface IXlsxInputAction
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IXlsxInputAction Insert(IInsert data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IXlsxInputAction Replace(IReplace data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IXlsxInputAction Set(ISet data);
    }
}