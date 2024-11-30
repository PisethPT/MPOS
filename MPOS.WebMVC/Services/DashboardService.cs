
using Microsoft.EntityFrameworkCore;
using MPOS.WebMVC.Data;
using System.Linq.Expressions;

namespace MPOS.WebMVC.Services
{
	public class DashboardService : IDashboardService
	{
		private readonly DemoContext context;
		public DashboardService(DemoContext context)
		{
			this.context = context;
		}
		public List<T> GetTop<T>(DbSet<T> values, string propertyName, int conditionValue, string orderByColumn, int take) where T : class
		{
			var parameter = Expression.Parameter(typeof(T), "x");
			var property = Expression.Property(parameter, propertyName);
			var condition = Expression.Constant(conditionValue);
			var comparison = Expression.GreaterThanOrEqual(property, condition);
			var lambda = Expression.Lambda<Func<T, bool>>(comparison, parameter);

			var orderByProperty = Expression.Property(parameter, orderByColumn);
			var orderByLambda = Expression.Lambda<Func<T, object>>(Expression.Convert(orderByProperty, typeof(object)), parameter);

			var list = values.Where(lambda)
							 .OrderByDescending(orderByLambda)
							 .Take(take)
							 .ToList();

			return list;
		}

	}
}
