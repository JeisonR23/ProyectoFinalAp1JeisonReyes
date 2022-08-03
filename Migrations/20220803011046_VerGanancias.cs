using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class VerGanancias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        CREATE VIEW View_Ganancias
        AS
         SELECT  l.Nombre,SUM(MontoGanancia) AS Ganancia
         from GananciaDetalle g 
         INNER JOIN Loterias l on g.LoteriaId = l.LoteriaId
         GROUP BY l.Nombre
        ");

        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW View_Ganancias");
        }
    }


}
