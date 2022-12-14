using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DescomplicaseApp.Migrations
{
    /// <inheritdoc />
    public partial class v6semfkoracamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: "$2a$10$q86Z51G.wIE1YvICoEGOVOc/tyagknoTMyQFV7RJcZ3OtVnKo1ylq");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: "$2a$10$evZoYUV4fQQhtmKjaiqaousTQZwR8PVxehm0vfsUSy00wZ2lAoR5i");

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
    }
}
