using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM_PromotionEngine
{
    interface IPromotionEngine
    {
        double GetOrderValue(Cart _cart);
    }
    public class PromotionEngine : IPromotionEngine
    {
        Cart myCart;
        double orderTotal = 0;
        public double GetOrderValue(Cart _cart)
        {
            myCart = _cart;
            List<Promotions> AllPromotions;
            IPromotions promotions = new Promotions();
            AllPromotions = promotions.AvailablePromotions(_cart);
            return CalculateTotalOrderValue(AllPromotions);
        }

        private double CalculateTotalOrderValue(List<Promotions> _promotions)
        {
            List<string> appliedItemsCode = new List<string>();

            foreach (var promo in _promotions)
            {
                if (promo.Combinations.Count == 0)
                {
                    int itemCount = myCart.Items.Where(x => x.Code == promo.ItemCode).Count();
                    var promoitem = myCart.Items.Where(x => x.Code == promo.ItemCode).FirstOrDefault();

                    if (itemCount >= promo.MinItemCount)
                    {
                        orderTotal += promo.Price * (itemCount / promo.MinItemCount);
                        orderTotal += promoitem.Price * (itemCount % promo.MinItemCount);
                        appliedItemsCode.Add(promo.ItemCode);
                        continue;
                    }
                }
                else
                {
                    Dictionary<string, int> promoitem = new Dictionary<string, int>();
                    int item1Count = myCart.Items.Where(x => x.Code == promo.Combinations[0]).Count();
                    int item2Count = myCart.Items.Where(x => x.Code == promo.Combinations[1]).Count();

                    if (item1Count == item2Count)
                    {
                        orderTotal += promo.Price * (item1Count / promo.MinItemCount);
                        appliedItemsCode.AddRange(promo.Combinations);
                    }
                    else if (item1Count > promo.MinItemCount)
                    {
                        orderTotal += promo.Price * (item1Count / promo.MinItemCount);
                        orderTotal += myCart.Items.Where(x => x.Code == promo.Combinations[0]).FirstOrDefault().Price * (item1Count % promo.MinItemCount);
                        appliedItemsCode.AddRange(promo.Combinations);
                    }
                    else if (item2Count > promo.MinItemCount)
                    {
                        orderTotal += promo.Price * (item2Count / promo.MinItemCount);
                        orderTotal += myCart.Items.Where(x => x.Code == promo.Combinations[1]).FirstOrDefault().Price * (item2Count % promo.MinItemCount);
                        appliedItemsCode.AddRange(promo.Combinations);
                    }
                }
            }

            IEnumerable<Sku> _result = myCart.Items.Where(i => !appliedItemsCode.Contains(i.Code));
            foreach (var item in _result)
            {
                int itemCount = myCart.Items.Where(x => x.Code == item.Code).Count();
                orderTotal += item.Price * itemCount;
            }

            return orderTotal;
        }
    }
}
