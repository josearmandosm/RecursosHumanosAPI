using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecursosHumanosAPI.Migrations
{
    /// <inheritdoc />
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    public partial class migracioninicial : Migration
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.DepartamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Puesto",
                columns: table => new
                {
                    PuestoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puesto", x => x.PuestoId);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: true),
                    PuestoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.EmpleadoId);
                    table.ForeignKey(
                        name: "FK__Empleado__Depart__398D8EEE",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamento",
                        principalColumn: "DepartamentoId");
                    table.ForeignKey(
                        name: "FK__Empleado__Puesto__38996AB5",
                        column: x => x.PuestoId,
                        principalTable: "Puesto",
                        principalColumn: "PuestoId");
                });

            migrationBuilder.CreateTable(
                name: "Beneficio",
                columns: table => new
                {
                    BeneficioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: true),
                    Tipo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficio", x => x.BeneficioId);
                    table.ForeignKey(
                        name: "FK__Beneficio__Emple__3E52440B",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoId");
                });

            migrationBuilder.CreateTable(
                name: "Capacitacion",
                columns: table => new
                {
                    CapacitacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: true),
                    NombreCurso = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capacitacion", x => x.CapacitacionId);
                    table.ForeignKey(
                        name: "FK__Capacitac__Emple__3C34F16F",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoId");
                });

            migrationBuilder.CreateTable(
                name: "Evaluacion",
                columns: table => new
                {
                    EvaluacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: true),
                    FechaEvaluacion = table.Column<DateOnly>(type: "date", nullable: false),
                    Puntuacion = table.Column<int>(type: "int", nullable: false),
                    Comentarios = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluacion", x => x.EvaluacionId);
                    table.ForeignKey(
                        name: "FK__Evaluacio__Emple__3D5E1FD2",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoId");
                });

            migrationBuilder.CreateTable(
                name: "Nomina",
                columns: table => new
                {
                    NominaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: true),
                    SalarioBruto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Impuestos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalarioNeto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaPago = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nomina", x => x.NominaId);
                    table.ForeignKey(
                        name: "FK__Nomina__Empleado__3F466844",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoId");
                });

            migrationBuilder.CreateTable(
                name: "Vacacion",
                columns: table => new
                {
                    VacacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: true),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: false),
                    Aprobado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacacion", x => x.VacacionId);
                    table.ForeignKey(
                        name: "FK__Vacacion__Emplea__3A4CA8FD",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficio_EmpleadoId",
                table: "Beneficio",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Capacitacion_EmpleadoId",
                table: "Capacitacion",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_DepartamentoId",
                table: "Empleado",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_PuestoId",
                table: "Empleado",
                column: "PuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluacion_EmpleadoId",
                table: "Evaluacion",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Nomina_EmpleadoId",
                table: "Nomina",
                column: "EmpleadoId",
                unique: true,
                filter: "[EmpleadoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Vacacion_EmpleadoId",
                table: "Vacacion",
                column: "EmpleadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beneficio");

            migrationBuilder.DropTable(
                name: "Capacitacion");

            migrationBuilder.DropTable(
                name: "Evaluacion");

            migrationBuilder.DropTable(
                name: "Nomina");

            migrationBuilder.DropTable(
                name: "Vacacion");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Puesto");
        }
    }
}
