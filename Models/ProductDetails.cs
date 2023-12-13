using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doanw.Models
{
    [Table("ProductDetails")]
    public class ProductDetails
    {
        [Key]
        public int ProductSCID { get; set; }
        public int ProductID { get; set; }
        public int SizeID { get; set; }
        public int ColorID { get; set; }

        public string? LinkImage { get; set; }
        
        public int Quantity { get; set; }

    }
}
