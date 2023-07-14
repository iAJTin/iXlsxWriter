
using iTin.Core.Models.Design;

namespace iTin.Utilities.Xlsx.Design.Settings.Document;

public partial class XlsxDocumentMetadataSettings : ICombinable<XlsxDocumentMetadataSettings>
{
    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">Reference settings</param>
    void ICombinable<XlsxDocumentMetadataSettings>.Combine(XlsxDocumentMetadataSettings reference) => Combine(reference);


    /// <summary>
    /// Combines this instance with reference parameter.
    /// </summary>
    /// <param name="reference">The reference.</param>
    public virtual void Combine(XlsxDocumentMetadataSettings reference)
    {
        if (reference == null)
        {
            return;
        }

        Author = reference.Author;
        Category = reference.Category;
        Comments = reference.Comments;
        Company = reference.Company;
        Keywords = reference.Keywords;
        Manager = reference.Manager;
        Subject = reference.Subject;
        Title = reference.Title;
        Url = reference.Url;
    }
}
