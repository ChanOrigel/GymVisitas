namespace WebApplication1.Modelo.Negocio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Horarios
    {
        [Key]
        public int HorarioID { get; set; }

        public int Socio_ID { get; set; }

        [Required]
        [StringLength(3)]
        public string CodigoID { get; set; }

        public DateTime? Fecha_Creo { get; set; }
    }
}
