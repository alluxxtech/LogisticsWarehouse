using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class UserPosition
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Permissions { get; set; }
    }
}
