# InsertLocationBase class

Specialization of [`ILocationInsert`](ILocationInsert.md) interface. Acts as base class for insert actions

```csharp
public abstract class InsertLocationBase : ILocationInsert
```

## Public Members

| name | description |
| --- | --- |
| [Location](InsertLocationBase/Location.md) { get; set; } | Gets or sets a reference a XlsxBaseRange which represents the insert location. |
| [SheetName](InsertLocationBase/SheetName.md) { get; set; } | Gets or sets the name of the sheet where it will be inserted. |
| [Apply](InsertLocationBase/Apply.md)(…) | Try to execute the insert action. (2 methods) |

## Protected Members

| name | description |
| --- | --- |
| [InsertLocationBase](InsertLocationBase/InsertLocationBase.md)() | The default constructor. |
| abstract [InsertImpl](InsertLocationBase/InsertImpl.md)(…) | Implementation to execute when insert action. |

## See Also

* interface [ILocationInsert](ILocationInsert.md)
* namespace [iTin.Utilities.Xlsx.Writer.ComponentModel](../iTin.Utilities.Xlsx.Writer.md)

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Utilities.Xlsx.Writer.dll -->
