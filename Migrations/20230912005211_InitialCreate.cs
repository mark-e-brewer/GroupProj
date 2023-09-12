using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GroupProj.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FollowerId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypeChangeRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Action = table.Column<string>(type: "text", nullable: true),
                    AdminOneId = table.Column<int>(type: "integer", nullable: false),
                    AdminTwoId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypeChangeRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    ProfileImageURL = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: true),
                    IsStaff = table.Column<bool>(type: "boolean", nullable: true),
                    UID = table.Column<string>(type: "text", nullable: true),
                    SubscriptionsId = table.Column<int>(type: "integer", nullable: true),
                    UserTypeChangeRequestsId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Subscriptions_SubscriptionsId",
                        column: x => x.SubscriptionsId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_UserTypeChangeRequests_UserTypeChangeRequestsId",
                        column: x => x.UserTypeChangeRequestsId,
                        principalTable: "UserTypeChangeRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RareUsersId = table.Column<int>(type: "integer", nullable: true),
                    CategoriesId = table.Column<int>(type: "integer", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Approved = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Users_RareUsersId",
                        column: x => x.RareUsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "text", nullable: true),
                    ImageURL = table.Column<string>(type: "text", nullable: true),
                    RareUsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reactions_Users_RareUsersId",
                        column: x => x.RareUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RareUsersId = table.Column<int>(type: "integer", nullable: false),
                    PostsId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_RareUsersId",
                        column: x => x.RareUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostsTags",
                columns: table => new
                {
                    PostsId = table.Column<int>(type: "integer", nullable: false),
                    TagsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsTags", x => new { x.PostsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PostsTags_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostsTags_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostsReaction",
                columns: table => new
                {
                    PostsId = table.Column<int>(type: "integer", nullable: false),
                    ReactionsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsReaction", x => new { x.PostsId, x.ReactionsId });
                    table.ForeignKey(
                        name: "FK_PostsReaction_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostsReaction_Reactions_ReactionsId",
                        column: x => x.ReactionsId,
                        principalTable: "Reactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Label" },
                values: new object[] { 1, "Comedy" });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "AuthorId", "CreatedOn", "EndedOn", "FollowerId" },
                values: new object[] { 1, 1, new DateTime(2023, 9, 11, 19, 52, 11, 541, DateTimeKind.Local).AddTicks(9448), new DateTime(2023, 9, 11, 19, 52, 11, 541, DateTimeKind.Local).AddTicks(9451), 2 });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Label" },
                values: new object[] { 1, "Tag Label" });

            migrationBuilder.InsertData(
                table: "UserTypeChangeRequests",
                columns: new[] { "Id", "Action", "AdminOneId", "AdminTwoId", "ModifiedUserId" },
                values: new object[] { 1, " Action", 1, 2, 3 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "Bio", "CreatedOn", "Email", "FirstName", "IsStaff", "LastName", "ProfileImageURL", "SubscriptionsId", "UID", "UserTypeChangeRequestsId" },
                values: new object[,]
                {
                    { 1, true, "This a bio", new DateTime(2023, 9, 11, 19, 52, 11, 541, DateTimeKind.Local).AddTicks(9126), "this@email.com", "Bob", true, "BobberSon", "This is a url", null, "", null },
                    { 2, true, "This a bio", new DateTime(2023, 9, 11, 19, 52, 11, 541, DateTimeKind.Local).AddTicks(9204), "this@email.com", "Sandra", true, "BobberSon", "This is a url", null, "", null },
                    { 3, true, "This a bio", new DateTime(2023, 9, 11, 19, 52, 11, 541, DateTimeKind.Local).AddTicks(9206), "this@email.com", "Tim", false, "Timmerson", "This is a url", null, "", null }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Approved", "CategoriesId", "Content", "ImageURL", "PublicationDate", "RareUsersId", "Title" },
                values: new object[] { 1, true, 1, "Blah Blah Blah", "Post Image Url", new DateTime(2023, 9, 11, 19, 52, 11, 541, DateTimeKind.Local).AddTicks(9509), 1, null });

            migrationBuilder.InsertData(
                table: "Reactions",
                columns: new[] { "Id", "ImageURL", "Label", "RareUsersId" },
                values: new object[] { 1, "A url", "this a label", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "PostsId", "RareUsersId" },
                values: new object[] { 1, "this is content", new DateTime(2023, 9, 11, 19, 52, 11, 541, DateTimeKind.Local).AddTicks(9401), 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostsId",
                table: "Comments",
                column: "PostsId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RareUsersId",
                table: "Comments",
                column: "RareUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoriesId",
                table: "Posts",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_RareUsersId",
                table: "Posts",
                column: "RareUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_PostsReaction_ReactionsId",
                table: "PostsReaction",
                column: "ReactionsId");

            migrationBuilder.CreateIndex(
                name: "IX_PostsTags_TagsId",
                table: "PostsTags",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_RareUsersId",
                table: "Reactions",
                column: "RareUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SubscriptionsId",
                table: "Users",
                column: "SubscriptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeChangeRequestsId",
                table: "Users",
                column: "UserTypeChangeRequestsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostsReaction");

            migrationBuilder.DropTable(
                name: "PostsTags");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "UserTypeChangeRequests");
        }
    }
}
