namespace WebApplication1.Modelo.Negocio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ope_Lista_Negra
    {
        [Key]
        public int Lista_ID { get; set; }

        [StringLength(100)]
        public string Nombre_Socio { get; set; }

        public int? Codigo_Socio { get; set; }

        public DateTime? Fecha_Creo { get; set; }
    }
}
