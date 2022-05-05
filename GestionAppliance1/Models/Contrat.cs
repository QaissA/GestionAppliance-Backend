using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAppliance1.Models
{
    public class Contrat
    {
        [Key]
        public int Contrat_Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Nom { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string Prenom { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string Telephone { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string Fonction { get; set; } = string.Empty;

        [Column(TypeName = "varchar(80)")]
        public string Email { get; set; } = string.Empty;

        public int Client_Id { get; set; }
        public Client? Client { get; set; }
    }
}
