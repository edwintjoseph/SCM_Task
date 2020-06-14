using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM_PromotionEngine
{
    interface IPromotions
    {
        List<Promotions> AvailablePromotions(Cart cart);
    }
    class Promotions : IPromotions
    {
        public List<string> Combinations { get; set; }
        public int MinItemCount { get; set; }
        public string ItemCode { get; set; }
        public double Price { get; set; }
        public int Percentage { get; set; }

        Cart myCart;

        public Promotions()
        {
            Combinations = new List<string>();
        }

        public List<Promotions> AvailablePromotions(Cart _cart)
        {
            List<Promotions> lstPromotions = new List<Promotions>();
            myCart = _cart;
            //gets the distinct items from the cart for gets each items promtion
            List<Sku> uniqueItems = myCart.Items.GroupBy(c => c.Code).Select(g => g.First()).ToList();

            //gets the promo values for same items
            int counter = 0;
            foreach (var item in uniqueItems)
            {
                var promos = SameSKUPromotion(item);
                if (!String.IsNullOrEmpty(promos.ItemCode))
                {
                    lstPromotions.Add(promos);
                }
                ++counter;
            }
            //gets the combination promos
            //if (counter < uniqueItems.Count)
            lstPromotions.Add(CombinationPromotion());
            return lstPromotions;
        }

        private Promotions SameSKUPromotion(Sku _item)
        {
            Promotions promotion = new Promotions();
            switch (_item.Code)
            {
                case "A":
                    promotion.MinItemCount = 3;
                    promotion.Price = 130;
                    promotion.ItemCode = "A";
                    break;
                case "B":
                    promotion.MinItemCount = 2;
                    promotion.Price = 45;
                    promotion.ItemCode = "B";
                    break;
            }
            return promotion;
        }
        private Promotions CombinationPromotion()
        {
            Promotions promotion = new Promotions();
            promotion.Combinations.Add("C");
            promotion.Combinations.Add("D");
            promotion.MinItemCount = 1;
            promotion.Price = 30;
            return promotion;
        }
    }
}
