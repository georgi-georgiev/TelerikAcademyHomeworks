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
    public class ArtistsCRUD
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


        //    //AddNewArtist("Kilata", "Bulgaria", DateTime.Now);
        //    //GetArtistById(5);
        //    //UpdateArtist(5, "Shamara", "German", DateTime.Now);
        //    //DeleteArtist(5);
        //    //GetAllArtists();

        //    //AddNewArtistXml("Kilata", "Bulgaria", DateTime.Now);
        //    //GetArtistByIdXml(5);
        //    //UpdateArtistXml(5, "Shamara", "German", DateTime.Now);
        //    //DeleteArtistXml(5);
        //    //GetAllArtistsXml();

        //    /*
        //     * The GetAsync method sends an HTTP GET request. As the name implies, GetAsyc is asynchronous.
        //     * It returns immediately, without waiting for a response from the server.
        //     * The return value is a Task object that represents the asynchronous operation.
        //     * When the operation completes, the Task.Result property contains the HTTP response.
        //     */

        //}

        internal static void DeleteArtist(int id)
        {
            HttpResponseMessage response = Client.DeleteAsync("api/artists/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist is deleted!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void UpdateArtist(int id, string name, string country, DateTime dateofbirth)
        {
            var artist = GetArtist(id);
            if (artist != null)
            {
                artist.Name = name;
                artist.Country = country;
                artist.DateOfBirth = dateofbirth;

                var response = Client.PutAsJsonAsync("api/artists/" + id, artist).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Artist updated!");
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
        internal static Artist GetArtist(int id)
        {
            HttpResponseMessage response = Client.GetAsync("api/artists/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var artist = response.Content.ReadAsAsync<Artist>().Result;

                return artist;
            }
            else
            {
                return null;
            }
        }
        internal static void GetArtistById(int id)
        {
            HttpResponseMessage response = Client.GetAsync("api/artists/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var artist = response.Content.ReadAsAsync<Artist>().Result;

                Console.WriteLine("{0} {1} {2} {3}", artist.Id, artist.Name, artist.Country, artist.DateOfBirth.ToString());
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        internal static void GetAllArtists()
        {
            HttpResponseMessage response = Client.GetAsync("api/artists").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
                foreach (var a in artists)
                {
                    Console.WriteLine("{0} {1} {2} {3}", a.Id, a.Name, a.Country, a.DateOfBirth.ToString());
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        internal static void AddNewArtist(string name, string country, DateTime dateofbirth)
        {
            var artist = new Artist { Name = name, Country = country, DateOfBirth = dateofbirth,};
            
            var response = Client.PostAsJsonAsync("api/artists", artist).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void AddNewArtistXml(string name, string country, DateTime dateofbirth)
        {
            var artist = new Artist { Name = name, Country = country, DateOfBirth = dateofbirth, };

            var response = ClientXml.PostAsXmlAsync("api/artists", artist).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void UpdateArtistXml(int id, string name, string country, DateTime dateofbirth)
        {
            var artist = GetArtistXml(id);
            if (artist != null)
            {
                artist.Name = name;
                artist.Country = country;
                artist.DateOfBirth = dateofbirth;

                var response = ClientXml.PutAsXmlAsync("api/artists/" + id, artist).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Artist updated!");
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

        internal static void DeleteArtistXml(int id)
        {
            HttpResponseMessage response = ClientXml.DeleteAsync("api/artists/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist is deleted!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static Artist GetArtistXml(int id)
        {
            HttpResponseMessage response = ClientXml.GetAsync("api/artists/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var artist = response.Content.ReadAsAsync<Artist>().Result;

                return artist;
            }
            else
            {
                return null;
            }
        }
        internal static void GetArtistByIdXml(int id)
        {
            HttpResponseMessage response = ClientXml.GetAsync("api/artists/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var artist = response.Content.ReadAsAsync<Artist>().Result;

                Console.WriteLine("{0} {1} {2} {3}", artist.Id, artist.Name, artist.Country, artist.DateOfBirth.ToString());
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        internal static void GetAllArtistsXml()
        {
            HttpResponseMessage response = ClientXml.GetAsync("api/artists").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
                foreach (var a in artists)
                {
                    Console.WriteLine("{0} {1} {2} {3}", a.Id, a.Name, a.Country, a.DateOfBirth.ToString());
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
