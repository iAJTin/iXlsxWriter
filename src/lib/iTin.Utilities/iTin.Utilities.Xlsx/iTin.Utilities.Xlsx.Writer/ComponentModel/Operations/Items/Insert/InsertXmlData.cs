
namespace iTin.Utilities.Xlsx.Writer.ComponentModel
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    using OfficeOpenXml;

    using iTin.Core.Helpers;

    using Design.Shared;

    using Result.Insert;

    /// <summary>
    /// A Specialization of <see cref="InsertLocationBase"/> class.<br/>
    /// Allows insert a <b>XML</b> data file.
    /// </summary>
    public class InsertXmlData : InsertLocationBase
    {
        #region constructor/s

        #region [public] InsertXmlData(): Initializes a new instance of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="InsertXmlData"/> class.
        /// </summary>
        public InsertXmlData()
        {
            File = null;
            SheetName = string.Empty;
            Location = new XlsxPointRange {Column = 1, Row = 1};
        }
        #endregion

        #endregion

        #region public properties

        #region [public] (string) File: Gets or sets a reference 
        /// <summary>
        /// Gets or sets a reference to datatable to insert.
        /// </summary>
        /// <value>
        /// A <see cref="DataTable"/> reference to insert.
        /// </value>
        public string File { get; set; }
        #endregion

        #endregion

        #region protected override methods

        #region [protected] {override} (InsertResult) InsertImpl(Stream, IInput): Implementation to execute when insert action
        /// <summary>
        /// Implementation to execute when insert action.
        /// </summary>
        /// <param name="input">stream input</param>
        /// <param name="context">Input context</param>
        /// <returns>
        /// <para>
        /// A <see cref="InsertResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
        /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
        /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
        /// </para>
        /// <para>
        /// The type of the return value is <see cref="InsertResultData"/>, which contains the operation result
        /// </para>
        /// </returns>
        protected override InsertResult InsertImpl(Stream input, IInput context)
        {
            if (string.IsNullOrEmpty(SheetName))
            {
                return InsertResult.CreateErroResult(
                    "Sheet name can not be null or empty",
                    new InsertResultData
                    {
                        Context = context,
                        InputStream = input,
                        OutputStream = input
                    });
            }

            if (Location == null)
            {
                return InsertResult.CreateSuccessResult(new InsertResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
            }

            if (string.IsNullOrEmpty(File))
            {
                return InsertResult.CreateSuccessResult(new InsertResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
            }

            return InsertImpl(context, input, SheetName, Location, File);
        }
        #endregion

        #endregion

        #region private static methods

        private static InsertResult InsertImpl(IInput context, Stream input, string sheetName, XlsxBaseRange location, string file)
        {
            var outputStream = new MemoryStream();

            try
            {
                using (var excel = new ExcelPackage(input))
                {
                    var ws = excel.Workbook.Worksheets.FirstOrDefault(worksheet => worksheet.Name.Equals(sheetName, StringComparison.OrdinalIgnoreCase));
                    if (ws == null)
                    {
                        return InsertResult.CreateErroResult(
                            $"Sheet '{sheetName}' not found",
                            new InsertResultData
                            {
                                Context = context,
                                InputStream = input,
                                OutputStream = input
                            });
                    }

                    ExcelAddressBase locationAddress = location.ToEppExcelAddress();
                    //ws.Cells[locationAddress.ToString()].lo(data, true);

                    var a = LoadXmlFromFile(file,"*");

                    excel.SaveAs(outputStream);

                    return InsertResult.CreateSuccessResult(new InsertResultData
                    {
                        Context = context,
                        InputStream = input,
                        OutputStream = outputStream
                    });
                }
            }
            catch (Exception ex)
            {
                return InsertResult.FromException(
                    ex,
                    new InsertResultData
                    {
                        Context = context,
                        InputStream = input,
                        OutputStream = input
                    });
            }
        }

        #endregion

        #region [protected] {static} (IEnumerable<XElement>) LoadXmlFromFile(string, string): Retrieves Xml content of specified table in a file
        /// <summary>
        /// Retrieves <c>Xml</c> content of specified <paramref name="table" /> in a file.
        /// </summary>
        /// <param name="fileName">Target filename</param>
        /// <param name="table">Table to retrieve</param>
        /// <returns>
        /// A collection of <see cref="T:System.Xml.Linq.XElement"/> that contains the table content as <strong>XML</strong>.
        /// </returns>
        protected static IEnumerable<XElement> LoadXmlFromFile(string fileName, string table)
        {
            SentinelHelper.IsTrue(string.IsNullOrEmpty(table));
            SentinelHelper.IsTrue(string.IsNullOrEmpty(fileName));

            IEnumerable<XElement> nodes = null;
            using (var stream = new FileStream(iTin.Core.IO.Path.PathResolver(fileName), FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
            {
                var reader = new XmlTextReader(stream);
                var document = XDocument.Load(reader);
                var root = document.Root;
                if (root != null)
                {
                    nodes = table == "*"
                        ? root.Elements()
                        : root.Elements(table);
                }

                ////var query = from element in root.Elements()
                ////            group element.Attributes().FirstOrDefault() by element.Name;
                ////var qq = from e in query let c = e.Count() where c > 1 select e.GetEnumerator();
                ////var vvvv = qq.Cast<XAttribute>().ToList();
            }

            return nodes;
        }
        #endregion
    }
}
