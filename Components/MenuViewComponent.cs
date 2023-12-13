﻿using Microsoft.AspNetCore.Mvc;
using doanw.Models;

namespace doanw.Components
{

    [ViewComponent(Name = "MenuView")]
    public class MenuViewComponent : ViewComponent
    {

        private DataContext _context;
        public MenuViewComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofMenu = (from m in _context.Categories
                            
                              select m).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofMenu));

        }
     
    }
}
