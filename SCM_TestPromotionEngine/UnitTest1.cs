using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCM_PromotionEngine;

namespace SCM_TestPromotionEngine
{
    [TestClass]
    public class UnitTest1
    {
        PromotionEngine promotionEngine;
        Cart _cart;

        [TestMethod]
        public void ScenarioA()
        {
            promotionEngine = new PromotionEngine();
            _cart = new Cart();

            _cart.Items.Add(new Sku() { Code = "A", Name = "A", Price = 50 });
            
            _cart.Items.Add(new Sku() { Code = "B", Name = "B", Price = 30 });

            _cart.Items.Add(new Sku() { Code = "C", Name = "C", Price = 20 });            

            Assert.AreEqual(100, promotionEngine.GetOrderValue(_cart));
        }
        [TestMethod]
        public void ScenarioB()
        {
            promotionEngine = new PromotionEngine();
            _cart = new Cart();

            _cart.Items.Add(new Sku() { Code = "A", Name = "A", Price = 50 });
            _cart.Items.Add(new Sku() { Code = "A", Name = "A", Price = 50 });
            _cart.Items.Add(new Sku() { Code = "A", Name = "A", Price = 50 });
            _cart.Items.Add(new Sku() { Code = "A", Name = "A", Price = 50 });
            _cart.Items.Add(new Sku() { Code = "A", Name = "A", Price = 50 });

            _cart.Items.Add(new Sku() { Code = "B", Name = "B", Price = 30 });
            _cart.Items.Add(new Sku() { Code = "B", Name = "B", Price = 30 });
            _cart.Items.Add(new Sku() { Code = "B", Name = "B", Price = 30 });
            _cart.Items.Add(new Sku() { Code = "B", Name = "B", Price = 30 });
            _cart.Items.Add(new Sku() { Code = "B", Name = "B", Price = 30 });

            _cart.Items.Add(new Sku() { Code = "C", Name = "C", Price = 20 });            

            Assert.AreEqual(370, promotionEngine.GetOrderValue(_cart));
        }

        [TestMethod]
        public void ScenarioC()
        {
            promotionEngine = new PromotionEngine();
            _cart = new Cart();

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

            Assert.AreEqual(280, promotionEngine.GetOrderValue(_cart));
        }
    }
}
