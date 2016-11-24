using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMCSystem.Server.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class IMCContext : DbContext
    {
        public IMCContext() : base("name=IMCContext")
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<DrugImage> DrugImages { get; set; }
        public DbSet<CabinetDevice> CabinetDevices { get; set; }
        public DbSet<CabinetFloor> CabinetFloors { get; set; }
        public DbSet<CabinetCell> CabinetCells { get; set; }
    }
}
