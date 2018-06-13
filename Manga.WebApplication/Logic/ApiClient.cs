using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Manga.WebApplication.Logic
{
    public class ApiClient
    {
        string baseUrl = @"http://localhost:62930/api/";

        public T GetData<T>(string url) where T : new()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responseTask = client.GetAsync(url);
                responseTask.Wait();
                var result = responseTask.Result;
                if (!result.IsSuccessStatusCode) return new T();
                var response = result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(response);
            }
        }
        public bool PostData<T>(string url, T obj) where T : new()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(JsonConvert.SerializeObject(obj).ToString(),
                    Encoding.UTF8, "application/json");
                var result = client.PostAsync(url, content);

                return result.Result.IsSuccessStatusCode;
            }
        }
    }
}