using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearn.DataLayer.Migrations
{
    public partial class UpdateCouseGroupModelAddIsDeletedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CourseGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CourseGroups");
        }
    }
}
