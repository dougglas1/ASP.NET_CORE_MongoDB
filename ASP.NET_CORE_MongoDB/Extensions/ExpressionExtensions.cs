using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ASP.NET_CORE_MongoDB.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<TParameter, bool>> And<TParameter>(
            this Expression<Func<TParameter, bool>> firstExpression,
            Expression<Func<TParameter, bool>> secondExpression)
        {
            var predicate = PredicateBuilder.New(firstExpression);
            return predicate.And(secondExpression);
        }

        public static Expression<Func<TParameter, bool>> ConcatWithAnd<TParameter>(
            this IList<Expression<Func<TParameter, bool>>> expressions)
        {
            var firstExpression = expressions.FirstOrDefault();

            return expressions.Skip(1).Aggregate(firstExpression, (current, expression) => current.And(expression));
        }
    }
}
