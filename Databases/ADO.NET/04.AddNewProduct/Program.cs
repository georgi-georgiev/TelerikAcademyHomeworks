using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AddNewProduct
{
    class Program
    {
        static void Main()
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; " +
            "Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                int inserted = InsertProduct("SomeName", 1, 2, "20 - 1L Bottles", 10.00, 13, 70, 25, 0, dbCon);
                Console.WriteLine("Row position in database {0}", inserted);
            }
        }
        static private int InsertProduct(string productName, int supplierId,
            int categoryId, string quantity, double price, int unitsInStock,
            int unitsOnOrder, int reaorderLevel, int discontinued, SqlConnection dbCon)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Products " +
              "(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, "+
              "UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) VALUES " +
              "(@name, @supplier, @category, @quantity, @price, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)", dbCon);
            cmd.Parameters.AddWithValue("@name", productName);
            cmd.Parameters.AddWithValue("@supplier", supplierId);
            cmd.Parameters.AddWithValue("@category", categoryId);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@unitsInStock", unitsInStock);
            cmd.Parameters.AddWithValue("@unitsOnOrder", unitsOnOrder);
            cmd.Parameters.AddWithValue("@reorderLevel", reaorderLevel);
            cmd.Parameters.AddWithValue("@discontinued", discontinued);
            cmd.ExecuteNonQuery();

            SqlCommand cmdSelectIdentity = new SqlCommand("SELECT @@Identity", dbCon);
            int insertedRecordId = (int)(decimal)cmdSelectIdentity.ExecuteScalar();
            return insertedRecordId;
        }

    }
}
