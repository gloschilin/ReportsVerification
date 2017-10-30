using System.Data.Entity;

namespace ReportsVerification.Web.Mappers.Interfaces
{
    public interface IEntityMapper<in TSource, in TDestination, in TContext>
        where TContext : DbContext
    {
        void Map(TSource source, TDestination destination, TContext context);
    }
}
