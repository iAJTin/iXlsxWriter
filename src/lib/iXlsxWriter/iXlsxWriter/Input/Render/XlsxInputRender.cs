
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using iTin.Core;

using iXlsxWriter.Abstractions.Writer.Operations.Results;
using iXlsxWriter.Operations;
using iXlsxWriter.Operations.Insert;
using iXlsxWriter.Operations.Result.Action;
using iXlsxWriter.Operations.Set;

namespace iXlsxWriter.Input;

/// <summary>
/// 
/// </summary>
internal static class XlsxInputRender
{
    /// <summary>
    /// Returns a new reference <see cref="ActionResult"/> that contains result of <b>set</b>, <b>insert</b> or <b>replace</b> action.
    /// </summary>
    /// <param name="context">A <see cref="XlsxInput"/> reference to render.</param>
    /// <returns>
    /// <para>
    /// A <see cref="ActionResult"/> reference that contains the result of the operation, to check if the operation is correct, the <b>Success</b>
    /// property will be <b>true</b> and the <b>Result</b> property will contain the Result; Otherwise, the the <b>Success</b> property
    /// will be false and the <b>Errors</b> property will contain the errors associated with the operation, if they have been filled in.
    /// </para>
    /// <para>
    /// The type of the return Result is <see cref="ActionResultData"/>, which contains the operation result
    /// </para>
    /// </returns>
    public static ActionResult Render<T>(XlsxInput context)
    {
        IEnumerable<IOperationAction> items;

        var input = context.ToStream();
        
        var rendertType = typeof(T);

        if (rendertType == typeof(IInsert))
        {
            items = XlsxInputCache.Cache.GetInserts(context);
        }
        else if(rendertType == typeof(ISet))
        {
            items = XlsxInputCache.Cache.GetSets(context);
        }
        else
        {
            items = XlsxInputCache.Cache.GetReplacements(context);
        }

        var outputStream = new MemoryStream();

        try
        {
            foreach (var item in items)
            {
                var worksheet = context.Package.Workbook.Worksheets.FirstOrDefault(wk => wk.Name.Equals(item.SheetName, StringComparison.OrdinalIgnoreCase));
                if (worksheet == null)
                {
                    if (rendertType != typeof(ISet))
                    {
                        return ActionResult.CreateErrorResult(
                            $"Sheet '{item.SheetName}' not found",
                            new ActionResultData
                            {
                                Context = context,
                                InputStream = input,
                                OutputStream = input
                            });
                    }
                }

                var executeResult = item.Execute(context, input, context.Package, worksheet);
                if (!executeResult.Success)
                {
                    return ActionResult.CreateErrorResult(executeResult.Errors.ToArray());
                }

                outputStream = executeResult.Result.OutputStream.ToMemoryStream();
                input = outputStream.Clone();
            }

            return ActionResult.CreateSuccessResult(new ActionResultData
            {
                Context = context,
                InputStream = input,
                OutputStream = new MemoryStream(outputStream.GetBuffer())
            });
        }
        catch (Exception ex)
        {
            return ActionResult.FromException(
                ex,
                new ActionResultData
                {
                    Context = context,
                    InputStream = input,
                    OutputStream = input
                });
        }
    }
}
