namespace WebApplication1.Modelo.Negocio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cat_Parametros
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Parametro_ID { get; set; }

        [StringLength(100)]
        public string Correo_Saliente { get; set; }

        [StringLength(100)]
        public string Servidor_Correo { get; set; }

        [StringLength(100)]
        public string Contrasenia_Correo { get; set; }

        public int? Puerto_Correo { get; set; }

        [StringLength(2)]
        public string Cifrar_Conexion { get; set; }

        [StringLength(100)]
        public string Correo_Destino { get; set; }

        [StringLength(100)]
        public string Impresora { get; set; }

        [StringLength(100)]
        public string Correo_Empleado { get; set; }

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
