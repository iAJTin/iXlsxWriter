# SetResult.CreateErroResult method (1 of 4)

Returns a new [`SetResult`](../SetResult.md) with specified detailed errors collection.

```csharp
public static SetResult CreateErroResult(IResultError[] errors)
```

| parameter | description |
| --- | --- |
| errors | A errors collection |

## Return Value

A new invalid [`SetResult`](../SetResult.md) with specified detailed errors collection.

## See Also

* class [SetResult](../SetResult.md)
* namespace [iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Set](../../iTin.Utilities.Xlsx.Writer.md)

---

# SetResult.CreateErroResult method (2 of 4)

Returns a new [`SetResult`](../SetResult.md) with specified detailed errors collection.

```csharp
public static SetResult CreateErroResult(IResultError[] errors, SetResultData value)
```

| parameter | description |
| --- | --- |
| errors | A errors collection |
| value | Response value |

## Return Value

A new invalid [`SetResult`](../SetResult.md) with specified detailed errors collection.

## See Also

* class [SetResultData](../SetResultData.md)
* class [SetResult](../SetResult.md)
* namespace [iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Set](../../iTin.Utilities.Xlsx.Writer.md)

---

# SetResult.CreateErroResult method (3 of 4)

Returns a new [`SetResult`](../SetResult.md) with specified detailed error.

```csharp
public static SetResult CreateErroResult(string message, string code = "")
```

| parameter | description |
| --- | --- |
| message | Error message |
| code | Error code |

## Return Value

A new invalid [`SetResult`](../SetResult.md) with specified detailed error.

## See Also

* class [SetResult](../SetResult.md)
* namespace [iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Set](../../iTin.Utilities.Xlsx.Writer.md)

---

# SetResult.CreateErroResult method (4 of 4)

Returns a new [`SetResult`](../SetResult.md) with specified detailed error.

```csharp
public static SetResult CreateErroResult(string message, SetResultData value, string code = "")
```

| parameter | description |
| --- | --- |
| message | Error message |
| value | Response value |
| code | Error code |

## Return Value

A new invalid [`SetResult`](../SetResult.md) with specified detailed errors collection.

## See Also

* class [SetResultData](../SetResultData.md)
* class [SetResult](../SetResult.md)
* namespace [iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Set](../../iTin.Utilities.Xlsx.Writer.md)

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Utilities.Xlsx.Writer.dll -->