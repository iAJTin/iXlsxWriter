# InsertCopyRange class

A Specialization of [`InsertBase`](InsertBase.md) class. Allows copy a source range to destination worksheet and point.

```csharp
public class InsertCopyRange : InsertBase
```

## Public Members

| name | description |
| --- | --- |
| [InsertCopyRange](InsertCopyRange/InsertCopyRange.md)() | Initializes a new instance of the [`InsertCopyRange`](InsertCopyRange.md) class. |
| [Destination](InsertCopyRange/Destination.md) { get; set; } | Gets or sets a reference to destination point. |
| [SourceRange](InsertCopyRange/SourceRange.md) { get; set; } | Gets or sets a reference to source range. |

## Protected Members

| name | description |
| --- | --- |
| override [InsertImpl](InsertCopyRange/InsertImpl.md)(…) | Implementation to execute when insert action. |

## See Also

* class [InsertBase](InsertBase.md)
* namespace [iTin.Utilities.Xlsx.Writer.ComponentModel](../iTin.Utilities.Xlsx.Writer.md)

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Utilities.Xlsx.Writer.dll -->