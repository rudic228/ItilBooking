using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System;
using System.Linq.Expressions;
using System.Globalization;
using System.Reflection;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.VisualBasic;

namespace Dal.EfExtensions
{
    public static class IQueryableExtension
    {
        //не знаю зачем это писал, но выглядит круто
        //пока оставлю, мб найду применение
        public static IQueryable<TEntity> StringFilter<TEntity>(this IQueryable<TEntity> qList, string propertyName, string operation, string valueConst)
        {
            var property = typeof(TEntity)?.GetProperty(propertyName);
            var parameterEntity = Expression.Parameter(typeof(TEntity), "x");

            Expression expression;

            if (property is null)
            {
                throw new ArgumentNullException($"Некорректное название свойства {nameof(property)}");
            }

            if (property.PropertyType == typeof(int))
            {
                if (int.TryParse(valueConst, out int intConst))
                {
                    expression = ExprInt(parameterEntity, property.Name, operation, intConst);
                }
                else
                {
                    throw new ArgumentException(nameof(valueConst));
                }

            }

            else if (property.PropertyType == typeof(decimal))
            {
                if (decimal.TryParse(valueConst, out decimal decimalConst))
                {
                    expression = ExprDecimal(parameterEntity, property.Name, operation, decimalConst);
                }
                else
                {
                    throw new ArgumentException(nameof(valueConst));
                }
            }

            else if (property.PropertyType == typeof(DateTime))
            {
                if (DateTime.TryParse(valueConst, CultureInfo.CreateSpecificCulture("ru-RU"), DateTimeStyles.None, out DateTime dateTimeConst))
                {
                    expression = ExprDateTime(parameterEntity, property.Name, operation, dateTimeConst);
                }
                else
                {
                    throw new ArgumentException(nameof(valueConst));
                }
            }

            else if (property.PropertyType == typeof(string))
            {
                expression = ExprString(parameterEntity, property.Name, operation, valueConst);
            }

            else if (property.PropertyType.IsEnum)
            {
                expression = ExprString(parameterEntity, property.Name, operation, valueConst);
            }

            else
            {
                throw new ArgumentException($"Неподдерживаемый тип {property.PropertyType}");
            }


            var expressionLambda = Expression.Lambda<Func<TEntity, bool>>(expression, parameterEntity);

            return qList.Where(expressionLambda);
        }


        //allowed operations "==", "!=", ">", "<", ">=", "<="
        private static Expression ExprInt(ParameterExpression parameterEntity, string propertyName, string operation, int constant)
        {
            var left = Expression.PropertyOrField(parameterEntity, propertyName);

            var right = Expression.Constant(constant, typeof(int));

            Expression expression;

            switch (operation)
            {
                case "==":
                    expression = Expression.Equal(left, right);
                    break;

                case "!=":
                    expression = Expression.NotEqual(left, right);
                    break;

                case ">":
                    expression = Expression.GreaterThan(left, right);
                    break;

                case "<":
                    expression = Expression.LessThan(left, right);
                    break;

                case ">=":
                    expression = Expression.GreaterThanOrEqual(left, right);
                    break;

                case "<=":
                    expression = Expression.LessThanOrEqual(left, right);
                    break;

                default:
                    throw new ArgumentException(nameof(operation));
            }

            return expression;
        }

        //allowed operations "==", "!=", ">", "<", ">=", "<="
        private static Expression ExprDecimal(ParameterExpression parameterEntity, string propertyName, string operation, decimal constant)
        {
            var left = Expression.PropertyOrField(parameterEntity, propertyName);

            var right = Expression.Constant(constant, typeof(decimal));

            Expression expression;

            switch (operation)
            {
                case "==":
                    expression = Expression.Equal(left, right);
                    break;

                case "!=":
                    expression = Expression.NotEqual(left, right);
                    break;

                case ">":
                    expression = Expression.GreaterThan(left, right);
                    break;

                case "<":
                    expression = Expression.LessThan(left, right);
                    break;

                case ">=":
                    expression = Expression.GreaterThanOrEqual(left, right);
                    break;

                case "<=":
                    expression = Expression.LessThanOrEqual(left, right);
                    break;

                default:
                    throw new ArgumentException(nameof(operation));
            }

            return expression;
        }

        //allowed operations "==", "!=", ">", "<", ">=", "<="
        private static Expression ExprDateTime(ParameterExpression parameterEntity, string propertyName, string operation, DateTime constant)
        {
            var left = Expression.PropertyOrField(parameterEntity, propertyName);

            var right = Expression.Constant(constant, typeof(DateTime));

            Expression expression;

            switch (operation)
            {
                case "==":
                    expression = Expression.Equal(left, right);
                    break;

                case "!=":
                    expression = Expression.NotEqual(left, right);
                    break;

                case ">":
                    expression = Expression.GreaterThan(left, right);
                    break;

                case "<":
                    expression = Expression.LessThan(left, right);
                    break;

                case ">=":
                    expression = Expression.GreaterThanOrEqual(left, right);
                    break;

                case "<=":
                    expression = Expression.LessThanOrEqual(left, right);
                    break;

                default:
                    throw new ArgumentException(nameof(operation));
            }

            return expression;
        }

        //allowed operations "==", "!=", ">", "<", ">=", "<="
        private static Expression ExprString(ParameterExpression parameterEntity, string propertyName, string operation, string constant)
        {
            var property = Expression.PropertyOrField(parameterEntity, propertyName);

            Expression left;

            if (property.Type.IsEnum)
            {
                var obj = Expression.Convert(property, typeof(object));//напрямую не работает

                left = Expression.Convert(obj, typeof(string));
            }
            else
            {
                left = property;
            }

            var right = Expression.Constant(constant, typeof(string));

            Expression expression;

            switch (operation)
            {
                case "==":
                    expression = Expression.Equal(left, right);
                    break;

                case "!=":
                    expression = Expression.NotEqual(left, right);
                    break;

                case "like":
                    expression = Expression.Call(left, "Contains", Type.EmptyTypes, right);
                    break;

                case "startwith":
                    expression = Expression.Call(left, "StartWith", Type.EmptyTypes, right);
                    break;

                case "endwith":
                    expression = Expression.Call(left, "EndWith", Type.EmptyTypes, right);
                    break;

                default:
                    throw new ArgumentException(nameof(operation));
            }

            return expression;
        }
    }


}
