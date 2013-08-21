using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumingWebServices
{
    public class ArticlesCollection
    {
        public IEnumerable<Article> Articles { get; set; }
    }
}
