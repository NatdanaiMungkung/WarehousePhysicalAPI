namespace WarehousePhysicalAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WMS_GESTIONE_UDC",Schema ="ITILE")]
    public partial class WMS_GESTIONE_UDC
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

        [StringLength(10)]
        public string STATO_COLORE { get; set; }

        public int? LOTTO_SERIAL { get; set; }

        [StringLength(14)]
        public string LOTTO { get; set; }

        [StringLength(14)]
        public string LOTTO_ESTERNO { get; set; }

        public int? STATO_QUALITATIVO { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(20)]
        public string ARTICOLO_CODICE { get; set; }

        [StringLength(1000)]
        public string ARTICOLO_DESCRIZIONE { get; set; }

        [StringLength(1025)]
        public string ARTICOLO { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CONFORMAZIONE_CODICE { get; set; }

        [StringLength(100)]
        public string CONFORMAZIONE { get; set; }

        public DateTime? SCADENZA { get; set; }

        public decimal? QTA_PRINCIPALE { get; set; }

        public decimal? QTA_SECONDARIA { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool QTA_SECONDARIA_VARIABILE { get; set; }

        public decimal? QTA_INIZIALE { get; set; }

        public decimal? QTA_INIZIALE_SECONDARIA { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(8)]
        public string ATTRIBUTO_CODICE { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string ATTRIBUTO_DESCRIZIONE { get; set; }

        [StringLength(63)]
        public string ATTRIBUTO { get; set; }

        [Key]
        [Column(Order = 9)]
        public DateTime DATA_CREAZIONE { get; set; }

        [StringLength(14)]
        public string PROPRIETARIO_CODICE { get; set; }

        [StringLength(1000)]
        public string PROPRIETARIO_DESC { get; set; }

        [StringLength(1019)]
        public string PROPRIETARIO { get; set; }

        [StringLength(14)]
        public string FORNITORE_CODICE { get; set; }

        [StringLength(1000)]
        public string FORNITORE_DESC { get; set; }

        [StringLength(1019)]
        public string FORNITORE { get; set; }

        [StringLength(14)]
        public string PRODUTTORE_CODICE { get; set; }

        [StringLength(1000)]
        public string PRODUTTORE_DESC { get; set; }

        [StringLength(1019)]
        public string PRODUTTORE { get; set; }

        [StringLength(4000)]
        public string TAG { get; set; }

        public bool? PRESENZA_MISSIONI_PENDENTI { get; set; }

        public bool? UDC_IN_AREA_VIRTUALE { get; set; }

        [StringLength(5)]
        public string UM_CUSTOM { get; set; }

        public bool? UDC_CLONE { get; set; }

        [StringLength(255)]
        public string UDC_NOTE { get; set; }
    }
}
