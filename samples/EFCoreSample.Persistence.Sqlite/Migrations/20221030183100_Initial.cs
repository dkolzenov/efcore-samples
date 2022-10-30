using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreSample.Persistence.Sqlite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Samples",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 400, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samples", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Samples",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 1L, "SampleDescription_1", "SampleTitle_1" });

            migrationBuilder.InsertData(
                table: "Samples",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 2L, "SampleDescription_2", "SampleTitle_2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Samples");
        }
    }
}
