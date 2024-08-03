namespace WcfService.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            Prestamo = new HashSet<Prestamo>();
        }

        [Key]
        public int cliente_id { get; set; }

        [StringLength(50)]
        public string numero_identificacion { get; set; }

        [StringLength(50)]
        public string tipo_identificacion { get; set; }

        [StringLength(50)]
        public string primer_nombre { get; set; }

        [StringLength(50)]
        public string segundo_nombre { get; set; }

        [StringLength(50)]
        public string primer_apellido { get; set; }

        [StringLength(50)]
        public string segundo_apellido { get; set; }

        public int? direccion_id { get; set; }

        public bool? estado { get; set; }

        public virtual Direccion Direccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prestamo> Prestamo { get; set; }
    }
}
