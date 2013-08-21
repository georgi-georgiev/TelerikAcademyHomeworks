using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Redis;
using ServiceStack.Text;
using ServiceStack.Common;
using NoSQL;
using ServiceStack.Redis.Generic;

namespace Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var redisClient = new RedisClient("127.0.0.1:6379"))
            {
                var entry = new Entry { Id = "dictionary", Word = "House", Translation = "Kushta" };
                redisClient.HSet(entry.Id, Extensions.ToAsciiCharArray(entry.Word), Extensions.ToAsciiCharArray(entry.Translation));
                var entry2 = new Entry { Id = "dictionary", Word = "Cat", Translation = "Kotka" };
                redisClient.HSet(entry2.Id, Extensions.ToAsciiCharArray(entry2.Word), Extensions.ToAsciiCharArray(entry2.Translation));

                byte[][] entries = redisClient.HGetAll("dictionary");
                foreach (var ent in entries)
                {
                    string entStr = Extensions.StringFromByteArray(ent);
                    Console.WriteLine(entStr);
                }
                Console.WriteLine();
                var result = Find(redisClient, "dictionary", "Cat");
                Console.WriteLine(Extensions.StringFromByteArray(result));
            }
        }

        static byte[] Find(RedisClient redis, string id, string word)
        {
            return redis.HGet(id, Extensions.ToAsciiCharArray(word));
        }
    }
}