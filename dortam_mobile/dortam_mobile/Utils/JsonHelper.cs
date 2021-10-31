using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace dortam_mobile.Utils
{
	public class JsonHelper
	{
		public static string SerializeObject(object obj, bool ignoreNulls = true, bool ignoreDefaults = true, bool noFormatting = true, bool addTypes = false, IContractResolver contractResolver = null, IList<JsonConverter> converters = null, JsonSerializerSettings settings = null)
		{
			JsonSerializerSettings sett = null;
			if (ignoreNulls || ignoreDefaults || addTypes || contractResolver != null || converters != null)
			{
				sett = settings ?? new JsonSerializerSettings();
				if (ignoreNulls)
					sett.NullValueHandling = NullValueHandling.Ignore;
				if (ignoreDefaults)
					sett.DefaultValueHandling = DefaultValueHandling.Ignore;
				if (addTypes)
					sett.TypeNameHandling = TypeNameHandling.All;
				if (contractResolver != null)
					sett.ContractResolver = contractResolver;
				if (converters != null)
					sett.Converters = converters;
			}

			return JsonConvert.SerializeObject(obj, noFormatting ? Formatting.None : Formatting.Indented, sett);
		}
		public static T DeserializeObject<T>(string data, bool silent = false)
		{
			T result;

			if (string.IsNullOrEmpty(data))
				return default(T);

			try
			{
				result = JsonConvert.DeserializeObject<T>(data);
			}
			catch (Exception)
			{
				if (!silent)
					throw;

				result = default(T);
			}

			return result;
		}
	}
}
