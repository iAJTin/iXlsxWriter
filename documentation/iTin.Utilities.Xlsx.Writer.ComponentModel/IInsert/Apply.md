# IInsert.Apply method (1 of 2)

Try to execute the inseert action.

```csharp
public InsertResult Apply(Stream input, IInput context)
```

| parameter | description |
| --- | --- |
| input | stream input |
| context | Input context |

## Return Value

A [`InsertResult`](../../iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Insert/InsertResult.md) reference that contains the result of the operation, to check if the operation is correct, the Success property will be true and the Value property will contain the value; Otherwise, the the Success property will be false and the Errors property will contain the errors associated with the operation, if they have been filled in.

The type of the return value is [`InsertResultData`](../../iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Insert/InsertResultData.md), which contains the operation result

## See Also

* class [InsertResult](../../iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Insert/InsertResult.md)
* interface [IInput](../IInput.md)
* interface [IInsert](../IInsert.md)
* namespace [iTin.Utilities.Xlsx.Writer.ComponentModel](../../iTin.Utilities.Xlsx.Writer.md)

---

# IInsert.Apply method (2 of 2)

Try to execute the insert action.

```csharp
public InsertResult Apply(string file, IInput context)
```

| parameter | description |
| --- | --- |
| file | file input |
| context | Input context |

## Return Value

A [`InsertResult`](../../iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Insert/InsertResult.md) reference that contains the result of the operation, to check if the operation is correct, the Success property will be true and the Value property will contain the value; Otherwise, the the Success property will be false and the Errors property will contain the errors associated with the operation, if they have been filled in.

The type of the return value is [`InsertResultData`](../../iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Insert/InsertResultData.md), which contains the operation result

## See Also

* class [InsertResult](../../iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Insert/InsertResult.md)
* interface [IInput](../IInput.md)
* interface [IInsert](../IInsert.md)
* namespace [iTin.Utilities.Xlsx.Writer.ComponentModel](../../iTin.Utilities.Xlsx.Writer.md)

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Utilities.Xlsx.Writer.dll -->