using Microsoft.EntityFrameworkCore;

namespace MPOS.WebMVC.Services
{
	public interface IDashboardService
	{
		List<T> GetTop<T>(DbSet<T> values, string propertyName, int conditionValue, string orderByColumn, int take) where T : class;
	}
}
