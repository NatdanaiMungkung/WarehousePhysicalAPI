namespace WarehousePhysicalAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITILE.WMS_GESTIONE_UDC_PHYSICAL")]
    public partial class WMS_GESTIONE_UDC_PHYSICAL
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string HOLDING { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short UDC_ANNO { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UDC_NUMERO { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short UDC_LIVELLO { get; set; }

        [StringLength(81)]
        public string UDC { get; set; }

        public int? AREA_CODICE { get; set; }

        [StringLength(20)]
        public string AREA { get; set; }

        public int? LOCAZIONE_CODICE { get; set; }

        [StringLength(56)]
        public string LOCAZIONE { get; set; }

        [StringLength(77)]
        public string POSIZIONE { get; set; }

        public int? STATO_CODICE { get; set; }

        [StringLength(50)]
        public string STATO { get; set; }

        [StringLength(14)]
        public string LOTTO { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(20)]
        public string ARTICOLO_CODICE { get; set; }

        [StringLength(1000)]
        public string ARTICOLO_DESCRIZIONE { get; set; }

        [StringLength(1025)]
        public string ARTICOLO { get; set; }

        public decimal? QTA_PRINCIPALE { get; set; }

        public decimal? QTA_SECONDARIA { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool QTA_SECONDARIA_VARIABILE { get; set; }

        public decimal? QTA_INIZIALE { get; set; }

        public decimal? QTA_INIZIALE_SECONDARIA { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(8)]
        public string ATTRIBUTO_CODICE { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string ATTRIBUTO_DESCRIZIONE { get; set; }

        [StringLength(63)]
        public string ATTRIBUTO { get; set; }

        [Key]
        [Column(Order = 8)]
        public DateTime DATA_CREAZIONE { get; set; }

        [StringLength(4000)]
        public string TAG { get; set; }

        [StringLength(5)]
        public string UM_CUSTOM { get; set; }

        [StringLength(255)]
        public string UDC_NOTE { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(3)]
        public string UM_ALTERNATIVE { get; set; }
    }
}
