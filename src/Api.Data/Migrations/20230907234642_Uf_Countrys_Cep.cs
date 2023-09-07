using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class UfCountrysCep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Abbreviation = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uf", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodIBGE = table.Column<int>(type: "int", nullable: false),
                    UfId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_Uf_UfId",
                        column: x => x.UfId,
                        principalTable: "Uf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Cep = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Logradouro = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountryId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cep_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Uf",
                columns: new[] { "Id", "Abbreviation", "CreateAt", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"), "PB", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7269), "Paraíba", null },
                    { new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"), "PR", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7273), "Paraná", null },
                    { new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"), "AC", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7246), "Acre", null },
                    { new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"), "MG", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7264), "Minas Gerais", null },
                    { new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"), "MT", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7266), "Mato Grosso", null },
                    { new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"), "MS", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7265), "Mato Grosso do Sul", null },
                    { new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"), "AP", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7253), "Amapá", null },
                    { new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"), "RJ", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7275), "Rio de Janeiro", null },
                    { new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"), "RN", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7276), "Rio Grande do Norte", null },
                    { new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"), "MA", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7262), "Maranhão", null },
                    { new Guid("5abca453-d035-4766-a81b-9f73d683a54b"), "BA", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7255), "Bahia", null },
                    { new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"), "CE", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7256), "Ceará", null },
                    { new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"), "AL", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7250), "Alagoas", null },
                    { new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"), "GO", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7261), "Goiás", null },
                    { new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"), "PA", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7268), "Pará", null },
                    { new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"), "RS", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7280), "Rio Grande do Sul", null },
                    { new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"), "RO", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7278), "Rondônia", null },
                    { new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"), "TO", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7286), "Tocantins", null },
                    { new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"), "RR", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7279), "Roraima", null },
                    { new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"), "PE", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7271), "Pernambuco", null },
                    { new Guid("b81f95e0-f226-4afd-9763-290001637ed4"), "SC", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7282), "Santa Catarina", null },
                    { new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"), "DF", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7258), "Distrito Federal", null },
                    { new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"), "ES", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7260), "Espírito Santo", null },
                    { new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"), "AM", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7252), "Amazonas", null },
                    { new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"), "SP", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7284), "São Paulo", null },
                    { new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"), "PI", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7272), "Piauí", null },
                    { new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"), "SE", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7283), "Sergipe", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("683bb91f-d0f8-4579-9221-797f48cd2b07"), new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7121), "adm@email.com", "Administrator", new DateTime(2023, 9, 7, 23, 46, 42, 157, DateTimeKind.Utc).AddTicks(7126) });

            migrationBuilder.CreateIndex(
                name: "IX_Cep_Cep",
                table: "Cep",
                column: "Cep",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cep_CountryId",
                table: "Cep",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_CodIBGE",
                table: "Country",
                column: "CodIBGE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Country_UfId",
                table: "Country",
                column: "UfId");

            migrationBuilder.CreateIndex(
                name: "IX_Uf_Abbreviation",
                table: "Uf",
                column: "Abbreviation",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cep");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Uf");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("683bb91f-d0f8-4579-9221-797f48cd2b07"));
        }
    }
}
