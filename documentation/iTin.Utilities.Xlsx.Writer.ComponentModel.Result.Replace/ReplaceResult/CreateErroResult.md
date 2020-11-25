# ReplaceResult.CreateErroResult method (1 of 2)

Returns a new [`ReplaceResult`](../ReplaceResult.md) with specified detailed errors collection.

```csharp
public static ReplaceResult CreateErroResult(IResultError[] errors)
```

| parameter | description |
| --- | --- |
| errors | A errors collection |

## Return Value

A new invalid [`ReplaceResult`](../ReplaceResult.md) with specified detailed errors collection.

## See Also

* class [ReplaceResult](../ReplaceResult.md)
* namespace [iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Replace](../../iTin.Utilities.Xlsx.Writer.md)

---

# ReplaceResult.CreateErroResult method (2 of 2)

Returns a new [`ReplaceResult`](../ReplaceResult.md) with specified detailed error.

```csharp
public static ReplaceResult CreateErroResult(string message, string code = "")
```

| parameter | description |
| --- | --- |
| message | Error message |
| code | Error code |

## Return Value

A new invalid [`ReplaceResult`](../ReplaceResult.md) with specified detailed error.

## See Also

* class [ReplaceResult](../ReplaceResult.md)
* namespace [iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Replace](../../iTin.Utilities.Xlsx.Writer.md)

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Utilities.Xlsx.Writer.dll -->