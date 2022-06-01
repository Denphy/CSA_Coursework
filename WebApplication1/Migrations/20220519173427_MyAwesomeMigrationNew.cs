using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class MyAwesomeMigrationNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    client_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    client_fullname = table.Column<string>(type: "text", nullable: false),
                    client_phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clients", x => x.client_id);
                });

            migrationBuilder.CreateTable(
                name: "receptions",
                columns: table => new
                {
                    reception_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    reception_name = table.Column<string>(type: "text", nullable: false),
                    reception_address = table.Column<string>(type: "text", nullable: false),
                    reception_weekday_start_time = table.Column<string>(type: "text", nullable: false),
                    reception_weekday_end_time = table.Column<string>(type: "text", nullable: false),
                    reception_weekend_start_time = table.Column<string>(type: "text", nullable: false),
                    reception_weekend_end_time = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_receptions", x => x.reception_id);
                });

            migrationBuilder.CreateTable(
                name: "receivers",
                columns: table => new
                {
                    receiver_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    client_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_receivers", x => x.receiver_id);
                    table.ForeignKey(
                        name: "fk_receivers_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "senders",
                columns: table => new
                {
                    sender_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    client_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_senders", x => x.sender_id);
                    table.ForeignKey(
                        name: "fk_senders_clients_client_id",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "parcels",
                columns: table => new
                {
                    parcel_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sender_id = table.Column<int>(type: "integer", nullable: false),
                    receiver_id = table.Column<int>(type: "integer", nullable: false),
                    reception_id = table.Column<int>(type: "integer", nullable: false),
                    parcel_rate = table.Column<string>(type: "text", nullable: false),
                    parcel_size = table.Column<string>(type: "text", nullable: false),
                    parcel_weight = table.Column<int>(type: "integer", nullable: false),
                    parcel_address = table.Column<string>(type: "text", nullable: false),
                    parcel_status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_parcels", x => x.parcel_id);
                    table.ForeignKey(
                        name: "fk_parcels_receivers_receiver_id",
                        column: x => x.receiver_id,
                        principalTable: "receivers",
                        principalColumn: "receiver_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_parcels_receptions_reception_id",
                        column: x => x.reception_id,
                        principalTable: "receptions",
                        principalColumn: "reception_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_parcels_senders_sender_id",
                        column: x => x.sender_id,
                        principalTable: "senders",
                        principalColumn: "sender_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_parcels_receiver_id",
                table: "parcels",
                column: "receiver_id");

            migrationBuilder.CreateIndex(
                name: "ix_parcels_reception_id",
                table: "parcels",
                column: "reception_id");

            migrationBuilder.CreateIndex(
                name: "ix_parcels_sender_id",
                table: "parcels",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "ix_receivers_client_id",
                table: "receivers",
                column: "client_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_senders_client_id",
                table: "senders",
                column: "client_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "parcels");

            migrationBuilder.DropTable(
                name: "receivers");

            migrationBuilder.DropTable(
                name: "receptions");

            migrationBuilder.DropTable(
                name: "senders");

            migrationBuilder.DropTable(
                name: "clients");
        }
    }
}
