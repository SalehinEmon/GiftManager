using GiftManagerWebApp.DatabaseContext;
using GiftManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace GiftManagerWebApp.BLL
{
    public class GiftManager
    {
        private GiftManagerContext _giftManagerContext;
        public GiftManager() { _giftManagerContext = new GiftManagerContext(); }


        public double GetTotalAmountByEvventId(int eventId)
        {
            //double totalAmount = _giftManagerContext.Gifts
            //                     .Where(e => e.EventId == eventId)
            //                     .Select(e => e.Amount).Sum();

            double totalAmount = _giftManagerContext.Gifts
                     .Where(e => e.EventId == eventId)
                     .Sum(e => (double?)e.Amount) ?? 0;

            return totalAmount;
        }

        public int GetTotalGiftByEvventId(int eventId)
        {
            var totalGifts = _giftManagerContext.Gifts
                                 .Where(g => g.EventId == eventId)
                                 .Select(g => g.TypeOfGift == "gift").ToList();

            return totalGifts.Count();
        }

        public int AddGift(Gift gift)
        {
            int localSerial = _giftManagerContext.Database.
                SqlQuery<int>
                ("SELECT ISNULL(MAX(LocalSerialId),0) LocalSerialId FROM Gifts WHERE EventId = " + gift.EventId)
                .FirstOrDefault();

            gift.LocalSerialId = localSerial + 1;            

            _giftManagerContext.Gifts.Add(gift);
            int rowEffected = _giftManagerContext.SaveChanges();

            return rowEffected;
        }


        public List<Gift> GetAllFiftByEventId(int eventId)
        {
            List<Gift> allGift = _giftManagerContext
                        .Gifts.Where(g => g.EventId == eventId)
                        .OrderBy(g=>g.LocalSerialId)
                        .ToList();

            return allGift;
        }
    }
}