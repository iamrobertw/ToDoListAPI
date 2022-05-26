using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListAPI.Migrations
{
    public partial class ChagedtoGide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDos",
                table: "ToDos");

            migrationBuilder.DropIndex(
                name: "IX_ToDos_id",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "id",
                table: "ToDos");

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                table: "ToDos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newsequentialid()");       
                

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDos",
                table: "ToDos",
                column: "id")
                .Annotation("SqlServer:Clustered", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDos",
                table: "ToDos");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "ToDos",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "newsequentialid()")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDos",
                table: "ToDos",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_id",
                table: "ToDos",
                column: "id",
                unique: true);
        }
    }
}
