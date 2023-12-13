using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doanw.Models
{
    [Table("Color")]
    public class Color
    {
        [Key]
        public int ColorID { get; set; }
        public string? ColorName { get; set; }
    }
}
