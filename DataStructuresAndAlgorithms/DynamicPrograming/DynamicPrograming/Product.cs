using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicPrograming
{
    public class Product
    {
        public Product(string name, int weight, int cost)
        {
            this.Name = name;
            this.Weight = weight;
            this.Cost = cost;
        }

        public string Name
        {
            get;
            private set;
        }

        public int Weight
        {
            get;
            private set;
        }

        public int Cost
        {
            get;
            private set;
        }
    }
}
