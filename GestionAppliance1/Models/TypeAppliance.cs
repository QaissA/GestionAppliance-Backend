using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAppliance1.Models
{
    public class TypeAppliance
    {
        [Key]
        public int TypeApp_ID { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Libelle { get; set; } = string.Empty;
    }
}
