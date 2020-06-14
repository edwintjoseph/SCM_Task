using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM_PromotionEngine
{
    public class Cart
    {
        public Cart()
        {
            Items = new List<Sku>();
        }
        public List<Sku> Items { get; set; }
    }
}
