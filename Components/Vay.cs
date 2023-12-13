using doanw.Models;
using Microsoft.AspNetCore.Mvc;

namespace doanw.Components
{
    [ViewComponent(Name ="Vay")]
    public class Vay : ViewComponent
    {
        private readonly DataContext _dataContext;
        public Vay(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = (from m in _dataContext.Sanphams
                        where m.ProductName.Contains("váy")
                        select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", list));
        }
    }
}
