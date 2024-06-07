using Project.Models;
using System;

namespace Project.DAL
{
    public class PurchasesDal : IPurchasesDal
    {
        private readonly Context Context;

        public PurchasesDal(Context Context)
        {
            this.Context = Context;
        }

        //public async Task AddPurchase(IEnumerable<Presents> Lc, int BuyerId)
        //{
        //   Purchases Order = new Purchases(BuyerId, Lc.Count());
        //    try
        //    {
        //        Context.Purchases.Add(Order);
        //        Context.SaveChanges();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    int idP = Order.ID;
        //    foreach (var item in Lc)
        //    {
        //        Card c = new Card() { PurchasesId = idP, PresentsID = item.ID };
        //        //sent to a add fund in card;
        //    }
        //}
        public async Task<int> AddPurchase(Purchases p)
        {
            try
            {
                Context.Purchases.Add(p);
                int id = Context.SaveChanges();
                await Task.Delay(100);
                return p.ID;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<Purchases> ContinuePur(int BuyerId)
        {
            try
            {
                var pur = Context.Purchases.FirstOrDefault(p => p.BuyerID == BuyerId && p.status == false);
                if (pur == null)
                {
                    Purchases newP = new Purchases() { BuyerID = BuyerId, NumberOfTicket = 0, status = false };
                    await AddPurchase(newP);
                }
                return pur;              
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
