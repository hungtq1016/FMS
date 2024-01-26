using Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Infrastructure.EFCore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){}

        protected AppDbContext(){}
    }
}
