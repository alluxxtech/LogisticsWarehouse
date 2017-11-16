using DAL.Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 256)]
        public string Name { get; set; }
        [Required, StringLength(maximumLength: 256)]
        public string CorpEmail { get; set; }
        [Required, StringLength(255)]
        public string Address { get; set; }
        public virtual ICollection<Depot> CompanyDepots { get; set; }
        public virtual ICollection<UserProfile> CompanyProfiles { get; set; }

    }
}
