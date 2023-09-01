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

#### Sample 2 - Hello world! (With styles)

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

# Documentation

 - For **Writer** code documentation, please see next link documentation.