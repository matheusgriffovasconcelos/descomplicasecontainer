using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DescomplicaseApp.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telefone = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    Cidade = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    UF = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    Bairro = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    RuaNumero = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    IdCategoria = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fornecedores_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$EsttmxnEcgSo2AF.I6aCkOZH9MA6v3KBqxwUs/JUSmCesf2KF5TcK");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_IdCategoria",
                table: "Fornecedores",
                column: "IdCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$CxrRA3mCsEBGP7jAWzy5aOaAodq/rM7/.gxk01piQwt8gB8rQgwk2");
        }
    }
}
