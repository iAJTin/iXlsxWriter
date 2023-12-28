# What is iXlsxWriter?

**iXlsxWriter** is a lightweight implementation that allows creates a **xlsx** document totally or partially.
**Currently only works on Windows**


The idea is to try to quickly and easily facilitate the task of filling in the 'typical' report file that the client wants to send by email with the data filled in from their erp, vertical application, custom development, etc... to which I am sure that you have faced each other at some point. 

I hope it helps someone. :smirk:

## Extensions

Below is a list of extensions available to use with **XlsxInput**.

   | Library | Version | Description |
   |:--------|:--------|:------------|
   | [![nuget package](./../assets/nuget_24x24.png)](https://www.nuget.org/packages/iXlsxWriter.AspNet) [iXlsxWriter.AspNet](https://github.com/iAJTin/iXlsxWriter.AspNet) | 1.0.0 | Extends **iXlsxWriter** to work in *AspNet* (FullFramework) projects, contains extension methods to download **XlsxInput** instances as well as **OutputResult**, facilitating its use in this environment |
   | [![nuget package](./../assets/nuget_24x24.png)](https://www.nuget.org/packages/iXlsxWriter.AspNetCore) [iXlsxWriter.AspNetCore](https://github.com/iAJTin/iXlsxWriter.AspNetCore) | 1.0.0 | Extends **iXlsxWriter** to work in *AspNetCore* projects, contains extension methods to download **XlsxInput** instances as well as **OutputResult**, facilitating its use in this environment |
   | [![nuget package](./../assets/nuget_24x24.png)](https://www.nuget.org/packages/iXlsxWriter.Mail) [iXlsxWriter.Mail](https://github.com/iAJTin/iXlsxWriter.Mail) | 1.0.0 | Extends **iXlsxWriter**, contains extension methods to download **XlsxInput** instances as well as **OutputResult** |

## Usage

### Samples

#### Sample 1 - Hello world!

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create("Sheet1");
    ```
        
2. Insert text

    ```csharp   
    doc.Insert(
        new InsertText
        {
            SheetName = "Sheet1",
            Data = "Hello world! from iXlsxWriter"
        });
    ```

3. Try to create xlsx output result

     **sync mode**
     ```csharp   
     var result = doc.CreateResult();
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

     **async mode**
     ```csharp   
     var result = await doc.CreateResultAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

4. Save xlsx file result
 
    **sync mode**
    ```csharp   
    var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-01/Sample-01" });
    if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

    **async mode**
    ```csharp   
    var saveResult = await result.Result
        .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-01/Sample-01" }, cancellationToken);
        .ConfigureAwait(false);

   if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

#### Sample 2 - Hello world! (With styles)

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create("Sheet1");
    ```
        
2. Define cell styles to use
              
    ```csharp  
    var cellStyles = new Dictionary<string, XlsxCellStyle>
    {
        {
            "Title",
            new XlsxCellStyle 
            {
                Font =
                {
                    Name = "Arial",
                    Size = 28.0f,
                    Bold = YesNo.Yes,
                    Color = "Blue"
                }
            }
        }
    };
    ```

3. Insert text

    ```csharp   
    doc.Insert(
        new InsertText
        {
            SheetName = "Sheet1",
            Style = cellStyles["Title"],
            Location = new XlsxPointRange { Column = 2, Row = 1 },
            Data = "Hello world! from iXlsxWriter"
        });
    ```

4. Try to create xlsx output result

     **sync mode**
     ```csharp   
     var result = doc.CreateResult();
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

     **async mode**
     ```csharp   
     var result = await doc.CreateResultAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

5. Save xlsx file result
 
    **sync mode**
    ```csharp   
    var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-02/Sample-02" });
   if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

    **async mode**
    ```csharp   
    var saveResult = await result.Result
        .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-02/Sample-02" }, cancellationToken);
        .ConfigureAwait(false);

    if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

### Sample 3 - Add custom document properties

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create("Sheet1");
    ```
        
2. Define cell styles to use
              
    ```csharp  
    var cellStyles = new Dictionary<string, XlsxCellStyle>
    {
        {
            "Title",
            new XlsxCellStyle 
            {
                Font =
                {
                    Name = "Arial",
                    Size = 28.0f,
                    Bold = YesNo.Yes,
                    Color = "Blue"
                }
            }
        }
    };
    ```

3. Insert text

    ```csharp   
    doc.Insert(
        new InsertText
        {
            SheetName = "Sheet1",
            Style = cellStyles["Title"],
            Location = new XlsxPointRange { Column = 2, Row = 1 },
            Data = "Hello world! from iXlsxWriter"
        });
    ```

4. Try to create xlsx output result

     **sync mode**
     ```csharp   
     var result = doc.CreateResult(new XlsxOutputResultConfig
     {
         GlobalSettings = new XlsxSettings
         {
             DocumentSettings =
             {
                 Author = "iTin",
                 Company = "iTin",
                 Manager = "Filled from iXlsxWriter",
                 Category = "Filled from iXlsxWriter",
                 Subject = "Filled from iXlsxWriter",
                 Url = "http://www.url-test.com",
                 Title = "Filled from iXlsxWriter",
                 Keywords = "Reports, Excel, Summary",
                 Comments = "Filled from iXlsxWriter"
             }
         }
     });
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

     **async mode**
     ```csharp   
     var result = await doc
         .CreateResultAsync(
             new XlsxOutputResultConfig
             {
                 GlobalSettings = new XlsxSettings
                 {
                     DocumentSettings =
                     {
                         Author = "iTin",
                         Company = "iTin",
                         Manager = "Filled from iXlsxWriter",
                         Category = "Filled from iXlsxWriter",
                         Subject = "Filled from iXlsxWriter",
                         Url = "http://www.url-test.com",
                         Title = "Filled from iXlsxWriter",
                         Keywords = "Reports, Excel, Summary",
                         Comments = "Filled from iXlsxWriter"
                     }
                 }
             },
             cancellationToken)
         .ConfigureAwait(false);

     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

5. Save xlsx file result
 
    **sync mode**
    ```csharp   
    var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-03/Sample-03" });
   if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

    **async mode**
    ```csharp   
    var saveResult = await result.Result
        .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-03/Sample-03" }, cancellationToken);
        .ConfigureAwait(false);

    if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

### Sample 4 - Add custom sheet properties

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create("Sheet1");
    ```
        
2. Define cell styles to use
              
    ```csharp  
    var cellStyles = new Dictionary<string, XlsxCellStyle>
    {
        {
            "Title",
            new XlsxCellStyle 
            {
                Font =
                {
                    Name = "Arial",
                    Size = 28.0f,
                    Bold = YesNo.Yes,
                    Color = "Blue"
                }
            }
        }
    };
    ```

3. Insert text

    ```csharp   
    doc.Insert(
        new InsertText
        {
            SheetName = "Sheet1",
            Style = cellStyles["Title"],
            Location = new XlsxPointRange { Column = 2, Row = 1 },
            Data = "Hello world! from iXlsxWriter"
        });
    ```

4. Try to create xlsx output result

     **sync mode**
     ```csharp   
     var globalSettings = new XlsxSettings
     {
         DocumentSettings =
         {
             Author = "iTin",
             Company = "iTin",
             Manager = "Filled from iXlsxWriter",
             Category = "Filled from iXlsxWriter",
             Subject = "Filled from iXlsxWriter",
             Url = "http://www.url-test.com",
             Title = "Filled from iXlsxWriter",
             Keywords = "Reports, Excel, Summary",
             Comments = "Filled from iXlsxWriter"
         },
         SheetsSettings =
         {
             new XlsxSheetSettings
             {
                 Size = KnownDocumentSize.A3,
                 View = KnownDocumentView.Design,
                 Orientation = KnownDocumentOrientation.Landscape,
                 FreezePanesPoint =
                 {
                     Row = 3,
                     Column = 3,
                 },
                 Margins =
                 {
                     Bottom = 25,
                     Left = 25,
                     Right = 25,
                     Top = 25,
                     Units = KnownUnit.Millimeters
                 },
                 Header =
                 {
                     Sections =
                     {
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "Sample header",
                             Type = KnownHeaderFooterSectionType.Odd,
                             Alignment = KnownHeaderFooterAlignment.Left,
                         },
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "Sample header",
                             Type = KnownHeaderFooterSectionType.Even,
                             Alignment = KnownHeaderFooterAlignment.Left,
                         },
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "iTin",
                             Type = KnownHeaderFooterSectionType.Odd,
                             Alignment = KnownHeaderFooterAlignment.Center,
                         },
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "iTin",
                             Type = KnownHeaderFooterSectionType.Even,
                             Alignment = KnownHeaderFooterAlignment.Center,
                         },
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "Header text",
                             Type = KnownHeaderFooterSectionType.Odd,
                             Alignment = KnownHeaderFooterAlignment.Right,
                         },
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "Header text",
                             Type = KnownHeaderFooterSectionType.Even,
                             Alignment = KnownHeaderFooterAlignment.Right,
                          }
                     }
                 },
                 Footer =
                 {
                     Sections =
                     {
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "Sample footer",
                             Type = KnownHeaderFooterSectionType.Odd,
                             Alignment = KnownHeaderFooterAlignment.Left,
                         },
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "Sample footer",
                             Type = KnownHeaderFooterSectionType.Even,
                             Alignment = KnownHeaderFooterAlignment.Left,
                         },
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "iTin",
                             Type = KnownHeaderFooterSectionType.Odd,
                             Alignment = KnownHeaderFooterAlignment.Center,
                         },
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "iTin",
                             Type = KnownHeaderFooterSectionType.Even,
                             Alignment = KnownHeaderFooterAlignment.Center,
                         },
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "@PageNumber / @NumberOfPages",
                             Type = KnownHeaderFooterSectionType.Odd,
                             Alignment = KnownHeaderFooterAlignment.Right
                         },
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "@PageNumber / @NumberOfPages",
                             Type = KnownHeaderFooterSectionType.Even,
                             Alignment = KnownHeaderFooterAlignment.Right
                         },
                     }
                 }
             }
         }
     };

     var result = doc.CreateResult(new XlsxOutputResultConfig { GlobalSettings = globalSettings });
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

     **async mode**
     ```csharp   
     var globalSettings = new XlsxSettings
     {
         DocumentSettings =
         {
             Author = "iTin",
             Company = "iTin",
             Manager = "Filled from iXlsxWriter",
             Category = "Filled from iXlsxWriter",
             Subject = "Filled from iXlsxWriter",
             Url = "http://www.url-test.com",
             Title = "Filled from iXlsxWriter",
             Keywords = "Reports, Excel, Summary",
             Comments = "Filled from iXlsxWriter"
         },
         SheetsSettings =
         {
             new XlsxSheetSettings
             {
                 Size = KnownDocumentSize.A3,
                 View = KnownDocumentView.Design,
                 Orientation = KnownDocumentOrientation.Landscape,
                 FreezePanesPoint =
                 {
                     Row = 3,
                     Column = 3,
                 },
                 Margins =
                 {
                     Bottom = 25,
                     Left = 25,
                     Right = 25,
                     Top = 25,
                     Units = KnownUnit.Millimeters
                 },
                 Header =
                 {
                     Sections =
                     {
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "Sample header",
                             Type = KnownHeaderFooterSectionType.Odd,
                             Alignment = KnownHeaderFooterAlignment.Left,
                         },
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "Sample header",
                             Type = KnownHeaderFooterSectionType.Even,
                             Alignment = KnownHeaderFooterAlignment.Left,
                         },
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "iTin",
                             Type = KnownHeaderFooterSectionType.Odd,
                             Alignment = KnownHeaderFooterAlignment.Center,
                         },
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "iTin",
                             Type = KnownHeaderFooterSectionType.Even,
                             Alignment = KnownHeaderFooterAlignment.Center,
                         },
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "Header text",
                             Type = KnownHeaderFooterSectionType.Odd,
                             Alignment = KnownHeaderFooterAlignment.Right,
                         },
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "Header text",
                             Type = KnownHeaderFooterSectionType.Even,
                             Alignment = KnownHeaderFooterAlignment.Right,
                          }
                     }
                 },
                 Footer =
                 {
                     Sections =
                     {
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "Sample footer",
                             Type = KnownHeaderFooterSectionType.Odd,
                             Alignment = KnownHeaderFooterAlignment.Left,
                         },
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "Sample footer",
                             Type = KnownHeaderFooterSectionType.Even,
                             Alignment = KnownHeaderFooterAlignment.Left,
                         },
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "iTin",
                             Type = KnownHeaderFooterSectionType.Odd,
                             Alignment = KnownHeaderFooterAlignment.Center,
                         },
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "iTin",
                             Type = KnownHeaderFooterSectionType.Even,
                             Alignment = KnownHeaderFooterAlignment.Center,
                         },
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "@PageNumber / @NumberOfPages",
                             Type = KnownHeaderFooterSectionType.Odd,
                             Alignment = KnownHeaderFooterAlignment.Right
                         },
                         new XlsxDocumentHeaderFooterSection
                         {
                             Text = "@PageNumber / @NumberOfPages",
                             Type = KnownHeaderFooterSectionType.Even,
                             Alignment = KnownHeaderFooterAlignment.Right
                         },
                     }
                 }
             }
         }
     };

     var result = await doc
         .CreateResultAsync(new XlsxOutputResultConfig { GlobalSettings = globalSettings }, cancellationToken)
         .ConfigureAwait(false);

     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

5. Save xlsx file result
 
    **sync mode**
    ```csharp   
    var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-04/Sample-04" });
   if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

    **async mode**
    ```csharp   
    var saveResult = await result.Result
        .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-04/Sample-04" }, cancellationToken);
        .ConfigureAwait(false);

    if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

### Sample 6 - Insert datatable and generic collections

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create(new[] { "Sheet1", "Sheet2" });
    ```
        
2. Define data model
    
    ```csharp  
    public class Person
    {     
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    ```

3. Insert actions

    ```csharp   
    doc.Insert(new InsertText
    {
        SheetName = "Sheet1",
        Location = new XlsxPointRange { Column = 2, Row = 1 },
        Data = "Custom text"
    }).Insert(new InsertEnumerable<Person>
    {
        SheetName = "Sheet1",
        Location = new XlsxPointRange { Column = 2, Row = 3 },
        Data = new Collection<Person>
        {
            new() { Name = "Name-01", Surname = "Surname-01" },
            new() { Name = "Name-02", Surname = "Surname-02" },
            new() { Name = "Name-03", Surname = "Surname-03" },
            new() { Name = "Name-04", Surname = "Surname-04" },
            new() { Name = "Name-05", Surname = "Surname-05" },
            new() { Name = "Name-06", Surname = "Surname-06" },
            new() { Name = "Name-07", Surname = "Surname-07" },
            new() { Name = "Name-08", Surname = "Surname-08" },
            new() { Name = "Name-09", Surname = "Surname-09" },
            new() { Name = "Name-10", Surname = "Surname-10" }
        }
    }).Insert(new InsertDataTable
    {
        SheetName = "Sheet1",
        Location = new XlsxPointRange { Column = 10, Row = 3 },
        Data = new Collection<Person>
        {
            new() { Name = "Name-01", Surname = "Surname-01" },
            new() { Name = "Name-02", Surname = "Surname-02" },
            new() { Name = "Name-03", Surname = "Surname-03" },
            new() { Name = "Name-04", Surname = "Surname-04" },
            new() { Name = "Name-05", Surname = "Surname-05" },
            new() { Name = "Name-06", Surname = "Surname-06" },
            new() { Name = "Name-07", Surname = "Surname-07" },
            new() { Name = "Name-08", Surname = "Surname-08" },
            new() { Name = "Name-09", Surname = "Surname-09" },
            new() { Name = "Name-10", Surname = "Surname-10" }
        }.ToDataTable<Person>("Person")
    });
    ```

4. Try to create xlsx output result

     **sync mode**
     ```csharp   
     var result = doc.CreateResult();
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

     **async mode**
     ```csharp   
        var result = await doc
         .CreateResultAsync(cancellationToken: cancellationToken)
         .ConfigureAwait(false);
         
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

5. Save xlsx file result
 
    **sync mode**
    ```csharp   
    var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-06/Sample-06" });
   if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

    **async mode**
    ```csharp   
    var saveResult = await result.Result
        .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-06/Sample-06" }, cancellationToken);
        .ConfigureAwait(false);

    if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

### Sample 7 - Save a xlsx input as zip file

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create(new[] { "Sheet1", "Sheet2" });
    ```
        
2. Define data model
    
    ```csharp  
    public class Person
    {     
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    ```

3. Insert actions

    ```csharp   
    doc.Insert(new InsertText
    {
        SheetName = "Sheet1",
        Location = new XlsxPointRange { Column = 2, Row = 1 },
        Data = "Custom text"
    }).Insert(new InsertEnumerable<Person>
    {
        SheetName = "Sheet1",
        Location = new XlsxPointRange { Column = 2, Row = 3 },
        Data = new Collection<Person>
        {
            new() { Name = "Name-01", Surname = "Surname-01" },
            new() { Name = "Name-02", Surname = "Surname-02" },
            new() { Name = "Name-03", Surname = "Surname-03" },
            new() { Name = "Name-04", Surname = "Surname-04" },
            new() { Name = "Name-05", Surname = "Surname-05" },
            new() { Name = "Name-06", Surname = "Surname-06" },
            new() { Name = "Name-07", Surname = "Surname-07" },
            new() { Name = "Name-08", Surname = "Surname-08" },
            new() { Name = "Name-09", Surname = "Surname-09" },
            new() { Name = "Name-10", Surname = "Surname-10" }
        }
    }).Insert(new InsertDataTable
    {
        SheetName = "Sheet1",
        Location = new XlsxPointRange { Column = 10, Row = 3 },
        Data = new Collection<Person>
        {
            new() { Name = "Name-01", Surname = "Surname-01" },
            new() { Name = "Name-02", Surname = "Surname-02" },
            new() { Name = "Name-03", Surname = "Surname-03" },
            new() { Name = "Name-04", Surname = "Surname-04" },
            new() { Name = "Name-05", Surname = "Surname-05" },
            new() { Name = "Name-06", Surname = "Surname-06" },
            new() { Name = "Name-07", Surname = "Surname-07" },
            new() { Name = "Name-08", Surname = "Surname-08" },
            new() { Name = "Name-09", Surname = "Surname-09" },
            new() { Name = "Name-10", Surname = "Surname-10" }
        }.ToDataTable<Person>("Person")
    });
    ```

4. Try to create xlsx output result

     **sync mode**
     ```csharp   
     var result = doc.CreateResult(XlsxOutputResultConfig.ZippedResult("custom_zipfile_name"));
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

     **async mode**
     ```csharp   
        var result = await doc
         .CreateResultAsync(XlsxOutputResultConfig.ZippedResult("custom_zipfile_name"), cancellationToken: cancellationToken)
         .ConfigureAwait(false);
         
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

5. Save xlsx file result
 
    **sync mode**
    ```csharp   
    var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-07/Sample-07" });
   if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

    **async mode**
    ```csharp   
    var saveResult = await result.Result
        .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-07/Sample-07" }, cancellationToken);
        .ConfigureAwait(false);

    if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

### Sample 9 - Insert a picture with effects

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create(new[] { "Sheet1" });
    ```
        
2. Insert actions
    
    ```csharp  
    doc.Insert(new InsertPicture
    {
        SheetName = "Sheet1",
        Location = new XlsxPointRange { Column = 4, Row = 4 },
        Picture = new XlsxPicture
        {
            Show = YesNo.Yes,
            Name = "image",
            Path = "~/Resources/Sample-09/image-1.jpg",
            Size = new XlsxSize
            {
                Width = 300,
                Height = 300
            },
            Effects =
            {
                new XlsxDarkEffect(),
                new XlsxDisabledEffect(),
                new XlsxOpacityEffect { Value = 50.0f }
            },
            Border =
            {
                Width = 4,
                Color = "Green",
                Show = YesNo.Yes,
                Transparency = 50,
                Style = KnownLineStyle.DashDot
            },
            Content =
            {
                Color = "Blue",
                Show = YesNo.Yes,
                Transparency = 50,
            },
            ShapeEffects =
            {
                Shadow = new XlsxOuterShadow
                {
                    Offset = 2,
                    Color = "Yellow",
                    Show = YesNo.Yes,
                }
            }
        }
    });
    ```

3. Try to create xlsx output result

     **sync mode**
     ```csharp   
     var result = doc.CreateResult();
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

     **async mode**
     ```csharp   
        var result = await doc
         .CreateResultAsync(cancellationToken: cancellationToken)
         .ConfigureAwait(false);
         
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

4. Save xlsx file result
 
    **sync mode**
    ```csharp   
    var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-09/Sample-09" });
   if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

    **async mode**
    ```csharp   
    var saveResult = await result.Result
        .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-09/Sample-09" }, cancellationToken);
        .ConfigureAwait(false);

    if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

### Sample 10 - Insert a picture from file and byte array

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create(new[] { "Sheet1" });
    ```
        
2. Insert actions
    
    ```csharp  
    using var image1 = XlsxImage.FromFile(iTinIO.Path.PathResolver("~/Resources/Sample-10/image-1.jpg"));
    using var image2 = XlsxImage.FromByteArray(File.ReadAllBytes(iTinIO.Path.PathResolver("~/Resources/Sample-10/image-2.jpg")));
    doc.Insert(new InsertText
    {
        SheetName = "Sheet1",
        Data = "From ByteArray",
        Style = cellStyles["Title"],
        Location = new XlsxPointRange { Column = 4, Row = 2 }
    }).Insert(new InsertText
    {
        SheetName = "Sheet1",
        Data = "From File",
        Style = cellStyles["Title"],
        Location = new XlsxPointRange { Column = 8, Row = 2 }
    }).Insert(new InsertPicture
    {
        SheetName = "Sheet1",
        Location = new XlsxPointRange { Column = 4, Row = 4 },
        Picture = image2.AsPicture(
            "image2",
            size: new XlsxSize { Width = 150, Height = 150 },
            border: new XlsxBorder { Width = 2, Color = "Green", Show = YesNo.Yes, Style = KnownLineStyle.DashDot },
            shapeEffects: new XlsxShapeEffects { Shadow = XlsxOuterShadow.DownRight })
    }).Insert(new InsertPicture
    {
        SheetName = "Sheet1",
        Location = new XlsxPointRange { Column = 8, Row = 4 },
        Picture = image1.AsPicture(
            "image1",
            size: new XlsxSize { Width = 150, Height = 150 },
            shapeEffects: new XlsxShapeEffects { Shadow = XlsxOuterShadow.Left })
    });
    ```

3. Try to create xlsx output result

     **sync mode**
     ```csharp   
     var result = doc.CreateResult();
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

     **async mode**
     ```csharp   
        var result = await doc
         .CreateResultAsync(cancellationToken: cancellationToken)
         .ConfigureAwait(false);
         
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

4. Save xlsx file result
 
    **sync mode**
    ```csharp   
    var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-10/Sample-10" });
   if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

    **async mode**
    ```csharp   
    var saveResult = await result.Result
        .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-10/Sample-10" }, cancellationToken);
        .ConfigureAwait(false);

    if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

### Sample 11 - Insert shapes with effects

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create(new[] { "Shadows", "Illumination", "Reflection", "Soft Edge" });
    ```
        
2. Insert actions
    
    **Shadows**
    ```csharp  
    doc.Insert(new InsertText
    {
        SheetName = "Shadows",
        Data = "Outer shadows",
        Location = new XlsxPointRange { Column = 2, Row = 2 },
        Style = cellStyles["Shadows"]
    }).Insert(new InsertShape
    {
        SheetName = "Shadows",
        Location = new XlsxPointRange { Column = 2, Row = 4 },
        Shape = new XlsxShape
        {
            ShapeType = ShapeType.Rect,
            Size = { Width = 128, Height = 128 },
            Border = { Show = YesNo.Yes, Color = "Yellow", Transparency = 50, Style = KnownLineStyle.DashDot },
            Content =
            {
                Text = "Shape 1",
                Color = "LightGray",
                Font = { Color = "Red", Bold = YesNo.Yes },
                Alignment = { Horizontal = KnownHorizontalAlignment.Center }
            },
            ShapeEffects = { Shadow = XlsxOuterShadow.DownLeft }
        }
    });
    ```
    **Illumination**
    ```csharp  
    doc.Insert(new InsertText
    {
        SheetName = "Illumination",
        Data = "Accent 1",
        Location = new XlsxPointRange { Column = 2, Row = 2 },
        Style = cellStyles["Illumination"]
    }).Insert(new InsertShape
    {
        SheetName = "Illumination",
        Location = new XlsxPointRange { Column = 2, Row = 4 },
        Shape = new XlsxShape
        {
            ShapeType = ShapeType.Rect,
            Size = { Width = 64, Height = 64 },
            Content = { Color = "LightGray" },
            ShapeEffects = { Illumination = XlsxIlluminationShapeEffect.Emphasis1Points5 }
        }
    });
    ```
    **Reflection**
    ```csharp  
    doc.Insert(new InsertText
    {
        SheetName = "Reflection",
        Data = "Strong",
        Location = new XlsxPointRange { Column = 2, Row = 2 },
        Style = cellStyles["Reflection"]
    }).Insert(new InsertShape
    {
        SheetName = "Reflection",
        Location = new XlsxPointRange { Column = 2, Row = 4 },
        Shape = new XlsxShape
        {
            ShapeType = ShapeType.Rect,
            Size = { Width = 128, Height = 128 },
            Content = { Color = "LightGray" },
            ShapeEffects = { Reflection = XlsxReflectionShapeEffect.StrongNoOffset }
        }
    });
    ```
    **Soft Edge**
    ```csharp  
    doc.Insert(new InsertText
    {
        SheetName = "Soft Edge",
        Data = "Soft Edge",
        Location = new XlsxPointRange { Column = 2, Row = 2 },
        Style = cellStyles["SoftEdge"]
    }).Insert(new InsertShape
    {
        SheetName = "Soft Edge",
        Location = new XlsxPointRange { Column = 2, Row = 4 },
        Shape = new XlsxShape
        {
            ShapeType = ShapeType.Rect,
            Size = { Width = 128, Height = 128 },
            Content = { Color = "LightGray" },
            ShapeEffects = { SoftEdge = XlsxSoftEdgeShapeEffect.SoftEdge1 }
        }
    });
    ```

3. Try to create xlsx output result

     **sync mode**
     ```csharp   
     var result = doc.CreateResult();
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

     **async mode**
     ```csharp   
        var result = await doc
         .CreateResultAsync(cancellationToken: cancellationToken)
         .ConfigureAwait(false);
         
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

4. Save xlsx file result
 
    **sync mode**
    ```csharp   
    var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-11/Sample-11" });
   if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

    **async mode**
    ```csharp   
    var saveResult = await result.Result
        .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-11/Sample-11" }, cancellationToken);
        .ConfigureAwait(false);

    if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

### Sample 12 - Insert a table with styles

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create(new[] { "Sheet1" });
    ```
        
2. Insert actions
    
    ```csharp  
    doc.Insert(new InsertTable
    {
        SheetName = "Sheet1",
        Data = new XmlInput(new Uri(iTinIO.Path.PathResolver("~/Resources/Sample-12/input.xml"))),
        Location = new XlsxPointRange { Column = 1, Row = 2 },
        Table =
        {
            Name = "Rates",
            Alias = "Rates",
            ShowColumnHeaders = YesNo.Yes,
            ShowDataValues = YesNo.Yes,
            Resources =
            {
                Styles = new XlsxStylesCollection
                {
                    new XlsxCellStyle
                    {
                        Name = "HeaderStyle",
                        Font = { Name = "Calibri", Size = 11.0f, Color = "White", Bold = YesNo.Yes },
                        Content =
                        {
                            Alignment = { Horizontal = KnownHorizontalAlignment.Right },
                            Color = "#ED7D31",
                            DataType = new TextDataType()
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "DateHeaderStyle",
                        Font = { Name = "Calibri", Size = 11.0f, Color = "White", Bold = YesNo.Yes },
                        Content =
                        {
                            Alignment = { Horizontal = KnownHorizontalAlignment.Left },
                            Color = "#ED7D31",
                            DataType = new TextDataType()
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "DateValueStyle",
                        Font = { Name = "Calibri" },
                        Borders =
                        {
                            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Left, Style = KnownBorderStyle.Thick, Color = "#ED7D31" },
                            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick, Color = "#ED7D31" }
                        },
                        Content =
                        {
                            Color = "#FCE4D6",
                            DataType = new DateTimeDataType{ Format = KnownDateTimeFormat.ShortDatePattern }
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "DecimalValueStyle",
                        Font = { Name = "Calibri", Size = 11.0f },
                        Borders =
                        {
                            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick, Color = "#ED7D31" }
                        },
                        Content =
                        {
                            Alignment = { Horizontal = KnownHorizontalAlignment.Right },
                            DataType = new NumberDataType { Decimals = 5, Separator = YesNo.Yes },
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "LastFieldDecimalValueStyle",
                        Font = { Name = "Calibri", Size = 11.0f },
                        Borders =
                        {
                            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Right, Style = KnownBorderStyle.Thick, Color = "#ED7D31" },
                            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick, Color = "#ED7D31" }
                        },
                        Content =
                        {
                            Alignment = { Horizontal = KnownHorizontalAlignment.Right },
                            DataType = new NumberDataType { Decimals = 5, Separator = YesNo.Yes },
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "SekValueStyle",
                        Font = { Name = "Calibri", Size = 11.0f },
                        Borders =
                        {
                            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick, Color = "#ED7D31" }
                        },
                        Content =
                        {
                            Alignment = { Horizontal = KnownHorizontalAlignment.Right },
                            DataType = new NumberDataType { Decimals = 0 }
                        }
                    }
                }
            },
            Fields =
            {
                new DataField { Name = "DATE", Alias = "Date", Header = { Style = "DateHeaderStyle", Show = YesNo.Yes }, Value = { Style = "DateValueStyle" } },
                new DataField { Name = "AUD", Alias = "AUD", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "CAD", Alias = "CAD", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "CHF", Alias = "CHF", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "DKK", Alias = "DKK", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "EUR", Alias = "EUR", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "GBP", Alias = "GBP", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "HKD", Alias = "HKD", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "JPY", Alias = "JPY", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "MYR", Alias = "MYR", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "NOK", Alias = "NOK", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "NZD", Alias = "NZD", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "RUB", Alias = "RUB", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "SEK", Alias = "SEK", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "SekValueStyle" } },
                new DataField { Name = "THB", Alias = "THB", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "TRY", Alias = "TRY", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "USD", Alias = "USD", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "LastFieldDecimalValueStyle" } }
            }
        }
    });
    ```

3. Try to create xlsx output result

     **sync mode**
     ```csharp   
     var result = doc.CreateResult();
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

     **async mode**
     ```csharp   
        var result = await doc
         .CreateResultAsync(cancellationToken: cancellationToken)
         .ConfigureAwait(false);
         
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

4. Save xlsx file result
 
    **sync mode**
    ```csharp   
    var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-12/Sample-12" });
   if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

    **async mode**
    ```csharp   
    var saveResult = await result.Result
        .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-12/Sample-12" }, cancellationToken);
        .ConfigureAwait(false);

    if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

### Sample 13 - Insert a table with styles and column headers

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create(new[] { "Sheet1" });
    ```
        
2. Insert actions
    
    ```csharp  
    doc.Insert(new InsertTable
    {
        SheetName = "Sheet1",
        Data = new XmlInput(new Uri(iTinIO.Path.PathResolver("~/Resources/Sample-12/input.xml"))),
        Location = new XlsxPointRange { Column = 1, Row = 2 },
        Table =
        {
            Name = "Rates",
            Alias = "Rates",
            ShowColumnHeaders = YesNo.Yes,
            ShowDataValues = YesNo.Yes,
            Resources =
            {
                Styles = new XlsxStylesCollection
                {
                    new XlsxCellStyle
                    {
                        Name = "GroupHeaderStyle",
                        Font = { Name = "Calibri", Size = 11.0f, Color = "White", Bold = YesNo.Yes },
                        Content =
                        {
                            Alignment = { Horizontal = KnownHorizontalAlignment.Center },
                            Color = "#ED7D31",
                            DataType = new TextDataType()
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "HeaderStyle",
                        Font = { Name = "Calibri", Size = 11.0f, Color = "White", Bold = YesNo.Yes },
                        Content =
                        {
                            Alignment = { Horizontal = KnownHorizontalAlignment.Right },
                            Color = "#ED7D31",
                            DataType = new TextDataType()
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "DateHeaderStyle",
                        Font = { Name = "Calibri", Size = 11.0f, Color = "White", Bold = YesNo.Yes },
                        Content =
                        {
                            Alignment = { Horizontal = KnownHorizontalAlignment.Left },
                            Color = "#ED7D31",
                            DataType = new TextDataType()
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "DateValueStyle",
                        Font = { Name = "Calibri" },
                        Borders =
                        {
                            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Left, Style = KnownBorderStyle.Thick, Color = "#ED7D31" },
                            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick, Color = "#ED7D31" }
                        },
                        Content =
                        {
                            Color = "#FCE4D6",
                            DataType = new DateTimeDataType{ Format = KnownDateTimeFormat.ShortDatePattern }
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "DecimalValueStyle",
                        Font = { Name = "Calibri", Size = 11.0f },
                        Borders =
                        {
                            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick, Color = "#ED7D31" }
                        },
                        Content =
                        {
                            Alignment = { Horizontal = KnownHorizontalAlignment.Right },
                            DataType = new NumberDataType { Decimals = 5, Separator = YesNo.Yes },
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "LastFieldDecimalValueStyle",
                        Font = { Name = "Calibri", Size = 11.0f },
                        Borders =
                        {
                            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Right, Style = KnownBorderStyle.Thick, Color = "#ED7D31" },
                            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick, Color = "#ED7D31" }
                        },
                        Content =
                        {
                            Alignment = { Horizontal = KnownHorizontalAlignment.Right },
                            DataType = new NumberDataType { Decimals = 5, Separator = YesNo.Yes },
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "SekValueStyle",
                        Font = { Name = "Calibri", Size = 11.0f },
                        Borders =
                        {
                            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick, Color = "#ED7D31" }
                        },
                        Content =
                        {
                            Alignment = { Horizontal = KnownHorizontalAlignment.Right },
                            DataType = new NumberDataType { Decimals = 0 }
                        }
                    }
                }
            },
            Fields =
            {
                new DataField { Name = "DATE", Alias = "Date", Header = { Style = "DateHeaderStyle", Show = YesNo.Yes }, Value = { Style = "DateValueStyle" } },
                new DataField { Name = "AUD", Alias = "AUD", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "CAD", Alias = "CAD", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "CHF", Alias = "CHF", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "DKK", Alias = "DKK", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "EUR", Alias = "EUR", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "GBP", Alias = "GBP", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "HKD", Alias = "HKD", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "JPY", Alias = "JPY", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "MYR", Alias = "MYR", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "NOK", Alias = "NOK", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "NZD", Alias = "NZD", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "RUB", Alias = "RUB", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "SEK", Alias = "SEK", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "SekValueStyle" } },
                new DataField { Name = "THB", Alias = "THB", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "TRY", Alias = "TRY", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "USD", Alias = "USD", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "LastFieldDecimalValueStyle" } }
            },
            Headers =
            {
                new XlsxColumnHeader { From = "AUD", To = "CHF", Text = "AUD-CHF", Show = YesNo.Yes, Style = "GroupHeaderStyle"},
                new XlsxColumnHeader { From = "DKK", To = "JPY", Text = "DKK-JPY", Show = YesNo.Yes, Style = "GroupHeaderStyle"},
                new XlsxColumnHeader { From = "MYR", To = "SEK", Text = "MYR-SEK", Show = YesNo.Yes, Style = "GroupHeaderStyle"},
                new XlsxColumnHeader { From = "THB", To = "USD", Text = "THB-USD", Show = YesNo.Yes, Style = "GroupHeaderStyle"},
            }
         }
    });
    ```

3. Try to create xlsx output result

     **sync mode**
     ```csharp   
     var result = doc.CreateResult();
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

     **async mode**
     ```csharp   
        var result = await doc
         .CreateResultAsync(cancellationToken: cancellationToken)
         .ConfigureAwait(false);
         
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

4. Save xlsx file result
 
    **sync mode**
    ```csharp   
    var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-13/Sample-13" });
   if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

    **async mode**
    ```csharp   
    var saveResult = await result.Result
        .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-13/Sample-13" }, cancellationToken);
        .ConfigureAwait(false);

    if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

### Sample 14 - Insert a table with styles and data filter

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create(new[] { "Sheet1" });
    ```
        
2. Insert actions
    
    ```csharp  
    doc.Insert(new InsertTable
    {
        SheetName = "Sheet1",
        Data = new XmlInput(new Uri(iTinPath.PathResolver("~/Resources/Sample-14/input.xml"))),
        Location = new XlsxPointRange { Column = 1, Row = 2 },
        Table = 
        {
            Name = "Rates",
            Alias = "Rates",
            Resources =
            {
                Filters =
                { 
                    new() { Key = "AudFilter", Field = "AUD", Criterial = KnownOperator.EqualTo, Value = "6,17350" }
                },
                Styles = new XlsxStylesCollection
                {
                    // Add styles here!!
                },
            },
            Filter = "AudFilter",
            Fields =
            {
                new DataField { Name = "DATE", Alias = "Date", Header = { Style = "DateHeaderStyle", Show = YesNo.Yes }, Value = { Style = "DateValueStyle" } },
                new DataField { Name = "AUD", Alias = "AUD", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "CAD", Alias = "CAD", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "CHF", Alias = "CHF", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "DKK", Alias = "DKK", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "EUR", Alias = "EUR", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "GBP", Alias = "GBP", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "HKD", Alias = "HKD", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "JPY", Alias = "JPY", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "MYR", Alias = "MYR", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "NOK", Alias = "NOK", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "NZD", Alias = "NZD", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "RUB", Alias = "RUB", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "SEK", Alias = "SEK", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "SekValueStyle" } },
                new DataField { Name = "THB", Alias = "THB", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "TRY", Alias = "TRY", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalValueStyle" } },
                new DataField { Name = "USD", Alias = "USD", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "LastFieldDecimalValueStyle" } }
            }
        }
    });
    ```

3. Try to create xlsx output result

     **sync mode**
     ```csharp   
     var result = doc.CreateResult();
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

     **async mode**
     ```csharp   
        var result = await doc
         .CreateResultAsync(cancellationToken: cancellationToken)
         .ConfigureAwait(false);
         
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

4. Save xlsx file result
 
    **sync mode**
    ```csharp   
    var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-14/Sample-14" });
   if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

    **async mode**
    ```csharp   
    var saveResult = await result.Result
        .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-14/Sample-14" }, cancellationToken);
        .ConfigureAwait(false);

    if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

### Sample 15 - Insert mini charts

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create(new[] { "Sheet1" });
    ```
        
2. Insert actions
    
    ```csharp  
    doc.Insert(new InsertTable
    {
        // Insert data... (Equals sample 12)
    });

    // Insert mini-charts
    for (var i = 2; i <= 17; i++)
    {
        doc.Insert(new InsertMiniChart
        {
            SheetName = "Sheet1",
            Location = new XlsxPointRange { Column = i, Row = 16 },
            MiniChart =
            {
                EmptyValueAs = MiniChartEmptyValuesAs.Zero,
                ChartSize = { HorizontalCells = 1, VerticalCells = 2 },
                ChartAxes = { Horizontal = { Show = YesNo.Yes, Type = MiniChartHorizontalAxisType.Date } },
                ChartType =
                {
                    Active = MiniChartType.Column,
                    Column =
                    {
                        Serie = { Color = "#376092" },
                        Points = { High = { Color = "Red" } }
                    }
                },
                ChartRanges =
                {
                    Axis = new XlsxRange
                    {
                        Start = new XlsxPoint { Column = 1, Row = 4 },
                        End = new XlsxPoint { Column = 1, Row = 14 }
                    },
                    Data = new XlsxRange
                    {
                        Start = new XlsxPoint { Column = i, Row = 4 },
                        End = new XlsxPoint { Column = i, Row = 14 }
                    }
                }
            }
        });
    }
    ```

3. Try to create xlsx output result

     **sync mode**
     ```csharp   
     var result = doc.CreateResult();
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

     **async mode**
     ```csharp   
        var result = await doc
         .CreateResultAsync(cancellationToken: cancellationToken)
         .ConfigureAwait(false);
         
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

4. Save xlsx file result
 
    **sync mode**
    ```csharp   
    var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-15/Sample-15" });
   if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

    **async mode**
    ```csharp   
    var saveResult = await result.Result
        .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-15/Sample-15" }, cancellationToken);
        .ConfigureAwait(false);

    if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

### Sample 16 - Insert a DataTable or Enumerable by InsertTable action without styles

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create(new[] { "Sheet1" });
    ```
        
2. Insert actions
    
    ```csharp  
    doc.Insert(new InsertTable
    {
        SheetName = "Sheet1",
        Data = new DataTableInput(
            new Collection<Person>
                {
                    new() { Name = "Name-01", Surname = "Surname-01" },
                    new() { Name = "Name-02", Surname = "Surname-02" },
                    new() { Name = "Name-03", Surname = "Surname-03" },
                    new() { Name = "Name-04", Surname = "Surname-04" },
                    new() { Name = "Name-05", Surname = "Surname-05" },
                    new() { Name = "Name-06", Surname = "Surname-06" },
                    new() { Name = "Name-07", Surname = "Surname-07" },
                    new() { Name = "Name-08", Surname = "Surname-08" },
                    new() { Name = "Name-09", Surname = "Surname-09" },
                    new() { Name = "Name-10", Surname = "Surname-10" }
                }
                .ToDataTable<Person>("Person")),
        Location = new XlsxPointRange { Column = 2, Row = 2 },
        Table =
        {
            Name = "Person",
            Alias = "Person",
            ShowColumnHeaders = YesNo.Yes,
            ShowDataValues = YesNo.Yes,
            Fields =
            {
                new DataField { Name = "Name", Alias = "Name", Header = { Show = YesNo.Yes } },
                new DataField { Name = "Surname", Alias = "Surname", Header = { Show = YesNo.Yes } }
            }
        }
    });
    ```

3. Try to create xlsx output result

     **sync mode**
     ```csharp   
     var result = doc.CreateResult();
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

     **async mode**
     ```csharp   
        var result = await doc
         .CreateResultAsync(cancellationToken: cancellationToken)
         .ConfigureAwait(false);
         
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

4. Save xlsx file result
 
    **sync mode**
    ```csharp   
    var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-16/Sample-16" });
   if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

    **async mode**
    ```csharp   
    var saveResult = await result.Result
        .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-16/Sample-16" }, cancellationToken);
        .ConfigureAwait(false);

    if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

### Sample 17 - Insert a table with styles and fixed fields

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create(new[] { "Sheet1" });
    ```
        
2. Insert actions
    
    ```csharp  
    doc.Insert(new InsertTable
    {
        SheetName = "Sheet1",
        Data = new XmlInput(new Uri(iTinPath.PathResolver("~/Resources/Sample-17/As400Packet.xml"))),
        Location = new XlsxPointRange { Column = 1, Row = 2 },
        Table =
        {
            Name = "R740D01",
            Alias = "AS400 - Ayers Rock",
            Resources =
            {
                Styles = new XlsxStylesCollection
                {
                    // Add styles here!!
                },
                Fixed =
                {
                    new Fixed
                    {
                        Name = "Pieces",
                        Reference = "SFLDTA",
                        Pieces =
                        {
                            new Piece { Name = "DCALL", From = 0, Lenght = 2, Trim = YesNo.Yes, TrimMode = KnownTrimMode.All },
                            new Piece { Name = "NOCOL", From = 2, Lenght = 14 },
                            new Piece { Name = "SHOP", From = 16, Lenght = 5 },
                            new Piece { Name = "SIT", From = 21, Lenght = 5 },
                            new Piece { Name = "PIK", From = 27, Lenght = 5 },
                            new Piece { Name = "PKG", From = 32, Lenght = 5 },
                            new Piece { Name = "DG", From = 37, Lenght = 5 },
                            new Piece { Name = "REM", From = 37, Lenght = 5 },
                            new Piece { Name = "SPR", From = 42, Lenght = 9 },
                            new Piece { Name = "DATESHOP", From = 56, Lenght = 11 }
                        }
                    }
                }
            },
            Fields =
            {
                new DataField { Name = "##LINE", Alias = "Line", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "LineValue" } },
                new DataField { Name = "*PERCENT", Alias = "%", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "PercentValue" } },
                new DataField { Name = "SFORDDATE", Alias = "Date", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "DateValue" } },
                new DataField { Name = "CMCUST", Alias = "Account", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "AccountValue" } },
                new DataField { Name = "CMNAME", Alias = "Name", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "NameValue" } },
                new FixedField { Pieces = "Pieces", Piece = "DCALL", Alias = "D/Call", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "FixedValue" } },
                new FixedField { Pieces = "Pieces", Piece = "NOCOL", Alias = "No/Col", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "FixedValue" } },
                new FixedField { Pieces = "Pieces", Piece = "SHOP", Alias = "Shop", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "FixedValue" } },
                new FixedField { Pieces = "Pieces", Piece = "SIT", Alias = "SIT", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "FixedValue" } },
                new FixedField { Pieces = "Pieces", Piece = "PIK", Alias = "Pik", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "FixedValue" } },
                new FixedField { Pieces = "Pieces", Piece = "PKG", Alias = "PKG", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "FixedValue" } },
                new FixedField { Pieces = "Pieces", Piece = "DG", Alias = "D&G", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "FixedValue" } },
                new FixedField { Pieces = "Pieces", Piece = "REM", Alias = "Rem", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "FixedValue" } },
                new FixedField { Pieces = "Pieces", Piece = "SPR", Alias = "SPR 2013", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "FixedValue" } },
                new FixedField { Pieces = "Pieces", Piece = "DATESHOP", Alias = "Date in Shop", Header = { Style = "CommonHeader", Show = YesNo.Yes }, Value = { Style = "FixedValue" } },
            }
        }
    });
    ```

3. Try to create xlsx output result

     **sync mode**
     ```csharp   
     var result = doc.CreateResult();
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

     **async mode**
     ```csharp   
        var result = await doc
         .CreateResultAsync(cancellationToken: cancellationToken)
         .ConfigureAwait(false);
         
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

4. Save xlsx file result
 
    **sync mode**
    ```csharp   
    var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-17/Sample-17" });
   if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

    **async mode**
    ```csharp   
    var saveResult = await result.Result
        .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-17/Sample-17" }, cancellationToken);
        .ConfigureAwait(false);

    if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

### Sample 18 - Insert a table with inherits styles and grouped fields

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create(new[] { "Sheet1" });
    ```
        
2. Insert actions
    
    ```csharp  
    doc.Insert(new InsertTable
    {
        SheetName = "Sheet1",
        Data = new XmlInput(new Uri(iTinPath.PathResolver("~/Resources/Sample-18/Input.xml"))),
        Location = new XlsxPointRange { Column = 1, Row = 2 },
        Table =
        {
            Name = "Invoice",
            Alias = "Invoice",
            Resources =
            {
                Styles = new XlsxStylesCollection
                {
                    new XlsxCellStyle
                    {
                        Name = "HeaderStyle",
                        Font = { Name = "Calibri", Color = "White", Size = 11.0f, Bold = YesNo.Yes },
                        Borders =
                        {
                            new XlsxStyleBorder { Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thick }
                        },
                        Content =
                        {
                            Color = "#ED7D31",
                            DataType = new TextDataType()
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "CustomerHeaderStyle",
                        Inherits = "HeaderStyle",
                        Content = { Color = "Green" }
                    },
                    new XlsxCellStyle
                    {
                        Name = "NumericStyle",
                        Font = { Name = "Calibri", Color = "White" },
                        Content =
                        {
                            Color = "#ED7D31",
                            DataType = new NumberDataType { Decimals = 0 }
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "DateStyle",
                        Font = { Name = "Calibri" },
                        Content =
                        {
                            Color = "#FCE4D6",
                            DataType = new DateTimeDataType { Format = KnownDateTimeFormat.ShortDatePattern }
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "DateStyle",
                        Font = { Name = "Calibri" },
                        Content =
                        {
                            Color = "#FCE4D6",
                            DataType = new DateTimeDataType { Format = KnownDateTimeFormat.ShortDatePattern }
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "StringStyle",
                        Font = { Name = "Calibri" },
                        Content =
                        {
                            Color = "#FCE4D6",
                            DataType = new TextDataType()
                        }
                    },
                    new XlsxCellStyle
                    {
                        Name = "CustomerStringStyle",
                        Inherits = "StringStyle",
                        Content = { Color = "LightGreen" }
                    },
                    new XlsxCellStyle
                    {
                        Name = "DecimalStyle",
                        Font = { Name = "Calibri" },
                        Content =
                        {
                            Alignment = { Horizontal = KnownHorizontalAlignment.Right },
                            Color = "#FCE4D6",
                            DataType = new NumberDataType { Separator = YesNo.Yes }
                        }
                    },
                },
                Groups =  
                {
                    new Group
                    { 
                        Name = "CustomerName",
                        Fields =
                        {
                            new GroupItem { Name = "CUSTOMERFIRSTNAME", Trim = YesNo.Yes, Separator = ", " },
                            new GroupItem { Name = "CUSTOMERLASTNAME" }
                        }
                    }
                }
            },
            Fields =
            {
                new DataField { Name = "ID", Alias = "Id", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "NumericStyle" } },
                new DataField { Name = "DATE", Alias = "Date", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DateStyle" } },
                new GroupField { Name = "CustomerName", Alias = "Customer", Header = { Style = "CustomerHeaderStyle", Show = YesNo.Yes }, Value = { Style = "CustomerStringStyle" } },
                new DataField { Name = "CUSTOMERPHONE", Alias = "Phone", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "StringStyle" } },
                new DataField { Name = "CUSTOMEREMAIL", Alias = "Email", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "StringStyle" } },
                new DataField { Name = "BILLINGADDRESS", Alias = "Address", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "StringStyle" } },
                new DataField { Name = "BILLINGCITY", Alias = "City", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "StringStyle" } },
                new DataField { Name = "BILLINGSTATE", Alias = "State", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "StringStyle" } },
                new DataField { Name = "BILLINGCOUNTRY", Alias = "Country", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "StringStyle" } },
                new DataField { Name = "BILLINGPOSTALCODE", Alias = "Postal Code", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "StringStyle" } },
                new DataField { Name = "TOTAL", Alias = "Total", Header = { Style = "HeaderStyle", Show = YesNo.Yes }, Value = { Style = "DecimalStyle" } },
            }
        }
    });
    ```

3. Try to create xlsx output result

     **sync mode**
     ```csharp   
     var result = doc.CreateResult();
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

     **async mode**
     ```csharp   
        var result = await doc
         .CreateResultAsync(cancellationToken: cancellationToken)
         .ConfigureAwait(false);
         
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

4. Save xlsx file result
 
    **sync mode**
    ```csharp   
    var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-18/Sample-18" });
   if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

    **async mode**
    ```csharp   
    var saveResult = await result.Result
        .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-18/Sample-18" }, cancellationToken);
        .ConfigureAwait(false);

    if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

### Sample 20 - Copy ranges

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create(new[] { "Sheet1", "Sheet2" });
    ```
        
2. Insert actions
    
    ```csharp  
    // Insert data
    doc.Insert(new InsertText
    {
        SheetName = "Sheet1",
        Location = new XlsxPointRange { Column = 2, Row = 1 },
        Data = "Custom text"
    }).Insert(new InsertEnumerable<Person>
    {
        SheetName = "Sheet1",
        Location = new XlsxPointRange { Column = 2, Row = 3 },
        Data = new Collection<Person>
        {
            new() { Name = "Name-01", Surname = "Surname-01" },
            new() { Name = "Name-02", Surname = "Surname-02" },
            new() { Name = "Name-03", Surname = "Surname-03" },
            new() { Name = "Name-04", Surname = "Surname-04" },
            new() { Name = "Name-05", Surname = "Surname-05" },
            new() { Name = "Name-06", Surname = "Surname-06" },
            new() { Name = "Name-07", Surname = "Surname-07" },
            new() { Name = "Name-08", Surname = "Surname-08" },
            new() { Name = "Name-09", Surname = "Surname-09" },
            new() { Name = "Name-10", Surname = "Surname-10" }
        }
    }).Insert(new InsertDataTable
    {
        SheetName = "Sheet1",
        Location = new XlsxPointRange { Column = 10, Row = 3 },
        Data = new Collection<Person>
        {
            new() { Name = "Name-01", Surname = "Surname-01" },
            new() { Name = "Name-02", Surname = "Surname-02" },
            new() { Name = "Name-03", Surname = "Surname-03" },
            new() { Name = "Name-04", Surname = "Surname-04" },
            new() { Name = "Name-05", Surname = "Surname-05" },
            new() { Name = "Name-06", Surname = "Surname-06" },
            new() { Name = "Name-07", Surname = "Surname-07" },
            new() { Name = "Name-08", Surname = "Surname-08" },
            new() { Name = "Name-09", Surname = "Surname-09" },
            new() { Name = "Name-10", Surname = "Surname-10" }
        }.ToDataTable<Person>("Person")
    });

    // Insert copy range
    doc.Insert(new InsertCopyRange
    {
        SheetName = "Sheet1",
        SourceRange = new XlsxRange
        {
            Start = { Column = 2, Row = 3 },
            End = { Column = 2, Row = 13 }
        },
        Destination = new QualifiedPointDefinition
        {
            WorkSheet = "Sheet2",
            Point = new XlsxPoint { Column = 2, Row = 3 }
        }
    });
    ```

3. Try to create xlsx output result

     **sync mode**
     ```csharp   
     var result = doc.CreateResult();
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

     **async mode**
     ```csharp   
        var result = await doc
         .CreateResultAsync(cancellationToken: cancellationToken)
         .ConfigureAwait(false);
         
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

4. Save xlsx file result
 
    **sync mode**
    ```csharp   
    var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-20/Sample-20" });
   if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

    **async mode**
    ```csharp   
    var saveResult = await result.Result
        .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-20/Sample-20" }, cancellationToken);
        .ConfigureAwait(false);

    if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

### Sample 21 - Transpose ranges

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create(new[] { "Sheet1", "Sheet2" });
    ```
        
2. Insert actions
    
    ```csharp  
    // Insert data
    doc.Insert(new InsertText
    {
        SheetName = "Sheet1",
        Location = new XlsxPointRange { Column = 2, Row = 1 },
        Data = "Custom text"
    }).Insert(new InsertEnumerable<Person>
    {
        SheetName = "Sheet1",
        Location = new XlsxPointRange { Column = 2, Row = 3 },
        Data = new Collection<Person>
        {
            new() { Name = "Name-01", Surname = "Surname-01" },
            new() { Name = "Name-02", Surname = "Surname-02" },
            new() { Name = "Name-03", Surname = "Surname-03" },
            new() { Name = "Name-04", Surname = "Surname-04" },
            new() { Name = "Name-05", Surname = "Surname-05" },
            new() { Name = "Name-06", Surname = "Surname-06" },
            new() { Name = "Name-07", Surname = "Surname-07" },
            new() { Name = "Name-08", Surname = "Surname-08" },
            new() { Name = "Name-09", Surname = "Surname-09" },
            new() { Name = "Name-10", Surname = "Surname-10" }
        }
    }).Insert(new InsertDataTable
    {
        SheetName = "Sheet1",
        Location = new XlsxPointRange { Column = 10, Row = 3 },
        Data = new Collection<Person>
        {
            new() { Name = "Name-01", Surname = "Surname-01" },
            new() { Name = "Name-02", Surname = "Surname-02" },
            new() { Name = "Name-03", Surname = "Surname-03" },
            new() { Name = "Name-04", Surname = "Surname-04" },
            new() { Name = "Name-05", Surname = "Surname-05" },
            new() { Name = "Name-06", Surname = "Surname-06" },
            new() { Name = "Name-07", Surname = "Surname-07" },
            new() { Name = "Name-08", Surname = "Surname-08" },
            new() { Name = "Name-09", Surname = "Surname-09" },
            new() { Name = "Name-10", Surname = "Surname-10" }
        }.ToDataTable<Person>("Person")
    });

    // Insert transpose range
    doc.Insert(new InsertTransposeRange
    {
        SheetName = "Sheet1",
        SourceRange = new XlsxRange
        {
            Start = { Column = 2, Row = 3 },
            End = { Column = 3, Row = 13 }
        },
        Destination = new QualifiedPointDefinition
        {
            WorkSheet = "Sheet2",
            Point = new XlsxPoint { Column = 2, Row = 3 }
        }
    });
    ```

3. Try to create xlsx output result

     **sync mode**
     ```csharp   
     var result = doc.CreateResult();
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

     **async mode**
     ```csharp   
        var result = await doc
         .CreateResultAsync(cancellationToken: cancellationToken)
         .ConfigureAwait(false);
         
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

4. Save xlsx file result
 
    **sync mode**
    ```csharp   
    var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-21/Sample-21" });
   if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

    **async mode**
    ```csharp   
    var saveResult = await result.Result
        .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-21/Sample-21" }, cancellationToken);
        .ConfigureAwait(false);

    if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

### Sample 22 - Use aggregate functions with a data range

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create(new[] { "Sheet1", "Sheet2" });
    ```

2. Defines data model
      
    ```csharp  
    public class Person
    {
        public string Name { get; set; }

        public string Surname { get; set; }
    }

    public class AgePerson : Person
    {
        public int Age { get; set; }
    }
    ```

3. Insert actions
    
    ```csharp  
    // Insert data
    doc.Insert(new InsertEnumerable<AgePerson>
    {
        SheetName = "Sheet1",
        Location = new XlsxPointRange { Column = 2, Row = 3 },
        Data = new Collection<AgePerson>
        {
            new() { Name = "Name-01", Surname = "Surname-01", Age = 23 },
            new() { Name = "Name-02", Surname = "Surname-02", Age = 7 },
            new() { Name = "Name-03", Surname = "Surname-03", Age = 11 },
            new() { Name = "Name-04", Surname = "Surname-04", Age = 22 },
            new() { Name = "Name-05", Surname = "Surname-05", Age = 52 },
            new() { Name = "Name-06", Surname = "Surname-06", Age = 33 },
            new() { Name = "Name-07", Surname = "Surname-07", Age = 8 },
            new() { Name = "Name-08", Surname = "Surname-08", Age = 2 },
            new() { Name = "Name-09", Surname = "Surname-09", Age = 12 },
            new() { Name = "Name-10", Surname = "Surname-10", Age = 21 },
        }
    });

    // Insert aggregate functions
    doc.Insert(new InsertText
    {
        SheetName = "Sheet1",
        Data = "Count",
        Style = XlsxCellStyle.Default,
        Location = new XlsxPointRange { Column = 1, Row = 14 },
    }).Insert(new InsertAggregateFunction
    {
        SheetName = "Sheet1",
        Style = numberStyle,
        Aggegate =
        {
            WorkSheet = "Sheet1",
            AggregateType = KnownAggregateType.Count,
            Range = new XlsxRange { Start = { Column = 2, Row = 4 }, End = { Column = 2, Row = 13 } }
        },
        Location = new XlsxPointRange { Column = 2, Row = 14 }
    }).Insert(new InsertText
    {
        SheetName = "Sheet1",
        Data = "Sum",
        Style = XlsxCellStyle.Default,
        Location = new XlsxPointRange { Column = 1, Row = 15 },
    }).Insert(new InsertAggregateFunction
    {
        SheetName = "Sheet1",
        Style = numberStyle,
        Aggegate =
        {
            WorkSheet = "Sheet1",
            AggregateType = KnownAggregateType.Sum,
            Range = new XlsxRange
            {
                Start = { Column = 2, Row = 4 }, End = { Column = 2, Row = 13 }
            }
        },
        Location = new XlsxPointRange { Column = 2, Row = 15 }
    }).Insert(new InsertText
    {
        SheetName = "Sheet1",
        Data = "Average",
        Style = XlsxCellStyle.Default,
        Location = new XlsxPointRange { Column = 1, Row = 16 },
    }).Insert(new InsertAggregateFunction
    {
        SheetName = "Sheet1",
        Style = numberStyle,
        Aggegate =
        {
            WorkSheet = "Sheet1",
            AggregateType = KnownAggregateType.Average,
            Range = new XlsxRange
            {
                Start = { Column = 2, Row = 4 }, End = { Column = 2, Row = 13 }
            }
        },
        Location = new XlsxPointRange { Column = 2, Row = 16 }
    }).Insert(new InsertText
    {
        SheetName = "Sheet1",
        Data = "Max",
        Style = XlsxCellStyle.Default,
        Location = new XlsxPointRange { Column = 1, Row = 17 },
    }).Insert(new InsertAggregateFunction
    {
        SheetName = "Sheet1",
        Style = numberStyle,
        Aggegate =
        {
            WorkSheet = "Sheet1",
            AggregateType = KnownAggregateType.Max,
            Range = new XlsxRange { Start = { Column = 2, Row = 4 }, End = { Column = 2, Row = 13 } }
        },
        Location = new XlsxPointRange { Column = 2, Row = 17 }
    }).Insert(new InsertText
    {
        SheetName = "Sheet1",
        Data = "Min",
        Style = XlsxCellStyle.Default,
        Location = new XlsxPointRange { Column = 1, Row = 18 },
    }).Insert(new InsertAggregateFunction
    {
        SheetName = "Sheet1",
        Style = numberStyle,
        Aggegate =
        {
            WorkSheet = "Sheet1",
            AggregateType = KnownAggregateType.Min,
            Range = new XlsxRange { Start = { Column = 2, Row = 4 }, End = { Column = 2, Row = 13 } }
        },
        Location = new XlsxPointRange { Column = 2, Row = 18 }
    });
    ```

4. Try to create xlsx output result

     **sync mode**
     ```csharp   
     var result = doc.CreateResult();
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

     **async mode**
     ```csharp   
        var result = await doc
         .CreateResultAsync(cancellationToken: cancellationToken)
         .ConfigureAwait(false);
         
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

5. Save xlsx file result
 
    **sync mode**
    ```csharp   
    var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-22/Sample-22" });
   if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

    **async mode**
    ```csharp   
    var saveResult = await result.Result
        .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-22/Sample-22" }, cancellationToken);
        .ConfigureAwait(false);

    if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

### Sample 25 - Use stacked charts

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create(new[] { "Stacked area chart" });
    ```

2. Defines styles
      
    ```csharp  
    var cellStyles = new Dictionary<string, XlsxCellStyle>
    {
        {
            "FieldHeader",
            new XlsxCellStyle
            {
                Font =
                {
                    Name = "Calibri",
                    Size = 11.0f,
                    Bold = YesNo.Yes,
                },
                Borders =
                {
                    new XlsxStyleBorder {Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Color = "#9BC2E6"},
                },
                Content =
                {
                    Color = "#DDEBF7"
                }
            }
        },
        {
            "FieldValue",
            new XlsxCellStyle
            {
                Font =
                {
                    Name = "Calibri",
                    Size = 11.0f,
                },
                Borders =
                {
                    new XlsxStyleBorder {Show = YesNo.Yes, Position = KnownBorderPosition.Left, Color = "#9BC2E6"},
                    new XlsxStyleBorder {Show = YesNo.Yes, Position = KnownBorderPosition.Right, Color = "#9BC2E6"}
                },
                Content =
                {
                    Color = "#BDD7EE",
                    AlternateColor = "#DDEBF7",
                    DataType = new NumberDataType
                    {
                        Decimals = 1,
                        Separator = YesNo.Yes
                    },
                    Alignment =
                    {
                        Horizontal = KnownHorizontalAlignment.Right
                    }
                }
            }
        },
        {
            "PeriodValue",
            new XlsxCellStyle
            {
                Font =
                {
                    Name = "Calibri",
                    Size = 11.0f,
                    Bold = YesNo.Yes,
                },
                Content =
                {
                    Color = "#BDD7EE",
                    AlternateColor = "#DDEBF7",
                    DataType = new DateTimeDataType
                    {
                        Locale = KnownCulture.Current,
                        Format = KnownDateTimeFormat.ShortDatePattern
                    }
                }
            }
        },
        {
            "AggregateHeader",
            new XlsxCellStyle
            {
                Font =
                {
                    Name = "Calibri",
                    Size = 11.0f,
                    Bold = YesNo.Yes,
                },
                Borders =
                {
                    new XlsxStyleBorder {Show = YesNo.Yes, Position = KnownBorderPosition.Top, Color = "#9BC2E6"},
                    new XlsxStyleBorder {Show = YesNo.Yes, Position = KnownBorderPosition.Left, Color = "#9BC2E6"},
                    new XlsxStyleBorder {Show = YesNo.Yes, Position = KnownBorderPosition.Right, Color = "#9BC2E6"}
                },
                Content =
                {
                    Color = "#DDEBF7",
                }
            }
        },
        {
            "AggregateFieldValue",
            new XlsxCellStyle
            {
                Font =
                {
                    Name = "Calibri",
                    Size = 11.0f,
                    Bold = YesNo.Yes,
                },
                Borders =
                {
                    new XlsxStyleBorder {Show = YesNo.Yes, Position = KnownBorderPosition.Top, Color = "#9BC2E6"},
                    new XlsxStyleBorder {Show = YesNo.Yes, Position = KnownBorderPosition.Left, Color = "#9BC2E6"},
                    new XlsxStyleBorder {Show = YesNo.Yes, Position = KnownBorderPosition.Right, Color = "#9BC2E6"}
                },
                Content =
                {
                    Color = "#DDEBF7",
                    DataType = new NumberDataType
                    {
                        Decimals = 1,
                        Separator = YesNo.Yes
                    },
                    Alignment =
                    {
                        Horizontal = KnownHorizontalAlignment.Right
                    }
                }
            }
        }
    };
    ```

3. Insert actions
    
    ```csharp  
    // Insert data here!!

    // Insert autofilter
    doc.Insert(new InsertAutoFilter
    {
        SheetName = "Stacked area chart",
        Location = new XlsxStringRange { Address = "A1:G1" }
    });

    // Insert chart
    doc.Insert(new InsertChart
    {
        SheetName = "Stacked area chart",
        Location = new XlsxPointRange { Column = 9, Row = 1 },
        Chart = new XlsxChart
        {
            Name = "chart1",
            Size = { Width = 800, Height = 600 },
            Axes = { Primary = { Values = { GridLines = GridLine.Major } } },
            Legend = { Show = YesNo.Yes, Border = { Show = YesNo.Yes } },
            Plots =
                {
                    new XlsxChartPlot
                    {
                        Name = "plot1",
                        Series =
                        {
                            new XlsxChartSerie
                            {
                                Name = "Europe",
                                Color = "#285A8F",
                                ChartType = ChartType.AreaStacked,
                                AxisRange = new XlsxRange {Start = {Column = 1, Row = 2}, End = {Column = 1, Row = 13}},
                                FieldRange = new XlsxRange {Start = {Column = 2, Row = 2}, End = {Column = 2, Row = 13}}
                            },
                            new XlsxChartSerie
                            {
                                Name = "AFRICA",
                                Color = "#336EA9",
                                ChartType = ChartType.AreaStacked,
                                AxisRange = new XlsxRange {Start = {Column = 1, Row = 2}, End = {Column = 1, Row = 13}},
                                FieldRange = new XlsxRange {Start = {Column = 3, Row = 2}, End = {Column = 3, Row = 13}}
                            },
                            new XlsxChartSerie
                            {
                                Name = "ASIA",
                                Color = "#3572B1",
                                ChartType = ChartType.AreaStacked,
                                AxisRange = new XlsxRange {Start = {Column = 1, Row = 2}, End = {Column = 1, Row = 13}},
                                FieldRange = new XlsxRange {Start = {Column = 4, Row = 2}, End = {Column = 4, Row = 13}}
                            },
                            new XlsxChartSerie
                            {
                                Name = "NORTHAMERICA",
                                Color = "#628AC5",
                                ChartType = ChartType.AreaStacked,
                                AxisRange = new XlsxRange {Start = {Column = 1, Row = 2}, End = {Column = 1, Row = 13}},
                                FieldRange = new XlsxRange {Start = {Column = 5, Row = 2}, End = {Column = 5, Row = 13}}
                            },
                            new XlsxChartSerie
                            {
                                Name = "SOUTHAMERICA",
                                Color = "#93ADCD",
                                ChartType = ChartType.AreaStacked,
                                AxisRange = new XlsxRange {Start = {Column = 1, Row = 2}, End = {Column = 1, Row = 13}},
                                FieldRange = new XlsxRange {Start = {Column = 6, Row = 2}, End = {Column = 6, Row = 13}}
                            },
                            new XlsxChartSerie
                            {
                                Name = "AUSTRALIA",
                                Color = "#BCCCDE",
                                ChartType = ChartType.AreaStacked,
                                AxisRange = new XlsxRange {Start = {Column = 1, Row = 2}, End = {Column = 1, Row = 13}},
                                FieldRange = new XlsxRange {Start = {Column = 7, Row = 2}, End = {Column = 7, Row = 13}}
                            }
                        }
                    }
                }
        }
    });
    ```

4. Try to create xlsx output result

     **sync mode**
     ```csharp   
     var result = doc.CreateResult();
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

     **async mode**
     ```csharp   
        var result = await doc
         .CreateResultAsync(cancellationToken: cancellationToken)
         .ConfigureAwait(false);
         
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

5. Save xlsx file result
 
    **sync mode**
    ```csharp   
    var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-25/Sample-25" });
   if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

    **async mode**
    ```csharp   
    var saveResult = await result.Result
        .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-25/Sample-25" }, cancellationToken);
        .ConfigureAwait(false);

    if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

### Sample 26 - Use charts with more than one chart type and secondary axis

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create(new[] { "Chart And Secondary Axis" });
    ```

2. Defines styles
      
    ```csharp  
    var cellStylesTable = new Dictionary<string, XlsxCellStyle>
    {
        {
            "FieldHeader",
            new XlsxCellStyle
            {
                Name = "HeaderStyle",
                Borders =
                {
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    },
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Right, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    },
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    },
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Left, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    }
                },
                Content = { Color = "#ED7D31" },
                Font = { Name = "Calibri", Color = "White", Size = 11.0f, Bold = YesNo.Yes }
            }
        },
        {
            "NumericStyle",
            new XlsxCellStyle
            {
                Name = "NumberStyle",
                Borders =
                {
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    },
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Right, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    },
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    },
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Left, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    }
                },
                Content =
                {
                    Color = "#F8CBAD",
                    AlternateColor = "#FCE4D6",
                    DataType = new NumberDataType { Decimals = 0 },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Right }
                },
                Font = { Name = "Calibri", Size = 11.0f }
            }
        },
        {
            "TextStyle",
            new XlsxCellStyle
            {
                Name = "TextStyle",
                Borders =
                {
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    },
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Right, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    },
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    },
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Left, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    }
                },
                Font = { Name = "Calibri", Size = 11.0f },
                Content = { Color = "#F8CBAD", AlternateColor = "#FCE4D6" }
            }
        },
        {
            "DecimalStyle",
            new XlsxCellStyle
            {
                Name = "DecimalStyle",
                Borders =
                {
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    },
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Right, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    },
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    },
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Left, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    }
                },
                Content =
                {
                    Color = "#F8CBAD",
                    AlternateColor = "#FCE4D6",
                    DataType = new NumberDataType { Decimals = 2 },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Right }
                },
                Font = { Name = "Calibri", Size = 11.0f }
            }
        },
        {
            "AggregateNumericStyle",
            new XlsxCellStyle
            {
                Name = "AggregateNumericStyle",
                Borders =
                {
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    },
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Right, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    },
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    },
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Left, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    }
                },
                Content =
                {
                    Color = "#ED7D31",
                    DataType = new NumberDataType { Decimals = 0 },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Right }
                },
                Font = { Name = "Calibri", Color = "White", Size = 11.0f, Bold = YesNo.Yes }
            }
        },
        {
            "AggregateDecimalStyle",
            new XlsxCellStyle
            {
                Name = "AggregateDecimalStyle",
                Borders =
                {
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Top, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    },
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Right, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    },
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Bottom, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    },
                    new XlsxStyleBorder
                    {
                        Show = YesNo.Yes, Position = KnownBorderPosition.Left, Style = KnownBorderStyle.Thin,
                        Color = "White"
                    }
                },
                Content =
                {
                    Color = "#ED7D31",
                    DataType = new NumberDataType { Decimals = 2 },
                    Alignment = { Horizontal = KnownHorizontalAlignment.Right }
                },
                Font = { Name = "Calibri", Color = "White", Size = 11.0f, Bold = YesNo.Yes }
            }
        }
    };
    ```

3. Insert actions
    
    ```csharp  
    // Hide grid lines
    doc.Set(new SetGridLines
    {
        Show = YesNo.No,
        SheetName = "Chart And Secondary Axis"
    });

    // Insert data here!!

    // Insert autofilter
    doc.Insert(new InsertAutoFilter
    {
        SheetName = "Chart And Secondary Axis",
        Location = new XlsxStringRange { Address = "A1:F1" }
    });

    // Define plot axis
    var axisRangePlot1 = new XlsxRange
    {
        Start = { Column = 2, Row = 2 },
        End = { Column = 2, Row = 6 }
    };

    var axisRangePlot2 = new XlsxRange
    {
        Start = { Column = 1, Row = 2 },
        End = { Column = 1, Row = 6 }
    };

    // Insert chart
    doc.Insert(new InsertChart
    {
        SheetName = "Chart And Secondary Axis",
        Location = new XlsxPointRange { Column = 8, Row = 2 },
        Chart = new XlsxChart
        {
            Name = "chart1",
            Size = { Width = 800, Height = 600 },
            Border =
            {
                Color = "Green"
            },
            Axes =
            {
                Primary =
                {
                    Values = { GridLines = GridLine.Major }
                },
                Secondary =
                {
                    Values =
                    {
                        Labels = { Position = LabelPosition.High },
                        Values = { Maximum = "50" }
                    },
                    Category =
                    {
                        Labels = { Position = LabelPosition.High }
                    }
                }
            },
            Legend =
            {
                Show = YesNo.Yes,
                Font = { Name = "Calibri" }
            },
            Plots =
            {
                new XlsxChartPlot
                {
                    Name = "plot1",
                    Series =
                    {
                        new XlsxChartSerie
                        {
                            Name = "Purchase Price",
                            Color = "#336EA9",
                            ChartType = ChartType.ColumnStacked,
                            AxisRange = axisRangePlot1,
                            FieldRange = new XlsxRange { Start = { Column = 4, Row = 2 }, End = { Column = 4, Row = 6 } }
                        },
                        new XlsxChartSerie
                        {
                            Name = "Profit",
                            Color = "#ED7D31",
                            ChartType = ChartType.ColumnStacked,
                            AxisRange = axisRangePlot1,
                            FieldRange = new XlsxRange { Start = { Column = 6, Row = 2 }, End = { Column = 6, Row = 6 } }
                        },
                    }
                },
                new XlsxChartPlot
                {
                    Name = "plot2",
                    UseSecondaryAxis = YesNo.Yes,
                    Series =
                    {
                        new XlsxChartSerie
                        {
                            Name = "Items in Stock",
                            Color = "Gray",
                            ChartType = ChartType.Line,
                            AxisRange = axisRangePlot2,
                            FieldRange = new XlsxRange { Start = { Column = 3, Row = 2 }, End = { Column = 3, Row = 6 } }
                        }
                    }
                }
            },
            Effects =
            {
                Shadow = XlsxPerspectiveShadow.Down,
                Illumination = XlsxIlluminationShapeEffect.Emphasis1Points8
            }
        }
    });
    ```

4. Try to create xlsx output result

     **sync mode**
     ```csharp   
     var result = doc.CreateResult();
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

     **async mode**
     ```csharp   
        var result = await doc
         .CreateResultAsync(cancellationToken: cancellationToken)
         .ConfigureAwait(false);
         
     if (!result.Success)
     {
         // Handle errors                 
     }
     ```

5. Save xlsx file result
 
    **sync mode**
    ```csharp   
    var saveResult = result.Result.Action(new SaveToFile { OutputPath = "~/Output/Sample-26/Sample-26" });
   if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

    **async mode**
    ```csharp   
    var saveResult = await result.Result
        .Action(new SaveToFileAsync { OutputPath = "~/Output/Sample-26/Sample-26" }, cancellationToken);
        .ConfigureAwait(false);

    if (!saveResult.Success)
    {
         // Handle errors                 
    }
     ```

# Documentation

 - For **Writer** code documentation, please see next link documentation.