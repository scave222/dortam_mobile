using dortam_mobile.Interface;
using dortam_mobile.Utils.LocalStorage;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dortam_mobile.Services
{
    public class LocalDatabaseService : ILocalDatabaseService
    {
        private static readonly Lazy<SQLiteAsyncConnection> Lazy = new Lazy<SQLiteAsyncConnection>(() => new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags));

        public static SQLiteAsyncConnection Database => Lazy.Value;

        private Dictionary<Type, bool> TablesCreationData { get; set; }

        public LocalDatabaseService()
        {
            TablesCreationData = new Dictionary<Type, bool>();
        }
        public async Task<bool> CreateTableIfNotExists<T>()
        {
            try
            {
                var type = typeof(T);
                var properties = type.GetProperties();
                bool hasPrimaryKeyColumn = properties.Any(p => p.GetCustomAttributes(false).Any(c => c.GetType() == typeof(PrimaryKeyAttribute)));// properties.Any(p => p.GetCustomAttributes(typeof(PrimaryKeyAttribute), false).Any());
                if (!hasPrimaryKeyColumn)
                    throw new Exception($"{type.Name} must implement a property with a PrimaryKey Attribute");


                if (TablesCreationData.ContainsKey(type) && TablesCreationData[type])
                    return true;


                if (Database.TableMappings.Any(m => m.MappedType.Name == typeof(T).Name))
                {
                    TablesCreationData.Add(type, true);
                    return true;
                }
                else
                {
                    await Database.CreateTablesAsync(CreateFlags.None, type);
                    TablesCreationData.Add(type, true);
                    return true;
                }
            }
            catch (Exception e)
            {
                //e.TrackError();
                return false;
            }

        }
        public async Task<int> Add<T>(T item)
        {
            await CreateTableIfNotExists<T>();

            return await Database.InsertAsync(item);

        }

        public async Task<int> AddOrUpdate<T>(T item) where T : new()
        {
            await CreateTableIfNotExists<T>();

            return await Database.InsertOrReplaceAsync(item);
        }
        public async Task DeleteRange<T>(List<T> items = null) where T : new()
        {
            await Database.DeleteAllAsync<T>();
        }
        public void AddOrUpdateRange<T>(List<T> items) where T : new()
        {
            items.ForEach(async x => await AddOrUpdate(x));
        }

        public async Task<int> CountAsync<T>(Expression<Func<T, bool>> expression = null) where T : new()
        {
            try
            {
                await CreateTableIfNotExists<T>();
                if (expression == null)
                    return await Database.Table<T>().CountAsync();

                return await Database.Table<T>().CountAsync(expression);
            }
            catch (Exception e)
            {
                //e.TrackError();
                return 0;
            }

        }


        public async Task<T> FirstOrDefault<T>(Expression<Func<T, bool>> expression = null) where T : new()
        {
            await CreateTableIfNotExists<T>();

            return await Database.Table<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> Get<T>(Expression<Func<T, bool>> expression = null) where T : new()
        {
            await CreateTableIfNotExists<T>();

            if (expression == null)
                return await Database.Table<T>().ToListAsync();

            return await Database.Table<T>().Where(expression).ToListAsync();
        }

        public async Task<int> Update<T>(T item)
        {
            await CreateTableIfNotExists<T>();
            return await Database.UpdateAsync(item);
        }
        public async Task<int> Update<T>(Expression<Func<T, bool>> expression = null) where T : new()
        {
            await CreateTableIfNotExists<T>();

            return await Database.UpdateAsync(expression);
        }

        public async Task<int> Delete<T>(Expression<Func<T, bool>> expression = null) where T : new()
        {
            return await Database.Table<T>().DeleteAsync(expression);
        }

        public async Task DropTableAsync<T>() where T : new()
        {
            await Database.DropTableAsync<T>();
        }

        public async Task DeleteTable<T>(Expression<Func<T, bool>> expression = null) where T : new()
        {
            var count = await CountAsync<T>();
            if (count > 0)
            {
                await Database.DropTableAsync<T>();
                await Database.CreateTableAsync<T>();
                await Database.DeleteAllAsync<T>();
            }
        }
    }
}
