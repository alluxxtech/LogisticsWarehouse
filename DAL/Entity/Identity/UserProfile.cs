using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity.Identity
{
    public class UserProfile
    {   
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
       
        [ForeignKey("UserPosition")]
        public int PositionId { get; set; }
        public UserPosition UserPosition { get; set; }
        [ForeignKey("Depots")]
        public int DepotId { get; set; }
        public virtual ICollection<Depot> Depots { get; set; }
    }
}
