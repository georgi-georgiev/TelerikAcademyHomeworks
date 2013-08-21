using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.UsingVSFDesigner;

namespace _06.SchemaGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities context = new NorthwindEntities();

            StringBuilder dbScript = new StringBuilder();
            dbScript.Append("USE NorthwindTwin ");

            string generatedScript =
                ((IObjectContextAdapter)context).ObjectContext.CreateDatabaseScript();
            dbScript.Append(generatedScript);
            context.Database.ExecuteSqlCommand("CREATE DATABASE NorthwindTwin");
            context.Database.ExecuteSqlCommand(dbScript.ToString());
        }
    }
}
