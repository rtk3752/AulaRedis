using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaRedis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");

            var redis = ConnectionMultiplexer.Connect("localhost");
            //GetSetValues(redis);
            var sub = redis.GetSubscriber();
            sub.Subscribe("fiapzin2", (ch,msg)=> {
                Console.WriteLine(msg.ToString());
            });

            sub.Publish("fiapzin2","testezin da porra");
        }

        private static void GetSetValues(ConnectionMultiplexer redis)
        {
            IDatabase db = redis.GetDatabase();
            // Get/Set
            db.StringSet("a", "123");
            var value = db.StringGet("a");
            db.StringSet("A", "1");
            db.StringGet("A").TryParse(out int x);
            db.StringIncrement("A");
            db.StringGet("A");

            db.SetAdd("tech", "SQL");
            db.HashSet("CLI", "AA", 1);

            db.ListLeftPush("L1", "A");
            db.ListLeftPush("L2", "B");
        }
    }
}
