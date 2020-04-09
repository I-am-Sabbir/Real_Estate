using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Real_Estate.Migrations
{
    public partial class Real_Estate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    user_name = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Builders",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    Company_Name = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    Contact = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Builders", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Builders_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    userID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.userID);
                    table.ForeignKey(
                        name: "FK_Buyers_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apartment_Name = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    Size = table.Column<string>(nullable: false),
                    Details = table.Column<string>(nullable: true),
                    BuilderID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Apartments_Builders_BuilderID",
                        column: x => x.BuilderID,
                        principalTable: "Builders",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApartmentID = table.Column<int>(nullable: true),
                    BuyeruserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reports_Apartments_ApartmentID",
                        column: x => x.ApartmentID,
                        principalTable: "Apartments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Buyers_BuyeruserID",
                        column: x => x.BuyeruserID,
                        principalTable: "Buyers",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requesteds",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuyeruserID = table.Column<int>(nullable: true),
                    ApartmentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requesteds", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Requesteds_Apartments_ApartmentID",
                        column: x => x.ApartmentID,
                        principalTable: "Apartments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requesteds_Buyers_BuyeruserID",
                        column: x => x.BuyeruserID,
                        principalTable: "Buyers",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_BuilderID",
                table: "Apartments",
                column: "BuilderID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ApartmentID",
                table: "Reports",
                column: "ApartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_BuyeruserID",
                table: "Reports",
                column: "BuyeruserID");

            migrationBuilder.CreateIndex(
                name: "IX_Requesteds_ApartmentID",
                table: "Requesteds",
                column: "ApartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Requesteds_BuyeruserID",
                table: "Requesteds",
                column: "BuyeruserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_user_name",
                table: "Users",
                column: "user_name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Requesteds");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Builders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
