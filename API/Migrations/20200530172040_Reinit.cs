using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Reinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: true, defaultValue: true),
                    DateOfCreateAccount = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoCategories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCategories", x => x.Id);
                    table.UniqueConstraint("AK_VideoCategories_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayLists",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Likes = table.Column<int>(nullable: false, defaultValue: 0),
                    Photo = table.Column<string>(nullable: true),
                    DateOfCreate = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    SubscriberId = table.Column<string>(nullable: false),
                    ChanelAuthorId = table.Column<string>(nullable: false),
                    DateOfCreateSubscription = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => new { x.SubscriberId, x.ChanelAuthorId });
                    table.ForeignKey(
                        name: "FK_Subscriptions_AspNetUsers_ChanelAuthorId",
                        column: x => x.ChanelAuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscriptions_AspNetUsers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    VideoCategoryId = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    UrlAddress = table.Column<string>(nullable: true),
                    PhotoUrl = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 5000, nullable: true),
                    DateOfCreate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Videos_VideoCategories_VideoCategoryId",
                        column: x => x.VideoCategoryId,
                        principalTable: "VideoCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    VideoId = table.Column<string>(nullable: true),
                    DateOfCreate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 30, 19, 20, 39, 384, DateTimeKind.Local).AddTicks(4115)),
                    Content = table.Column<string>(maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    VideoId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VideoOnPlayList",
                columns: table => new
                {
                    VideoId = table.Column<string>(nullable: false),
                    PlayListId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoOnPlayList", x => new { x.VideoId, x.PlayListId });
                    table.ForeignKey(
                        name: "FK_VideoOnPlayList_PlayLists_PlayListId",
                        column: x => x.PlayListId,
                        principalTable: "PlayLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoOnPlayList_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VideoCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "68ae8fc7-8716-4135-9146-9b8eac82825d", "Sc-Fi" },
                    { "46d87f13-62fb-4d15-943c-f6885be1f4ac", "Komedia" },
                    { "d71842eb-34af-4739-ba73-cc31fa25b40d", "Dramat" },
                    { "d7bdbb30-47ec-4b7c-b31d-6727609b76cc", "Śmieszne Kotki" },
                    { "757a6487-1efa-4c33-8632-bf759308812e", "" },
                    { "a5bf9d05-bdd7-42e4-8977-de002fc39caf", "084b52e0-a28c-4798-adf1-f4d1da4e73b4" }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "DateOfCreate", "Description", "Name", "PhotoUrl", "UrlAddress", "UserId", "VideoCategoryId" },
                values: new object[,]
                {
                    { "dc12ceb9-f672-4466-b013-71cb91a98641", new DateTime(2020, 5, 30, 19, 20, 39, 431, DateTimeKind.Local).AddTicks(8494), "Opis:  43c96c27-f9d8-4155-9031-dd9cb0e26437 a03b7c69-1aaf-4ada-88dc-55c3745c7bab", "Film d54c6598-8b80-4a01-bc5d-df698d820f78 fc32cac8-62d4-4f01-91f4-d24dc6dc7a6d", null, null, null, "68ae8fc7-8716-4135-9146-9b8eac82825d" },
                    { "66c11beb-3c2b-400d-b0c4-c947d10d2796", new DateTime(2020, 5, 30, 19, 20, 39, 432, DateTimeKind.Local).AddTicks(8190), "Opis:  cc2e384c-ae63-415d-8dbf-41e32816d5cf 73347e35-477b-4e39-bbe4-6bd524ae73f8", "Film 621d8fa5-4e6c-4851-b2b6-c86387db8976 703256e7-e2c6-488f-80b6-c6597bcf0b70", null, null, null, "46d87f13-62fb-4d15-943c-f6885be1f4ac" },
                    { "ee36dcc0-f318-4055-99d8-1ec43a6199e2", new DateTime(2020, 5, 30, 19, 20, 39, 432, DateTimeKind.Local).AddTicks(9271), "Opis:  dfc6f0f9-5126-4b9a-8802-836ecf538468 150b0a1e-dc3c-48d2-b68e-2d3d5a6965c9", "Film d42ff738-6a3b-4439-ab72-658e2ffe0814 dd6e6f55-559c-4c20-a9a6-54fe3c5750fb", null, null, null, "d71842eb-34af-4739-ba73-cc31fa25b40d" },
                    { "49866006-f9c5-40be-bc8d-82a4814b1f72", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(436), "Opis:  0cca69c5-883e-4049-b661-e149dbbdefbb 7602f9eb-0b5d-47ff-ad03-288cc3c89d7b", "Film 0e2cc36f-1679-4df1-b198-c4479564d842 d3582a56-2801-409c-bdcc-2bf5981b13b5", null, null, null, "d7bdbb30-47ec-4b7c-b31d-6727609b76cc" },
                    { "c2b2a299-ae16-4d33-b8db-bb224badeb48", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(1373), "Opis:  535c98ca-ba09-4ceb-b82b-57b00c651aa8 123295b3-1ba6-4069-aa0c-17d35af1d412", "Film 276bd9bd-fe9a-471e-b0d4-a5f24b545cce dcdf5fcc-c727-4843-800e-284389ad03d0", null, null, null, "757a6487-1efa-4c33-8632-bf759308812e" },
                    { "c3e1ee03-4105-45f5-ad45-f30cf28e0b34", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(2625), "Opis:  312c6084-f207-4f38-88df-d10f0e25f235 08984952-f14c-45ad-83c1-86cb64f7c533", "Film 34b6913d-2823-4e3f-9180-ddee363fe862 80814fee-a1eb-4a05-b343-1a0ceccadd93", null, null, null, "a5bf9d05-bdd7-42e4-8977-de002fc39caf" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "DateOfCreate", "UserId", "VideoId" },
                values: new object[,]
                {
                    { "2f414b21-a850-4189-bef2-9b2f608089fc", "Komentarz: 448bcf31-8b31-4690-a21a-3ee9c70a24bb a9f6519d-3bc9-4287-9e62-504e7bb9964c", new DateTime(2020, 5, 30, 19, 20, 39, 432, DateTimeKind.Local).AddTicks(5847), "1", "dc12ceb9-f672-4466-b013-71cb91a98641" },
                    { "2f8c530a-08d5-4174-9d0f-880794c7c9df", "Komentarz: dc9b55c1-f3ce-47ca-8677-7ecb5eb015b0 91812988-b963-4bfe-a7cb-2c1eefc9aada", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(812), "1", "49866006-f9c5-40be-bc8d-82a4814b1f72" },
                    { "19c74347-f9eb-404e-b143-b39455c3eefc", "Komentarz: 9d4bc7dd-8892-4714-a0e2-754d7fb34ae2 cf6a6c1a-2918-43a3-a7d8-71a04e1945e6", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(902), "1", "49866006-f9c5-40be-bc8d-82a4814b1f72" },
                    { "87ea9d7b-9814-459f-853c-03710ba61cdc", "Komentarz: de34ad9e-7fbc-433d-a3de-7dac2c35138e 181c1669-8e8c-46b7-9d48-f0bca787bc93", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(1015), "1", "49866006-f9c5-40be-bc8d-82a4814b1f72" },
                    { "403b138d-bc7a-4278-a56e-1f2031049591", "Komentarz: 145f8460-87fb-4c94-adfc-f454bce3589b 0286a2e6-2c2b-40b0-bdc9-26b4fd5e34f7", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(1100), "1", "49866006-f9c5-40be-bc8d-82a4814b1f72" },
                    { "e7779e77-2d69-44be-8466-a3d38821d3d2", "Komentarz: c5bab837-0bec-4d4d-b051-4f595d9c8039 1f0b9294-2dcf-4381-b002-c9c715d21407", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(1553), "1", "c2b2a299-ae16-4d33-b8db-bb224badeb48" },
                    { "22ac41af-6c19-46a7-b1f9-ccc82a215b9d", "Komentarz: 1b45887e-2f3e-4e53-a68d-b49217c4f460 8d76925c-e72b-4dfd-8159-546cfeb2618e", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(1729), "1", "c2b2a299-ae16-4d33-b8db-bb224badeb48" },
                    { "ec897da7-d892-4869-9713-b75d71ab02d0", "Komentarz: 5abaf33b-3a62-40a1-a1b0-fe31397c2071 d7aa2aff-c32a-4903-9fc3-ba994c14aef9", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(714), "1", "49866006-f9c5-40be-bc8d-82a4814b1f72" },
                    { "5b42a63a-084a-483d-b57b-3df42e3a36e9", "Komentarz: 4c77160b-01fd-4a80-b04f-1a23579e5003 e12d7b94-42e1-4e33-9e81-e281e3c859cf", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(1890), "1", "c2b2a299-ae16-4d33-b8db-bb224badeb48" },
                    { "0e9378ee-85e1-4a2a-b8d7-817282963e66", "Komentarz: c05a5aa3-22f1-4fd7-a9b6-9cc2c9617a46 67bc1be1-fad2-44ed-93b4-5aa63615b7b4", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(2212), "1", "c2b2a299-ae16-4d33-b8db-bb224badeb48" },
                    { "1ba4e78f-21e4-4296-9458-287318b88021", "Komentarz: 04c9ca23-9117-484e-81fe-b08181e4e9e2 60899487-215c-44b4-a633-f7ca6944549e", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(2378), "1", "c2b2a299-ae16-4d33-b8db-bb224badeb48" },
                    { "5e95d881-6b60-4f32-9648-fc7ce8659ad4", "Komentarz: 239ed381-c63c-40b9-9dbd-f24394f68fb4 978388c7-9ac6-4400-a8cc-022897200480", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(2710), "1", "c3e1ee03-4105-45f5-ad45-f30cf28e0b34" },
                    { "9a506565-2f9c-47e7-b747-fc9265c7dcd2", "Komentarz: f1154527-3420-40ff-8f95-d14d38020829 7b5a3f86-7475-448f-9858-3644e41087c7", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(2788), "1", "c3e1ee03-4105-45f5-ad45-f30cf28e0b34" },
                    { "15f23304-3cf7-464a-ba53-7cdb1ccda265", "Komentarz: aa8dd35e-35d8-4fed-a514-44f50d6fa17a 19d400f6-68ab-4490-b7fd-6f2f07e6628e", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(2886), "1", "c3e1ee03-4105-45f5-ad45-f30cf28e0b34" },
                    { "4b02fc04-8ae3-40f3-b756-2ad0bded7b56", "Komentarz: e5a63bf8-5956-4384-a97b-585e04005687 2e993ac5-d056-49b8-8e6a-bac4196cb800", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(2973), "1", "c3e1ee03-4105-45f5-ad45-f30cf28e0b34" },
                    { "b44c8cac-03bf-43af-b9cf-5f05e47b81c6", "Komentarz: e6aad903-75b1-4b2b-b2c2-3e768a2cf65d acec9d1a-9e93-4d6d-91ee-55d894256a37", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(2044), "1", "c2b2a299-ae16-4d33-b8db-bb224badeb48" },
                    { "91c627ef-2310-436e-bc74-5dccbf0c25fb", "Komentarz: 2a7373a8-5749-4e2b-9301-55c144d79624 2eca419d-a07f-4dfb-a3ef-9c721358daa5", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(570), "1", "49866006-f9c5-40be-bc8d-82a4814b1f72" },
                    { "a95dc6db-2d16-4cfa-8443-1f81d92928af", "Komentarz: 0951f942-7785-4705-9344-b08410a45cba ac58cd2c-5cae-4250-a409-dd3f6a0d7660", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(11), "1", "ee36dcc0-f318-4055-99d8-1ec43a6199e2" },
                    { "4d7b8e4c-3bf2-4318-add4-e4dadd14b7da", "Komentarz: bcb39bcd-306b-4956-9f6b-5d1bec0bb21f fb109bb3-4537-427b-83c0-4159fdfb33d3", new DateTime(2020, 5, 30, 19, 20, 39, 432, DateTimeKind.Local).AddTicks(9875), "1", "ee36dcc0-f318-4055-99d8-1ec43a6199e2" },
                    { "eb21dab0-3933-4fa4-ae89-30904d37a94e", "Komentarz: 80de478f-c877-4dbe-899b-352ceb828b9d 4745f0d8-d31c-41f7-adba-553cb54a100b", new DateTime(2020, 5, 30, 19, 20, 39, 432, DateTimeKind.Local).AddTicks(6620), "1", "dc12ceb9-f672-4466-b013-71cb91a98641" },
                    { "95e2a337-2eb0-46e6-b421-fcac74e34436", "Komentarz: e988e1a8-2dde-4519-9597-e74143cde9c6 fa021bc7-47fe-40af-85f3-90257c1a7898", new DateTime(2020, 5, 30, 19, 20, 39, 432, DateTimeKind.Local).AddTicks(6736), "1", "dc12ceb9-f672-4466-b013-71cb91a98641" },
                    { "9d001d06-9321-480d-b4d9-7da9d59f8b38", "Komentarz: 5957cfcb-7c02-43f2-a378-ad87f242d91e b0d4f43a-feb3-49f3-b82b-d1c1b0962ae1", new DateTime(2020, 5, 30, 19, 20, 39, 432, DateTimeKind.Local).AddTicks(6853), "1", "dc12ceb9-f672-4466-b013-71cb91a98641" },
                    { "d9086957-6f8b-4736-ab17-edace34b99c3", "Komentarz: 10f26da6-816f-4a5d-9f64-091ab83740d6 659877de-f35a-4fae-bbaf-0e5be1028733", new DateTime(2020, 5, 30, 19, 20, 39, 432, DateTimeKind.Local).AddTicks(7064), "1", "dc12ceb9-f672-4466-b013-71cb91a98641" },
                    { "1b2d4145-c1da-4a3a-954d-ddffb233e7db", "Komentarz: f1da91ab-47d3-4058-bff7-8baa72c50b7e 252da633-3704-49e9-b520-9ee0dde1833a", new DateTime(2020, 5, 30, 19, 20, 39, 432, DateTimeKind.Local).AddTicks(7186), "1", "dc12ceb9-f672-4466-b013-71cb91a98641" },
                    { "ec998917-d671-48a2-bf18-c0658ba0a895", "Komentarz: 4500d4ac-83bf-49d2-8a73-fd12b65475bf 6c307268-d7f6-426e-b380-d3d03258b9a7", new DateTime(2020, 5, 30, 19, 20, 39, 432, DateTimeKind.Local).AddTicks(8336), "1", "66c11beb-3c2b-400d-b0c4-c947d10d2796" },
                    { "03aa6298-d7da-45b3-b771-5f6252613d7a", "Komentarz: f513c55b-6889-4291-9922-7caa7d162229 f64b8534-c2e9-4b47-a81b-0fee036e9934", new DateTime(2020, 5, 30, 19, 20, 39, 432, DateTimeKind.Local).AddTicks(8465), "1", "66c11beb-3c2b-400d-b0c4-c947d10d2796" },
                    { "ca7cf74c-8c1a-4fda-b08b-d20bfe021ddc", "Komentarz: d9e3616b-5b78-48a1-96cb-75182d20bf72 91b10c73-1926-4af6-af31-26ebb87fc2ee", new DateTime(2020, 5, 30, 19, 20, 39, 432, DateTimeKind.Local).AddTicks(8587), "1", "66c11beb-3c2b-400d-b0c4-c947d10d2796" },
                    { "f30d6702-dcbb-4f64-8d39-c632fe5e81fb", "Komentarz: 1f6f8645-5a5c-460e-b725-9992d0ba1fc4 12066b14-fb15-4b0d-9e5a-50ea640263b0", new DateTime(2020, 5, 30, 19, 20, 39, 432, DateTimeKind.Local).AddTicks(8707), "1", "66c11beb-3c2b-400d-b0c4-c947d10d2796" },
                    { "484e0547-8f41-4470-9ead-e34f64e064ec", "Komentarz: 9a5c0b5d-897a-4e3e-93c0-76156b421c6a 2ba06b57-852a-4112-96ab-42f4755fdbb7", new DateTime(2020, 5, 30, 19, 20, 39, 432, DateTimeKind.Local).AddTicks(8826), "1", "66c11beb-3c2b-400d-b0c4-c947d10d2796" },
                    { "270e2a72-c0a1-4b84-80f5-a9d7f96e97eb", "Komentarz: ec5e9f14-477e-46f8-943e-0ed83e63df8c 373f0bfa-d24f-414f-93e8-ea13955b0bd8", new DateTime(2020, 5, 30, 19, 20, 39, 432, DateTimeKind.Local).AddTicks(8944), "1", "66c11beb-3c2b-400d-b0c4-c947d10d2796" },
                    { "4a6b6fb6-7dc7-4f03-8249-52d6e150b1a8", "Komentarz: 1f1c540a-7fae-4957-8c73-cf6d17a9a19b 773b612c-4ba7-49ef-820f-e454600be2c0", new DateTime(2020, 5, 30, 19, 20, 39, 432, DateTimeKind.Local).AddTicks(9396), "1", "ee36dcc0-f318-4055-99d8-1ec43a6199e2" },
                    { "09b22482-f8ca-4cf0-96db-26a18bf786bd", "Komentarz: cb47d324-9c14-4802-ad44-e227fafcd7fb a232d170-d3c8-4c21-9f25-91d3fe8f5591", new DateTime(2020, 5, 30, 19, 20, 39, 432, DateTimeKind.Local).AddTicks(9522), "1", "ee36dcc0-f318-4055-99d8-1ec43a6199e2" },
                    { "8a818330-722c-4d44-a1a8-3b3d3666b623", "Komentarz: 68eb0f8e-b8bd-4f57-b297-5b0bdaa9457e fa25be2d-6057-4c4a-8510-9bf2952c86cb", new DateTime(2020, 5, 30, 19, 20, 39, 432, DateTimeKind.Local).AddTicks(9638), "1", "ee36dcc0-f318-4055-99d8-1ec43a6199e2" },
                    { "d3b7eb33-2c37-4695-826d-cee275f6bb9f", "Komentarz: ec8aa1cf-8710-438e-8de7-9cf1d03bcd0a baa096c1-3e91-49c4-ad5d-691a447b7b32", new DateTime(2020, 5, 30, 19, 20, 39, 432, DateTimeKind.Local).AddTicks(9759), "1", "ee36dcc0-f318-4055-99d8-1ec43a6199e2" },
                    { "db4f15a5-83e7-4c0d-b142-1e64c7125043", "Komentarz: 3f51fd82-e74a-4a53-84d1-37b515921aab f924cf70-c0f8-497c-8433-9ed0d6e8edc4", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(3046), "1", "c3e1ee03-4105-45f5-ad45-f30cf28e0b34" },
                    { "6878362b-dd4a-490a-84e7-8843bd7568b5", "Komentarz: 419d7f16-5d85-47c3-9125-758b2e0d8901 b75431fe-a2a1-47a6-bc07-8ed0ea589fd0", new DateTime(2020, 5, 30, 19, 20, 39, 433, DateTimeKind.Local).AddTicks(3159), "1", "c3e1ee03-4105-45f5-ad45-f30cf28e0b34" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_VideoId",
                table: "Comments",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_VideoId",
                table: "Likes",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayLists_UserId",
                table: "PlayLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_ChanelAuthorId",
                table: "Subscriptions",
                column: "ChanelAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoOnPlayList_PlayListId",
                table: "VideoOnPlayList",
                column: "PlayListId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_UserId",
                table: "Videos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_VideoCategoryId",
                table: "Videos",
                column: "VideoCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "VideoOnPlayList");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PlayLists");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "VideoCategories");
        }
    }
}
