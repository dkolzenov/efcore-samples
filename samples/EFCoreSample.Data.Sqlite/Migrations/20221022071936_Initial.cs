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
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterOnGrids",
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
                    table.PrimaryKey("PK_CharacterOnGrids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterOnGrids_Alphabets_AlphabetId",
                        column: x => x.AlphabetId,
                        principalTable: "Alphabets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterOnGrids_DataGrids_DataGridId",
                        column: x => x.DataGridId,
                        principalTable: "DataGrids",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WordOnGrids",
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
                    table.PrimaryKey("PK_WordOnGrids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordOnGrids_DataGrids_DataGridId",
                        column: x => x.DataGridId,
                        principalTable: "DataGrids",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WordOnGrids_Directions_DirectionId",
                        column: x => x.DirectionId,
                        principalTable: "Directions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WordOnGrids_WordSets_WordSetId",
                        column: x => x.WordSetId,
                        principalTable: "WordSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterOnGrids_AlphabetId",
                table: "CharacterOnGrids",
                column: "AlphabetId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterOnGrids_DataGridId",
                table: "CharacterOnGrids",
                column: "DataGridId");

            migrationBuilder.CreateIndex(
                name: "IX_WordOnGrids_DataGridId",
                table: "WordOnGrids",
                column: "DataGridId");

            migrationBuilder.CreateIndex(
                name: "IX_WordOnGrids_DirectionId",
                table: "WordOnGrids",
                column: "DirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_WordOnGrids_WordSetId",
                table: "WordOnGrids",
                column: "WordSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterOnGrids");

            migrationBuilder.DropTable(
                name: "WordOnGrids");

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
