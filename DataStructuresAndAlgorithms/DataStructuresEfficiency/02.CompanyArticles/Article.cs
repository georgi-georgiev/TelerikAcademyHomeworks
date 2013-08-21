using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CompanyArticles
{
    public class Article:IComparable<Article>
    {
        public Article(long barcode, string vendor, string title, int price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }
        public long Barcode
        {
            get;
            private set;
        }
        public string Vendor
        {
            get;
            private set;
        }
        public string Title
        {
            get;
            private set;
        }
        public int Price
        {
            get;
            private set;
        }
        public override string ToString()
        {
            return this.Barcode.ToString()+" "+this.Vendor+" "+this.Title+" "+this.Price.ToString();
        }

        public int CompareTo(Article other)
        {
            return string.Compare(this.Vendor, other.Vendor) +
            string.Compare(this.Title, other.Title);
        }
    }
}
