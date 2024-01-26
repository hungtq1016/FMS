using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Core
{
    public interface IDbFacadeResolver
    {
        DatabaseFacade Database { get; }
    }
}
