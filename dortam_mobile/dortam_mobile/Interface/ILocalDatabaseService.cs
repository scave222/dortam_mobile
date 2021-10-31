using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace dortam_mobile.Interface
{
	public interface ILocalDatabaseService
	{
		Task<bool> CreateTableIfNotExists<T>();
		Task<int> Add<T>(T item);
		Task<int> Update<T>(T item);
		Task<int> Update<T>(Expression<Func<T, bool>> expression = null) where T : new();
		Task<int> Delete<T>(Expression<Func<T, bool>> expression = null) where T : new();
		Task DeleteRange<T>(List<T> items = null) where T : new();
		Task DeleteTable<T>(Expression<Func<T, bool>> expression = null) where T : new();
		void AddOrUpdateRange<T>(List<T> items) where T : new();
		Task<int> AddOrUpdate<T>(T item) where T : new();
		Task<T> FirstOrDefault<T>(Expression<Func<T, bool>> expression = null) where T : new();
		Task<int> CountAsync<T>(Expression<Func<T, bool>> expression = null) where T : new();
		Task<List<T>> Get<T>(Expression<Func<T, bool>> expression = null) where T : new();
		Task DropTableAsync<T>() where T : new();
	}
}
