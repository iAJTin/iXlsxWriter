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

# Documentation

 - For **Writer** code documentation, please see next link documentation.
