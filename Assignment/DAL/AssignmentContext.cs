using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Assignment.DAL
{
    public class AssignmentContext : DbContext
    {
        public AssignmentContext() : base("name=AssignmentConnectionString1")
        {
        }

        public DbSet<District> Districts { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Seller2District> Seller2Districts {get;set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}