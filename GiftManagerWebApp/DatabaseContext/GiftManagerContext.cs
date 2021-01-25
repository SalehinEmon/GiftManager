using GiftManagerWebApp.Models;
using System.Data.Entity;


namespace GiftManagerWebApp.DatabaseContext
{
    public class GiftManagerContext:DbContext
    {
        public GiftManagerContext() : base("main_db") { }

        public DbSet<Gift> Gifts { get; set; }
        public DbSet<EventModel> EventModels { get; set; }
        public DbSet<User> Users { get; set; }



    }
}