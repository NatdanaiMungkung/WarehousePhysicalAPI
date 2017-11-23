using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WarehousePhysicalAPI.Models;

namespace WarehousePhysicalAPI.Domain
{
    public class EFDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Attributes> Attributes { get; set; }
        public DbSet<ReconcileGroup> ReconcileGroup { get; set; }
        public DbSet<Statuses> Statuses { get; set; }
        public DbSet<StandardPrices> StandardPrices { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<SAPInputs> SAPInputs { get; set; }
        public DbSet<ReconcileInputs> ReconcileInputs { get; set; }
        public DbSet<ItileInputs> ItileInputs { get; set; }
        public DbSet<ResultInputs> ResultInputs { get; set; }
    }
}