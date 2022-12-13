using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DescomplicaseApp.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idFornecedor",
                table: "Orcamentos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$rQim7WiL17jjfrRLF3KiDeLX4YBbzv58Ax9C.Yw.mTYg7vMb7u.yC");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentos_idFornecedor",
                table: "Orcamentos",
                column: "idFornecedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamentos_Fornecedores_idFornecedor",
                table: "Orcamentos",
                column: "idFornecedor",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentos_Fornecedores_idFornecedor",
                table: "Orcamentos");

            migrationBuilder.DropIndex(
                name: "IX_Orcamentos_idFornecedor",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "idFornecedor",
                table: "Orcamentos");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$T7YAw.GAq48D9XtFtaziAOS9huoEpbHh09yQGYwJw05/FdsD/NQhy");
        }
    }
}
