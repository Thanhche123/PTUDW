using doanw.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace doanw.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<ProductDetails> ProductDetailss { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Chitietsp> Chitietspp { get; set;}
        public DbSet<Chitiet> Chitiets { get; set; }
        public DbSet<Chitietq> Chitietqss { get;set; }
        public DbSet<Chitietcv> Chitietcvs { get; set; }
        public DbSet<Chitietv> Chitietvays { get; set; }
        public DbSet<Sanpham> Sanphams { get; set; }
        public DbSet<Users> Userss { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<giohang> Goshang { get; set; }
    }
}
