using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAppliance1.Models
{
    public class Client
    {
        [Key]
        public int Client_Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Libelle { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string Secteur { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string Activite { get; set; } = string.Empty;

    }
}
