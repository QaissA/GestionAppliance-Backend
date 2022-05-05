using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionAppliance1.Models
{
    public class Seance
    {
        [Key]
        public int Seance_Id { get; set; }

        public DateTime Date_Seance { get; set; }
        
        [Column(TypeName = "varchar(20)")]
        public string Resumer { get; set; } = string.Empty;

        public string Participant { get; set; } = String.Empty;

        public int POV_Id { get; set; }
        public POV? POV { get; set; }
    }
}
