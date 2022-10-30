using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EFCoreSample.Persistence.PostgreSql.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alphabets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Characters = table.Column<string>(type: "text", nullable: false),
                    Script = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alphabets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataGrids",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Row = table.Column<int>(type: "integer", nullable: false),
                    Column = table.Column<int>(type: "integer", nullable: false),
                    Size = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataGrids", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RowMovement = table.Column<int>(type: "integer", nullable: false),
                    ColumnMovement = table.Column<int>(type: "integer", nullable: false),
                    Layout = table.Column<string>(type: "text", nullable: false),
                    DirectionType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WordSets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Words = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharactersOnGrid",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: false),
                    AlphabetId = table.Column<long>(type: "bigint", nullable: false),
                    DataGridId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharactersOnGrid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharactersOnGrid_Alphabets_AlphabetId",
                        column: x => x.AlphabetId,
                        principalTable: "Alphabets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharactersOnGrid_DataGrids_DataGridId",
                        column: x => x.DataGridId,
                        principalTable: "DataGrids",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WordsOnGrid",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: false),
                    WordSetId = table.Column<long>(type: "bigint", nullable: false),
                    DirectionId = table.Column<long>(type: "bigint", nullable: false),
                    DataGridId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordsOnGrid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordsOnGrid_DataGrids_DataGridId",
                        column: x => x.DataGridId,
                        principalTable: "DataGrids",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WordsOnGrid_Directions_DirectionId",
                        column: x => x.DirectionId,
                        principalTable: "Directions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WordsOnGrid_WordSets_WordSetId",
                        column: x => x.WordSetId,
                        principalTable: "WordSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alphabets",
                columns: new[] { "Id", "Characters", "Script" },
                values: new object[,]
                {
                    { 1L, "abcdefghijklmnopqrstuvwxyz", "latin" },
                    { 2L, "абвгдеёжзийклмнопрстуфхцчшщъыьэюя", "cyrillic" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharactersOnGrid_AlphabetId",
                table: "CharactersOnGrid",
                column: "AlphabetId");

            migrationBuilder.CreateIndex(
                name: "IX_CharactersOnGrid_DataGridId",
                table: "CharactersOnGrid",
                column: "DataGridId");

            migrationBuilder.CreateIndex(
                name: "IX_WordsOnGrid_DataGridId",
                table: "WordsOnGrid",
                column: "DataGridId");

            migrationBuilder.CreateIndex(
                name: "IX_WordsOnGrid_DirectionId",
                table: "WordsOnGrid",
                column: "DirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_WordsOnGrid_WordSetId",
                table: "WordsOnGrid",
                column: "WordSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharactersOnGrid");

            migrationBuilder.DropTable(
                name: "WordsOnGrid");

            migrationBuilder.DropTable(
                name: "Alphabets");

            migrationBuilder.DropTable(
                name: "DataGrids");

            migrationBuilder.DropTable(
                name: "Directions");

            migrationBuilder.DropTable(
                name: "WordSets");
        }
    }
}
