namespace WebApplication1.Modelo.Negocio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ope_Visitas_Diarias
    {
        [Key]
        [Column(Order = 0)]
        public int Visita_Diaria_ID { get; set; }

        [StringLength(10)]
        public string Codigo_Socio { get; set; }

        [StringLength(50)]
        public string Motivo { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime Fecha_Creo { get; set; }
    }
}
