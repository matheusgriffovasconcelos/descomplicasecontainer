using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DescomplicaseApp.Migrations
{
    /// <inheritdoc />
    public partial class v6orcamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Orcamentos_OrcamentoModelId",
                table: "Fornecedores");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedores_OrcamentoModelId",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "IdFornecedor",
                table: "Orcamentos");

            migrationBuilder.DropColumn(
                name: "OrcamentoModelId",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "ValorIndividual",
                table: "Fornecedores");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$T7YAw.GAq48D9XtFtaziAOS9huoEpbHh09yQGYwJw05/FdsD/NQhy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdFornecedor",
                table: "Orcamentos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrcamentoModelId",
                table: "Fornecedores",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ValorIndividual",
                table: "Fornecedores",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$aHlmJs8s.ufcA6ShpDGd.uh44/3k4aXtwOGxc6Okb20lF4sfFC2Km");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_OrcamentoModelId",
                table: "Fornecedores",
                column: "OrcamentoModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Orcamentos_OrcamentoModelId",
                table: "Fornecedores",
                column: "OrcamentoModelId",
                principalTable: "Orcamentos",
                principalColumn: "Id");
        }
    }
}
