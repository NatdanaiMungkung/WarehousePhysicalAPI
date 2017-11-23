namespace WarehousePhysicalAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITILE.T_ARTICOLI_CONF_FLAT")]
    public partial class T_ARTICOLI_CONF_FLAT
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string ACF_HOL_CODICE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string ACF_AR_CODICE { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ACF_CONF { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ACF_PROG { get; set; }

        public decimal ACF_QTA_UM_BASE { get; set; }

        [Required]
        [StringLength(3)]
        public string ACF_UM_ALTERNATIVA { get; set; }

        public decimal ACF_QTA_UM_ALT { get; set; }

        [StringLength(20)]
        public string ACF_RIF_ESTERNO { get; set; }

        [Required]
        [StringLength(1)]
        public string ACF_RIF_TIPO { get; set; }

        public bool ACF_OBSO { get; set; }

        [StringLength(20)]
        public string ACF_IMB_CODICE { get; set; }

        public bool ACF_IS_STOCK { get; set; }

        [StringLength(14)]
        public string ACF_EAN { get; set; }
    }
}
