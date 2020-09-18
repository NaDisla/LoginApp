using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LoginAPI.Models
{
    public partial class DB_LoginAppContext : DbContext
    {
        public DB_LoginAppContext()
        {
        }

        public DB_LoginAppContext(DbContextOptions<DB_LoginAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TareasClientes> TareasClientes { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // #warning directive
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=NDISLA-PC;Database=DB_LoginApp;Trusted_Connection=True;");
#pragma warning restore CS1030 // #warning directive
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.CliId)
                    .HasName("PK__Clientes__83531C5A34BEC19D");

                entity.Property(e => e.CliId).HasColumnName("Cli_ID");

                entity.Property(e => e.CliApellidos)
                    .IsRequired()
                    .HasColumnName("Cli_Apellidos")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.CliCelular)
                    .IsRequired()
                    .HasColumnName("Cli_Celular")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CliCorreo)
                    .IsRequired()
                    .HasColumnName("Cli_Correo")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.CliDireccion)
                    .IsRequired()
                    .HasColumnName("Cli_Direccion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CliEstatus)
                    .HasColumnName("Cli_Estatus")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ACTIVO')");

                entity.Property(e => e.CliGenero)
                    .IsRequired()
                    .HasColumnName("Cli_Genero")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CliNombres)
                    .IsRequired()
                    .HasColumnName("Cli_Nombres")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.CliTelFijo)
                    .IsRequired()
                    .HasColumnName("Cli_TelFijo")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UsuId).HasColumnName("Usu_ID");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.UsuId)
                    .HasConstraintName("FK_CliUsuario");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RolId)
                    .HasName("PK__Roles__795EBD6985EF0C69");

                entity.Property(e => e.RolId).HasColumnName("Rol_ID");

                entity.Property(e => e.RolNombre)
                    .IsRequired()
                    .HasColumnName("Rol_Nombre")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TareasClientes>(entity =>
            {
                entity.HasKey(e => e.TarCliId)
                    .HasName("PK__TareasCl__9B6053EBDB7B73BA");

                entity.Property(e => e.TarCliId).HasColumnName("TarCli_ID");

                entity.Property(e => e.CliId).HasColumnName("Cli_ID");

                entity.Property(e => e.TarCliDescripcion)
                    .IsRequired()
                    .HasColumnName("TarCli_Descripcion")
                    .IsUnicode(false);

                entity.Property(e => e.TarCliEstatus)
                    .HasColumnName("TarCli_Estatus")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ACTIVA')");

                entity.Property(e => e.TarCliFechaCreacion)
                    .HasColumnName("TarCli_FechaCreacion")
                    .HasColumnType("date");

                entity.Property(e => e.TarCliNombre)
                    .IsRequired()
                    .HasColumnName("TarCli_Nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cli)
                    .WithMany(p => p.TareasClientes)
                    .HasForeignKey(d => d.CliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TarCliente");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsuId)
                    .HasName("PK__Usuarios__B6173FEBAD5FF1D5");

                entity.Property(e => e.UsuId).HasColumnName("Usu_ID");

                entity.Property(e => e.RolId).HasColumnName("Rol_ID");

                entity.Property(e => e.UsuClave)
                    .IsRequired()
                    .HasColumnName("Usu_Clave")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UsuNombre)
                    .IsRequired()
                    .HasColumnName("Usu_Nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UsuNombreReal)
                    .IsRequired()
                    .HasColumnName("Usu_NombreReal")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolUsuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
