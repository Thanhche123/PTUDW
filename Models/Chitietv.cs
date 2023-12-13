using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doanw.Models
{
    [Table("Chitietv")]
    public class Chitietv
    {
        [Key]
        public int ProductSCID { get; set; }
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public int SizeID { get; set; }
        public string? SizeName { get; set; }
        public int ColorID { get; set; }
        public string? ColorName { get; set; }
        public string? LinkImage { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
