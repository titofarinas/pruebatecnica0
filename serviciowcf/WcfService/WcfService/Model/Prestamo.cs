namespace WcfService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prestamo")]
    public partial class Prestamo
    {
        [Key]
        public int prestamo_id { get; set; }

        [StringLength(50)]
        public string tipo { get; set; }

        public int? cliente_id { get; set; }

        public DateTime? fecha_inicio { get; set; }

        public DateTime? fecha_fin { get; set; }

        public decimal? monto_solicitado { get; set; }

        [StringLength(10)]
        public string moneda { get; set; }

        public decimal? monto_aprobado { get; set; }

        public int? plazo_financiado { get; set; }

        public bool? estado { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
