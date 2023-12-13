using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doanw.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
		public int Levels { get; set; }
		public int ParentID { get; set; }
		public int MenuOrder { get; set; }
	}
}
