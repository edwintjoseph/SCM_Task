using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM_PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            PromotionEngine promotionEngine = new PromotionEngine();
            Cart _cart = new Cart();

            _cart.Items.Add(new Sku() { Code = "A", Name = "A", Price = 50 });
            _cart.Items.Add(new Sku() { Code = "A", Name = "A", Price = 50 });
            _cart.Items.Add(new Sku() { Code = "A", Name = "A", Price = 50 });


            _cart.Items.Add(new Sku() { Code = "B", Name = "B", Price = 30 });
            _cart.Items.Add(new Sku() { Code = "B", Name = "B", Price = 30 });
            _cart.Items.Add(new Sku() { Code = "B", Name = "B", Price = 30 });
            _cart.Items.Add(new Sku() { Code = "B", Name = "B", Price = 30 });
            _cart.Items.Add(new Sku() { Code = "B", Name = "B", Price = 30 });

            _cart.Items.Add(new Sku() { Code = "C", Name = "C", Price = 20 });
            _cart.Items.Add(new Sku() { Code = "D", Name = "D", Price = 15 });

            Console.WriteLine("Total " + promotionEngine.GetOrderValue(_cart));
        }
    }
}
