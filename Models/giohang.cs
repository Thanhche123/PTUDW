using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doanw.Models
{
    [Table("giohang")]
    public class giohang
    {
        [Key]
        public int CartID { get; set; }
        public int UserID { get; set; }
        public int ProductSCID { get; set; }
        public string? ProductName { get; set; }
        public string? ColorName { get; set; }
        public string? SizeName { get; set; }
        public int Price { get; set; }
        public string? LinkImage { get; set; }
     
        public int Quantity { get; set; }
    }
}
