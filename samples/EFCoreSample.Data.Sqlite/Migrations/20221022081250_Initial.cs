using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreSample.Data.Sqlite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alphabets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Characters = table.Column<string>(type: "TEXT", nullable: false),
                    Script = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alphabets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataGrids",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Row = table.Column<int>(type: "INTEGER", nullable: false),
                    Column = table.Column<int>(type: "INTEGER", nullable: false),
                    Size = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataGrids", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RowMovement = table.Column<int>(type: "INTEGER", nullable: false),
                    ColumnMovement = table.Column<int>(type: "INTEGER", nullable: false),
                    Layout = table.Column<string>(type: "TEXT", nullable: false),
                    DirectionType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WordSets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Words = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Language = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharactersOnGrid",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    AlphabetId = table.Column<long>(type: "INTEGER", nullable: false),
                    DataGridId = table.Column<long>(type: "INTEGER", nullable: true)
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
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    WordSetId = table.Column<long>(type: "INTEGER", nullable: false),
                    DirectionId = table.Column<long>(type: "INTEGER", nullable: false),
                    DataGridId = table.Column<long>(type: "INTEGER", nullable: true)
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
