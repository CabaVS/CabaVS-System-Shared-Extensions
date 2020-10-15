using System;
using System.Linq;
using System.Linq.Expressions;

namespace CabaVS.Shared.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyPredicate<T>(this IQueryable<T> expression, Expression<Func<T, bool>> predicate, bool isOptional = true)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            if (!isOptional && predicate == null) throw new ArgumentNullException(nameof(predicate));

            var result = expression;

            if (predicate != null)
            {
                result = result.Where(predicate);
            }

            return result;
        }

        public static IQueryable<T> SkipAndTake<T>(this IQueryable<T> expression, int skip, int take)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));

            var result = expression;

            if (skip > 0) result = result.Skip(skip);
            if (take > 0) result = result.Take(take);

            return result;
        }
    }
}