using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoard.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    BoardId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.BoardId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BoardId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    DatePosted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "BoardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(nullable: false),
                    Heading = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    DatePosted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "BoardId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "General discussions about computer programming i.e., best practices, tips-and-trick, etc...", "Programming" },
                    { 2, "A place where we can share cute things our pets have done", "Pets" },
                    { 3, "Trading nutrition tips, recipes, and support", "Diet/Nutrition" },
                    { 4, "A friendly chat about what video games we are playing these days", "Video Games" },
                    { 5, "Best places to eat around Portland", "Eats!" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "Role", "Token", "Username" },
                values: new object[,]
                {
                    { 1, "Admin", "User", "noel", "Admin", null, "noel" },
                    { 2, "Admin", "User", "spencer", "Admin", null, "spencer" },
                    { 3, "Admin", "User", "christine", "Admin", null, "christine" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "BoardId", "DatePosted", "Title" },
                values: new object[] { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C#" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "BoardId", "DatePosted", "Title" },
                values: new object[] { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JavaScript" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "BoardId", "DatePosted", "Title" },
                values: new object[] { 3, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dogs" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Body", "DatePosted", "Heading", "PostId" },
                values: new object[] { 1, "JK! C# Rocks.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# Sucks!", 1 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Body", "DatePosted", "Heading", "PostId" },
                values: new object[] { 2, "Songs to listen to while making a database?", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Databases, Databases, Databases", 1 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Body", "DatePosted", "Heading", "PostId" },
                values: new object[] { 3, "Suggestions?", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "My Dog keeps eating trash?", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_PostId",
                table: "Messages",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BoardId",
                table: "Posts",
                column: "BoardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
