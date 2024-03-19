using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace pharma_izi.core.infrastructure.Database;

public partial class PharmaIziContext : DbContext
{
    public PharmaIziContext()
    {
    }

    public PharmaIziContext(DbContextOptions<PharmaIziContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriaMedicamento> CategoriaMedicamentos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<CodigosQr> CodigosQrs { get; set; }

    public virtual DbSet<DetalleMedicina> DetalleMedicinas { get; set; }

    public virtual DbSet<Doctore> Doctores { get; set; }

    public virtual DbSet<EstadoPedido> EstadoPedidos { get; set; }

    public virtual DbSet<MarcaMedicamento> MarcaMedicamentos { get; set; }

    public virtual DbSet<Medicamento> Medicamentos { get; set; }

    public virtual DbSet<MedicinaReceta> MedicinaRecetas { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Receta> Recetas { get; set; }

    public virtual DbSet<TemplatesReceta> TemplatesRecetas { get; set; }

    public virtual DbSet<TipoIva> TipoIvas { get; set; }

    public virtual DbSet<TiposPago> TiposPagos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=146.190.160.237,1401; Database=pharma-izi; TrustServerCertificate=True; User=sa; Password=Kali123!");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriaMedicamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categoria_medicamento_PK");

            entity.ToTable("categoria_medicamento");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("nombre");
            entity.Property(e => e.TipoMedicamento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("tipo_medicamento");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clientes_PK");

            entity.ToTable("clientes");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("apellido");
            entity.Property(e => e.Cedula)
                .HasMaxLength(10)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("cedula");
            entity.Property(e => e.Celular)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("celular");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("email");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("password");
        });

        modelBuilder.Entity<CodigosQr>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("codigos_qr_PK");

            entity.ToTable("codigos_qr");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FechaEscaneo)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("fecha_escaneo");
            entity.Property(e => e.Valor)
                .HasMaxLength(512)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("valor");
        });

        modelBuilder.Entity<DetalleMedicina>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("detalle_medicina_PK");

            entity.ToTable("detalle_medicina");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("descripcion");
            entity.Property(e => e.IdMedicinaReceta).HasColumnName("id_medicina_receta");

            entity.HasOne(d => d.IdMedicinaRecetaNavigation).WithMany(p => p.DetalleMedicinas)
                .HasForeignKey(d => d.IdMedicinaReceta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detalle_medicina_FK");
        });

        modelBuilder.Entity<Doctore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("doctores_PK");

            entity.ToTable("doctores");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("apellido");
            entity.Property(e => e.Celular)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("celular");
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("email");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.IdTemplateReceta).HasColumnName("id_template_receta");
            entity.Property(e => e.Nombre)
                .HasMaxLength(128)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("nombre");
            entity.Property(e => e.NombreConsultorio)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("nombre_consultorio");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("password");

            entity.HasOne(d => d.IdTemplateRecetaNavigation).WithMany(p => p.Doctores)
                .HasForeignKey(d => d.IdTemplateReceta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("doctores_FK");
        });

        modelBuilder.Entity<EstadoPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("estado_pedido_PK");

            entity.ToTable("estado_pedido");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<MarcaMedicamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("marca_medicamento_PK");

            entity.ToTable("marca_medicamento");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("medicamentos_PK");

            entity.ToTable("medicamentos");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.EnStock).HasColumnName("en_stock");
            entity.Property(e => e.FotoMedicamento)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("foto_medicamento");
            entity.Property(e => e.IdCategoriaMedicamento).HasColumnName("id_categoria_medicamento");
            entity.Property(e => e.IdMarcaMedicamento).HasColumnName("id_marca_medicamento");
            entity.Property(e => e.IdTipoIva).HasColumnName("id_tipo_iva");
            entity.Property(e => e.Nombre)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("nombre");
            entity.Property(e => e.RequiereReceta).HasColumnName("requiere_receta");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("valor");

            entity.HasOne(d => d.IdCategoriaMedicamentoNavigation).WithMany(p => p.Medicamentos)
                .HasForeignKey(d => d.IdCategoriaMedicamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicamentos_FK");

            entity.HasOne(d => d.IdMarcaMedicamentoNavigation).WithMany(p => p.Medicamentos)
                .HasForeignKey(d => d.IdMarcaMedicamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicamentos_FK_2");

            entity.HasOne(d => d.IdTipoIvaNavigation).WithMany(p => p.Medicamentos)
                .HasForeignKey(d => d.IdTipoIva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicamentos_FK_1");
        });

        modelBuilder.Entity<MedicinaReceta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("medicina_recetas_PK");

            entity.ToTable("medicina_recetas");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdMedicina).HasColumnName("id_medicina");
            entity.Property(e => e.IdReceta).HasColumnName("id_receta");
            entity.Property(e => e.IdTipoIva).HasColumnName("id_tipo_iva");
            entity.Property(e => e.RequiereReceta).HasColumnName("requiere_receta");

            entity.HasOne(d => d.IdMedicinaNavigation).WithMany(p => p.MedicinaReceta)
                .HasForeignKey(d => d.IdMedicina)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicina_recetas_FK_2");

            entity.HasOne(d => d.IdRecetaNavigation).WithMany(p => p.MedicinaReceta)
                .HasForeignKey(d => d.IdReceta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicina_recetas_FK_1");

            entity.HasOne(d => d.IdTipoIvaNavigation).WithMany(p => p.MedicinaReceta)
                .HasForeignKey(d => d.IdTipoIva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("medicina_recetas_FK");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pagos_PK");

            entity.ToTable("pagos");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Evidencia)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("evidencia");
            entity.Property(e => e.IdTipoPago).HasColumnName("id_tipo_pago");
            entity.Property(e => e.Nombre)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("nombre");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("valor");

            entity.HasOne(d => d.IdTipoPagoNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdTipoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pagos_FK");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pedidos_PK");

            entity.ToTable("pedidos");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FechaEntrega)
                .HasColumnType("datetime")
                .HasColumnName("fecha_entrega");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.IdEstadoPedido).HasColumnName("id_estado_pedido");
            entity.Property(e => e.IdPago).HasColumnName("id_pago");
            entity.Property(e => e.IdReceta).HasColumnName("id_receta");

            entity.HasOne(d => d.IdEstadoPedidoNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdEstadoPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pedidos_FK");

            entity.HasOne(d => d.IdPagoNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pedidos_pagos_FK_1");

            entity.HasOne(d => d.IdRecetaNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdReceta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pedidos_FK_1");
        });

        modelBuilder.Entity<Receta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recetas_PK");

            entity.ToTable("recetas");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdCodigoQr).HasColumnName("id_codigo_qr");
            entity.Property(e => e.IdDoctor).HasColumnName("id_doctor");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Receta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recetas_FK_1");

            entity.HasOne(d => d.IdCodigoQrNavigation).WithMany(p => p.Receta)
                .HasForeignKey(d => d.IdCodigoQr)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recetas_FK_3");

            entity.HasOne(d => d.IdDoctorNavigation).WithMany(p => p.Receta)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recetas_FK");
        });

        modelBuilder.Entity<TemplatesReceta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("templates__recetas_PK");

            entity.ToTable("templates__recetas");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Ruta)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("ruta");
        });

        modelBuilder.Entity<TipoIva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipo_iva_PK");

            entity.ToTable("tipo_iva");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("nombre");
            entity.Property(e => e.Valor)
                .HasColumnType("decimal(38, 0)")
                .HasColumnName("valor");
        });

        modelBuilder.Entity<TiposPago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipos_pagos_PK");

            entity.ToTable("tipos_pagos");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(256)
                .IsUnicode(false)
                .UseCollation("Modern_Spanish_CI_AS")
                .HasColumnName("descripcion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
