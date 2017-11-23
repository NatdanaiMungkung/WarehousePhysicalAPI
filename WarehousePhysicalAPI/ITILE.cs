namespace WarehousePhysicalAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ITILE : DbContext
    {
        public ITILE()
            : base("name=ITILE")
        {
        }

        public virtual DbSet<WMS_GESTIONE_UDC_PHYSICAL> WMS_GESTIONE_UDC_PHYSICAL { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WMS_GESTIONE_UDC_PHYSICAL>()
                .Property(e => e.HOLDING)
                .IsUnicode(false);

            modelBuilder.Entity<WMS_GESTIONE_UDC_PHYSICAL>()
                .Property(e => e.UDC)
                .IsUnicode(false);

            modelBuilder.Entity<WMS_GESTIONE_UDC_PHYSICAL>()
                .Property(e => e.AREA)
                .IsUnicode(false);

            modelBuilder.Entity<WMS_GESTIONE_UDC_PHYSICAL>()
                .Property(e => e.LOCAZIONE)
                .IsUnicode(false);

            modelBuilder.Entity<WMS_GESTIONE_UDC_PHYSICAL>()
                .Property(e => e.POSIZIONE)
                .IsUnicode(false);

            modelBuilder.Entity<WMS_GESTIONE_UDC_PHYSICAL>()
                .Property(e => e.STATO)
                .IsUnicode(false);

            modelBuilder.Entity<WMS_GESTIONE_UDC_PHYSICAL>()
                .Property(e => e.LOTTO)
                .IsUnicode(false);

            modelBuilder.Entity<WMS_GESTIONE_UDC_PHYSICAL>()
                .Property(e => e.ARTICOLO_CODICE)
                .IsUnicode(false);

            modelBuilder.Entity<WMS_GESTIONE_UDC_PHYSICAL>()
                .Property(e => e.ARTICOLO_DESCRIZIONE)
                .IsUnicode(false);

            modelBuilder.Entity<WMS_GESTIONE_UDC_PHYSICAL>()
                .Property(e => e.ARTICOLO)
                .IsUnicode(false);

            modelBuilder.Entity<WMS_GESTIONE_UDC_PHYSICAL>()
                .Property(e => e.QTA_PRINCIPALE)
                .HasPrecision(14, 4);

            modelBuilder.Entity<WMS_GESTIONE_UDC_PHYSICAL>()
                .Property(e => e.QTA_SECONDARIA)
                .HasPrecision(14, 4);

            modelBuilder.Entity<WMS_GESTIONE_UDC_PHYSICAL>()
                .Property(e => e.QTA_INIZIALE)
                .HasPrecision(12, 3);

            modelBuilder.Entity<WMS_GESTIONE_UDC_PHYSICAL>()
                .Property(e => e.QTA_INIZIALE_SECONDARIA)
                .HasPrecision(12, 3);

            modelBuilder.Entity<WMS_GESTIONE_UDC_PHYSICAL>()
                .Property(e => e.ATTRIBUTO_CODICE)
                .IsUnicode(false);

            modelBuilder.Entity<WMS_GESTIONE_UDC_PHYSICAL>()
                .Property(e => e.ATTRIBUTO_DESCRIZIONE)
                .IsUnicode(false);

            modelBuilder.Entity<WMS_GESTIONE_UDC_PHYSICAL>()
                .Property(e => e.ATTRIBUTO)
                .IsUnicode(false);

            modelBuilder.Entity<WMS_GESTIONE_UDC_PHYSICAL>()
                .Property(e => e.TAG)
                .IsUnicode(false);

            modelBuilder.Entity<WMS_GESTIONE_UDC_PHYSICAL>()
                .Property(e => e.UM_CUSTOM)
                .IsUnicode(false);

            modelBuilder.Entity<WMS_GESTIONE_UDC_PHYSICAL>()
                .Property(e => e.UDC_NOTE)
                .IsUnicode(false);

            modelBuilder.Entity<WMS_GESTIONE_UDC_PHYSICAL>()
                .Property(e => e.UM_ALTERNATIVE)
                .IsUnicode(false);
        }
    }
}
