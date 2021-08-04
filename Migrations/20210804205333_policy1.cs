using Microsoft.EntityFrameworkCore.Migrations;

namespace poc.Migrations
{
    public partial class policy1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    policyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    coverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    premium = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sumInsured = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    coverUpto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    termsConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policies");
        }
    }
}
