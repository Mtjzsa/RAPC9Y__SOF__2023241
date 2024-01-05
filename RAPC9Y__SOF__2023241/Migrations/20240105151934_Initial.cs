using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RAPC9Y__SOF__2023241.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Champions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resources = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    Release = table.Column<int>(type: "int", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Champions_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "RegionName" },
                values: new object[,]
                {
                    { 1, "Bandle-City" },
                    { 2, "Bilgewater" },
                    { 3, "Demacia" },
                    { 4, "Ionia" },
                    { 5, "Ixtal" },
                    { 6, "Noxus" },
                    { 7, "Piltover" },
                    { 8, "Runeterra" },
                    { 9, "Shadow Isles" },
                    { 10, "Shurima" },
                    { 11, "Targon" },
                    { 12, "Freljord" },
                    { 13, "Void" },
                    { 14, "Zaun" }
                });

            migrationBuilder.InsertData(
                table: "Champions",
                columns: new[] { "Id", "ContentType", "Data", "Gender", "Name", "RegionId", "Release", "Resources", "Species" },
                values: new object[,]
                {
                    { "1", null, null, "Male", "Aatrox", 8, 2013, "Manaless", "Darkin" },
                    { "10", null, null, "Female", "Ashe", 12, 2009, "Mana", "Human" },
                    { "100", null, null, "Female", "Renata Glasc", 14, 2022, "Mana", "Chemically Altered" },
                    { "101", null, null, "Male", "Renekton", 10, 2011, "Fury", "God" },
                    { "102", null, null, "Male", "Rengar", 5, 2012, "Ferocity", "Vastayan" },
                    { "103", null, null, "Female", "Riven", 4, 2011, "Manaless", "Human" },
                    { "104", null, null, "Male", "Rumble", 1, 2011, "Heat", "Yordle" },
                    { "105", null, null, "Male", "Ryze", 8, 2009, "Mana", "Magically Altered" },
                    { "106", null, null, "Female", "Samira", 6, 2020, "Mana", "Human" },
                    { "107", null, null, "Female", "Sejuani", 12, 2012, "Mana", "Human" },
                    { "108", null, null, "Female", "Senna", 3, 2019, "Mana", "Human" },
                    { "109", null, null, "Female", "Seraphine", 7, 2020, "Mana", "Human" },
                    { "11", null, null, "Male", "Aurelion Sol", 11, 2016, "Mana", "Celestial" },
                    { "110", null, null, "Male", "Sett", 4, 2020, "Grit", "Vastayan" },
                    { "111", null, null, "Male", "Shaco", 8, 2009, "Mana", "Spirit" },
                    { "112", null, null, "Male", "Shen", 4, 2010, "Energy", "Human" },
                    { "113", null, null, "Female", "Shyvana", 3, 2011, "Fury", "Magically Altered" },
                    { "114", null, null, "Male", "Singed", 14, 2009, "Mana", "Chemically Altered" },
                    { "115", null, null, "Male", "Sion", 6, 2009, "Mana", "Revenant" },
                    { "116", null, null, "Female", "Sivir", 10, 2009, "Mana", "Human" },
                    { "117", null, null, "Male", "Skarner", 10, 2011, "Mana", "Brackern" },
                    { "118", null, null, "Female", "Sona", 8, 2013, "Mana", "Human" },
                    { "119", null, null, "Female", "Soraka", 11, 2009, "Mana", "Celestial" },
                    { "12", null, null, "Male", "Azir", 10, 2014, "Mana", "God" },
                    { "120", null, null, "Male", "Swain", 6, 2010, "Mana", "Magically Altered" },
                    { "121", null, null, "Male", "Sylas", 3, 2019, "Mana", "Human" },
                    { "122", null, null, "Female", "Syndra", 4, 2012, "Mana", "Human" },
                    { "123", null, null, "Male", "Tahm Kech", 2, 2015, "Mana", "Demon" },
                    { "124", null, null, "Female", "Taliyah", 10, 2016, "Mana", "Human" },
                    { "125", null, null, "Male", "Talon", 6, 2011, "Mana", "Human" },
                    { "126", null, null, "Male", "Taric", 11, 2009, "Mana", "Human" },
                    { "127", null, null, "Male", "Teemo", 1, 2009, "Mana", "Yordle" },
                    { "128", null, null, "Male", "Thresh", 9, 2013, "Mana", "Undead" },
                    { "129", null, null, "Female", "Tristana", 1, 2009, "Mana", "Yordle" },
                    { "13", null, null, "Male", "Bard", 8, 2015, "Mana", "Celestial" },
                    { "130", null, null, "Male", "Trundle", 12, 2010, "Mana", "Troll" },
                    { "131", null, null, "Male", "Tryndamere", 12, 2009, "Fury", "Magically Altered" },
                    { "132", null, null, "Male", "Twisted Fate", 2, 2009, "Mana", "Human" },
                    { "133", null, null, "Male", "Twitch", 14, 2009, "Mana", "Chemically Altered" },
                    { "134", null, null, "Male", "Udyr", 12, 2009, "Mana", "Vastayan" },
                    { "135", null, null, "Male", "Urgot", 6, 2010, "Mana", "Chemically Altered" },
                    { "136", null, null, "Male", "Varus", 8, 2012, "Mana", "Darkin" }
                });

            migrationBuilder.InsertData(
                table: "Champions",
                columns: new[] { "Id", "ContentType", "Data", "Gender", "Name", "RegionId", "Release", "Resources", "Species" },
                values: new object[,]
                {
                    { "137", null, null, "Female", "Vayne", 3, 2011, "Mana", "Human" },
                    { "138", null, null, "Male", "Veigar", 1, 2009, "Mana", "Yordle" },
                    { "139", null, null, "Male", "Vel'Koz", 13, 2014, "Mana", "Void-Being" },
                    { "14", null, null, "Female", "Bel'Veth", 13, 2022, "Manaless", "Void-Being" },
                    { "140", null, null, "Female", "Vex", 9, 2021, "Mana", "Yordle" },
                    { "141", null, null, "Female", "Vi", 14, 2012, "Mana", "Human" },
                    { "142", null, null, "Male", "Viego", 9, 2021, "Manaless", "Undead" },
                    { "143", null, null, "Male", "Viktor", 14, 2011, "Mana", "Human" },
                    { "144", null, null, "Male", "Vladimir", 6, 2010, "Bloodthirst", "Magically Altered" },
                    { "145", null, null, "Male", "Volibear", 12, 2011, "Mana", "God" },
                    { "146", null, null, "Male", "Warwick", 14, 2009, "Mana", "Chemically Altered" },
                    { "147", null, null, "Male", "Wukong", 4, 2011, "Mana", "Vastayan" },
                    { "148", null, null, "Female", "Xayah", 4, 2017, "Mana", "Vastayan" },
                    { "149", null, null, "Male", "Xerath", 10, 2011, "Mana", "God" },
                    { "15", null, null, "Other", "Blitzcrank", 14, 2009, "Mana", "Golem" },
                    { "150", null, null, "Male", "Xin Zhao", 3, 2010, "Mana", "Human" },
                    { "151", null, null, "Male", "Yasuo", 4, 2013, "Flow", "Human" },
                    { "152", null, null, "Male", "Yone", 4, 2020, "Manaless", "Magically Altered" },
                    { "153", null, null, "Male", "Yorick", 9, 2011, "Mana", "Magically Altered" },
                    { "154", null, null, "Female", "Yuumi", 1, 2019, "Mana", "Magically Altered" },
                    { "155", null, null, "Male", "Zac", 14, 2013, "Health", "Golem" },
                    { "156", null, null, "Male", "Zed", 4, 2012, "Energy", "Human" },
                    { "157", null, null, "Female", "Zeri", 14, 2022, "Mana", "Human" },
                    { "158", null, null, "Male", "Ziggs", 7, 2012, "Mana", "Yordle" },
                    { "159", null, null, "Male", "Zilean", 8, 2009, "Mana", "Human" },
                    { "16", null, null, "Male", "Brand", 8, 2011, "Mana", "Magically Altered" },
                    { "160", null, null, "Female", "Zoe", 11, 2017, "Mana", "Human" },
                    { "161", null, null, "Other", "Zyra", 5, 2012, "Mana", "Unknown" },
                    { "17", null, null, "Male", "Braum", 12, 2014, "Mana", "Human" },
                    { "18", null, null, "Female", "Caitlyn", 7, 2011, "Mana", "Human" },
                    { "19", null, null, "Female", "Camille", 7, 2016, "Mana", "Human" },
                    { "2", null, null, "Female", "Ahri", 4, 2011, "Mana", "Vastayan" },
                    { "20", null, null, "Female", "Cassiopeia", 6, 2012, "Mana", "Magically Altered" },
                    { "21", null, null, "Male", "Cho'Gath", 13, 2009, "Mana", "Void-Being" },
                    { "22", null, null, "Male", "Corki", 1, 2009, "Mana", "Yordle" },
                    { "23", null, null, "Male", "Darius", 6, 2012, "Mana", "Human" },
                    { "24", null, null, "Female", "Diana", 11, 2012, "Mana", "Human" },
                    { "25", null, null, "Male", "Dr.Mundo", 14, 2009, "Health", "Chemically Altered" },
                    { "26", null, null, "Male", "Draven", 6, 2012, "Mana", "Human" },
                    { "27", null, null, "Male", "Ekko", 14, 2015, "Mana", "Human" },
                    { "28", null, null, "Female", "Elise", 9, 2012, "Mana", "Magically Altered" },
                    { "29", null, null, "Female", "Evelynn", 8, 2009, "Mana", "Demon" }
                });

            migrationBuilder.InsertData(
                table: "Champions",
                columns: new[] { "Id", "ContentType", "Data", "Gender", "Name", "RegionId", "Release", "Resources", "Species" },
                values: new object[,]
                {
                    { "3", null, null, "Female", "Akali", 4, 2010, "Energy", "Human" },
                    { "30", null, null, "Male", "Ezreal", 7, 2010, "Mana", "Human" },
                    { "31", null, null, "Other", "Fiddlesticks", 8, 2009, "Mana", "Demon" },
                    { "32", null, null, "Female", "Fiora", 3, 2012, "Mana", "Human" },
                    { "33", null, null, "Male", "Fizz", 2, 2011, "Mana", "Yordle" },
                    { "34", null, null, "Male", "Galio", 3, 2010, "Mana", "Golem" },
                    { "35", null, null, "Male", "Gangplank", 2, 2009, "Mana", "Human" },
                    { "36", null, null, "Male", "Garen", 3, 2010, "Manaless", "Human" },
                    { "37", null, null, "Male", "Gnar", 12, 2014, "Rage", "Yordle" },
                    { "38", null, null, "Male", "Gragas", 12, 2011, "Mana", "Human" },
                    { "39", null, null, "Male", "Graves", 2, 2011, "Mana", "Human" },
                    { "4", null, null, "Male", "Akshan", 10, 2021, "Mana", "Human" },
                    { "40", null, null, "Female", "Gwen", 9, 2021, "Mana", "Magically Altered" },
                    { "41", null, null, "Male", "Hecarim", 9, 2012, "Mana", "Undead" },
                    { "42", null, null, "Male", "Heimerdinger", 7, 2009, "Mana", "Yordle" },
                    { "43", null, null, "Female", "Illaoi", 2, 2015, "Mana", "Human" },
                    { "44", null, null, "Female", "Irelia", 4, 2010, "Mana", "Human" },
                    { "45", null, null, "Male", "IV.Jarvan", 3, 2011, "Mana", "Human" },
                    { "46", null, null, "Male", "Ivern", 4, 2016, "Mana", "Magically Altered" },
                    { "47", null, null, "Female", "Janna", 10, 2009, "Mana", "God" },
                    { "48", null, null, "Male", "Jax", 8, 2009, "Mana", "Unknown" },
                    { "49", null, null, "Male", "Jayce", 7, 2012, "Mana", "Human" },
                    { "5", null, null, "Male", "Alistar", 8, 2009, "Mana", "Minotaur" },
                    { "50", null, null, "Male", "Jhin", 4, 2016, "Mana", "Human" },
                    { "51", null, null, "Female", "Jinx", 14, 2013, "Mana", "Chemically Altered" },
                    { "52", null, null, "Female", "Kai'Sa", 13, 2018, "Mana", "Void-Being" },
                    { "53", null, null, "Female", "Kalista", 9, 2014, "Mana", "Undead" },
                    { "54", null, null, "Female", "Karma", 4, 2011, "Mana", "Human" },
                    { "55", null, null, "Male", "Karthus", 9, 2009, "Mana", "Undead" },
                    { "56", null, null, "Male", "Kassadin", 13, 2009, "Mana", "Void-Being" },
                    { "57", null, null, "Female", "Katarina", 6, 2009, "Manaless", "Human" },
                    { "58", null, null, "Female", "Kayle", 3, 2009, "Mana", "Magically Altered" },
                    { "59", null, null, "Male", "Kayn", 8, 2017, "Mana", "Darkin" },
                    { "6", null, null, "Male", "Amumu", 10, 2009, "Mana", "Yordle" },
                    { "60", null, null, "Male", "Kennen", 4, 2010, "Energy", "Yordle" },
                    { "61", null, null, "Male", "Kha'Zix", 13, 2012, "Mana", "Void-Being" },
                    { "62", null, null, "Other", "Kindred", 8, 2015, "Mana", "God" },
                    { "63", null, null, "Male", "Kled", 6, 2016, "Courage", "Yordle" },
                    { "64", null, null, "Male", "Kog'Maw", 13, 2010, "Mana", "Void-Being" },
                    { "65", null, null, "Femlae", "LeBlanc", 6, 2010, "Mana", "Magically Altered" },
                    { "66", null, null, "Male", "Lee Sin", 4, 2011, "Energy", "Human" },
                    { "67", null, null, "Female", "Leona", 11, 2011, "Mana", "Human" }
                });

            migrationBuilder.InsertData(
                table: "Champions",
                columns: new[] { "Id", "ContentType", "Data", "Gender", "Name", "RegionId", "Release", "Resources", "Species" },
                values: new object[,]
                {
                    { "68", null, null, "Female", "Lillia", 4, 2020, "Mana", "Spirit" },
                    { "69", null, null, "Female", "Lissandra", 12, 2013, "Mana", "Human" },
                    { "7", null, null, "Female", "Anivia", 12, 2009, "Mana", "God" },
                    { "70", null, null, "Male", "Lucian", 3, 2013, "Mana", "Human" },
                    { "71", null, null, "Female", "Lulu", 1, 2012, "Mana", "Yordle" },
                    { "72", null, null, "Female", "Lux", 3, 2010, "Mana", "Human" },
                    { "73", null, null, "Male", "Malphite", 10, 2009, "Mana", "Golem" },
                    { "74", null, null, "Male", "Malzahar", 13, 2010, "Mana", "Void-Being" },
                    { "75", null, null, "Male", "Maokai", 9, 2009, "Mana", "Spirit" },
                    { "76", null, null, "Male", "Master Yi", 4, 2010, "Mana", "Human" },
                    { "77", null, null, "Female", "Miss Fortune", 2, 2010, "Mana", "Human" },
                    { "78", null, null, "Male", "Mordekaiser", 6, 2010, "Shield", "Revenant" },
                    { "79", null, null, "Female", "Morgana", 3, 2009, "Mana", "Magically Altered" },
                    { "8", null, null, "Female", "Annie", 8, 2009, "Mana", "Magically Altered" },
                    { "80", null, null, "Female", "Nami", 8, 2012, "Mana", "Vastayan" },
                    { "81", null, null, "Male", "Nasus", 10, 2009, "Mana", "God" },
                    { "82", null, null, "Male", "Nautilus", 2, 2012, "Mana", "Revenant" },
                    { "83", null, null, "Female", "Neeko", 5, 2018, "Mana", "Vastayan" },
                    { "84", null, null, "Female", "Nidalee", 8, 2009, "Mana", "Vastayan" },
                    { "85", null, null, "Female", "Nilah", 2, 2022, "Mana", "Magically Altered" },
                    { "86", null, null, "Male", "Nocturne", 8, 2011, "Mana", "Demon" },
                    { "87", null, null, "Male", "Nunu & Willump", 12, 2009, "Mana", "Human" },
                    { "88", null, null, "Male", "Olaf", 12, 2010, "Mana", "Human" },
                    { "89", null, null, "Female", "Orianna", 7, 2011, "Mana", "Golem" },
                    { "9", null, null, "Male", "Aphelios", 11, 2019, "Mana", "Human" },
                    { "90", null, null, "Male", "Ornn", 12, 2017, "Mana", "God" },
                    { "91", null, null, "Male", "Pantheon", 11, 2010, "Mana", "Human" },
                    { "92", null, null, "Male", "Poppy", 3, 2010, "Mana", "Yordle" },
                    { "93", null, null, "Male", "Pyke", 2, 2018, "Mana", "Revenant" },
                    { "94", null, null, "Female", "Qiyana", 5, 2019, "Mana", "Human" },
                    { "95", null, null, "Female", "Quinn", 3, 2013, "Mana", "Human" },
                    { "96", null, null, "Male", "Rakan", 4, 2017, "Mana", "Vastayan" },
                    { "97", null, null, "Male", "Rammus", 10, 2009, "Mana", "God" },
                    { "98", null, null, "Female", "Rek'Sai", 13, 2014, "Rage", "Void-Being" },
                    { "99", null, null, "Female", "Rell", 6, 2013, "Mana", "Magivally Altered" }
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
                name: "IX_Champions_RegionId",
                table: "Champions",
                column: "RegionId");
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
                name: "Champions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
