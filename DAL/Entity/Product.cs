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
        public string Name { get; set; }
        public string ProductType { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public decimal Weight { get; set; }
        public string Sender { get; set; }
        public string Description { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartedTime { get; set; }
        
        public virtual ICollection<ProductAction> ActionsList{ get; set; }

    }
}
