using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doanw.Models
{
	[Table("Sanpham")]
	public class Sanpham
	{
		[Key]
		public int ProductID { get; set; }
		public int CategoryID { get; set; }
		public string? CategoryName { get; set; }
		public string? ProductName { get; set; }
        public int Levels { get; set; }
        public int ParentID { get; set; }
        public int MenuOrder { get; set; }
        public int Price { get; set; }
		public string? LinkImage { get; set; }
	}
}
