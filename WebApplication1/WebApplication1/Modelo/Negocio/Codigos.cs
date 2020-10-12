namespace WebApplication1.Modelo.Negocio
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Codigos
    {
        [Key]
        [StringLength(3)]
        public string CodigoID { get; set; }

        [Required]
        [StringLength(50)]
        public string Dia { get; set; }

        [Required]
        [StringLength(20)]
        public string Hora { get; set; }
    }
}
