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
    public class SongsCRUD
    {
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("http://localhost:52960/") };
        private static readonly HttpClient ClientXml = new HttpClient { BaseAddress = new Uri("http://localhost:52960/") };

        internal static void Main()
        {
            // Add an Accept header for JSON format.
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            ClientXml.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/xml"));


            //AddNewSong("Pesen", 2012, "Qko chalga");
            //GetSongById(2);
            //UpdateSong(1, "Ziggy Zao", 2005, "Rapec");
            //DeleteSong(5);
            GetAllSongs();

            //AddNewSongXml("Pesen", 2012, "Qko chalga");
            //GetSongByIdXml(2);
            //UpdateSongXml(1, "Ziggy Zao", 2005, "Rapec");
            //DeleteSongXml(5);
            //GetAllSongsXml();

            /*
             * The GetAsync method sends an HTTP GET request. As the name implies, GetAsyc is asynchronous.
             * It returns immediately, without waiting for a response from the server.
             * The return value is a Task object that represents the asynchronous operation.
             * When the operation completes, the Task.Result property contains the HTTP response.
             */

        }

        internal static void DeleteSong(int id)
        {
            HttpResponseMessage response = Client.DeleteAsync("api/songs/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song is deleted!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void UpdateSong(int id, string title, int year, string genre)
        {
            var song = GetSong(id);
            if (song != null)
            {
                song.Title = title;
                song.Year = year;
                song.Genre = genre;

                var response = Client.PutAsJsonAsync("api/songs/" + id, song).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song updated!");
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
        internal static Song GetSong(int id)
        {
            HttpResponseMessage response = Client.GetAsync("api/songs/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var song = response.Content.ReadAsAsync<Song>().Result;

                return song;
            }
            else
            {
                return null;
            }
        }
        internal static void GetSongById(int id)
        {
            HttpResponseMessage response = Client.GetAsync("api/songs/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var song = response.Content.ReadAsAsync<Song>().Result;

                Console.WriteLine("{0} {1} {2} {3}", song.Id, song.Title, song.Year, song.Genre);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        internal static void GetAllSongs()
        {
            HttpResponseMessage response = Client.GetAsync("api/songs").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var songs = response.Content.ReadAsAsync<IEnumerable<Song>>().Result;
                foreach (var s in songs)
                {
                    Console.WriteLine("{0} {1} {2} {3}", s.Id, s.Title, s.Year, s.Genre);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void AddNewSong(string title, int year, string genre)
        {
            var song = new Song { Title = title, Year = year, Genre = genre};

            var response = Client.PostAsJsonAsync("api/songs", song).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void AddNewSongXml(string title, int year, string genre)
        {
            var song = new Song { Title = title, Year = year, Genre = genre };

            var response = ClientXml.PostAsXmlAsync("api/songs", song).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void UpdateSongXml(int id, string title, int year, string genre)
        {
            var song = GetSongXml(id);
            if (song != null)
            {
                song.Title = title;
                song.Year = year;
                song.Genre = genre;

                var response = ClientXml.PutAsXmlAsync("api/songs/" + id, song).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song updated!");
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

        internal static void DeleteSongXml(int id)
        {
            HttpResponseMessage response = ClientXml.DeleteAsync("api/songs/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song is deleted!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static Song GetSongXml(int id)
        {
            HttpResponseMessage response = ClientXml.GetAsync("api/songs/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var song = response.Content.ReadAsAsync<Song>().Result;

                return song;
            }
            else
            {
                return null;
            }
        }
        internal static void GetSongByIdXml(int id)
        {
            HttpResponseMessage response = ClientXml.GetAsync("api/songs/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var song = response.Content.ReadAsAsync<Song>().Result;

                Console.WriteLine("{0} {1} {2} {3}", song.Id, song.Title, song.Year, song.Genre);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        internal static void GetAllSongsXml()
        {
            HttpResponseMessage response = ClientXml.GetAsync("api/songs").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var songs = response.Content.ReadAsAsync<IEnumerable<Song>>().Result;
                foreach (var s in songs)
                {
                    Console.WriteLine("{0} {1} {2} {3}", s.Id, s.Title, s.Year, s.Genre);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
