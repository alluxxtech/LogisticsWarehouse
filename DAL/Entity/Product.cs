using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 256)]
        public string Name { get; set; }
        [Required, StringLength(maximumLength: 50)]
        public string ProductType { get; set; }
        [Required]
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }
        public decimal Weight { get; set; }
        [Required, StringLength(maximumLength: 256)]
        public string Sender { get; set; }
        [StringLength(maximumLength: 256)]
        public string Description { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartedTime { get; set; }
        
        public virtual ICollection<ProductAction> ActionsList{ get; set; }

    }
}
