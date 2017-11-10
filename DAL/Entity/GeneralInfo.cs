using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class GeneralInfo
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Depot")]
        public int DepotId { get; set; }
        public Depot Depot { get; set; }
        [ForeignKey("ProductStatus")]
        public int ProductStatusId { get; set; }
        public ProductStatus ProductStatus { get; set; }
    }
}
