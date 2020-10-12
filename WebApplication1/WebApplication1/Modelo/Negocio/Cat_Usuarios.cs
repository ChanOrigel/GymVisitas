namespace WebApplication1.Modelo.Negocio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cat_Usuarios
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string Usuario_ID { get; set; }

        [StringLength(3)]
        public string Identificador { get; set; }

        [StringLength(250)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(20)]
        public string Tipo { get; set; }

        [StringLength(30)]
        public string Estatus { get; set; }

        [StringLength(100)]
        public string Usuario_Creo { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime Fecha_Creo { get; set; }

        [StringLength(100)]
        public string Usuario_Modifico { get; set; }

        public DateTime? Fecha_Modifico { get; set; }
    }
}
