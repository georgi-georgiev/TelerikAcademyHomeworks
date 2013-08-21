using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace NoSQL
{
    class Program
    {
        public static MongoDatabase db
        {
            get
            {
                var connectionstring = "mongodb://user:password@provider/database";
                string dbName = MongoUrl.Create(connectionstring).DatabaseName;
                MongoServer dbServer = new MongoClient(connectionstring).GetServer();
                MongoDatabase dbConnection = dbServer.GetDatabase(dbName);
                return dbConnection;
            }
        }

        static void Main(string[] args)
        {
            Save(db, new Entry() { Word = "House", Translation = "Kyshta" });
            Save(db, new Entry() { Word = "Cat", Translation = "Kotka" });
            Save(db, new Entry() { Word = "Dog", Translation = "Kuche" });
            Save(db, new Entry() { Word = "Milk", Translation = "Mlqko" });
            Save(db, new Entry() { Word = "Stone", Translation = "Kamyk" });
            var entries = Load().ToList();
            foreach (var entry in entries)
            {
                System.Console.WriteLine(entry.Word + " " + entry.Translation);
            }

            System.Console.WriteLine();

            var result = Find("Milk").ToString();
            System.Console.WriteLine(result);
        }

        public static void Save(MongoDatabase db, Entry value)
        {
            db.GetCollection<Entry>("Dictionary").Save(value);
        }

        public static IQueryable<Entry> Load()
        {
            return db.GetCollection<Entry>("Dictionary").AsQueryable();
        }

        public static IQueryable<Entry> Find(string word)
        {
            db.GetCollection<Entry>("Dictionary").AsQueryable().Select( e => e.Word = word);
        }
    }
}