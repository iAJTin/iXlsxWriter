<p align="center">
  <img src="https://github.com/iAJTin/iXlsxWriter/blob/master/nuget/iXlsxWriter.png" height="32"/>
</p>
<p align="center">
  <a href="https://github.com/iAJTin/iXlsxWriter">
    <img src="https://img.shields.io/badge/iTin-iXlsxWriter-green.svg?style=flat"/>
  </a>
</p>

***

# What is iXlsxWriter?

**iXlsxWriter** is a lightweight implementation that allows creates a **xlsx** document totally or partially.
**Currently only works on Windows**


The idea is to try to quickly and easily facilitate the task of filling in the 'typical' report file that the client wants to send by email with the data filled in from their erp, vertical application, custom development, etc... to which I am sure that you have faced each other at some point. 

I hope it helps someone. :smirk:

# Install via NuGet

- From nuget gallery

<table>
  <tr>
    <td>
      <a href="https://github.com/iAJTin/iXlsxWriter">
        <img src="https://img.shields.io/badge/-iXlsxWriter-green.svg?style=flat"/>
      </a>
    </td>
    <td>
      <a href="https://www.nuget.org/packages/iXlsxWriter/">
        <img alt="NuGet Version" 
             src="https://img.shields.io/nuget/v/iXlsxWriter.svg" /> 
      </a>
    </td>  
  </tr>
</table>

- From package manager console

```PM> Install-Package iXlsxWriter```

# Extensions

Below is a list of extensions available to use with **XlsxInput**.

   | Library | Version | Description |
   |:--------|:--------|:------------|
   | [![nuget package](./assets/nuget_24x24.png)](https://www.nuget.org/packages/iXlsxWriter.AspNet) [iXlsxWriter.AspNet](https://github.com/iAJTin/iXlsxWriter.AspNet) | 1.0.0 | Extends **iXlsxWriter** to work in *AspNet* (FullFramework) projects, contains extension methods to download **XlsxInput** instances as well as **OutputResult**, facilitating its use in this environment |
   | [![nuget package](./assets/nuget_24x24.png)](https://www.nuget.org/packages/iXlsxWriter.AspNetCore) [iXlsxWriter.AspNetCore](https://github.com/iAJTin/iXlsxWriter.AspNetCore) | 1.0.0 | Extends **iXlsxWriter** to work in *AspNetCore* projects, contains extension methods to download **XlsxInput** instances as well as **OutputResult**, facilitating its use in this environment |
   | [![nuget package](./assets/nuget_24x24.png)](https://www.nuget.org/packages/iXlsxWriter.Mail) [iXlsxWriter.Mail](https://github.com/iAJTin/iXlsxWriter.Mail) | 1.0.0 | Extends **iXlsxWriter**, contains extension methods to download **XlsxInput** instances as well as **OutputResult** |

# Usage

## Samples

### Sample 1 - Hello world!

Basic steps, for more details please see [sample01.cs] file.

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
5. Output

   ###### Below is an image showing the result after inserting the text

    ![Sample01.image][Sample01.image] 

### Sample 2 - Hello world! (With styles)

Basic steps, for more details please see [sample02.cs] file.

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
6. Output

   ###### Below is an image showing the result after inserting the text

    ![Sample02.image][Sample02.image] 

### Sample 3 - Add custom document properties

Basic steps, for more details please see [sample03.cs] file.

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
6. Output

   ###### Below is an image showing the result when viewing the document properties

    ![Sample03.image][Sample03.image] 

### Sample 4 - Add custom sheet properties

Basic steps, for more details please see [sample04.cs] file.

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
6. Output

   ###### Below is an image showing the result

    ![Sample04.image][Sample04.image] 

### Sample 6 - Insert datatable and generic collections

Basic steps, for more details please see [sample06.cs] file.

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create(new[] { "Sheet1", "Sheet2" });
    ```
        
2. Define data model
    
   For more details please see [Person.cs] file.          

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
6. Output

   ###### Below is an image showing the result

    ![Sample06.image][Sample06.image] 

### Sample 7 - Save a xlsx input as zip file

Basic steps, for more details please see [sample07.cs] file.

1. Creates xlsx input

    ```csharp   
    var doc = XlsxInput.Create(new[] { "Sheet1", "Sheet2" });
    ```
        
2. Define data model
    
   For more details please see [Person.cs] file.          

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
6. Output

   ###### Below is an image showing the result

    ![Sample07.image][Sample07.image] 

### Sample 9 - Insert a picture with effects

Basic steps, for more details please see [sample09.cs] file.

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
5. Output

   ###### Below is an image showing the result

    ![Sample09.image][Sample09.image] 

### Sample 10 - Insert a picture from file and byte array

Basic steps, for more details please see [sample10.cs] file.

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
5. Output

   ###### Below is an image showing the result

    ![Sample10.image][Sample10.image] 

### Sample 11 - Insert shapes with effects

Basic steps, for more details please see [sample11.cs] file.

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
5. Output

   ###### Below is an image showing the result

    ![Sample11.image][Sample11.image] 

### Sample 12 - Insert a table with styles

Basic steps, for more details please see [sample12.cs] file.

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
5. Output

   ###### Below is an image showing the result

    ![Sample12.image][Sample12.image] 

### Sample 13 - Insert a table with styles and column headers

Basic steps, for more details please see [sample13.cs] file.

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
5. Output

   ###### Below is an image showing the result

    ![Sample13.image][Sample13.image] 

### Sample 14 - Insert a table with styles and data filter

Basic steps, for more details please see [sample14.cs] file.

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
5. Output

   ###### Below is an image showing the result

    ![Sample14.image][Sample14.image] 

### Sample 15 - Insert mini charts

Basic steps, for more details please see [sample15.cs] file.

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
5. Output

   ###### Below is an image showing the result

    ![Sample15.image][Sample15.image] 

### Sample 16 - Insert a DataTable or Enumerable by InsertTable action without styles

Basic steps, for more details please see [sample16.cs] file.

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
5. Output

   ###### Below is an image showing the result

    ![Sample16.image][Sample16.image] 

### Sample 17 - Insert a table with styles and fixed fields

Basic steps, for more details please see [sample17.cs] file.

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
5. Output

   ###### Below is an image showing the result

    ![Sample17.image][Sample17.image] 

# Documentation

 - For **Writer** code documentation, please see next link documentation.

# How can I send feedback!!!

If you have found **iXlsxWriter** useful at work or in a personal project, I would love to hear about it. If you have decided not to use **iXlsxWriter**, please send me and email stating why this is so. I will use this feedback to improve **iXlsxWriter** in future releases.

My email address is 

![email.png][email] 

[email]: ./assets/email.png "email"
[documentation]: ./documentation/iXlsxWriterr.md
[nuget]: ./assets/nuget.png "nuget"

[sample17.cs]: https://github.com/iAJTin/iXlsxWriter/blob/master/src/samples/NetCore/iXlsxWriter.ConsoleAppCore/Code/Sample17.cs
[Sample17.image]: ./assets/samples/sample-17/Sample-17.png "sample-17"

[sample16.cs]: https://github.com/iAJTin/iXlsxWriter/blob/master/src/samples/NetCore/iXlsxWriter.ConsoleAppCore/Code/Sample16.cs
[Sample16.image]: ./assets/samples/sample-16/Sample-16.png "sample-16"

[sample15.cs]: https://github.com/iAJTin/iXlsxWriter/blob/master/src/samples/NetCore/iXlsxWriter.ConsoleAppCore/Code/Sample15.cs
[Sample15.image]: ./assets/samples/sample-15/Sample-15.png "sample-15"

[sample14.cs]: https://github.com/iAJTin/iXlsxWriter/blob/master/src/samples/NetCore/iXlsxWriter.ConsoleAppCore/Code/Sample14.cs
[Sample14.image]: ./assets/samples/sample-14/Sample-14.png "sample-14"

[sample13.cs]: https://github.com/iAJTin/iXlsxWriter/blob/master/src/samples/NetCore/iXlsxWriter.ConsoleAppCore/Code/Sample13.cs
[Sample13.image]: ./assets/samples/sample-13/Sample-13.png "sample-13"

[sample12.cs]: https://github.com/iAJTin/iXlsxWriter/blob/master/src/samples/NetCore/iXlsxWriter.ConsoleAppCore/Code/Sample12.cs
[Sample12.image]: ./assets/samples/sample-12/Sample-12.png "sample-12"

[sample11.cs]: https://github.com/iAJTin/iXlsxWriter/blob/master/src/samples/NetCore/iXlsxWriter.ConsoleAppCore/Code/Sample11.cs
[Sample11.image]: ./assets/samples/sample-11/Sample-11.png "sample-11"
[Sample11.shadows.image]: ./assets/samples/sample-11/Sample-11-Shadows.png "sample-11"
[Sample11.illumination.image]: ./assets/samples/sample-11/Sample-11-Illumination.png "sample-11"
[Sample11.reflection.image]: ./assets/samples/sample-11/Sample-11-Reflection.png "sample-11"
[Sample11.softedge.image]: ./assets/samples/sample-11/Sample-11-SoftEdge.png "sample-11"

[sample10.cs]: https://github.com/iAJTin/iXlsxWriter/blob/master/src/samples/NetCore/iXlsxWriter.ConsoleAppCore/Code/Sample10.cs
[Sample10.image]: ./assets/samples/sample-10/Sample-10.png "sample-10"

[sample09.cs]: https://github.com/iAJTin/iXlsxWriter/blob/master/src/samples/NetCore/iXlsxWriter.ConsoleAppCore/Code/Sample09.cs
[Sample09.image]: ./assets/samples/sample-09/Sample-09.png "sample-09"

[sample08.cs]: https://github.com/iAJTin/iXlsxWriter/blob/master/src/samples/NetCore/iXlsxWriter.ConsoleAppCore/Code/Sample08.cs
[Sample08.image]: ./assets/samples/sample-08/Sample-08.png "sample-08"

[sample07.cs]: https://github.com/iAJTin/iXlsxWriter/blob/master/src/samples/NetCore/iXlsxWriter.ConsoleAppCore/Code/Sample07.cs
[Sample07.image]: ./assets/samples/sample-07/Sample-07.png "sample-07"

[sample06.cs]: https://github.com/iAJTin/iXlsxWriter/blob/master/src/samples/NetCore/iXlsxWriter.ConsoleAppCore/Code/Sample06.cs
[Sample06.image]: ./assets/samples/sample-06/Sample-06.png "sample-06"

[sample05.cs]: https://github.com/iAJTin/iXlsxWriter/blob/master/src/samples/NetCore/iXlsxWriter.ConsoleAppCore/Code/Sample05.cs
[Sample05.image]: ./assets/samples/sample-05/Sample-05.png "sample-05"

[sample04.cs]: https://github.com/iAJTin/iXlsxWriter/blob/master/src/samples/NetCore/iXlsxWriter.ConsoleAppCore/Code/Sample04.cs
[Sample04.image]: ./assets/samples/sample-04/Sample-04.png "sample-04"

[sample03.cs]: https://github.com/iAJTin/iXlsxWriter/blob/master/src/samples/NetCore/iXlsxWriter.ConsoleAppCore/Code/Sample03.cs
[Sample03.image]: ./assets/samples/sample-03/Sample-03.png "sample-03"

[sample02.cs]: https://github.com/iAJTin/iXlsxWriter/blob/master/src/samples/NetCore/iXlsxWriter.ConsoleAppCore/Code/Sample02.cs
[Sample02.image]: ./assets/samples/sample-02/Sample-02.png "sample-02"

[sample01.cs]: https://github.com/iAJTin/iXlsxWriter/blob/master/src/samples/NetCore/iXlsxWriter.ConsoleAppCore/Code/Sample01.cs
[Sample01.image]: ./assets/samples/sample-01/Sample-01.png "sample-01"

[Person.cs]: https://github.com/iAJTin/iXlsxWriter/blob/master/src/samples/NetCore/iXlsxWriter.ConsoleAppCore/ComponentModel/Person.cs
