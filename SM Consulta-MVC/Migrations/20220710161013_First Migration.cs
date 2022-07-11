using Microsoft.EntityFrameworkCore.Migrations;

namespace SM_Consulta_MVC.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserEntities",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    IncomeTax = table.Column<int>(type: "int", nullable: false),
                    HealthSocialInsurance = table.Column<int>(type: "int", nullable: false),
                    TotalTaxes = table.Column<int>(type: "int", nullable: false),
                    NetSaLary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntities", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEntities");
        }
    }
}
