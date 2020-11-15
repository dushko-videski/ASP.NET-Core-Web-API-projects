using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainModels.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Username = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TaskName = table.Column<string>(maxLength: 50, nullable: false),
                    TaskDescription = table.Column<string>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubTask",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubTaskName = table.Column<string>(maxLength: 50, nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    ToDoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTask_Task_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Firstname", "Lastname", "Password", "Username" },
                values: new object[] { 1, "Dushko", "Videski", "??9I?Y??V?W??>", "dusvid01" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Firstname", "Lastname", "Password", "Username" },
                values: new object[] { 2, "Ilija", "Pecevski", "???&s?x?m?uH]?", "ilipec01" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "IsCompleted", "TaskDescription", "TaskName", "UserId" },
                values: new object[] { 1, true, "regular exercise", "exercise", 1 });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "IsCompleted", "TaskDescription", "TaskName", "UserId" },
                values: new object[] { 2, false, "webapi", "study", 1 });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "IsCompleted", "TaskDescription", "TaskName", "UserId" },
                values: new object[] { 3, false, "first shift", "go to work", 1 });

            migrationBuilder.InsertData(
                table: "SubTask",
                columns: new[] { "Id", "IsCompleted", "SubTaskName", "ToDoId" },
                values: new object[,]
                {
                    { 1, true, "pushups", 1 },
                    { 2, false, "bench", 1 },
                    { 3, true, "arms", 1 },
                    { 4, true, "swagger", 2 },
                    { 5, false, "postman", 2 },
                    { 6, true, "attend a meeting", 3 },
                    { 7, false, "read the e-mail", 3 },
                    { 8, true, "take a lunch brae at noon", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubTask_ToDoId",
                table: "SubTask",
                column: "ToDoId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_UserId",
                table: "Task",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubTask");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
