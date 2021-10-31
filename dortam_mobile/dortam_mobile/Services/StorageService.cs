using dortam_mobile.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using dortam_mobile.Utils;

namespace dortam_mobile.Services
{
	public class StorageService : IStorageService
	{
		public async Task<T> Read<T>(string name)
		{
			string content = await Xamarin.Essentials.SecureStorage.GetAsync(name);

			if (string.IsNullOrEmpty(content))
				return default(T);

			return JsonHelper.DeserializeObject<T>(content, true);
		}

		public async Task Write<T>(string name, T value)
		{
			await Xamarin.Essentials.SecureStorage.SetAsync(name, JsonHelper.SerializeObject(value));
			//CrossSecureStorage.Current.SetValue(name, JsonHelper.SerializeObject(value));
		}
	}
}
