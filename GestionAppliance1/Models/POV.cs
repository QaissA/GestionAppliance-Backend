using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAppliance1.Models
{
    public class POV
    {
        [Key]
        public int POV_Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Libelle_POV { get; set; } = string.Empty;

        public DateTime Date_Debut { get; set; }

        public DateTime Date_Fin { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string Compte_Manager { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string Ingenieur_CyberSecurite { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string Analyse_CyberSecurite { get; set; } = string.Empty;

        public int Appliance_Id { get; set; }
        public Appliance? Appliance { get; set; }

        public int Client_Id { get; set; }
        public Client? Client { get; set; }

    }
}
