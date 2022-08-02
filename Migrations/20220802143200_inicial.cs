using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ganancias",
                columns: table => new
                {
                    GananciaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    montoJugado = table.Column<double>(type: "REAL", nullable: false),
                    Totalganancias = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ganancias", x => x.GananciaId);
                });

            migrationBuilder.CreateTable(
                name: "Jugadas",
                columns: table => new
                {
                    JugadaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Monto = table.Column<double>(type: "REAL", nullable: false),
                    LoteriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoJugadaId = table.Column<int>(type: "INTEGER", nullable: false),
                    NombreLoteria = table.Column<string>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    MontoGanancia = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadas", x => x.JugadaId);
                });

            migrationBuilder.CreateTable(
                name: "Loterias",
                columns: table => new
                {
                    LoteriaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loterias", x => x.LoteriaId);
                });

            migrationBuilder.CreateTable(
                name: "tipoJugada",
                columns: table => new
                {
                    TipoJugadaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LoteriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    NombreJugada = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoJugada", x => x.TipoJugadaId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GananciaDetalle",
                columns: table => new
                {
                    GananciaDetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GananciaId = table.Column<int>(type: "INTEGER", nullable: false),
                    JugadaId = table.Column<int>(type: "INTEGER", nullable: false),
                    LoteriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoJugadaId = table.Column<int>(type: "INTEGER", nullable: false),
                    NombreLoteria = table.Column<string>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Montojugado = table.Column<double>(type: "REAL", nullable: false),
                    MontoGanancia = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GananciaDetalle", x => x.GananciaDetalleId);
                    table.ForeignKey(
                        name: "FK_GananciaDetalle_Ganancias_GananciaId",
                        column: x => x.GananciaId,
                        principalTable: "Ganancias",
                        principalColumn: "GananciaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JugadaDetalle",
                columns: table => new
                {
                    JugadaDetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JugadaId = table.Column<int>(type: "INTEGER", nullable: false),
                    GananciaId = table.Column<int>(type: "INTEGER", nullable: false),
                    LoteriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoJugadaId = table.Column<int>(type: "INTEGER", nullable: false),
                    NombreLoteria = table.Column<string>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Monto = table.Column<double>(type: "REAL", nullable: false),
                    MontoGanancia = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JugadaDetalle", x => x.JugadaDetalleId);
                    table.ForeignKey(
                        name: "FK_JugadaDetalle_Ganancias_GananciaId",
                        column: x => x.GananciaId,
                        principalTable: "Ganancias",
                        principalColumn: "GananciaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JugadaDetalle_Jugadas_JugadaId",
                        column: x => x.JugadaId,
                        principalTable: "Jugadas",
                        principalColumn: "JugadaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "Nombre" },
                values: new object[] { 1, "Leidsa" });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "Nombre" },
                values: new object[] { 2, "Loteria Real" });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "Nombre" },
                values: new object[] { 3, "Loteka" });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "Nombre" },
                values: new object[] { 4, "Americana" });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "Nombre" },
                values: new object[] { 5, "La Suerte" });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "Nombre" },
                values: new object[] { 6, "Primera" });

            migrationBuilder.InsertData(
                table: "Loterias",
                columns: new[] { "LoteriaId", "Nombre" },
                values: new object[] { 7, "Loteria Nacional" });

            migrationBuilder.InsertData(
                table: "tipoJugada",
                columns: new[] { "TipoJugadaId", "LoteriaId", "NombreJugada" },
                values: new object[] { 1, 0, "Loto" });

            migrationBuilder.InsertData(
                table: "tipoJugada",
                columns: new[] { "TipoJugadaId", "LoteriaId", "NombreJugada" },
                values: new object[] { 2, 0, "Loto Pool" });

            migrationBuilder.InsertData(
                table: "tipoJugada",
                columns: new[] { "TipoJugadaId", "LoteriaId", "NombreJugada" },
                values: new object[] { 3, 0, "Quiniela Pale" });

            migrationBuilder.InsertData(
                table: "tipoJugada",
                columns: new[] { "TipoJugadaId", "LoteriaId", "NombreJugada" },
                values: new object[] { 4, 0, "Super Kino" });

            migrationBuilder.InsertData(
                table: "tipoJugada",
                columns: new[] { "TipoJugadaId", "LoteriaId", "NombreJugada" },
                values: new object[] { 5, 0, "Tripleta" });

            migrationBuilder.InsertData(
                table: "tipoJugada",
                columns: new[] { "TipoJugadaId", "LoteriaId", "NombreJugada" },
                values: new object[] { 6, 0, "Pega Mas" });

            migrationBuilder.InsertData(
                table: "tipoJugada",
                columns: new[] { "TipoJugadaId", "LoteriaId", "NombreJugada" },
                values: new object[] { 7, 0, "Quiniela" });

            migrationBuilder.InsertData(
                table: "tipoJugada",
                columns: new[] { "TipoJugadaId", "LoteriaId", "NombreJugada" },
                values: new object[] { 8, 0, "Pale" });

            migrationBuilder.InsertData(
                table: "tipoJugada",
                columns: new[] { "TipoJugadaId", "LoteriaId", "NombreJugada" },
                values: new object[] { 9, 0, "Pega 3 Mas" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GananciaDetalle_GananciaId",
                table: "GananciaDetalle",
                column: "GananciaId");

            migrationBuilder.CreateIndex(
                name: "IX_JugadaDetalle_GananciaId",
                table: "JugadaDetalle",
                column: "GananciaId");

            migrationBuilder.CreateIndex(
                name: "IX_JugadaDetalle_JugadaId",
                table: "JugadaDetalle",
                column: "JugadaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "GananciaDetalle");

            migrationBuilder.DropTable(
                name: "JugadaDetalle");

            migrationBuilder.DropTable(
                name: "Loterias");

            migrationBuilder.DropTable(
                name: "tipoJugada");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Ganancias");

            migrationBuilder.DropTable(
                name: "Jugadas");
        }
    }
}
