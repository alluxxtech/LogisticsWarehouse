using DAL.Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Depot
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 256)]
        public string Name { get; set; }
        [Required, StringLength(maximumLength: 256)]
        public string Address { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }
        //[ForeignKey("UserProfiles")]
        //public int UserProfileId { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public virtual ICollection<GeneralInfo> GeneralInformations { get; set; }
    }
}
