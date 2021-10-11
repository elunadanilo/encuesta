using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Encuesta.Data
{
    public partial class DbEncuestaContext : DbContext
    {
        public DbEncuestaContext()
        {
        }

        public DbEncuestaContext(DbContextOptions<DbEncuestaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblEncuesta> TblEncuesta { get; set; }
        public virtual DbSet<TblListadoCampos> TblListadoCampos { get; set; }
        public virtual DbSet<TblRespuestas> TblRespuestas { get; set; }
        public virtual DbSet<TblUsuarios> TblUsuarios { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-4K9Q8J3\\SQLEXPRESS;Database=DbEncuesta;Integrated Security = true");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblEncuesta>(entity =>
            {
                entity.HasKey( e => e.IdEncuesta);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)  
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdEncuesta).HasDefaultValueSql("(newid())");

                entity.Property(e => e.NombreEncuesta)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblListadoCampos>(entity =>
            {
                entity.HasKey(e => e.IdListadoCampoEncuesta);

                entity.Property(e => e.Encuesta)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDeCampo)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRespuestas>(entity =>
            {
                entity.HasKey(e => e.IdRespuesta);

                entity.Property(e => e.IdListadoCampoEncuesta)
                    .IsRequired();

                entity.Property(e => e.Respuesta)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUsuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
