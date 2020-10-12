namespace WebApplication1.Modelo.Negocio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cat_Precios
    {
        [Key]
        public int Precio_ID { get; set; }

        [StringLength(150)]
        public string Descripcion { get; set; }

        public decimal? Monto { get; set; }

        public int? Unidades { get; set; }

        [StringLength(5)]
        public string Checar { get; set; }

        public DateTime? Fecha_Modificacion { get; set; }
    }
}
