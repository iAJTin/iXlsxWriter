
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

using iTin.Core;
using iTin.Core.Helpers;

using iTin.Logging;

using iTin.Utilities.Xlsx.Writer.ComponentModel;
using iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Output;

namespace iTin.Utilities.Xlsx.Writer
{
    /// <summary>
    /// Represents a generic xlsx object, this allows add docx files to <see cref="XlsxObject.Items"/> property and specify a user custom configuration.
    /// </summary>
    public class XlsxObject : IDisposable
    {
        #region private field members

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _isDisposed;

        #endregion

        #region constructor/s

        #region [public] XlsxObject(): Initializes a new instance of the class with default configuration
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxObject"/> class with default configuration.
        /// </summary>
        public XlsxObject() : this(XlsxObjectConfig.Default)
        {     
        }
        #endregion

        #region [public] XlsxObject(XlsxObjectConfig): Initializes a new instance of the class with specified configuration
        /// <summary>
        /// Initializes a new instance of the <see cref="XlsxObject"/> class with specified configuration
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public XlsxObject(XlsxObjectConfig configuration)
        {
            Logger.Instance.Debug("External Call");
            Logger.Instance.Info("  Initializes a new instance of the XlsxObject class with specified configuration");
            Logger.Instance.Info("  > Library: iTin.Utilities.Xlsx");
            Logger.Instance.Info("  > Class: XlsxObject");
            Logger.Instance.Info("  > Method: ctor(XlsxObjectConfig)");

            Configuration = configuration;
            Items = new List<XlsxInput>();
        }
        #endregion

        #endregion

        #region finalizer

        #region [~] XlsxObject(): Finalizer
        /// <summary>
        /// Finalizer
        /// </summary>
        ~XlsxObject()
        {
            Dispose(false);
        }
        #endregion

        #endregion

        #region interfaces

        #region IDisposable

        #region public methods

        #region [public] (void) Dispose(): Clean managed resources
        /// <summary>
        /// Clean managed resources
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #endregion

        #endregion

        #endregion

        #region public properties

        #region [public] (IEnumerable<XlsxInput>) Items: Gets or sets the xlsx input list
        /// <summary>
        /// Gets or sets the xlsx input list.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public IEnumerable<XlsxInput> Items { get; set; }
        #endregion

        #region [public] (XlsxObjectConfig) Configuration: Gets the configuration settings
        /// <summary>
        /// Gets the configuration settings.
        /// </summary>
        /// <value>
        /// The object configuration.
        /// </value>
        public XlsxObjectConfig Configuration { get; }
        #endregion

        #endregion

        #region public methods

        #region [public] (OutputResult) TryMergeInputs(): Merges all XlsInput entries
        /// <summary>
        /// Merges all <see cref="XlsxInput"/> entries.
        /// </summary>
        /// <returns>
        /// <para>
        /// A <see cref="OutputResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
        /// property will be <b>true</b> and the <b>Value</b> property will contain the value; Otherwise, the the <b>Success</b> property
        /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
        /// </para>
        /// <para>
        /// The type of the return value is <see cref="OutputResultData"/>, which contains the operation result
        /// </para>
        /// </returns>
        public OutputResult TryMergeInputs()
        {
            Logger.Instance.Debug("");
            Logger.Instance.Debug(" Assembly: iTin.Utilities.Xlsx.Writer, Namespace: iTin.Utilities.Xlsx.Writer, Class: XlsxObject");
            Logger.Instance.Debug($" Merges all {typeof(XlsxInput)} entries into a new {typeof(XlsxObject)}");
            Logger.Instance.Debug($" > Signature: ({typeof(OutputResult)}) TryMergeInputs()");

            var items = Items.ToList();

            //if (Configuration.UseIndex)
            //{
            //    items = items.OrderBy(i => i.Index).ToList();
            //}

            try
            {
                MemoryStream outStream = new MemoryStream(); //MergeFiles(items.Select(item => item.ToStream()));

                if (Configuration.DeletePhysicalFilesAfterMerge)
                {
                    foreach (var item in items)
                    {
                        var inputType = item.InputType;
                        if (inputType != KnownInputType.Filename)
                        {
                            continue;
                        }

                        if (item.DeletePhysicalFilesAfterMerge)
                        {
                            File.Delete(TypeHelper.ToType<string>(item.Input));
                        }
                    }
                }

                var safeOutAsByteArray = outStream.GetBuffer();
                var outputInMegaBytes = (float)safeOutAsByteArray.Length / XlsxObjectConfig.OneMegaByte;
                var generateOutputAsZip = outputInMegaBytes > Configuration.CompressionThreshold;
                var zipped = Configuration.AllowCompression && generateOutputAsZip;

                return
                    OutputResult.CreateSuccessResult(
                        new OutputResultData
                        {
                            Zipped = zipped,
                            Configuration = Configuration,
                            UncompressOutputStream = safeOutAsByteArray.ToMemoryStream()
                        });
            }    
            catch (Exception ex)
            {
                return OutputResult.FromException(ex);
            }
        }
        #endregion

        #endregion

        #region public override methods

        #region [public] {override} (string) ToString(): Returns a string than represents the current object
        /// <summary>
        /// Returns a string that represents the current data type.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> than represents the current object.
        /// </returns>
        public override string ToString() => $"Count={Items.Count()}";
        #endregion

        #endregion

        #region protected virtual methods

        #region [protected] {virtual} (void) Dispose(bool): Cleans managed and unmanaged resources
        /// <summary>
        /// Cleans managed and unmanaged resources.
        /// </summary>
        /// <param name="disposing">
        /// If it is <b>true</b>, the method is invoked directly or indirectly from the user code.
        /// If it is <b>false</b>, the method is called the finalizer and only unmanaged resources are finalized.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            // free managed resources
            if (disposing)
            {
                foreach (var item in Items)
                {
                    switch (item.InputType)
                    {
                        case KnownInputType.Stream:
                            ((Stream)item.Input)?.Dispose();
                            break;

                        case KnownInputType.ByteArray:
                            item.Input = null;
                            break;

                        case KnownInputType.Filename:
                            item.Input = null;
                            break;

                        case KnownInputType.NotSupported:
                            // nothing to do
                            break;
                    }
                }

                Items = null;
            }

            // free native resources

            // avoid seconds calls 
            _isDisposed = true;
        }
        #endregion

        #endregion
    }
}
