using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiftManagerWebApp.Models
{
    public class Massage
    {
        public static readonly string success = "success";
        public static readonly string failed = "failed";
        public string Body { get; set; }
        public string Type { get; set; }
    }
}