using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAppliance1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Client_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "varchar(20)", nullable: false),
                    Secteur = table.Column<string>(type: "varchar(20)", nullable: false),
                    Activite = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Client_Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeAppliance",
                columns: table => new
                {
                    TypeApp_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAppliance", x => x.TypeApp_ID);
                });

            migrationBuilder.CreateTable(
                name: "TypePrestation",
                columns: table => new
                {
                    TypePrestation_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePrestation", x => x.TypePrestation_ID);
                });

            migrationBuilder.CreateTable(
                name: "Contrat",
                columns: table => new
                {
                    Contrat_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "varchar(20)", nullable: false),
                    Prenom = table.Column<string>(type: "varchar(20)", nullable: false),
                    Telephone = table.Column<string>(type: "varchar(20)", nullable: false),
                    Fonction = table.Column<string>(type: "varchar(20)", nullable: false),
                    Email = table.Column<string>(type: "varchar(80)", nullable: false),
                    Client_Id = table.Column<int>(type: "int", nullable: false),
                    Client_Id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrat", x => x.Contrat_Id);
                    table.ForeignKey(
                        name: "FK_Contrat_Client_Client_Id1",
                        column: x => x.Client_Id1,
                        principalTable: "Client",
                        principalColumn: "Client_Id");
                });

            migrationBuilder.CreateTable(
                name: "Appliance",
                columns: table => new
                {
                    Appliance_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libell = table.Column<string>(type: "varchar(20)", nullable: false),
                    DBID = table.Column<string>(type: "varchar(20)", nullable: false),
                    Disponibilite = table.Column<bool>(type: "bit", nullable: false),
                    References = table.Column<string>(type: "varchar(20)", nullable: false),
                    ApplianceType = table.Column<int>(type: "int", nullable: false),
                    TypeApplianceTypeApp_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appliance", x => x.Appliance_Id);
                    table.ForeignKey(
                        name: "FK_Appliance_TypeAppliance_TypeApplianceTypeApp_ID",
                        column: x => x.TypeApplianceTypeApp_ID,
                        principalTable: "TypeAppliance",
                        principalColumn: "TypeApp_ID");
                });

            migrationBuilder.CreateTable(
                name: "POV",
                columns: table => new
                {
                    POV_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle_POV = table.Column<string>(type: "varchar(20)", nullable: false),
                    Date_Debut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_Fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", nullable: false),
                    Compte_Manager = table.Column<string>(type: "varchar(20)", nullable: false),
                    Ingenieur_CyberSecurite = table.Column<string>(type: "varchar(20)", nullable: false),
                    Analyse_CyberSecurite = table.Column<string>(type: "varchar(20)", nullable: false),
                    Appliance_Id = table.Column<int>(type: "int", nullable: false),
                    Appliance_Id1 = table.Column<int>(type: "int", nullable: true),
                    Client_Id = table.Column<int>(type: "int", nullable: false),
                    Client_Id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POV", x => x.POV_Id);
                    table.ForeignKey(
                        name: "FK_POV_Appliance_Appliance_Id1",
                        column: x => x.Appliance_Id1,
                        principalTable: "Appliance",
                        principalColumn: "Appliance_Id");
                    table.ForeignKey(
                        name: "FK_POV_Client_Client_Id1",
                        column: x => x.Client_Id1,
                        principalTable: "Client",
                        principalColumn: "Client_Id");
                });

            migrationBuilder.CreateTable(
                name: "Seance",
                columns: table => new
                {
                    Seance_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_Seance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Resumer = table.Column<string>(type: "varchar(20)", nullable: false),
                    Participant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    POV_Id = table.Column<int>(type: "int", nullable: false),
                    POV_Id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seance", x => x.Seance_Id);
                    table.ForeignKey(
                        name: "FK_Seance_POV_POV_Id1",
                        column: x => x.POV_Id1,
                        principalTable: "POV",
                        principalColumn: "POV_Id");
                });

            migrationBuilder.CreateTable(
                name: "Suivi",
                columns: table => new
                {
                    Suivi_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Offre_Comm = table.Column<bool>(type: "bit", nullable: false),
                    Montant = table.Column<float>(type: "real", nullable: false),
                    Compte_Rendu = table.Column<string>(type: "varchar(500)", nullable: false),
                    TypePrestation_ID = table.Column<int>(type: "int", nullable: false),
                    TypePrestation_ID1 = table.Column<int>(type: "int", nullable: true),
                    POV_Id = table.Column<int>(type: "int", nullable: false),
                    POV_Id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suivi", x => x.Suivi_ID);
                    table.ForeignKey(
                        name: "FK_Suivi_POV_POV_Id1",
                        column: x => x.POV_Id1,
                        principalTable: "POV",
                        principalColumn: "POV_Id");
                    table.ForeignKey(
                        name: "FK_Suivi_TypePrestation_TypePrestation_ID1",
                        column: x => x.TypePrestation_ID1,
                        principalTable: "TypePrestation",
                        principalColumn: "TypePrestation_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appliance_TypeApplianceTypeApp_ID",
                table: "Appliance",
                column: "TypeApplianceTypeApp_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Contrat_Client_Id1",
                table: "Contrat",
                column: "Client_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_POV_Appliance_Id1",
                table: "POV",
                column: "Appliance_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_POV_Client_Id1",
                table: "POV",
                column: "Client_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_POV_Id1",
                table: "Seance",
                column: "POV_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Suivi_POV_Id1",
                table: "Suivi",
                column: "POV_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Suivi_TypePrestation_ID1",
                table: "Suivi",
                column: "TypePrestation_ID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contrat");

            migrationBuilder.DropTable(
                name: "Seance");

            migrationBuilder.DropTable(
                name: "Suivi");

            migrationBuilder.DropTable(
                name: "POV");

            migrationBuilder.DropTable(
                name: "TypePrestation");

            migrationBuilder.DropTable(
                name: "Appliance");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "TypeAppliance");
        }
    }
}
