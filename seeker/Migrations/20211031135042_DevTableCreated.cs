using Microsoft.EntityFrameworkCore.Migrations;

namespace seeker.Migrations
{
    public partial class DevTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    devName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    devEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    devPhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    devFrom = table.Column<int>(type: "int", nullable: true),
                    devAbout = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    devProject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    devGitHub = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Developer");
        }
    }
}
