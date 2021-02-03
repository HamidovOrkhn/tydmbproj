using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCYDMWebApp.ViewComponents
{
    public class RegistrationViewComponent :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
           return View();
        }
    }
}
