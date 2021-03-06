# XlsxObjectConfig class

Specialization of [`IXlsxObjectConfig`](../iTin.Utilities.Xlsx.Writer.ComponentModel/IXlsxObjectConfig.md) interface. Represents configuration information for an object [`XlsxObject`](XlsxObject.md).

```csharp
public sealed class XlsxObjectConfig : IXlsxObjectConfig
```

## Public Members

| name | description |
| --- | --- |
| [XlsxObjectConfig](XlsxObjectConfig/XlsxObjectConfig.md)() | Initializes a new instance of the [`XlsxObjectConfig`](XlsxObjectConfig.md) class. |
| static readonly [Default](XlsxObjectConfig/Default.md) | Defaults configuration. Use index and delete the physical files after merge. |
| [AllowCompression](XlsxObjectConfig/AllowCompression.md) { get; set; } | Gets or sets a value indicating whether compression is allowed. |
| [CompressionThreshold](XlsxObjectConfig/CompressionThreshold.md) { get; set; } | Gets or sets a value that establishes the threshold from which the output stream will be compressed, this value will be set to MB, remember that a MB equals 1.024 Bytes. |
| [DeletePhysicalFilesAfterMerge](XlsxObjectConfig/DeletePhysicalFilesAfterMerge.md) { get; set; } | Gets or sets a value indicating whether delete physical files after merge. |
| [UseIndex](XlsxObjectConfig/UseIndex.md) { get; set; } | Gets or sets a value indicating whether use index. |
| override [ToString](XlsxObjectConfig/ToString.md)() | Returns a string that represents the current data type. |
| const [OneMegaByte](XlsxObjectConfig/OneMegaByte.md) | Defines a one-megabyte in bytes. |

## See Also

* interface [IXlsxObjectConfig](../iTin.Utilities.Xlsx.Writer.ComponentModel/IXlsxObjectConfig.md)
* namespace [iTin.Utilities.Xlsx.Writer](../iTin.Utilities.Xlsx.Writer.md)

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Utilities.Xlsx.Writer.dll -->
