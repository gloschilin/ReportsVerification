using System.Data.Entity;

namespace ReportsVerification.Web.Repositories.Interfaces
{
    internal interface IEntityMapper<in TSource, in TDestination, in TContext>
        where TContext : DbContext
    {
        void Map(TSource source, TDestination destination, TContext context);
    }
}
