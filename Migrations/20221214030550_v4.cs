using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DescomplicaseApp.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentos_Usuarios_IdUsuario",
                table: "Orcamentos");

            migrationBuilder.DropIndex(
                name: "IX_Orcamentos_IdUsuario",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Orcamentos");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$evZoYUV4fQQhtmKjaiqaousTQZwR8PVxehm0vfsUSy00wZ2lAoR5i");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Orcamentos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$4FTl7.wA9sdweMvmxwh71.Ym62x5ACDZcvWKG2sP7PCgST2FHbMZO");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentos_IdUsuario",
                table: "Orcamentos",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamentos_Usuarios_IdUsuario",
                table: "Orcamentos",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
