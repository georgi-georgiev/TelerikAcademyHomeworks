using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsumingWebServices
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress =  new Uri("http://api.feedzilla.com/");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            PrintArticles(httpClient, "Michael", 5);
        }

        static void PrintArticles(HttpClient httpClient, string query, int count)
        {
            var response = httpClient.GetAsync("v1/articles/search.json?q=" + query + "&count=" + count).Result;
;
            if (response.IsSuccessStatusCode)
            {
                
                var articles = response.Content.ReadAsStringAsync().Result;
                var desArticles = JsonConvert.DeserializeObject<ArticlesCollection>(articles);
                foreach (var article in desArticles.Articles)
                {
                    Console.WriteLine("{0}\n{1}", article.Title, article.Url);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        

    }
}
