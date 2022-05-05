using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAppliance1.Models
{
    public class TypePrestation
    {
        [Key]
        public int TypePrestation_ID { get; set; }

        [Column(TypeName ="varchar(20)")]
        public string Libelle { get; set; } = string.Empty;
    }
}
