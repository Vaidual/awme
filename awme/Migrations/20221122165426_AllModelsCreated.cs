using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace awme.Migrations
{
    /// <inheritdoc />
    public partial class AllModelsCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Username);
                    table.ForeignKey(
                        name: "FK_Profiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstProfileUsername = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SecondProfileUsername = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfileUsername = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Profiles_FirstProfileUsername",
                        column: x => x.FirstProfileUsername,
                        principalTable: "Profiles",
                        principalColumn: "Username");
                    table.ForeignKey(
                        name: "FK_Chats_Profiles_ProfileUsername",
                        column: x => x.ProfileUsername,
                        principalTable: "Profiles",
                        principalColumn: "Username");
                    table.ForeignKey(
                        name: "FK_Chats_Profiles_SecondProfileUsername",
                        column: x => x.SecondProfileUsername,
                        principalTable: "Profiles",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserProfileUsername = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Profiles_UserProfileUsername",
                        column: x => x.UserProfileUsername,
                        principalTable: "Profiles",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileProfile",
                columns: table => new
                {
                    FollowersUsername = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FollowingUsername = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileProfile", x => new { x.FollowersUsername, x.FollowingUsername });
                    table.ForeignKey(
                        name: "FK_ProfileProfile_Profiles_FollowersUsername",
                        column: x => x.FollowersUsername,
                        principalTable: "Profiles",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileProfile_Profiles_FollowingUsername",
                        column: x => x.FollowingUsername,
                        principalTable: "Profiles",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderUsername1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SenderUsername = table.Column<int>(type: "int", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_Profiles_SenderUsername1",
                        column: x => x.SenderUsername1,
                        principalTable: "Profiles",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    ProfileUsername = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Profiles_ProfileUsername",
                        column: x => x.ProfileUsername,
                        principalTable: "Profiles",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LikedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileUsername = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Profiles_ProfileUsername",
                        column: x => x.ProfileUsername,
                        principalTable: "Profiles",
                        principalColumn: "Username");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Role" },
                values: new object[] { 1, "admin@admin.com", "Admin", "Admin", new byte[] { 208, 34, 163, 227, 219, 55, 206, 110, 65, 182, 90, 187, 95, 43, 81, 145, 60, 240, 84, 126, 233, 195, 200, 190, 17, 178, 213, 192, 19, 17, 185, 139, 225, 46, 69, 53, 123, 231, 131, 223, 5, 8, 86, 232, 84, 117, 46, 112, 131, 199, 251, 170, 10, 150, 14, 114, 154, 161, 127, 33, 25, 107, 9, 95 }, new byte[] { 240, 237, 102, 188, 43, 100, 1, 0, 191, 97, 106, 173, 157, 46, 129, 43, 66, 99, 49, 5, 68, 99, 122, 106, 14, 141, 122, 202, 108, 245, 106, 100, 123, 92, 8, 198, 82, 158, 93, 223, 143, 254, 6, 8, 206, 11, 103, 229, 240, 110, 136, 178, 8, 153, 124, 160, 190, 245, 108, 43, 103, 83, 173, 149, 253, 98, 152, 68, 109, 239, 61, 134, 209, 138, 7, 14, 153, 160, 176, 149, 20, 253, 253, 148, 102, 73, 148, 249, 233, 227, 116, 191, 229, 172, 208, 189, 190, 151, 48, 3, 63, 244, 242, 229, 95, 133, 158, 36, 39, 4, 238, 106, 228, 62, 37, 84, 36, 81, 136, 223, 204, 20, 232, 188, 174, 195, 32, 144 }, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_FirstProfileUsername",
                table: "Chats",
                column: "FirstProfileUsername",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ProfileUsername",
                table: "Chats",
                column: "ProfileUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_SecondProfileUsername",
                table: "Chats",
                column: "SecondProfileUsername",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProfileUsername",
                table: "Comments",
                column: "ProfileUsername",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ProfileUsername",
                table: "Likes",
                column: "ProfileUsername",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderUsername1",
                table: "Messages",
                column: "SenderUsername1");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserProfileUsername",
                table: "Posts",
                column: "UserProfileUsername");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileProfile_FollowingUsername",
                table: "ProfileProfile",
                column: "FollowingUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "ProfileProfile");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "Name");
        }
    }
}
