using Infrastructure.EFCore.Data;

namespace DocumentService.Infrastructure.Data
{
    public class DocumentContextFactory : AppDbContextFactory<DocumentContext>
    {
        public DocumentContextFactory() : base("documentDB")
        {
        }
    }
}
