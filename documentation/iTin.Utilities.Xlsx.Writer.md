# iTin.Utilities.Xlsx.Writer assembly

## iTin.Utilities.Xlsx.Writer namespace

| public type | description |
| --- | --- |
| class [XlsxInput](iTin.Utilities.Xlsx.Writer/XlsxInput.md) | Represents a xlsx file. |
| class [XlsxObject](iTin.Utilities.Xlsx.Writer/XlsxObject.md) | Represents a generic xlsx object, this allows add docx files to [`Items`](iTin.Utilities.Xlsx.Writer/XlsxObject/Items.md) property and specify a user custom configuration. |
| class [XlsxObjectConfig](iTin.Utilities.Xlsx.Writer/XlsxObjectConfig.md) | Specialization of [`IXlsxObjectConfig`](iTin.Utilities.Xlsx.Writer.ComponentModel/IXlsxObjectConfig.md) interface. Represents configuration information for an object [`XlsxObject`](iTin.Utilities.Xlsx.Writer/XlsxObject.md). |

## iTin.Utilities.Xlsx.Writer.ComponentModel namespace

| public type | description |
| --- | --- |
| interface [IInput](iTin.Utilities.Xlsx.Writer.ComponentModel/IInput.md) | Defines a generic input |
| interface [IInsert](iTin.Utilities.Xlsx.Writer.ComponentModel/IInsert.md) | Defines allowed actions for insert objects |
| interface [IInsertWithStyle](iTin.Utilities.Xlsx.Writer.ComponentModel/IInsertWithStyle.md) | Specialization of [`ILocationInsert`](iTin.Utilities.Xlsx.Writer.ComponentModel/ILocationInsert.md) interface. Defines allowed actions for insert objects with style |
| interface [ILocationInsert](iTin.Utilities.Xlsx.Writer.ComponentModel/ILocationInsert.md) | Defines allowed actions for insert objects |
| class [InsertAggregateFunction](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertAggregateFunction.md) | A Specialization of [`InsertLocationBase`](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertLocationBase.md) class. Allows insert an aggregate function applied to specified data range in the specified location. |
| class [InsertAutoFilter](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertAutoFilter.md) | A Specialization of [`InsertLocationBase`](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertLocationBase.md) class. Allows insert an autofilter in the specified location |
| abstract class [InsertBase](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertBase.md) | Specialization of [`IInsert`](iTin.Utilities.Xlsx.Writer.ComponentModel/IInsert.md) interface. Acts as base class for insert actions. |
| class [InsertChart](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertChart.md) | A Specialization of [`InsertLocationBase`](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertLocationBase.md) class. Allows insert a XlsxChart. |
| class [InsertCopyRange](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertCopyRange.md) | A Specialization of [`InsertBase`](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertBase.md) class. Allows copy a source range to destination worksheet and point. |
| class [InsertDataTable](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertDataTable.md) | A Specialization of [`InsertLocationBase`](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertLocationBase.md) class. Allows insert a DataTable reference. |
| class [InsertDictionary](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertDictionary.md) | A Specialization of [`InsertBase`](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertBase.md) class. Allows insert a Dictionary reference. TKey is String TValue is Object. |
| class [InsertEnumerable&lt;Ti&gt;](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertEnumerable-1.md) | A Specialization of [`InsertWithStyleBase`](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertWithStyleBase.md) class. Allows insert a [`InsertEnumerable`](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertEnumerable-1.md) reference. |
| abstract class [InsertLocationBase](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertLocationBase.md) | Specialization of [`ILocationInsert`](iTin.Utilities.Xlsx.Writer.ComponentModel/ILocationInsert.md) interface. Acts as base class for insert actions |
| class [InsertMiniChart](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertMiniChart.md) | A Specialization of [`InsertLocationBase`](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertLocationBase.md) class. Allows insert a XlsxMiniChart. |
| class [InsertPicture](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertPicture.md) | A Specialization of [`InsertLocationBase`](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertLocationBase.md) class. Allows insert a picture in the specified location |
| class [InsertPivotTable](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertPivotTable.md) | A Specialization of [`InsertLocationBase`](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertLocationBase.md) class. Allows insert a pivot table in the specified location |
| class [InsertShape](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertShape.md) | A Specialization of [`InsertLocationBase`](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertLocationBase.md) class. Allows insert a xlsx shape. |
| class [InsertText](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertText.md) | A Specialization of [`InsertWithStyleBase`](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertWithStyleBase.md) class. Allows insert a text, number or date with style. |
| class [InsertTransposeRange](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertTransposeRange.md) | A Specialization of [`InsertWithStyleBase`](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertWithStyleBase.md) class. Allows to transpose a range of data indicating the destination sheet and the starting point. |
| abstract class [InsertWithStyleBase](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertWithStyleBase.md) | Specialization of [`InsertLocationBase`](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertLocationBase.md) class. Acts as base class for insert actions with style. |
| class [InsertXmlData](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertXmlData.md) | A Specialization of [`InsertLocationBase`](iTin.Utilities.Xlsx.Writer.ComponentModel/InsertLocationBase.md) class. Allows insert a XML data file. |
| interface [IReplace](iTin.Utilities.Xlsx.Writer.ComponentModel/IReplace.md) | Defines allowed actions for replacement objects. |
| interface [ISet](iTin.Utilities.Xlsx.Writer.ComponentModel/ISet.md) | Defines allowed actions for set features to worksheets. |
| interface [IXlsxObjectConfig](iTin.Utilities.Xlsx.Writer.ComponentModel/IXlsxObjectConfig.md) | Represents configuration information for an object [`XlsxInput`](iTin.Utilities.Xlsx.Writer/XlsxInput.md). |
| enum [KnownInputType](iTin.Utilities.Xlsx.Writer.ComponentModel/KnownInputType.md) | Specifies the known input type. |
| enum [KnownOutputType](iTin.Utilities.Xlsx.Writer.ComponentModel/KnownOutputType.md) | Specifies the known output type. |
| class [OutputResultConfig](iTin.Utilities.Xlsx.Writer.ComponentModel/OutputResultConfig.md) | Specialization of [`IXlsxObjectConfig`](iTin.Utilities.Xlsx.Writer.ComponentModel/IXlsxObjectConfig.md) interface. Represents configuration information for an object [`XlsxInput`](iTin.Utilities.Xlsx.Writer/XlsxInput.md). |
| abstract class [SetBase](iTin.Utilities.Xlsx.Writer.ComponentModel/SetBase.md) | Specialization of [`ISet`](iTin.Utilities.Xlsx.Writer.ComponentModel/ISet.md) interface. Acts as base class for set actions |
| class [SetColumnWidth](iTin.Utilities.Xlsx.Writer.ComponentModel/SetColumnWidth.md) | A Specialization of [`SetBase`](iTin.Utilities.Xlsx.Writer.ComponentModel/SetBase.md) class. Allows modify column(s) width in the specified worksheet. |
| class [SetGridLines](iTin.Utilities.Xlsx.Writer.ComponentModel/SetGridLines.md) | A Specialization of [`SetBase`](iTin.Utilities.Xlsx.Writer.ComponentModel/SetBase.md) class. Allows to establish the visibility of the grid lines of a spreadsheet. |
| class [SetRowHeight](iTin.Utilities.Xlsx.Writer.ComponentModel/SetRowHeight.md) | A Specialization of [`SetBase`](iTin.Utilities.Xlsx.Writer.ComponentModel/SetBase.md) class. Allows modify row(s) height in the specified worksheet. |
| class [SetWorkSheetName](iTin.Utilities.Xlsx.Writer.ComponentModel/SetWorkSheetName.md) | A Specialization of [`SetBase`](iTin.Utilities.Xlsx.Writer.ComponentModel/SetBase.md) class. Allows modify worksheet name. |
| class [XlsxFormulaResolver](iTin.Utilities.Xlsx.Writer.ComponentModel/XlsxFormulaResolver.md) | Represents a qualified xlsx aggregate definition. |

## iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Action namespace

| public type | description |
| --- | --- |
| interface [IOutputAction](iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Action/IOutputAction.md) | Defines allowed actions for output result. |

## iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Action.Save namespace

| public type | description |
| --- | --- |
| class [SaveToFile](iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Action.Save/SaveToFile.md) | Specialization of [`IOutputAction`](iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Action/IOutputAction.md) interface. Defines allowed actions for output result data |

## iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Insert namespace

| public type | description |
| --- | --- |
| class [InsertResult](iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Insert/InsertResult.md) | Specialization of ResultBase interface. Represents result after insert an element in xlsx document. |
| class [InsertResultData](iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Insert/InsertResultData.md) | Represents insert data for an object [`InsertResult`](iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Insert/InsertResult.md). |

## iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Output namespace

| public type | description |
| --- | --- |
| class [OutputResult](iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Output/OutputResult.md) | Specialization of ResultBase interface. Represents configuration information for an object [`OutputResult`](iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Output/OutputResult.md). |
| class [OutputResultData](iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Output/OutputResultData.md) | Represents configuration information for an object [`OutputResult`](iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Output/OutputResult.md). |

## iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Replace namespace

| public type | description |
| --- | --- |
| class [ReplaceResult](iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Replace/ReplaceResult.md) | Specialization of ResultBase interface. Represents result after insert an element in xlsx document. |
| class [ReplaceResultData](iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Replace/ReplaceResultData.md) | Represents insert data for an object [`ReplaceResult`](iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Replace/ReplaceResult.md). |

## iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Set namespace

| public type | description |
| --- | --- |
| class [SetResult](iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Set/SetResult.md) | Specialization of ResultBase interface. Represents result after set an element in xlsx document. |
| class [SetResultData](iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Set/SetResultData.md) | Represents set data for an object [`SetResult`](iTin.Utilities.Xlsx.Writer.ComponentModel.Result.Set/SetResult.md). |

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Utilities.Xlsx.Writer.dll -->
