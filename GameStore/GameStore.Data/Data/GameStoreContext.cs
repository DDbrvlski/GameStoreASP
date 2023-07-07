using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using GameStore.Data.Data.CMS;
using GameStore.Data.Data.Shop;
using GameStore.Data.Data.Media;
using GameStore.Data.Data.Account;

namespace GameStore.Data.Data
{
    public class GameStoreContext : DbContext
    {
        public GameStoreContext(DbContextOptions<GameStoreContext> options)
            : base(options)
        {
        }

        //Account
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<AccountType> AccountType { get; set; }
        public DbSet<OrderElement> OrderElement { get; set; }
        public DbSet<Order> Order { get; set; }

        //CMS
        public DbSet<FooterDetails> FooterDetails { get; set; }
        public DbSet<FooterLinks> FooterLinks { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<PageContent> PageContent { get; set; }

        //Media
        public DbSet<Images> Images { get; set; }

        //Shop
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Platforms> Platforms { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Publishers> Publishers { get; set; }
        public DbSet<Rates> Rates { get; set; }
        public DbSet<TypesOfProducts> TypesOfProducts { get; set; }
        public DbSet<Producers> Producers { get; set; }
        public DbSet<RatesProductsAccounts> RatesProductsAccounts { get; set; }
        public DbSet<CartElement> CartElement { get; set; }

    }
}
