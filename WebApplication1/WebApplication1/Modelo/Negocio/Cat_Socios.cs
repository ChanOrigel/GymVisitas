namespace WebApplication1.Modelo.Negocio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cat_Socios
    {
        [Key]
        [Column(Order = 0)]
        public int Socio_ID { get; set; }

        [StringLength(150)]
        public string Nombre { get; set; }

        [StringLength(10)]
        public string Codigo_Socio { get; set; }

        public int? Mensualidades_Pagadas { get; set; }

        public int? Visitas_Pagadas { get; set; }

        public DateTime? Fecha_Inicio_Mensualidad { get; set; }

        public DateTime? Fecha_Fin_Mensualidad { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime Fecha_Creo { get; set; }
    }
}
