using doanw.Models;
using Microsoft.AspNetCore.Mvc;

namespace doanw.Components
{
    [ViewComponent(Name ="Chanvay")]
    public class Chanvay : ViewComponent
    {
        private readonly DataContext _dataContext;
        public Chanvay(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = (from m in _dataContext.Chitietcvs
                       
                        select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", list));
        }
    }
}
