using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMasterTutorial.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusSeeDataTODB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Statuses (Name) VALUES ('To Do'),('In Progress'),('Done');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
