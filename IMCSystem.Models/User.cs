using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMCSystem.Models
{
    public class User : Entity
    {
        public const int RoleAdministrator = 0;
        public const int RoleDoctor = 1;

        public string Name { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public bool Online { get; set; }
        public string Description { get; set; }
        //public int DoctorId { get; set; }
    }
}
