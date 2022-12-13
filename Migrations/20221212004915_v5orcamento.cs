using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DescomplicaseApp.Migrations
{
    /// <inheritdoc />
    public partial class v5orcamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "RuaNumero",
                table: "Fornecedores");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCasamento",
                table: "Usuarios",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NomeConjuge",
                table: "Usuarios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SobreNome",
                table: "Usuarios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Caracteristicas",
                table: "Fornecedores",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPremium",
                table: "Fornecedores",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddColumn<double>(
                name: "ValorPessoa",
                table: "Fornecedores",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorTotal",
                table: "Fornecedores",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "aPartir",
                table: "Fornecedores",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Orcamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdFornecedor = table.Column<int>(type: "INTEGER", nullable: false),
                    IdUsuario = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorDesejado = table.Column<double>(type: "REAL", nullable: false),
                    NumConvidados = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorOrcamento = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orcamentos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                columns: new[] { "DataCasamento", "NomeConjuge", "Senha", "SobreNome" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "$2a$10$aHlmJs8s.ufcA6ShpDGd.uh44/3k4aXtwOGxc6Okb20lF4sfFC2Km", null });

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_OrcamentoModelId",
                table: "Fornecedores",
                column: "OrcamentoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamentos_IdUsuario",
                table: "Orcamentos",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Orcamentos_OrcamentoModelId",
                table: "Fornecedores",
                column: "OrcamentoModelId",
                principalTable: "Orcamentos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Orcamentos_OrcamentoModelId",
                table: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Orcamentos");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedores_OrcamentoModelId",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "DataCasamento",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "NomeConjuge",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "SobreNome",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Caracteristicas",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "IsPremium",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "OrcamentoModelId",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "ValorIndividual",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "ValorPessoa",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "aPartir",
                table: "Fornecedores");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Fornecedores",
                type: "TEXT",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuaNumero",
                table: "Fornecedores",
                type: "TEXT",
                maxLength: 64,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$MB9gJrjmxilMcItpXcftZu0XQP8T/0r97FvwbSc4TE7iwa2lRQ7Ua");
        }
    }
}
