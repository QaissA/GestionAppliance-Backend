using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAppliance1.Models
{
    public class Appliance
    {
        [Key]
        public int Appliance_Id { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Libell { get; set; } = string.Empty;

        [Column(TypeName = "varchar(20)")]
        public string DBID { get; set; } = string.Empty;

        public bool Disponibilite { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string References { get; set; } = string.Empty;

        public int ApplianceType { get; set; }

        public TypeAppliance? TypeAppliance { get; set; }

    }
}
