using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Models.DTO;
using System.Collections.Generic;

namespace Project.DAL
{
    public class PresentDal:IPresentDal
    {
        private readonly Context Context;

        public PresentDal(Context Context)
        {
            this.Context = Context;
        }
        public async Task<IEnumerable<Presents>> Get()
        {
            return await Context.Presents
                .Include(p=>p.Category)
                .ToListAsync();
        }
        public Presents AddPresents(Presents p)
        {
            try
            {
                Context.Presents.Add(p);
                Context.SaveChanges();
                //return o;
            }
            catch (Exception ex)
            {
                throw;
            }
            return p;
        }
        public void RemoveById(int id)
        {
            var present = Context.Presents.FirstOrDefault(c => c.ID == id);
            if (present == null)
            {
                throw new Exception($"customer {id} not found");
            }
            Context.Presents.Remove(present);
            Context.SaveChanges();
        }

        public void RemoveSeveralPresent(List<PresentDTO2> presents)
        {
            for(int i=0; i<presents.Capacity; i++)
            {
                PresentDTO2 p = presents.ElementAt(i);
                RemoveById(p.ID);
            }
        }

        public Presents UpdateP(int id, Presents pre)
        {
            var up = Context.Presents.FirstOrDefault(c => c.ID == id);

            up = pre;
            //Context.Donors.Remove(up);
            Context.Presents.Update(up);
            Context.SaveChanges();
            return up;
        }
        public async Task<IEnumerable<Presents>> GetPresentByBuyer(int IdBuyer)
        {
            IEnumerable<Presents> list = Context.Presents
                .Where(d => d.ID == IdBuyer)
                .ToList();
            await Task.Delay(100);
            return list;
        }
        public async Task<List<Presents>> GetPresentByDonor(int DonorId)
        {
            //var pre = Context.Donors
            //    .Include(d => d.Donations)
            //    .Where(d => d.ID == DonorId).ToList();

            //List<Presents> reslist =new List<Presents>();
            //return reslist;     

            List<Presents> pre = Context.Presents
                .Where(d => d.DonorsID == DonorId).ToList();
            await Task.Delay(100);
            return pre;
        }
        public async Task<IEnumerable<Presents>> GetPresentByNumOfPurchasers(int NumOfPurchasers)
        {
            List<Presents> pre = Context.Presents
               .Where(d => d.NumOfPurchasers == NumOfPurchasers).ToList();
            await Task.Delay(100);
            return pre;
        }
        public async Task<IEnumerable<Presents>> getPresentsPurcheses(int buyerId)
        {

            IEnumerable<Presents> presents = await (from c in Context.Card
                                                    join p in Context.Presents.Include(p => p.Category) on c.PresentsID equals p.ID
                                                    join pur in Context.Purchases on c.PurchasesId equals pur.ID
                                                    where pur.BuyerID == buyerId
                                                    select new Presents
                                                    {
                                                        ID = p.ID,
                                                        Name = p.Name,
                                                        Price = p.Price,
                                                        Category=p.Category
                                                    })
                                      .ToListAsync();
            return presents;
        }
    }

}


