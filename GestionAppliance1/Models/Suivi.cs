using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAppliance1.Models
{
    public class Suivi
    {
        [Key]
        public int Suivi_ID { get; set; }

        public bool Offre_Comm { get; set; }

        public float Montant { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string Compte_Rendu { get; set; } = string.Empty;

        public int TypePrestation_ID { get; set; }
        public TypePrestation? TypePrestation { get; set; }

        public int POV_Id { get; set; }
        public POV? POV { get; set; }
    }
}
