using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.UsingVSFDesigner;

namespace _02.DaoClass
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateNewProduct("Motorbike");
            //ModifyProductName(78, "Car");
            //DeleteProduct(78);
        }
        static int CreateNewProduct(string productName)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            Product newProduct = new Product
            {
                ProductName = productName,
                Discontinued = false
            };
            northwindEntities.Products.Add(newProduct);
            northwindEntities.SaveChanges();
            return newProduct.ProductID;
        }

        static void ModifyProductName(int productId, string newName)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            Product product = GetProductById(northwindEntities, productId);
            product.ProductName = newName;
            northwindEntities.SaveChanges();
        }

        static void DeleteProduct(int productId)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            Product product = GetProductById(northwindEntities, productId);
            northwindEntities.Products.Remove(product);
            northwindEntities.SaveChanges();
        }

        static Product GetProductById(NorthwindEntities northwindEntities, int productId)
        {
            Product product = northwindEntities.Products.FirstOrDefault(
                p => p.ProductID == productId);
            return product;
        }
    }
}
