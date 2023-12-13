using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doanw.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int CartID { get; set; }
        public int UserID { get; set; }
        public int ProductSCID { get; set; }
        public int Quantity { get; set; }
    }
}
