using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RecursosHumanosAPI.Models;

public partial class RecursosHumanosDbContext : DbContext
{
    public RecursosHumanosDbContext()
    {
    }

    public RecursosHumanosDbContext(DbContextOptions<RecursosHumanosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beneficio> Beneficios { get; set; }

    public virtual DbSet<Capacitacion> Capacitacions { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Evaluacion> Evaluacions { get; set; }

    public virtual DbSet<Nomina> Nominas { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<Vacacion> Vacacions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=RecursosHumanosDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beneficio>(entity =>
        {
            entity.HasKey(e => e.BeneficioId).HasName("PK__Benefici__A02B32B1C8F673F8");

            entity.ToTable("Beneficio");

            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.Tipo).HasMaxLength(100);

            entity.HasOne(d => d.Empleado).WithMany(p => p.Beneficios)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__Beneficio__Emple__47DBAE45");
        });

        modelBuilder.Entity<Capacitacion>(entity =>
        {
            entity.HasKey(e => e.CapacitacionId).HasName("PK__Capacita__42816922D14E38CE");

            entity.ToTable("Capacitacion");

            entity.Property(e => e.NombreCurso).HasMaxLength(100);

            entity.HasOne(d => d.Empleado).WithMany(p => p.Capacitacions)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__Capacitac__Emple__44FF419A");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.DepartamentoId).HasName("PK__Departam__66BB0E3E1F27B05C");

            entity.ToTable("Departamento");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK__Empleado__958BE910844628F9");

            entity.ToTable("Empleado");

            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.Departamento).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.DepartamentoId)
                .HasConstraintName("FK__Empleado__Depart__3A81B327");

            entity.HasOne(d => d.Puesto).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.PuestoId)
                .HasConstraintName("FK__Empleado__Puesto__3B75D760");
        });

        modelBuilder.Entity<Evaluacion>(entity =>
        {
            entity.HasKey(e => e.EvaluacionId).HasName("PK__Evaluaci__99ABA7451251FE6A");

            entity.ToTable("Evaluacion");

            entity.Property(e => e.Comentarios).HasMaxLength(500);

            entity.HasOne(d => d.Empleado).WithMany(p => p.Evaluacions)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__Evaluacio__Emple__4222D4EF");
        });

        modelBuilder.Entity<Nomina>(entity =>
        {
            entity.HasKey(e => e.NominaId).HasName("PK__Nomina__33A37612DAA3392F");

            entity.ToTable("Nomina");

            entity.HasIndex(e => e.EmpleadoId, "UQ__Nomina__958BE9117835D3E3").IsUnique();

            entity.Property(e => e.Impuestos).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SalarioBruto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SalarioNeto).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Empleado).WithOne(p => p.Nomina)
                .HasForeignKey<Nomina>(d => d.EmpleadoId)
                .HasConstraintName("FK__Nomina__Empleado__3F466844");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.PuestoId).HasName("PK__Puesto__F7F6C6044CE6B6A4");

            entity.ToTable("Puesto");

            entity.Property(e => e.Salario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Titulo).HasMaxLength(100);
        });

        modelBuilder.Entity<Vacacion>(entity =>
        {
            entity.HasKey(e => e.VacacionId).HasName("PK__Vacacion__CEAEE9DADA1A8DE7");

            entity.ToTable("Vacacion");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Vacacions)
                .HasForeignKey(d => d.EmpleadoId)
                .HasConstraintName("FK__Vacacion__Emplea__4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
