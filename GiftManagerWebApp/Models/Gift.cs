using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiftManagerWebApp.Models
{
    public class Gift
    {
        public int Id { get; set; }
        public string TypeOfGift { get; set; }
        public double Amount { get; set; }
        public string Address { get; set; }
        public string PayersName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public int LocalSerialId { get; set; }
        public int EventId { get; set; }
        public int AddedBy { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }


    }
}