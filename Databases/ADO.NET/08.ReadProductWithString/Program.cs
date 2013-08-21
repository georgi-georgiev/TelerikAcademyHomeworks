using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.ReadProductWithString
{
    class Program
    {
        static void Main(string[] args)
        {
            //If u run exercise 4 u can try with SomeName
            string userSearch = Console.ReadLine();
            List<string> allProducts;
            GetProducts(out allProducts, userSearch);
            foreach (var item in allProducts)
            {
                Console.WriteLine(item);
            }
        }

        private static void GetProducts(out  List<string> allProducts, string input)
        {
            allProducts = new List<string>();
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; " +
                    "Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                string sql = "SELECT ProductName, ProductId FROM Products where ProductName LIKE @input";
                SqlParameter userInput = new SqlParameter("@input", "%" + input + "%");
                SqlCommand cmd = new SqlCommand(sql, dbCon);
                cmd.Parameters.Add(userInput);

                SqlDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string product = (string)reader["ProductName"] + " -> " + (int)reader["ProductId"];
                        allProducts.Add(product);
                    }
                }
            }
        }
    }
}
