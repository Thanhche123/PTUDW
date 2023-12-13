using Microsoft.AspNetCore.Mvc;
using doanw.Models;

namespace doanw.Components
{

    [ViewComponent(Name = "MenuView1")]
    public class MenuViewComponent1 : ViewComponent
    {
        private DataContext _context;
        public MenuViewComponent1(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofMenu = (from m in _context.Menus
                              where (m.IsActive == true) && (m.Position == 2)
                              select m).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofMenu));

        }
    }
}
