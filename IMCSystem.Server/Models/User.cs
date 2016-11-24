using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMCSystem.Server.Models
{
    public class User : Entity
    {
        public const int RoleAdministrator = 0;
        public const int RoleDoctor = 1;

        public User()
        {

        }

        [StringLength(64)]
        public string Name { get; set; }
        [StringLength(64)]
        public string Password { get; set; }
        public int Role { get; set; }
        public bool Online { get; set; }
        [StringLength(512)]
        public string Description { get; set; }
        //public int DoctorId { get; set; }
    }
}
