using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doanw.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string? ProductName { get; set; }

        public int Price { get; set; }
		public string? LinkImage { get; set; }
		public string? Description { get; set; }
    }
}
