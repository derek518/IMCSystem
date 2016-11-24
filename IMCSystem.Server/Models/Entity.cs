using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMCSystem.Server.Models
{
    public class Entity
    {
        public Entity()
        {
            UpdatedAt = DateTime.Now;
            CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }
        //[Timestamp]
        //public byte[] RowVersion { get; set; }
        [ConcurrencyCheck]
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
