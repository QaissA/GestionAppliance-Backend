using GestionAppliance1.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionAppliance1.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        public DbSet<TypeAppliance> TypeAppliance { get; set; }

        public DbSet<TypePrestation> TypePrestation { get; set; }

        public DbSet<Client> Client { get; set; }

        public DbSet<Appliance> Appliance { get; set; }

        public DbSet<POV> POV { get; set; }

        public DbSet<Suivi> Suivi { get; set; }

        public DbSet<Contrat> Contrat { get; set; }

        public DbSet<Seance> Seance { get; set; }
    }
}
