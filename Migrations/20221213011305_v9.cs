using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DescomplicaseApp.Migrations
{
    /// <inheritdoc />
    public partial class v9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcamentos_Fornecedores_FornecedorId",
                table: "Orcamentos");

            migrationBuilder.DropIndex(
                name: "IX_Orcamentos_FornecedorId",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "Orcamentos");

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
                value: "$2a$10$CDxlcPxWuXQI23/Mn6aCrebGhSKtJH4Gfk4dB5Bpv7VotDZEJ/yZu");

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

            migrationBuilder.AddColumn<int>(
                name: "FornecedorId",
                table: "Orcamentos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$oF66B1.Q8BHkRDCYtRNPWeqIj2xjlLgLpGpGlUxLO6xc9nsfhIlbi");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentos_FornecedorId",
                table: "Orcamentos",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orcamentos_Fornecedores_FornecedorId",
                table: "Orcamentos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id");
        }
    }
}
