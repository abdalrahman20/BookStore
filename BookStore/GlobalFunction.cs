using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace BookStore
{
    public static class GlobalFunction
    {
        public static HttpClient client;

        /// <summary>
        /// Constuctor that's initilize HttpClient to connect with  WebAPI
        /// </summary>
        static GlobalFunction()
        { 
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54040/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// function Handle GET Method and retraive data using WebAPI (Retraive Collection of Data)
        /// </summary>
        public static void retraiveAll<T>(out IEnumerable<T> list, string Path) where T : class
        {
            HttpResponseMessage response = client.GetAsync(Path).Result;
            if (response.IsSuccessStatusCode)
            {
                list = response.Content.ReadAsAsync<IList<T>>().Result;
            }
            else
            {
                list = Enumerable.Empty<T>();
            }
        }

        /// <summary>
        /// function Handle GET Method and retraive data using WebAPI (Retraive One Record of Dtata)
        /// </summary>
        public static void retraiveOne<T>(out T obj, string Path) where T : class
        {
            HttpResponseMessage response = client.GetAsync(Path).Result;
            if (response.IsSuccessStatusCode)
            {
                obj = response.Content.ReadAsAsync<T>().Result;
            }
            else
            {
                obj = default(T);
            }
        }

        /// <summary>
        /// function Handle POST Method and post data to server using WebAPI
        /// </summary>
        public static bool PostMethod<T>(T obj, string Path) where T:class
        {
            HttpResponseMessage response = client.PostAsJsonAsync(Path, obj).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// function Handle PUT Method and update data using WebAPI
        /// </summary>
        public static void PutMethod<T>(ref T obj, string Path) where T : class
        {
            HttpResponseMessage response = client.PutAsJsonAsync(Path, obj).Result;
            if (response.IsSuccessStatusCode)
            {
                obj = response.Content.ReadAsAsync<T>().Result;
            }
            else
            {
                obj = null;
            }
        }

        /// <summary>
        /// function Handle Delete Method and delete data using WebAPI
        /// </summary>
        public static void DeleteMethod<T>(out T obj, string Path) where T : class
        {
            HttpResponseMessage response = client.DeleteAsync(Path).Result;
            if (response.IsSuccessStatusCode)
            {
                obj = response.Content.ReadAsAsync<T>().Result;
            }
            else
            {
                obj = null;
            }
        }

    }
}