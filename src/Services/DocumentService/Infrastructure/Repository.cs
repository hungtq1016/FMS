using DocumentService.Infrastructure.Data;
using DocumentService.Models;
using Infrastructure.EFCore.Repository;
using Microsoft.Extensions.Caching.Memory;

namespace DocumentService.Infrastructure
{
    public class DocumentRepository : RepositoryBase<DocumentContext, Document>
    {
        public DocumentRepository(DocumentContext context, IMemoryCache cache) : base(context, cache)
        {
        }
    }
}
