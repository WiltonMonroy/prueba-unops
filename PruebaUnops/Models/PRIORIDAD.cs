namespace PruebaUnops.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("unops.PRIORIDAD")]
    public partial class PRIORIDAD
    {
        [Key]
        public int ID_PRIORIDAD { get; set; }

        [StringLength(200)]
        public string NOMBRE { get; set; }

        public virtual INCIDENCIA INCIDENCIA { get; set; }
    }
}
