using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace awme.Migrations
{
    /// <inheritdoc />
    public partial class IdAddedToProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Profiles_FirstProfileUsername",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Profiles_ProfileUsername",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Profiles_SecondProfileUsername",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Profiles_ProfileUsername",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Profiles_ProfileUsername",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Profiles_SenderUsername1",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Profiles_UserProfileUsername",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileProfile_Profiles_FollowersUsername",
                table: "ProfileProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileProfile_Profiles_FollowingUsername",
                table: "ProfileProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileProfile",
                table: "ProfileProfile");

            migrationBuilder.DropIndex(
                name: "IX_ProfileProfile_FollowingUsername",
                table: "ProfileProfile");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserProfileUsername",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderUsername1",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Likes_ProfileUsername",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ProfileUsername",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Chats_FirstProfileUsername",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_ProfileUsername",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_SecondProfileUsername",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "FollowersUsername",
                table: "ProfileProfile");

            migrationBuilder.DropColumn(
                name: "FollowingUsername",
                table: "ProfileProfile");

            migrationBuilder.DropColumn(
                name: "UserProfileUsername",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "SenderUsername1",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ProfileUsername",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "ProfileUsername",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "FirstProfileUsername",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "ProfileUsername",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "SecondProfileUsername",
                table: "Chats");

            migrationBuilder.RenameColumn(
                name: "SenderUsername",
                table: "Messages",
                newName: "SenderId");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "FollowersId",
                table: "ProfileProfile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FollowingId",
                table: "ProfileProfile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FirstProfileId",
                table: "Chats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Chats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondProfileId",
                table: "Chats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileProfile",
                table: "ProfileProfile",
                columns: new[] { "FollowersId", "FollowingId" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 246, 214, 17, 142, 161, 12, 109, 22, 250, 147, 81, 211, 213, 194, 17, 104, 171, 238, 79, 110, 155, 23, 162, 80, 136, 241, 205, 183, 118, 142, 79, 202, 247, 124, 33, 240, 16, 239, 145, 162, 53, 203, 108, 43, 46, 249, 26, 78, 212, 34, 64, 7, 130, 253, 12, 159, 221, 165, 69, 92, 143, 125, 153, 84 }, new byte[] { 180, 110, 176, 72, 135, 206, 212, 66, 225, 102, 221, 113, 16, 236, 206, 175, 13, 6, 29, 53, 228, 133, 86, 89, 206, 131, 180, 79, 170, 56, 252, 24, 207, 31, 99, 61, 41, 40, 3, 68, 205, 175, 105, 231, 149, 204, 21, 45, 159, 219, 25, 110, 165, 117, 246, 196, 162, 233, 206, 215, 84, 250, 208, 109, 43, 14, 165, 85, 49, 107, 165, 46, 19, 13, 184, 15, 53, 176, 250, 172, 154, 43, 42, 47, 156, 231, 243, 197, 90, 16, 93, 163, 16, 77, 205, 1, 141, 52, 189, 146, 195, 199, 97, 187, 214, 167, 76, 243, 4, 234, 172, 5, 224, 137, 4, 157, 188, 138, 184, 243, 176, 227, 26, 227, 77, 54, 33, 97 } });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileProfile_FollowingId",
                table: "ProfileProfile",
                column: "FollowingId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ProfileId",
                table: "Posts",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ProfileId",
                table: "Likes",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProfileId",
                table: "Comments",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_FirstProfileId",
                table: "Chats",
                column: "FirstProfileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ProfileId",
                table: "Chats",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_SecondProfileId",
                table: "Chats",
                column: "SecondProfileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Profiles_FirstProfileId",
                table: "Chats",
                column: "FirstProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Profiles_ProfileId",
                table: "Chats",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Profiles_SecondProfileId",
                table: "Chats",
                column: "SecondProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Profiles_ProfileId",
                table: "Comments",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Profiles_ProfileId",
                table: "Likes",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Profiles_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Profiles_ProfileId",
                table: "Posts",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileProfile_Profiles_FollowersId",
                table: "ProfileProfile",
                column: "FollowersId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileProfile_Profiles_FollowingId",
                table: "ProfileProfile",
                column: "FollowingId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Profiles_FirstProfileId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Profiles_ProfileId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Profiles_SecondProfileId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Profiles_ProfileId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Profiles_ProfileId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Profiles_SenderId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Profiles_ProfileId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileProfile_Profiles_FollowersId",
                table: "ProfileProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileProfile_Profiles_FollowingId",
                table: "ProfileProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileProfile",
                table: "ProfileProfile");

            migrationBuilder.DropIndex(
                name: "IX_ProfileProfile_FollowingId",
                table: "ProfileProfile");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ProfileId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Likes_ProfileId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ProfileId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Chats_FirstProfileId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_ProfileId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_SecondProfileId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "FollowersId",
                table: "ProfileProfile");

            migrationBuilder.DropColumn(
                name: "FollowingId",
                table: "ProfileProfile");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "FirstProfileId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "SecondProfileId",
                table: "Chats");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Messages",
                newName: "SenderUsername");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Profiles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FollowersUsername",
                table: "ProfileProfile",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FollowingUsername",
                table: "ProfileProfile",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserProfileUsername",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderUsername1",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileUsername",
                table: "Likes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileUsername",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstProfileUsername",
                table: "Chats",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileUsername",
                table: "Chats",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondProfileUsername",
                table: "Chats",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "Username");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileProfile",
                table: "ProfileProfile",
                columns: new[] { "FollowersUsername", "FollowingUsername" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 187, 173, 92, 65, 181, 112, 247, 207, 224, 196, 77, 59, 151, 217, 144, 248, 174, 100, 8, 84, 1, 21, 194, 108, 240, 51, 136, 77, 1, 104, 91, 11, 165, 43, 235, 101, 59, 233, 200, 50, 167, 58, 126, 18, 200, 179, 100, 194, 17, 203, 240, 137, 240, 190, 30, 191, 146, 110, 106, 5, 197, 103, 250, 14 }, new byte[] { 198, 4, 34, 206, 36, 54, 6, 155, 247, 90, 95, 254, 1, 161, 197, 86, 51, 26, 37, 228, 58, 158, 200, 90, 136, 240, 232, 42, 105, 9, 160, 48, 35, 163, 214, 132, 134, 214, 97, 223, 47, 237, 232, 223, 46, 211, 19, 225, 39, 200, 104, 83, 57, 239, 12, 206, 108, 140, 253, 74, 175, 20, 75, 177, 228, 68, 220, 17, 161, 215, 220, 185, 143, 219, 7, 90, 72, 151, 192, 234, 19, 98, 164, 12, 48, 201, 39, 195, 84, 155, 233, 234, 254, 87, 154, 182, 186, 199, 179, 200, 25, 214, 194, 172, 206, 127, 198, 158, 217, 59, 185, 186, 246, 24, 224, 231, 205, 60, 253, 125, 118, 99, 8, 14, 95, 82, 67, 138 } });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileProfile_FollowingUsername",
                table: "ProfileProfile",
                column: "FollowingUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserProfileUsername",
                table: "Posts",
                column: "UserProfileUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderUsername1",
                table: "Messages",
                column: "SenderUsername1");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ProfileUsername",
                table: "Likes",
                column: "ProfileUsername",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProfileUsername",
                table: "Comments",
                column: "ProfileUsername",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Profiles_FirstProfileUsername",
                table: "Chats",
                column: "FirstProfileUsername",
                principalTable: "Profiles",
                principalColumn: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Profiles_ProfileUsername",
                table: "Chats",
                column: "ProfileUsername",
                principalTable: "Profiles",
                principalColumn: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Profiles_SecondProfileUsername",
                table: "Chats",
                column: "SecondProfileUsername",
                principalTable: "Profiles",
                principalColumn: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Profiles_ProfileUsername",
                table: "Comments",
                column: "ProfileUsername",
                principalTable: "Profiles",
                principalColumn: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Profiles_ProfileUsername",
                table: "Likes",
                column: "ProfileUsername",
                principalTable: "Profiles",
                principalColumn: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Profiles_SenderUsername1",
                table: "Messages",
                column: "SenderUsername1",
                principalTable: "Profiles",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Profiles_UserProfileUsername",
                table: "Posts",
                column: "UserProfileUsername",
                principalTable: "Profiles",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileProfile_Profiles_FollowersUsername",
                table: "ProfileProfile",
                column: "FollowersUsername",
                principalTable: "Profiles",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileProfile_Profiles_FollowingUsername",
                table: "ProfileProfile",
                column: "FollowingUsername",
                principalTable: "Profiles",
                principalColumn: "Username");
        }
    }
}
