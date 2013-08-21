using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using MusicStore.Client;

namespace HttpClientCRUD
{
    public class AlbumsCRUD
    {
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("http://localhost:52960/") };
        private static readonly HttpClient ClientXml = new HttpClient { BaseAddress = new Uri("http://localhost:52960/") };

        //The project can have only one Main Method
        //Uncomment to use

        //internal static void Main()
        //{
        //    // Add an Accept header for JSON format.
        //    Client.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json"));

        //    ClientXml.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/xml"));



        //    //AddNewAlbum("New title", 2013, "New Producer");
        //    //GetAlbumById(3);
        //    //UpdateAlbum(3, "Some title", 2005, "Some Producer");
        //    //DeleteAlbum(3);
        //    //GetAllAlbums();

        //    //AddNewAlbumXml("New title", 2013, "New Producer");
        //    //GetAlbumByIdXml(3);
        //    //UpdateAlbumXml(3, "Some title", 2005, "Some Producer");
        //    //DeleteAlbumXml(3);
        //    //GetAllAlbumsXml();

        //    /*
        //     * The GetAsync method sends an HTTP GET request. As the name implies, GetAsyc is asynchronous.
        //     * It returns immediately, without waiting for a response from the server.
        //     * The return value is a Task object that represents the asynchronous operation.
        //     * When the operation completes, the Task.Result property contains the HTTP response.
        //     */
            
        //}

        internal static void DeleteAlbum(int id)
        {
            HttpResponseMessage response = Client.DeleteAsync("api/albums/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album is deleted!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void UpdateAlbum(int id, string title, int year, string producer)
        {
            var album = GetAlbum(id);
            if (album != null)
            {
                album.Title = title;
                album.Producer = producer;
                album.Year = year;

                var response = Client.PutAsJsonAsync("api/albums/" + id, album).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Album updated!");
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
            else
            {
                Console.WriteLine("No item found");
            }
        }

        internal static Album GetAlbum(int id)
        {
            HttpResponseMessage response = Client.GetAsync("api/albums/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var album = response.Content.ReadAsAsync<Album>().Result;

                return album;
            }
            else
            {
                return null;
            }
        }
        internal static void GetAlbumById(int id)
        {
            HttpResponseMessage response = Client.GetAsync("api/albums/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                var album = response.Content.ReadAsAsync<Album>().Result;

                Console.WriteLine("{0} {1} {2} {3}", album.Id, album.Title, album.Year, album.Producer);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        internal static void GetAllAlbums()
        {
            HttpResponseMessage response = Client.GetAsync("api/albums").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsAsync<IEnumerable<Album>>().Result;
                foreach (var a in albums)
                {
                    Console.WriteLine("{0} {1} {2} {3}", a.Id, a.Title, a.Year, a.Producer);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void AddNewAlbums(string title, int year, string producer)
        {
            var album = new Album { Title = title, Year = year, Producer = producer };

            var response = Client.PostAsJsonAsync("api/albums", album).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void UpdateAlbumXml(int id, string title, int year, string producer)
        {
            var album = GetAlbumXml(id);
            if (album != null)
            {
                album.Title = title;
                album.Producer = producer;
                album.Year = year;

                var response = ClientXml.PutAsXmlAsync("api/albums/" + id, album).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Album updated!");
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
            else
            {
                Console.WriteLine("No item found");
            }
        }

        internal static void AddNewAlbumsXml(string title, int year, string producer)
        {
            var album = new Album { Title = title, Year = year, Producer = producer };

            var response = ClientXml.PostAsXmlAsync("api/albums", album).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void DeleteAlbumXml(int id)
        {
            HttpResponseMessage response = ClientXml.DeleteAsync("api/albums/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album is deleted!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static Album GetAlbumXml(int id)
        {
            HttpResponseMessage response = ClientXml.GetAsync("api/albums/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var album = response.Content.ReadAsAsync<Album>().Result;

                return album;
            }
            else
            {
                return null;
            }
        }
        internal static void GetAlbumByIdXml(int id)
        {
            HttpResponseMessage response = ClientXml.GetAsync("api/albums/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var album = response.Content.ReadAsAsync<Album>().Result;

                Console.WriteLine("{0} {1} {2} {3}", album.Id, album.Title, album.Year, album.Producer);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        internal static void GetAllAlbumsXml()
        {
            HttpResponseMessage response = ClientXml.GetAsync("api/albums").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsAsync<IEnumerable<Album>>().Result;
                foreach (var a in albums)
                {
                    Console.WriteLine("{0} {1} {2} {3}", a.Id, a.Title, a.Year, a.Producer);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
