namespace PruebaUnops.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("unops.INCIDENCIA")]
    public partial class INCIDENCIA
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_INCIDENCIA { get; set; }

        public int? ID_USUARIO { get; set; }

        public int? ID_CLASIFICACION { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_PRIORIDAD { get; set; }

        public int? ID_ESTADO { get; set; }

        [StringLength(200)]
        public string ASUNTO { get; set; }

        [StringLength(10)]
        public string HORAS { get; set; }

        public virtual CLASIFICACION CLASIFICACION { get; set; }

        public virtual ESTADO ESTADO { get; set; }

        public virtual PRIORIDAD PRIORIDAD { get; set; }

        public virtual USUARIO USUARIO { get; set; }
    }
}
