using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace doanw.Models
{
    [Table("Size")]
    public class Size
    {
        [Key]
        public int SizeID { get; set; }
        public string? SizeName { get; set; }
    }
}
