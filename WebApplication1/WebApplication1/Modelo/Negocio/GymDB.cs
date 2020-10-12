namespace WebApplication1.Modelo.Negocio
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GymDB : DbContext
    {
        public GymDB()
            : base("name=GymDB")
        {
        }

        public virtual DbSet<Codigos> Codigos { get; set; }
        public virtual DbSet<Horarios> Horarios { get; set; }
        public virtual DbSet<Cat_Parametros> Cat_Parametros { get; set; }
        public virtual DbSet<Cat_Precios> Cat_Precios { get; set; }
        public virtual DbSet<Cat_Socios> Cat_Socios { get; set; }
        public virtual DbSet<Cat_Usuarios> Cat_Usuarios { get; set; }
        public virtual DbSet<Ope_Lista_Negra> Ope_Lista_Negra { get; set; }
        public virtual DbSet<Ope_Pagos> Ope_Pagos { get; set; }
        public virtual DbSet<Ope_Visitas_Diarias> Ope_Visitas_Diarias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Codigos>()
                .Property(e => e.CodigoID)
                .IsUnicode(false);

            modelBuilder.Entity<Codigos>()
                .Property(e => e.Dia)
                .IsUnicode(false);

            modelBuilder.Entity<Codigos>()
                .Property(e => e.Hora)
                .IsUnicode(false);

            modelBuilder.Entity<Horarios>()
                .Property(e => e.CodigoID)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Parametros>()
                .Property(e => e.Correo_Saliente)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Parametros>()
                .Property(e => e.Servidor_Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Parametros>()
                .Property(e => e.Contrasenia_Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Parametros>()
                .Property(e => e.Cifrar_Conexion)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Parametros>()
                .Property(e => e.Correo_Destino)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Parametros>()
                .Property(e => e.Impresora)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Parametros>()
                .Property(e => e.Correo_Empleado)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Parametros>()
                .Property(e => e.Usuario_Creo)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Parametros>()
                .Property(e => e.Usuario_Modifico)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Precios>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Precios>()
                .Property(e => e.Checar)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Socios>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Socios>()
                .Property(e => e.Codigo_Socio)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Usuarios>()
                .Property(e => e.Usuario_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Usuarios>()
                .Property(e => e.Identificador)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Usuarios>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Usuarios>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Usuarios>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Usuarios>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Usuarios>()
                .Property(e => e.Estatus)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Usuarios>()
                .Property(e => e.Usuario_Creo)
                .IsUnicode(false);

            modelBuilder.Entity<Cat_Usuarios>()
                .Property(e => e.Usuario_Modifico)
                .IsUnicode(false);

            modelBuilder.Entity<Ope_Pagos>()
                .Property(e => e.Codigo_Socio)
                .IsUnicode(false);

            modelBuilder.Entity<Ope_Pagos>()
                .Property(e => e.Motivo)
                .IsUnicode(false);

            modelBuilder.Entity<Ope_Visitas_Diarias>()
                .Property(e => e.Codigo_Socio)
                .IsUnicode(false);

            modelBuilder.Entity<Ope_Visitas_Diarias>()
                .Property(e => e.Motivo)
                .IsUnicode(false);
        }
    }
}
