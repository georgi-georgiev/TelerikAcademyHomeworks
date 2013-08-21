using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.DataLayer;
using MusicStore.Models;

namespace MusicStore.Client
{
    public class Program
    {
        static void Main()
        {
            
            MusicStoreContext context = new MusicStoreContext();

            var album = new Album()
                {
                    Title = "Title",
                    Year = 2013,
                    Producer = "Producer"
                };
            context.Albums.Add(album);
            context.SaveChanges();

            var query = from b in context.Albums
                        select b;

            foreach (var item in query)
            {
                Console.WriteLine(item.Title);
            }
        }
    }
}
