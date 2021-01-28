namespace PruebaUnops.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("unops.USUARIO")]
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            INCIDENCIA = new HashSet<INCIDENCIA>();
        }

        [Key]
        public int ID_USUARIO { get; set; }

        [StringLength(200)]
        public string NOMBRE { get; set; }

        public int? ID_PERFIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INCIDENCIA> INCIDENCIA { get; set; }

        public virtual PERFIL PERFIL { get; set; }
    }
}
