namespace PruebaUnops.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("unops.CLASIFICACION")]
    public partial class CLASIFICACION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLASIFICACION()
        {
            INCIDENCIA = new HashSet<INCIDENCIA>();
        }

        [Key]
        public int ID_CLASIFICACION { get; set; }

        [StringLength(200)]
        public string NOMBRE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INCIDENCIA> INCIDENCIA { get; set; }
    }
}
