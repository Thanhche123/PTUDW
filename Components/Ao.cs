using doanw.Models;
using Microsoft.AspNetCore.Mvc;

namespace doanw.Components
{
    [ViewComponent(Name = "Ao")]
    public class Ao : ViewComponent
    {
        private readonly DataContext _dataContext;
        public Ao(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = (from m in _dataContext.Products
                      where m.ProductName.Contains("áo")
                        select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", list));
        }
    }
}
