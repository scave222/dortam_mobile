using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace dortam_mobile.Services
{
    public static class GenericService
    {


        public static async Task<T> GetAsync<T>(string uri, string authToken = "")
        {
            try
            {

                //HttpClient httpClient = CreateHttpClient(uri);
                //HttpClient httpClient = HttpClientHandler.Instance.HttpClient;
                string jsonResult = string.Empty;

                var responseMessage = await HttpClientHandler.Instance.HttpClient.GetAsync(uri);

                if (responseMessage.IsSuccessStatusCode)
                {
                    // var ss = await responseMessage.Content.ReadAsStreamAsync();

                    jsonResult =
                        await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);


                    var json = JsonConvert.DeserializeObject<T>(jsonResult);
                    return json;
                }

                if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return (T)(object)new { };
                }
                if (responseMessage.StatusCode == HttpStatusCode.Forbidden)
                {
                    return (T)(object)new { };
                }
                if (responseMessage.StatusCode == HttpStatusCode.BadRequest)
                {
                    return (T)(object)new { };
                }
                return (T)(object)new { };

            }
            catch (Exception e)
            {
                var s = $"{ e.GetType().Name + " : " + e.Message}";

                return (T)(object)new { };
            }
        }
        public static async Task<TR> PostAsync<T, TR>(string uri, T data, string authToken = "")
        {
            try
            {
                var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var responseMessage = await HttpClientHandler.Instance.HttpClient.PostAsync(uri, content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var json = JsonConvert.DeserializeObject<TR>(jsonResult);
                    return json;
                }

                if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return (TR)(object)new { };
                }

                if (responseMessage.StatusCode == HttpStatusCode.Forbidden || responseMessage.StatusCode == HttpStatusCode.NotFound || responseMessage.StatusCode == HttpStatusCode.BadRequest)
                {
                    return (TR)(object)new { };
                }
                return (TR)(object)new { };

            }
            catch (Exception e)
            {
                return (TR)(object)new { };
            }
        }
    }
}
