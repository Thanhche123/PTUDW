using doanw.Models;
using Microsoft.AspNetCore.Mvc;

namespace doanw.Components
{
    [ViewComponent(Name ="Quan")]
    public class Quan : ViewComponent
    {
        private readonly DataContext _dataContext;
        public Quan(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = (from m in _dataContext.Sanphams
                        where m.ProductName.Contains("quần")
                        select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", list));
        }
    }
}
