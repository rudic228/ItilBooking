using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dal.EfExtensions
{
    public static class DbSetExtension
    {
        public static IQueryable<TEntity> FindAllAsync<TEntity>(this DbSet<TEntity> set, IEnumerable<TEntity> entitiesToFind, bool invert = false) 
            where TEntity : class
        {
            var args = entitiesToFind;
            var dbParameter = Expression.Parameter(typeof(TEntity), typeof(TEntity).Name);

            var properties = set.EntityType.FindPrimaryKey()?.Properties;

            if (properties == null)
                throw new ArgumentException($"{typeof(TEntity).FullName} is not an entity, or does not have a primary key specified.");

            if (args == null)
                throw new ArgumentNullException(nameof(args));

            if (!args.Any())
                return Enumerable.Empty<TEntity>().AsQueryable();

            Expression aggregatedExpression = args.Select(entity =>
            {
                var entry = set.Entry(entity);

                return properties.Select(p =>
                {
                    var dbProp = dbParameter.Type.GetProperty(p.Name);
                    var left = Expression.Property(dbParameter, dbProp);

                    var argValue = entry.Property(p.Name).CurrentValue;
                    var right = Expression.Constant(argValue);

                    return Expression.Equal(left, right);
                })
                .Aggregate((acc, next) => Expression.And(acc, next));
            })
            .Aggregate((acc, next) => Expression.OrElse(acc, next));

            if (invert) aggregatedExpression = Expression.Not(aggregatedExpression);

            return set.Where(Expression.Lambda<Func<TEntity, bool>>(aggregatedExpression, dbParameter));
        }
    }
}
